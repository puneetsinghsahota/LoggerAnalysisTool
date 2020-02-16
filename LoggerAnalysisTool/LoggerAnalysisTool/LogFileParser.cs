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

namespace LoggerAnalysisTool
{
    class LogFileParser
    {
        public ErrorLogger _logger = new ErrorLogger(); //The logger object for this class
        DateTime _start = new DateTime(); //Stores relative start time for a particular workOrder
        DateTime _end = new DateTime(); // Stores relative end time for a particular work Order
        bool _isLoomSystem = true; // stores whether a system is a loom system or not
        string _workOrder = ""; //stores the current workorder being processed
       

        //The class is used to parse a set of Logs by Taking in the WorkOrder Number 
        public LogFileParser(string workOrder, bool isLoomSystem, DateTime start, DateTime end)
        {
            _workOrder = workOrder;
            _isLoomSystem = isLoomSystem;
            _start = start;
            _end = end;

        }

        //This function is only used to parse DB logs according to a given start and end time
        public DataTable Parse_DB_Logs(int cs,int m)
        {
            DataTable dbLogs = new DataTable();
            dbLogs = GetDataBaseTable(_start, _end, cs, m);
            return dbLogs;
        }

        //This function is used to parse the logs in text format inside the errors folder of each system
        public List<string> ParseLogs(string key, int cs, int m)
        {
            List<string> priorityLines = new List<string>();
            DataTable workOrderdt = new DataTable();


            _logger.WriteLog("Finding Logs for : " + key + "    |||STARTS");


            List<string> files = findFiles(key, cs, m, _isLoomSystem);
            if (files.Count > 0)
            {
                _logger.WriteLog("Number of Files Found : " + files.Count.ToString());

                if (!key.Equals(ConfigurationManager.AppSettings["mainLogKey"].ToString()))
                {
                    priorityLines = readFiles(files, key);
                }
                else
                {
                    priorityLines = parseMainLog(key, files);
                }
                _logger.WriteLog("Number of Relevant Lines Found inside all the files under this Key: " + priorityLines.Count.ToString());
         
            }

            _logger.WriteLog("Finding Logs for : " + key + "    |||FINISHES");
            return priorityLines;
        }
        
        //This function gets the db logs of specific work order between the starting and ending time and a specific camera set and master number 
        private DataTable GetDataBaseTable(DateTime start, DateTime end, int cs, int m)
        {
            DBMaster dbMaster = new DBMaster();
            string condition = "LogTime >= '" + Convert.ToDateTime(start).ToString("yyyy-MM-dd HH:mm:ss") + "' and LogTime <= '" + Convert.ToDateTime(end).ToString("yyyy-MM-dd HH:mm:ss") + "' and CameraSet = " + cs + " and PCNumber = " + (m - 1) + ";";
            
            DataTable dt = dbMaster.queryDB(ConfigurationManager.AppSettings["EventLogDBName"].ToString(), "[AllEvents]", "CONVERT(varchar,LogTime,120) AS LogTime,EventMessage,CurrentWorkOrder,NextWorkOrder", condition);
            return dt;
        }

        //A special parser for main logs
        private List<string> parseMainLog(string key, List<string> files)
        {
            List<string> priorityLines = new List<string>();
            foreach (string path in files)
            {
                _logger.WriteLog("Reading the Contents of File : " + path + " for Key - > " + key);
                if (File.Exists(path))
                {
                    bool isRelevant = checkRelevance(path);
                    if (isRelevant)
                    {
                        string line;
                        bool record = false;
                        _logger.WriteLog("File is Relevant");
                        System.IO.StreamReader file = new System.IO.StreamReader(path);
                        while ((line = file.ReadLine()) != null)
                        {
                            if (!String.IsNullOrEmpty(line))
                            {
                                if (line.Contains("mm/dd/yy"))
                                {
                                    string date = line.Trim().Split(' ').ToList<string>().First<string>();
                                    string time = line.Trim().Split('\t').ToList<string>().Last<string>();
                                    string createdTimeString = date + " " + time;
                                    DateTime createdTime = new DateTime();
                                    DateTimeParser.Parse(createdTimeString, out createdTime);

                                    if (createdTime <= _end && createdTime >= _start)
                                    {
                                        record = true;
                                    }
                                }
                                if (record == true)
                                {
                                    priorityLines.Add(line);
                                }
                                if (line.Contains("----"))
                                {
                                    record = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        _logger.WriteLog("File does not contain the specified Work Order");
                    }
                }
            }
            return priorityLines;
        }

        //Checks whether the file is relevant to be read or not by looking at the valid date stamps
        private bool checkRelevance(string path)
        {
            bool isRelevant = false;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains("mm/dd/yy"))
                {
                    break;
                }
            }
            string date = line.Trim().Split(' ').ToList<string>().First<string>();
            string time = line.Trim().Split('\t').ToList<string>().Last<string>();
            string createdTimeString = date + " " + time;
            DateTime createdTime = new DateTime();
            DateTime.TryParseExact(createdTimeString, "MM/dd/yy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out createdTime);
            string timeStampString = path.Split('\\').ToList<string>().Last<string>().Split('.').ToList<string>().First<string>();
            if (timeStampString.Contains("_"))
            {
                timeStampString = timeStampString.Split('_').ToList<string>().First<string>();

                DateTime timeStampTime = new DateTime();
                DateTimeParser.Parse(timeStampString, out timeStampTime);
                if (_start >= createdTime && _start <= timeStampTime)
                {
                    isRelevant = true;
                }
            }
            else
            {
                if (_start >= createdTime)
                {
                    isRelevant = true;
                }

            }

            return isRelevant;
        }
        //Finds the files which are relevant to be parsed in order to find the required work order
        private List<string> findFiles(string key, int cs, int m, bool isLoomSystem)
        {
            string path = "";
            DBMaster dbMaster = new DBMaster();
            bool frontEnd = false;
            if(cs==0)
            {
                frontEnd = true;
            }
            if (!frontEnd)
            {

                string pcName = "";
                if (isLoomSystem)
                {
                    pcName = ConfigurationManager.AppSettings["genericErrorFolderPathLoomSystem"].ToString();
                    path = pcName;
                }
                else
                {
                    //FOR PINCROFT PC1-- 
              //      pcName = "PC1CS" + cs.ToString() + "M" + m.ToString();

                //  FOR PINCROFT PC2-- 
                //  pcName = "PC2CS" + cs.ToString() + "M" + m.ToString();

                //  GENERIC PC Name
                  pcName = dbMaster.queryDB(ConfigurationManager.AppSettings["webSpectorDBName"].ToString(), "PC_List", "PCName", "PCName like '%CS" + cs.ToString() + "M" + m.ToString() + "'").Rows[0]["PCName"].ToString();

                    path = ConfigurationManager.AppSettings["genericErrorFolderPath"].ToString().Replace("XXXXX", pcName);
                }


            }
            else
            {
            //  Generic PC Name
              string pcName = dbMaster.queryDB(ConfigurationManager.AppSettings["webSpectorDBName"].ToString(), "PC_List", "PCName", "PCName like '%F1'").Rows[0]["PCName"].ToString();
                
                //FOR PENCROFT PC1
                //string pcName = "PC1F1";

                //FOR PENCROFT PC2
              //  string pcName = "PC2F1";
                path = ConfigurationManager.AppSettings["genericErrorFolderPath"].ToString().Replace("XXXXX", pcName);
            }
            List<string> files = checkDirectory(key, path, cs, m);
            return files;
        }
        //Checks a directory for particular kind of log files by matching the key for each type of llog file as mentioned in the app.config and the extension i.e. .txt
        private List<string> checkDirectory(string key, string path, int cs, int m)
        {
            List<string> files = new List<string>();
            if (Directory.Exists(path))
            {
                string searchTag = key;
                if (searchTag.ToLower().Contains("witstatus"))
                {
                    if (cs > 0)
                    {
                        searchTag = searchTag + "CS" + cs.ToString() + "M" + m.ToString();
                    }
                    else
                    {
                        searchTag = searchTag + "fe";
                    }
                }
                _logger.WriteLog("Path found : " + path + "Looking for files inside ... ");
                files = Directory.GetFiles(path, "*" + searchTag + "*"+".txt").ToList<string>();
                if (files.Count == 0)
                {
                    string messagePost = ConfigurationManager.AppSettings["NoContentInFileOrDirectory"].ToString(); //Generic Errors are defined in the App.config file
                    _logger.WriteLog(messagePost + path);
                }
            }
            else
            {
                _logger.WriteLog(ConfigurationManager.AppSettings["PathNotFound"] + path);
            }
            return files;
        }

        //This function is responsible for reading the files which are relevant to the system
        private List<string> readFiles(List<string> files, string key)
        {
            List<string> priorityLines = new List<string>();
            foreach (string indPath in files)
            {
                if (File.Exists(indPath))
                {
                    bool dontReadFlag = parseFile(indPath, key);
                    if (!dontReadFlag)
                    {
                        _logger.WriteLog("File is Relevant");
                        List<string> filteredLines = getParsedLines(indPath, key);
                        _logger.WriteLog(("Relevant Number of Lines Found = " + filteredLines.Count.ToString()));
                        priorityLines.AddRange(filteredLines);
                    }
                }
                else
                {
                    _logger.WriteLog(ConfigurationManager.AppSettings["PathNotFound"].ToString() + indPath);
                }
            }
            return priorityLines;
        }

        // The relevant files are found and there path is sent to this function to parse the files for relevant lines
        private bool parseFile(string indPath, string key)
        {
            DateTime fileTimeStamp = new DateTime();
            _logger.WriteLog("Reading the Contents of File : " + indPath + "for Key - > " + key);
            bool dontReadFlag = false;
            string timeStampString = indPath.Split('\\').ToList<string>().Last<string>().Split('.').ToList<string>().First<string>();
            string firstLine = System.IO.File.ReadLines(indPath).First<string>();
            _logger.WriteLog("FirstLine = " + firstLine);
            firstLine = firstLine.Split(',')[0].Replace('\"', ' ').Trim() + " " + firstLine.Split(',')[1].Replace('\"', ' ').Trim();
            DateTime createdTime = new DateTime();
            DateTimeParser.Parse(firstLine, out createdTime);
            _logger.WriteLog("Created Time = " + createdTime.ToString());
            _logger.WriteLog("WorkOrder Log Start Time = " + _start.ToString());
            if (timeStampString.Contains("_"))
            {
                timeStampString = timeStampString.Split('_').ToList<string>().First<string>();
                DateTimeParser.Parse(timeStampString, out fileTimeStamp);
                _logger.WriteLog("File Time Stamp = " + fileTimeStamp.ToString());
                if (_start > fileTimeStamp || _start < createdTime) // If start time of the Work Order is Less than the File Created Time and Greater than File's Last Log Recorded (File TimeStamp)
                {
                    _logger.WriteLog("File does not contain the specified Work Order");
                    dontReadFlag = true;
                }
            }
            else
            {
                _logger.WriteLog("File Time Stamp = No File Time Stamp Available");
                if (_start < createdTime)
                {
                    _logger.WriteLog("File does not contain the specified Work Order");
                    dontReadFlag = true;
                }
            }
            return dontReadFlag;
        }

        // parsed lines from a file are sent to this function to filter out the relevant lines 
        private List<string> getParsedLines(string indPath, string key)
        {
            List<string> lines = System.IO.File.ReadAllLines(indPath).ToList<string>();
            List<string> filteredLines = new List<string>();
            if (lines.Count > 0)
            {
                _logger.WriteLog("File not Empty");
                filteredLines = GetFilteredLines(lines, key, 0);
            }
            else
            {
                string message = ConfigurationManager.AppSettings["NoContentInFileorDirectory"].ToString(); //Gneric Error Text
                _logger.WriteLog(message + indPath);
            }
            return filteredLines;
        }

        // The actual parsing takes place inside this function where each line is sent to get their time stamps checked and reading the time stamp tells whether a line should be included in shown logs or not
        private List<string> GetFilteredLines(List<string> lines, string key, int flag)
        {
            List<string> filteredLines = new List<string>();
            foreach (string line in lines)
            {
                if (!String.IsNullOrEmpty(line) && !key.Equals(ConfigurationManager.AppSettings["mainLogKey"].ToString()))
                {
                    bool print = checkLineTimeStamp(line);
                    if (print)
                    {
                        filteredLines.Add(line); //Keeps on adding the lines which are relevant to the application
                    }
                }
            }

            return filteredLines;
        }

        // This function checks time stamp of each line and compares it with the start and end time of the current work order being processed
        private bool checkLineTimeStamp(string line)
        {
            bool isFine = false;
            line = line.Trim();
            if (line.Contains(","))
            {
                string firstLine = "DateTime Split Parse Error";
                try
                {
                    firstLine = line.Split(',')[0].Replace('\"', ' ').Trim() + " " + line.Split(',')[1].Replace('\"', ' ').Trim();
                }
                catch (Exception ex)
                {
                    _logger.WriteLog("Incompatible Log Line Found :: " + ex.Message + ",// LINE : " + line + " ->" + firstLine);
                }
                DateTime createdTime = new DateTime();
                DateTimeParser.Parse(firstLine, out createdTime);
                if (createdTime >= _start && createdTime <= _end)
                {
                    _logger.WriteLog("Line is Relevant");
                    isFine = true;

                }

            }
            return isFine;
        }
    }
}
