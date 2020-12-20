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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonTypeByMonth_Click(object sender, EventArgs e)
        {
            string report = "";

            var queryTypes = from appt in Dal.Appointments.ToList<AppointmentRecord>()
                        group appt by appt.AppointmentType into TypeGroup
                        orderby TypeGroup.Key
                        select TypeGroup;

            foreach (var TypeName in queryTypes)
            {
                report += $"{TypeName.Key}:{TypeName.Count()}{Environment.NewLine}{Environment.NewLine}";
            }

            textReport.Text = report;

        }

        private void ButtonSchedulePerConsultant_Click(object sender, EventArgs e)
        {
            string report = "";

            var consulants = from emp in Dal.Users.ToList<UserRecord>()
                             group emp by emp.UserRecordName into eg
                             orderby eg.Key
                             select eg;

            foreach (var Consultant in consulants)
            {
                report += $"{Consultant.Key}{Environment.NewLine}----------------{Environment.NewLine}";
                var appts = from appt in Dal.Appointments.ToList<AppointmentRecord>()
                            join cus in Dal.CustomerList.ToList<CustomerRecord>() on appt.AppointmentCustomerID equals cus.CustomerID
                            where appt.AppointmentUserID == Consultant.FirstOrDefault().UserRecordID  // filter to only appointments for the current consultant
                            orderby appt.AppointmentStartTime
                            select new { cus.CustomerName, appt.AppointmentTitle, appt.AppointmentType, AppointmentStartTime = appt.AppointmentStartTime.ToLocalTime(), AppointmentEndTime = appt.AppointmentEndTime.ToLocalTime() };                                         

                foreach (var Appt in appts)
                {
                    report += $"{Appt.AppointmentStartTime.ToShortDateString()} {Appt.AppointmentStartTime.ToShortTimeString()}-{Appt.AppointmentEndTime.ToShortTimeString()}: {Appt.CustomerName} for a {Appt.AppointmentType}{Environment.NewLine}";
                }
                textReport.Text = report;
            }
        }

        private void ButtonPerCustomer_Click(object sender, EventArgs e)
        {
            string report = "";

            foreach (CustomerRecord cr in Dal.CustomerList.ToList<CustomerRecord>())
            {
                report += $"{cr.CustomerName} ({cr.CustomerID}){Environment.NewLine}---------------------{Environment.NewLine}";

                foreach (AppointmentRecord ar in Dal.Appointments.ToList<AppointmentRecord>())
                {
                    if (ar.AppointmentCustomerID == cr.CustomerID)
                    {
                        report += $"{ar.AppointmentStartTime.ToShortDateString()} {ar.AppointmentStartTime.ToShortTimeString()}-{ar.AppointmentEndTime.ToShortTimeString()} {ar.AppointmentType} {ar.AppointmentTitle}{Environment.NewLine}";
                    }
                }
                report += $"{Environment.NewLine}{Environment.NewLine}";
            }
            textReport.Text = report;
        }
    }
}
