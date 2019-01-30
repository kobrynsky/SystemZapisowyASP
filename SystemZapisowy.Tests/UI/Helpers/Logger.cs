using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemZapisowy.Tests.UI.Helpers
{

    public class Logger
    {
        private readonly string logPath = "E:\\Programowanie\\Projekty\\C# VisualStudio\\SystemZapisowy\\SystemZapisowy.Tests\\Content\\logs\\";
        
        public void SaveLog(Exception exception, string methodName)
        {
            var fileName = methodName + "-" + DateTime.Now.ToString("yyyyMMddTHHmmss") + ".txt";
            using (StreamWriter writer = new StreamWriter(logPath + fileName, true))
            {
                writer.WriteLine("-----------------------------------------------------------------------------");
                writer.WriteLine("Date : " + DateTime.Now);
                writer.WriteLine();

                while (exception != null)
                {
                    writer.WriteLine(exception.GetType().FullName);
                    writer.WriteLine("Message : " + exception.Message);
                    writer.WriteLine("StackTrace : " + exception.StackTrace);

                    exception = exception.InnerException;
                }
            }
        }
    }
}
