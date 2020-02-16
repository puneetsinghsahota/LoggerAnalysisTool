using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerAnalysisTool
{
    class WorkOrderLoader
    { 
        public Dictionary<string, List<string>> _logs;
        public string _workOrderNum;
        public string _dateTimeStart;
        public string _dateTimeEnd;
        public string _nextWorkOrder;
        public string _previousWorkOrder;

        public WorkOrderLoader(string workOrderNum, Dictionary<string, List<string>> fetchedData)
        {
            _workOrderNum = workOrderNum;
            _logs = fetchedData;
            if (fetchedData.Count > 0)
            {
                List<string> datetimeList = new List<string>();
                _dateTimeStart = fetchedData[ConfigurationManager.AppSettings["dateTimeKey"].ToString()].First<string>();
                _dateTimeEnd = fetchedData[ConfigurationManager.AppSettings["dateTimeKey"].ToString()].Last<string>();
                _nextWorkOrder = fetchedData[ConfigurationManager.AppSettings["nextPrevWO"].ToString()].First<string>();
                _previousWorkOrder = fetchedData[ConfigurationManager.AppSettings["nextPrevWO"].ToString()].Last<string>();
            }
        }
    }
}
