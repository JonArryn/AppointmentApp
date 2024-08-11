using AppointmentApp.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentApp.Helper
{
    public class Logger
    {
        public static void LogAuthentication(bool success, string userName)
        {
            string logMessage = $"User: {userName} {(success ? "logged in successfully" : "attempted to login unsuccessfully")}";
            try
            {
                using (StreamWriter writer = File.AppendText(@"..\..\login_audit.txt"))
                {
                    writer.Write("\r\nLog Entry : ");
                    writer.WriteLine($" Date: {DateTime.UtcNow.ToLongDateString()} AT {DateTime.UtcNow.ToLongTimeString()} UTC ");
                    writer.WriteLine(" - ");
                    writer.WriteLine($" - {logMessage}");
                    writer.WriteLine("-------------------------------");
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                string message = $"Error writing to log file: {ex.Message}";
                if (ex.InnerException != null)
                {
                    message += $" | Inner Exception: {ex.InnerException.Message}";
                }
                Messages.ShowError("AuthLogger Error", message);
            }


        }
    }
}
