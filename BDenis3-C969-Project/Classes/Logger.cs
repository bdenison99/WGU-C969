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
        private static StreamWriter logFile;
        private static string filename;

        public Logger(string logfilename)
        {
            filename = logfilename;
        }

        public void Log(int id, string name)
        {
            try
            {
                logFile = new StreamWriter(filename, true);  // append to the file
                string loginLine = $"User {name} with ID {id} logged in at {DateTime.UtcNow.ToString()}";
                logFile.WriteLine(loginLine);
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
}
