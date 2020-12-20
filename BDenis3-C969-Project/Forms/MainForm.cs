using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Timers;

namespace BDenis3_C969_Project
{
    public partial class MainForm : Form
    {
        private ResourceManager rm = new ResourceManager(typeof(BDenis3_C969_Project.strings));
        

        // Properties to keep track of who is logged in
        public int LoginID
        {
            get { return Dal.CurrentUserID;  }
            set { Dal.CurrentUserID = value; }
        }

        public string LoginName
        {
            get { return Dal.CurrentUsername; }
            set { Dal.CurrentUsername = value; }
        }

        public MainForm()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Default to daily view
            radioMonthly.Checked = true;
            radioWeekly.Checked = false;
            
            

            // Create a logger object, and create a record for the login that just happened
            Logger logger = new Logger("logins.txt");
            logger.Log(Dal.CurrentUserID, Dal.CurrentUsername);

            // Need to retrieve list of appointments
            // Need to retrieve list of customers
            Dal.RetrieveData();
            PopulateAppointmentList();

            // Check for alerts, then start a timer to check again every 5 minutes
            ProcessAppointmentsForAlerts(this, null);

            System.Timers.Timer t = new System.Timers.Timer(TimeSpan.FromMinutes(5).TotalMilliseconds)
            {
                AutoReset = true
            };
            t.Elapsed += new System.Timers.ElapsedEventHandler( ProcessAppointmentsForAlerts );
            t.Start();
        }

        private void ProcessAppointmentsForAlerts(object sender, ElapsedEventArgs e)
        {
            // DO NOT CONVERT APPOINTMENT DATETIMES TO LOCAL TIME - by the time they are displayed they are already in local time
            foreach (DataGridViewRow row in dgAppointments.Rows)
            {
                DateTime now = DateTime.Now;
                
                // adjust the start time for comparison purposes - move it 15 minutes earlier
                DateTime prestart = Convert.ToDateTime(row.Cells["AppointmentStartTime"].Value).AddMinutes(-15);
                DateTime start = Convert.ToDateTime(row.Cells["AppointmentStartTime"].Value);
                DateTime end = Convert.ToDateTime(row.Cells["AppointmentEndTime"].Value);

                // If now is greater than or equal to prestart then a 0 or 1 is returned which should be a boolean true
                // If now is less than or equal to start, then the appointment hasn't started yet which should also be a boolean true
                // Both of these tests being true prevents alerts about appointments that have already happened in the day and are now over
                if ( DateTime.Compare(now, prestart) >= 0 && DateTime.Compare(now, start) <= 0)
                {
                    ShowAlert(row.Cells["CustomerName"].Value.ToString(), row.Cells["UserRecordName"].Value.ToString(), row.Cells["AppointmentTitle"].Value.ToString(), row.Cells["AppointmentType"].Value.ToString(), Convert.ToDateTime(row.Cells["AppointmentStartTime"].Value.ToString()).ToShortTimeString(), Convert.ToDateTime(row.Cells["AppointmentEndTime"].Value.ToString()).ToShortTimeString());
                }
            }
        }

        private void ShowAlert(string customer, string employee, string title, string type, string starttime, string endtime)
        {
            MessageBox.Show($"{employee} has a {type} appointment with {customer} at {starttime} for {title}.  Appointment is scheduled to end at {endtime}");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ButtonAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomer newCustomer = new AddCustomer();
            newCustomer.Show();
            PopulateAppointmentList();
        }

        private void ButtonEditCustomer_Click(object sender, EventArgs e)
        {
            SearchCustomer findCustomer = new SearchCustomer();

            // enable the button and text box to allow searching of a customer record, and set the isUpdate value to true so that the code will update instead of create new records
            findCustomer.Show();
        }

        private void RadioMonthly_CheckedChanged(object sender, EventArgs e)
        {
            // if the daily button is checked after being changed, then make sure to uncheck the weekly
            if (radioMonthly.Checked)
            {
                // update the selected range to be first of month to end of month
                radioWeekly.Checked = false;
                DateTime now = mainCalendar.SelectionStart; // just shortening the name for the next lines parameters
                mainCalendar.SelectionStart = new DateTime(now.Year, now.Month, 1, 0, 0, 0);
                DateTime dt = mainCalendar.SelectionStart;  // just shortening the name used in the parameter list for the next line
                mainCalendar.SelectionEnd = new DateTime(dt.Year, dt.AddMonths(1).AddDays(-1).Month, dt.AddMonths(1).AddDays(-1).Day, 0, 0, 0);
            }
        }

        private void RadioWeekly_CheckedChanged(object sender, EventArgs e)
        {
            // if the weekly button is checked after being changes, then make sure to uncheck the daily
            // Also update the selection range to be the full week
            if (radioWeekly.Checked)
            {
                radioMonthly.Checked = false;
                int i = Convert.ToInt32(mainCalendar.SelectionStart.DayOfWeek);

                // Move selection date ranges to Sunday through Saturday of the selected week when changing radio weekly state
                mainCalendar.SelectionStart = mainCalendar.SelectionStart.AddDays(0 - i);
                mainCalendar.SelectionEnd = mainCalendar.SelectionStart.AddDays(6);

            }

        }

        private void ButtonDeleteCustomer_Click(object sender, EventArgs e)
        {
            // overloading the customer search form to do deletes as well
            SearchCustomer deleteCustomer = new SearchCustomer
            {
                isDelete = true  // Tells the form that the "edit" button will trigger a delete instead
            };
            deleteCustomer.buttonSearchEdit.Text = "&Delete"; // changes the text on the edit button to indicate a delete and not an edit will be performed
            deleteCustomer.Show();

        }

        private void ButtonAddAppointment_Click(object sender, EventArgs e)
        {
            AddAppointment newAppt = new AddAppointment();
            newAppt.Show();
        }

        private void ButtonEditAppointment_Click(object sender, EventArgs e)
        {
            SearchAppointment apptSearcher = new SearchAppointment();
            apptSearcher.Show();
            apptSearcher.Owner = this;
        }

        private void ButtonCancelAppointment_Click(object sender, EventArgs e)
        {
            SearchAppointment apptSearcher = new SearchAppointment
            {
                isDelete = true
            };
            apptSearcher.Show();
            PopulateAppointmentList();
        }

        private void MainCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            PopulateAppointmentList();
        }

        public void PopulateAppointmentList()
        {
            DateTime startdate = new DateTime();
            DateTime enddate = new DateTime();

            if (radioWeekly.Checked)
            {
                int i = Convert.ToInt32(mainCalendar.SelectionStart.DayOfWeek);
                startdate = mainCalendar.SelectionStart.AddDays(0 - i);
                enddate = startdate.AddDays(6);
            }
            else
            {
                startdate = new DateTime(mainCalendar.SelectionStart.Year, mainCalendar.SelectionStart.Month, 1, 0, 0, 0);
                enddate = startdate.AddMonths(1).AddDays(-1);
            }

            dgAppointments.DataSource = (   from appt in Dal.Appointments.ToList<AppointmentRecord>()
                                            join cust in Dal.CustomerList.ToList<CustomerRecord>()
                                              on appt.AppointmentCustomerID equals cust.CustomerID
                                            join emp in Dal.Users.ToList<UserRecord>()
                                              on appt.AppointmentUserID equals emp.UserRecordID
                                            where (appt.AppointmentStartTime.ToLocalTime() >= startdate)
                                            where (appt.AppointmentEndTime.ToLocalTime() <= enddate)
                                        select new { cust.CustomerName, emp.UserRecordName, appt.AppointmentTitle, appt.AppointmentType, AppointmentStartTime = appt.AppointmentStartTime.ToLocalTime(), AppointmentEndTime = appt.AppointmentEndTime.ToLocalTime()}
                                         ).ToList();
            dgAppointments.Columns[0].HeaderCell.Value = "Customer";
            dgAppointments.Columns[1].HeaderCell.Value = "Employee";
            dgAppointments.Columns[2].HeaderCell.Value = "Appointment";
            dgAppointments.Columns[3].HeaderCell.Value = "Type";
            dgAppointments.Columns[4].HeaderCell.Value = "Starts";
            dgAppointments.Columns[5].HeaderCell.Value = "Ends";
        }

        private void ButtonReports_Click(object sender, EventArgs e)
        {
            Reports r = new Reports();
            r.Show();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
