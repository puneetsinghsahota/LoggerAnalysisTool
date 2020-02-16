using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoggerAnalysisTool
{
    class StartEndTimeParser
    {
        static ErrorLogger _logger = new ErrorLogger();

        private static List<string> _WODetails = new List<string>(); //Stores last and next work order details

        private static DateTime _start = new DateTime();
        private static DateTime _end = new DateTime();
        private static string _workOrder = "";


        
        public static bool SetStartEndTimeForWorkOrder(string workOrder,bool isTransition,out DateTime start, out DateTime end , out DataTable workOrderdt, out List<string> woDetails)
        {
            _workOrder = workOrder;
            bool moveAhead = false;
            workOrderdt = new DataTable();
            try
            {
                workOrderdt = getWorkOrderSequenceDetails();
                moveAhead = ProcessLogsForTime(workOrderdt, isTransition);
            }
            catch (IndexOutOfRangeException exception)
            {
                MessageBox.Show("Entered Work Order cannot be found.");
                _logger.WriteLog("Exception Occured : " + exception.Message);
                throw new IndexOutOfRangeException("No Work Order Found", exception);
            }
            woDetails = new List<string>();
            woDetails.AddRange(_WODetails);
            start = new DateTime();
            end = new DateTime();

            start = _start;
            end = _end;
            return moveAhead;
        }

        private static bool ProcessLogsForTime(DataTable workOrderdt, bool isTransition)
        {
            bool moveAhead = true;

            string startString = workOrderdt.Rows[0]["DateOfProduction"].ToString();
            string endString = workOrderdt.Rows[0]["InspectionEndDate"].ToString();

            _start = DateTime.MinValue;
            _end = DateTime.MinValue;
            try
            {
                checkTransition(workOrderdt, startString, endString, isTransition);
            }
            catch (Exception ex)
            {
                moveAhead = false;

                _logger.WriteLog("Cannot find one or the other field :: " + ex.Message + " - > Start String : " + startString + " - > End String : " + endString);
            }
            if (_end == DateTime.MinValue)
            {
                _end = DateTime.MaxValue;
            }
            return moveAhead;
        }

        //Checks whether the workOrder information demanded by WorkOrderLogsForm includes transition or not
        private static void checkTransition(DataTable workOrderdt, string startString, string endString, bool isTransition)
        {
            if (isTransition)
            {
                setTransitionStartEndTime(workOrderdt);
            }
            else
            {
                setNormalStartEndTime(workOrderdt, startString, endString);
            }
           // _logFiles.Add(ConfigurationManager.AppSettings["nextPrevWO"].ToString(), _WODetails);
        }

        //If the current workOrder needed by WorkOrderLogsForm includes a transition then the start and end times are fetched by the DB
        private static void setTransitionStartEndTime(DataTable workOrderdt)
        {
            string start = "";
            start = workOrderdt.Rows[0]["PREVIOUSWORKORDERSTARTTIME"].ToString();

            DateTimeParser.Parse(start, out _start);


            string end = "";
            end = workOrderdt.Rows[0]["NEXTWORKORDERENDTIME"].ToString();
            DateTimeParser.Parse(end, out _end);

            if (_end < _start)
            {
                _end = DateTime.MaxValue;
            }
        }

        //Sets the normal start end time for current workorder
        private static void setNormalStartEndTime(DataTable workOrderdt, string startString, string endString)
        {

            DateTimeParser.Parse(startString, out _start);
            DateTimeParser.Parse(endString, out _end);

        }

        //Finds the next work Order and the previous Work Order
        private static DataTable getWorkOrderSequenceDetails()
        {
            DBMaster dbMaster = new DBMaster();
            DataTable workOrderdt = dbMaster.fetchWorkOrderDetails(ConfigurationManager.AppSettings["workOrdersDBName"].ToString(), _workOrder);
            _WODetails = new List<string>();
            _WODetails.Add(workOrderdt.Rows[0]["NEXTWORKORDER"].ToString());
            _WODetails.Add(workOrderdt.Rows[0]["PREVIOUSWORKORDER"].ToString());


            return workOrderdt;
        }

    }
}
