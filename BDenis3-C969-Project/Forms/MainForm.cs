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
            radioDaily.Checked = true;
            radioWeekly.Checked = false;

            // Create a logger object, and create a record for the login that just happened
            Logger logger = new Logger("logins.txt");
            logger.Log(Dal.CurrentUserID, Dal.CurrentUsername);

            // Need to retrieve list of appointments
            // Need to retrieve list of customers
            Dal.RetrieveData();
            

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ButtonAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomer newCustomer = new AddCustomer();
            newCustomer.Show();
        }

        private void ButtonEditCustomer_Click(object sender, EventArgs e)
        {
            SearchCustomer findCustomer = new SearchCustomer();

            // enable the button and text box to allow searching of a customer record, and set the isUpdate value to true so that the code will update instead of create new records
            findCustomer.Show();
        }

        private void RadioDaily_CheckedChanged(object sender, EventArgs e)
        {
            // if the daily button is checked after being changed, then make sure to uncheck the weekly
            if (radioDaily.Checked)
            {
                radioWeekly.Checked = false;
            }
        }

        private void RadioWeekly_CheckedChanged(object sender, EventArgs e)
        {
            // if the weekly button is checked after being changes, then make sure to uncheck the daily
            if (radioWeekly.Checked)
            {
                radioDaily.Checked = false;
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

        }

        private void ButtonCancelAppointment_Click(object sender, EventArgs e)
        {
            
        }
    }
}
