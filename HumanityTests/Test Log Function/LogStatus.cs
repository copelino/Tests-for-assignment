using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanityTests
{
    public static class LogStatus
    {
        public static void LogError(string stepName, string testName, string date, string errorMessage)
        {
            string basePath = @"C:\";
            string logPath = basePath + date;
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }
            using (StreamWriter writer = new StreamWriter(logPath + @"\" + "LogStatusError.txt", true))
            {
                writer.WriteLine("Exception - " + DateTime.Now);
                writer.WriteLine(" {0} - {1} - ERROR : {2}", testName, stepName, errorMessage);
            }
        }

        public static void LogSuccess(string stepName, string testName, string date)
        {
            string basePath = @"C:\";
            string logPath = basePath + date;
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            using (StreamWriter writer = new StreamWriter(logPath + @"\" + "LogStatusSuccess.txt", true))
            {
                writer.WriteLine(DateTime.Now);
                writer.WriteLine(" {0} - {1} - SUCCESS", testName, stepName);
                writer.WriteLine();
            }
        }
    }
}
