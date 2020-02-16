using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



/*
    
 * LogFilesGrabber Class ----- Parses and returns data for each WorkOrder
 * 
 * This class is responsible for Finding relevant information inside the log files
 * It segments the log files according to the work Orders
 */

namespace LoggerAnalysisTool
{
    class LogFilesGrabber
    {
        private List<string> _keyTags; //Includes all the key tags 
        private Dictionary<string, List<string>> _logFiles = new Dictionary<string, List<string>>(); //  contains all the relevant log details to be returned to the Basic Form
        private List<string> _WODetails; //Stores last and next work order details
        private List<string> _dateTime; //Stores starting and ending time 
        private string _workOrder; //Stores the current workOrder number
        private DataTable _dbLogs; //Stores DB Logs which are fetched by the DB
    
        ErrorLogger _logger = new ErrorLogger();  //Error logger for this class
        DateTime _start = new DateTime(); //Stores relative start time for a particular workOrder
        DateTime _end = new DateTime(); //Stores End time of a particular Work Order
          

        //Constructor which fetches relevant data from each log file 
        public LogFilesGrabber(string workOrder)
        {
            _logger.WriteLog("LogFilesGrabber Invoked :: Execution STARTS --- ");
            InitializeGlobalParams(workOrder);
            _logger.WriteLog("LogFilesGrabber Invoked :: Execution FINISHES --- ");
        }

        //Sets Initial WorkOrder
        public void ProcessSystemSpecificLogs(int cs, int m, bool frontEnd, bool isTransition,bool isLoomSystem) 
        {
            DataTable workOrderdt = new DataTable();
            bool moveAhead = StartEndTimeParser.SetStartEndTimeForWorkOrder(_workOrder,isTransition, out _start,out _end,out workOrderdt,out _WODetails);
            _logFiles.Add(ConfigurationManager.AppSettings["nextPrevWO"].ToString(), _WODetails);
            
            if (moveAhead)
            {
                SeUpAllKeysForSinglePC(workOrderdt);
                LogFileParser obj = new LogFileParser(_workOrder,isLoomSystem,_start,_end);
                _dbLogs = obj.Parse_DB_Logs(cs, m);
                foreach (string key in _keyTags)
                {
                    List<string> priorityLines = obj.ParseLogs(key, cs, m);
                    _logFiles.Add(key, priorityLines);

                }
            }
           
        }

        // This function is used to process the logsspecific to a single log type Eg VB EVENT LOG FOR CS1M1,CS2M1,F1 etc.
        public void ProcessLogKeySpecificLogs(DataTable dt, string key, bool isTransition, bool isLoomSystem, out Dictionary<string, List<string>> keySpecificLogs, out Dictionary<string, DataTable> dbLogs)
        {
            keySpecificLogs = new Dictionary<string, List<string>>();
            dbLogs = new Dictionary<string, DataTable>();
            DataTable workOrderdt = new DataTable();
            bool moveAhead = StartEndTimeParser.SetStartEndTimeForWorkOrder(_workOrder, isTransition, out _start, out _end, out workOrderdt, out _WODetails); // This is a static function which gets the start end time for a particular work Order
            _logFiles.Add(ConfigurationManager.AppSettings["nextPrevWO"].ToString(), _WODetails);
            if (moveAhead)
            {
                SetSingleKey(key,workOrderdt);
                LogFileParser obj = new LogFileParser(_workOrder, isLoomSystem, _start, _end);
                foreach(DataRow dr in dt.Rows)
                {
                    
                        string pcName = "";
                        int cs = 0;
                        Int32.TryParse(dr["cs"].ToString(), out cs);
                        int m = 0;
                        Int32.TryParse(dr["m"].ToString(), out m);
                        if (cs != 0)
                        {
                            pcName = "CS" + cs + "M" + (m+1);
                        }
                        else
                        {
                            pcName = "Frontend";
                        }
                    if (key.ToLower().Contains("dblog"))
                    {
                        DataTable keyspecificDbLogs = obj.Parse_DB_Logs(cs, (m+1));
                        dbLogs.Add(pcName,keyspecificDbLogs);
                    }
                    else
                    {
                        List<string> priorityLines = obj.ParseLogs(key, cs, (m+1));
                        keySpecificLogs.Add(pcName, priorityLines);
                    }
                }
            }
        }

        //Sets Up All the properties for each kind of logs -- Needs to be changed if another log is added
        private void SeUpAllKeysForSinglePC(DataTable workOrderdt)
        {
            List<string> logTags = ConfigurationManager.AppSettings.AllKeys.Where(key => key.Contains("LogKey")).Select(key => ConfigurationManager.AppSettings[key]).ToList<string>();
            foreach(string key in logTags)
            {
                if (!key.ToLower().Contains("dblog"))
                {
                    _keyTags.Add(key);
                }
            }
            _dateTime.Add(workOrderdt.Rows[0]["DateOfProduction"].ToString());
            _dateTime.Add(workOrderdt.Rows[0]["InspectionEndDate"].ToString());
            _logFiles.Add(ConfigurationManager.AppSettings["dateTimeKey"].ToString(), _dateTime);
        } 

        //Sets up the settings for a single key
        private void SetSingleKey(string key,DataTable workOrderdt)
        {
            _keyTags.Add(key);
            _dateTime.Add(workOrderdt.Rows[0]["DateOfProduction"].ToString());
            _dateTime.Add(workOrderdt.Rows[0]["InspectionEndDate"].ToString());
            _logFiles.Add(ConfigurationManager.AppSettings["dateTimeKey"].ToString(), _dateTime);
        }

        //Initializes all the global parameters being used in this class
        private void InitializeGlobalParams(string workOrder)
        {
            _workOrder = workOrder;
            _keyTags = new List<string>();
            _WODetails = new List<string>();
            _dateTime = new List<string>();
            _WODetails.Clear();
        }

        //A public function to return start and end time 
        public string getStartEndTime()
        {
            string Message = "Logs Time Interval : " +_start.ToString() + " TO " + _end.ToString();
            return Message;
        }

        //Starts gathering DB logs
        public DataTable GetDBLog()
        {
            return _dbLogs;
        }

        //Just returns the data fetched by the class from all the log files found
        public Dictionary<string, List<string>> GetFetchedData() 
        {
            return _logFiles;
        }
    }
}
