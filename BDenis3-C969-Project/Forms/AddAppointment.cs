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
        public bool isUpdate = false;
        private int customerid = -1;
        private int useridselected = -1;
        private string title = "";
        private string desc = "";
        private string type = "";
        private DateTime apptDate;
        private DateTime startTime;
        private DateTime stopTime;
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
                apptDate = dtpAppointmentDate.Value;
                startTime = dtpStartTime.Value;
                stopTime = dtpStopTime.Value;
                // Reformatting the timestamp to match MySQLs expected format
                UTCStart = new DateTime(apptDate.Year, apptDate.Month, apptDate.Day, startTime.Hour, startTime.Minute, startTime.Second).ToUniversalTime();
                UTCStop = new DateTime(apptDate.Year, apptDate.Month, apptDate.Day, stopTime.Hour, stopTime.Minute, stopTime.Second).ToUniversalTime();

                Dal.AddAppointment(customerid, useridselected, title, desc, type, UTCStart, UTCStop);
            }

        }

        // Verify that required fields have values
        private bool ValidateFields()
        {
            bool result = true;  // True if fields have values, false if any required field is missing a value

            if (string.IsNullOrEmpty(comboCustomers.SelectedItem.ToString()))
            {
                result = false;
            }

            if (string.IsNullOrEmpty(comboUsers.SelectedItem.ToString()))
            {
                result = false;
            }

            if (string.IsNullOrEmpty(textAppointmentTitle.Text.ToString()))
            {
                result = false;
            }

            if (string.IsNullOrEmpty(textApptDescription.Text.ToString()))
            {
                result = false;
            }

            if (string.IsNullOrEmpty(textApptType.Text.ToString()))
            {
                result = false;
            }

            if (string.IsNullOrEmpty(dtpStartTime.Value.ToString()))
            {
                result = false;
            }

            if (string.IsNullOrEmpty(dtpStopTime.Value.ToString()))                
            {
                result = false;
            }

            return result;
        }

        private void AddAppointment_Load(object sender, EventArgs e)
        {
            // Populates comboboxes with name and ID of the customer and employee/user
            LoadCustomerNames();
            LoadUserNames();
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
    }
}
