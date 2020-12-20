using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDenis3_C969_Project
{
    public partial class AddAppointment : Form
    {
        private CustomerRecord customer = new CustomerRecord();
        private AppointmentRecord appt = new AppointmentRecord();
        private UserRecord employee = new UserRecord();

        public bool isUpdate = false;
        private int customerid = -1;
        private int useridselected = -1;
        private string title = "";
        private string desc = "";
        private string type = "";
        private DateTime UTCStart;
        private DateTime UTCStop;

        public AddAppointment()
        {
            InitializeComponent();
        }

        private void ButtonCancelApptAdd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonSaveAppt_Click(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                if (ValidateFields())
                {
                    customerid = Convert.ToInt32(comboCustomers.SelectedItem.ToString().Split('(')[1].Split(')')[0]);
                    useridselected = Convert.ToInt32(comboUsers.SelectedItem.ToString().Split('(')[1].Split(')')[0]);
                    UTCStart = dtpStartTime.Value.ToUniversalTime();
                    UTCStop = dtpStopTime.Value.ToUniversalTime();

                    AppointmentRecord updatedAppt = new AppointmentRecord();
                    updatedAppt = Dal.Appointments.ToList<AppointmentRecord>().Find(item => item.AppointmentID == Convert.ToInt32(textAppointmentID.Text));
                    updatedAppt.AppointmentTitle = textAppointmentTitle.Text.ToString();
                    updatedAppt.AppointmentDescription = textApptDescription.Text.ToString();
                    updatedAppt.AppointmentType = textApptType.Text.ToString();
                    updatedAppt.AppointmentCustomerID = customerid;
                    updatedAppt.AppointmentUserID = useridselected;
                    updatedAppt.AppointmentStartTime = UTCStart;
                    updatedAppt.AppointmentEndTime = UTCStop;

                    if (ValidateTimeslots(updatedAppt, true))
                    {
                        Dal.UpdateAppointment(updatedAppt);
                        (this.Owner as MainForm).PopulateAppointmentList();
                        this.Close();
                    }
                    
                }
            }
            else
            {
                // The combobox dropdown doesn't seem to support having two columns so that the name and ID for customers and users can be displayed.
                // Since it's entirely possible to have two people with the same name this poses a problem when only the name is visible
                // I chose to solve this by putting the ID in parenthesis at the end of the name, with a space separating the parenthesis from the name
                // This line below is a little convoluted, but it undoes that concatenation and returns the id for both customers and users
                if (ValidateFields())
                {
                    customerid = Convert.ToInt32(comboCustomers.SelectedItem.ToString().Split('(')[1].Split(')')[0]);
                    useridselected = Convert.ToInt32(comboUsers.SelectedItem.ToString().Split('(')[1].Split(')')[0]);
                    title = textAppointmentTitle.Text.ToString();
                    desc = textApptDescription.Text.ToString();
                    type = textApptType.Text.ToString();
                    UTCStart = dtpStartTime.Value.ToUniversalTime();
                    UTCStop = dtpStopTime.Value.ToUniversalTime();

                    AppointmentRecord newAppt = new AppointmentRecord
                    {
                        AppointmentCustomerID = customerid,
                        AppointmentUserID = useridselected,
                        AppointmentTitle = title,
                        AppointmentDescription = desc,
                        AppointmentType = type,
                        AppointmentStartTime = UTCStart,
                        AppointmentEndTime = UTCStop
                    };

                    if (ValidateTimeslots(newAppt))
                    {
                        Dal.AddAppointment(newAppt);
                        this.Close();
                    }
                }
            }
        }

        private bool ValidateFields()
        {
            bool result = true;  // True if fields have values, false if any required field is missing a value

            if (string.IsNullOrEmpty(comboCustomers.SelectedItem.ToString()))
            {
                result = false;
                MessageBox.Show("Please select a customer");
            }

            if (string.IsNullOrEmpty(comboUsers.SelectedItem.ToString()))
            {
                result = false;
                MessageBox.Show("Please select a consultant / employee");
            }

            if (string.IsNullOrEmpty(textAppointmentTitle.Text.ToString()))
            {
                result = false;
                MessageBox.Show("Please provide a title for this appointment");
            }

            if (string.IsNullOrEmpty(textApptDescription.Text.ToString()))
            {
                result = false;
                MessageBox.Show("Please provide a description for this appointment");
            }

            if (string.IsNullOrEmpty(textApptType.Text.ToString()))
            {
                result = false;
                MessageBox.Show("Please provide an appointment type");
            }

            if (string.IsNullOrEmpty(dtpStartTime.Value.ToString()))
            {
                result = false;
                MessageBox.Show("Please select a Start Time");
            }

            if (string.IsNullOrEmpty(dtpStopTime.Value.ToString()))                
            {
                result = false;
                MessageBox.Show("Please select an End Time");
            }

            return result;
        }

        private bool ValidateTimeslots(AppointmentRecord newAppt, bool isUpdate = false)
        {
            int workdayStartHour = 9; // Workday start time using a 24-hour clock
            int workdayEndHour = 17; // Workday end time using a 24-hour clock
            List<AppointmentRecord> conflicts = new List<AppointmentRecord>();

            // Incoming appointment record should be in UTC time - convert back to local time to compare timezone specific hours to working hours
            // Use a 24-hour clock to prevent 10PM from being seen as 10AM

            if ( Convert.ToInt32(newAppt.AppointmentStartTime.ToLocalTime().ToString("HH")) < workdayStartHour )
            {
                // Compare the hour of the appointment time (converted to local time) to the hour of a 9:00 AM local time
                MessageBox.Show("This appointment starts earlier than 9:00 AM, local time.  Please adjust to fit within working hours of 9-5.");
                return false;
            }

            if ( Convert.ToInt32(newAppt.AppointmentEndTime.ToLocalTime().ToString("HH")) > workdayEndHour )
            {
                // Compare the first datetime stamp (end of working day) to appointment start time.  A less than zero response means the appointment start time is later than the workday end time
                MessageBox.Show("This appointment ends later than 5:00 PM, local time.  Please adjust to fit within working hours of 9-5.");
                return false;
            }

            if ( newAppt.AppointmentStartTime.ToLocalTime().DayOfWeek.ToString().ToLower() == "saturday" ||
                 newAppt.AppointmentStartTime.ToLocalTime().DayOfWeek.ToString().ToLower() == "sunday")
            {
                MessageBox.Show("This appointment falls on a weekend - please reschedule during weekday working hours");
                return false;
            }

            // build a list of existing appointments that conflict with the time slots of the new appt
            foreach (AppointmentRecord existingAppt in Dal.Appointments)
            {
                /*  Laying out an appointment overlap:
                 An overlap happens one of five ways:

                A - Overlap of both start times
                B - New start completely overshadows existing appt (starts before, ends after)
                C - New start overlaps the start time only (starts before, ends in middle)
                D - New start overlaps the end time only (starts in the middle, ends at same time or later)
                E - An existing appointment overshadows the new appt (starts before, ends after)

                No need to calculate scenarios where there are multiple appointments in conflict
                since the first overlap is enough to reject the appointment

                Consolidating things down to three comparisons:
                New start <= Existing start AND New end > existing start time (covers A, B, C)
                New start < Existing end time AND New end time >= existing end time (covers D)
                New start > Existing Start Time AND New end time <= existing end time (covers E)

                One Exception - an update of an existing appt may show up as a conflict - need to compare appointment IDs between
                the new appt and the conflicting appt records and make sure the appt doesn't conflict with anything else

                */

                // does the new appointment start on the same day as an existing appointment?
                if (newAppt.AppointmentStartTime.ToShortDateString() == existingAppt.AppointmentStartTime.ToShortDateString())
                {
                    // Check conditions A, B, and C
                    if ( (newAppt.AppointmentStartTime <= existingAppt.AppointmentStartTime) && (newAppt.AppointmentEndTime > existingAppt.AppointmentStartTime))
                    {
                        conflicts.Add(existingAppt);
                    }

                    // Check condition D
                    if ( (newAppt.AppointmentStartTime < existingAppt.AppointmentEndTime) && (newAppt.AppointmentEndTime >= existingAppt.AppointmentEndTime) )
                    {
                        conflicts.Add(existingAppt);
                    }

                    // Check condition E
                    if ( (newAppt.AppointmentStartTime > existingAppt.AppointmentStartTime) && (newAppt.AppointmentEndTime <= existingAppt.AppointmentEndTime) )
                    {
                        conflicts.Add(existingAppt);
                    }
                }
            }

            if (conflicts.Count > 0)
            {
                int count = conflicts.Count;
                foreach (AppointmentRecord conflict in conflicts)
                {
                    // Remove conflicts with self - any remaining conflicts will trigger an error message for the user
                    if (conflict.AppointmentID == newAppt.AppointmentID)
                    {
                        count--;
                    }
                }

                if (count > 0)
                {
                    MessageBox.Show("One or more existing appointments conflict with the start and end times of this appointment.  Please reschedule");
                    return false;
                }
            }
            return true;

        }

        private void AddAppointment_Load(object sender, EventArgs e)
        {
            // Populates comboboxes with name and ID of the customer and employee/user
            LoadCustomerNames();
            LoadUserNames();
            this.textAppointmentID.Visible = false;
        }

        private void LoadUserNames()
        {
            List<string> userNames = new List<string>();

            foreach (UserRecord ur in Dal.Users)
            {
                userNames.Add(ur.UserRecordName + $" ({ur.UserRecordID})");
            }
            this.comboUsers.DataSource = userNames;


        }

        private void LoadCustomerNames()
        {
            // A temporary list of just the customer names - I tried to use a Lambda with selectmany from the raw data but only got one char per row in the combo box
            // As a result, I just chose to walk the list of customers, and append the customer ID in parenthesis at the end
            List<string> customerNames = new List<string>();

            foreach (CustomerRecord cr in Dal.CustomerList)
            {
                customerNames.Add(cr.CustomerName + $" ({cr.CustomerID})");
            }
            this.comboCustomers.DataSource = customerNames;

        }

        public void Populate_Appointment(int apptid)
        {
            appt = Dal.Appointments.ToList<AppointmentRecord>().Find(item => item.AppointmentID == apptid);
            customer = Dal.CustomerList.ToList<CustomerRecord>().Find(item => item.CustomerID == appt.AppointmentCustomerID);
            employee = Dal.Users.ToList<UserRecord>().Find(item => item.UserRecordID == appt.AppointmentUserID);

            textAppointmentID.Text = appt.AppointmentID.ToString();
            comboCustomers.FindStringExact(customer.CustomerName + $" ({customer.CustomerID})");
            comboUsers.FindStringExact(employee.UserRecordName + $" ({employee.UserRecordID})");
            textAppointmentTitle.Text = appt.AppointmentTitle;
            textApptDescription.Text = appt.AppointmentDescription;
            textApptType.Text = appt.AppointmentType;
            dtpStartTime.Value = appt.AppointmentStartTime.ToLocalTime();
            dtpStopTime.Value = appt.AppointmentEndTime.ToLocalTime();
            
        }
    }
}
