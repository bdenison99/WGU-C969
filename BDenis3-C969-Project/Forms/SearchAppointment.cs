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
    public partial class SearchAppointment : Form
    {
        public bool isDelete = false;

        public SearchAppointment()
        {
            InitializeComponent();


            dgAppointments.DataSource = (from appt in Dal.Appointments.ToList<AppointmentRecord>()
                                         join cust in Dal.CustomerList.ToList<CustomerRecord>()
                                           on appt.AppointmentCustomerID equals cust.CustomerID
                                         join emp in Dal.Users.ToList<UserRecord>()
                                           on appt.AppointmentUserID equals emp.UserRecordID
                                         select new { appt.AppointmentID, cust.CustomerName, emp.UserRecordName, appt.AppointmentTitle, appt.AppointmentDescription, appt.AppointmentType, appt.AppointmentStartTime, appt.AppointmentEndTime, appt.AppointmentCustomerID, appt.AppointmentUserID }
                                         ).ToList();

            // Hide the columns, but we need them in the dataset for later
            dgAppointments.Columns["AppointmentCustomerID"].Visible = false;
            dgAppointments.Columns["AppointmentUserID"].Visible = false;
            dgAppointments.Columns["UserRecordName"].HeaderText = "Employee";
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonEditAppt_Click(object sender, EventArgs e)
        {
            if (isDelete)
            {

                int selectedRowCount = dgAppointments.Rows.GetRowCount(DataGridViewElementStates.Selected);

                if (selectedRowCount != -1)
                {
                    Dal.DeleteAppointment(Convert.ToInt32(dgAppointments.CurrentRow.Cells["AppointmentID"].Value.ToString()));
                }
                (this.Owner as MainForm).PopulateAppointmentList();
                this.Close();
            }
            else
            {
                AddAppointment editAppt = new AddAppointment
                {
                    isUpdate = true,
                };

                editAppt.textAppointmentID.Visible = true;
                editAppt.Owner = this.Owner;
                editAppt.Populate_Appointment(Convert.ToInt32(dgAppointments.CurrentRow.Cells["AppointmentID"].Value));

                this.Close();
                editAppt.Show();

            }
        }

        private void ButtonSearchAppt_Click(object sender, EventArgs e)
        {
            CurrencyManager cm = (CurrencyManager)BindingContext[dgAppointments.DataSource];
            cm.SuspendBinding();

            //textApptSearchValue.Text
            foreach (DataGridViewRow ar in dgAppointments.Rows)
            {
                dgAppointments.ClearSelection();
                // assume hide all rows
                bool showrow = false;

                // if the customer name cell contains the search value, then show the row
                if (ar.Cells["CustomerName"].Value.ToString().ToLower().Contains(textApptSearchValue.Text.ToString().ToLower()))
                {
                    ar.Visible = showrow = true;
                }

                // if the user name cell contains the search value, then show the row
                if (ar.Cells["UserRecordName"].Value.ToString().ToLower().Contains(textApptSearchValue.Text.ToString().ToLower()))
                {
                    ar.Visible = showrow = true;
                }

                // if the appt title / description / type cell contains the search value, then show the row
                if (ar.Cells["AppointmentTitle"].Value.ToString().ToLower().Contains(textApptSearchValue.Text.ToString().ToLower()))
                {
                    ar.Visible = showrow = true;
                }
                if (ar.Cells["AppointmentDescription"].Value.ToString().ToLower().Contains(textApptSearchValue.Text.ToString().ToLower()))
                {
                    ar.Visible = showrow = true;
                }
                if (ar.Cells["AppointmentType"].Value.ToString().ToLower().Contains(textApptSearchValue.Text.ToString().ToLower()))
                {
                    ar.Visible = showrow = true;
                }

                try
                {
                    ar.Visible = showrow;
                }
                catch
                {

                }
                finally
                {
                    cm.ResumeBinding();
                }
            }

        }

        private void ButtonClearSearch_Click(object sender, EventArgs e)
        {
            textApptSearchValue.Text = ""; // clear the previous search text

            foreach (DataGridViewRow ar in dgAppointments.Rows)
            {
                // make all rows visible again
                ar.Visible = true;
            }
        }

        private void SearchAppointment_Load(object sender, EventArgs e)
        {
            if (isDelete)
            {
                buttonCancel.Text = "Close";
                buttonEditAppt.Text = "Cancel Appt";
            }
        }

    }
}
