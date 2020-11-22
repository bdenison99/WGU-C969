using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;

namespace BDenis3_C969_Project
{
    class Logger
    {
        //
        // This class is intended to handle updates to the binary log file which contains the login history of the application
        // It wraps the file open / close logic and provides a method to write a new login record to the logfile.
        //
        private static BinaryFormatter binaryWriter = new BinaryFormatter();
        private static FileStream logFile;
        private static string filename;

        public Logger(string logfilename)
        {
            filename = logfilename;
        }

        public void Log(int id, string name)
        {
            try
            {
                logFile = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                LoginRecord rec = new LoginRecord(id, name);
                binaryWriter.Serialize(logFile, rec);
            }
            catch
            {
                // Maybe add some exception handling here
            }
            finally
            {
                logFile.Close();
            }
        }
    }

    [Serializable]
    public class LoginRecord
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string DateTimeStr { get; set; }
        public string ZoneOffset { get; set; }

        public LoginRecord( int id, string name)
        {
            UserID = id;
            UserName = name;
            DateTimeStr = DateTime.UtcNow.ToString();
            ZoneOffset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString();
        }
    }

}
