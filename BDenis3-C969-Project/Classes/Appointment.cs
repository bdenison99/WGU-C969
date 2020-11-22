using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDenis3_C969_Project
{
    [Serializable]
    public class AppointmentRecord
    {
        public int AppointmentID { get; set; }
        public int AppointmentCustomerID { get; set; }
        public int AppointmentUserID { get; set; }
        public string AppointmentTitle { get; set; }
        public string AppointmentDescription { get; set; }
        public string AppointmentLocation { get; set; }
        public string AppointmentContact { get; set; }
        public string AppointmentType { get; set; }
        public string AppointmentUrl { get; set; }
        public DateTime AppointmentStartTime { get; set;}
        public DateTime AppointmentEndTime { get; set; }


        public AppointmentRecord() { }
        public AppointmentRecord(int id, string title, string desc, string loc, string contact, string type, string url, DateTime start, DateTime end)
        {
            AppointmentID = id;
            AppointmentTitle = title;
            AppointmentDescription = desc;
            AppointmentLocation = loc;
            AppointmentContact = contact;
            AppointmentType = type;
            AppointmentUrl = url;
            AppointmentStartTime = start;
            AppointmentEndTime = end;
        }
    }
}
