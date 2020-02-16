using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Windows.Forms;


/*
 * This class helps in logging the errors to a particular Log File of LoggerAnalysisTool
 */

namespace LoggerAnalysisTool
{
    class ErrorLogger
    {
        string _errorLogPath = ConfigurationManager.AppSettings["errorLogPath"].ToString();

        //This function writes the logs
        public void WriteLog(string message) 
        {
            if (!String.IsNullOrEmpty(message))
            {
                System.IO.StreamWriter file;
                if(File.Exists(_errorLogPath))
                {
                    file = File.AppendText(_errorLogPath);
                }
                else
                {
                    file = File.CreateText(_errorLogPath);
                }
                string line = "\"" + DateTime.Now.Date.ToString("d/M/yyyy") + "\",\"" + DateTime.Now.TimeOfDay.ToString() + "\"  -  ";
                file.WriteLine(line + message);
             
                file.Close();
            }
        }
    }
}
