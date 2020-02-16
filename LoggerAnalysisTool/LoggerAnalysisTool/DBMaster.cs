using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace LoggerAnalysisTool
{
    class DBMaster
    {
        ErrorLogger _logger = new ErrorLogger(); // Error loggger for this class

        // Gets names for all the  relevant Databases
        public void GetDBNames()
        {
            DataTable dbNames = queryDB("master","sys.databases","name",ConfigurationManager.AppSettings["noConditions"].ToString());
            foreach(DataRow dr in dbNames.Rows)
            {
                checkAllDBNames(dr); 
            }
            ConfigurationManager.RefreshSection("appSettings");
        }

        //Logic to fetch DB Name (Comparing DB name with the db names in config and storing the similar ones)
        private void checkAllDBNames(DataRow dr)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (dr[0].ToString().ToLower().Contains(ConfigurationManager.AppSettings["webSpectorDBName"].ToString()))
            {
                config.AppSettings.Settings["webSpectorDBName"].Value = dr["Name"].ToString();
                config.Save(ConfigurationSaveMode.Modified);
            }
            else if (dr[0].ToString().ToLower().Contains(ConfigurationManager.AppSettings["workOrdersDBName"].ToString()))
            {
                config.AppSettings.Settings["workOrdersDBName"].Value = dr["Name"].ToString();
                config.Save(ConfigurationSaveMode.Modified);
            }
            else if (dr[0].ToString().ToLower().Contains(ConfigurationManager.AppSettings["EventLogDBName"].ToString()))
            {
                config.AppSettings.Settings["EventLogDBName"].Value = dr["Name"].ToString();
                config.Save(ConfigurationSaveMode.Modified);
            }
        }

        //This connection is used to make a connection to a db string 
        public SqlConnection makeConnection(string dbName)
        {
            string connectionString = "";
            connectionString = ConfigurationManager.AppSettings["DBConnectionString"].ToString();
            connectionString = connectionString.Replace("XXXXX",dbName);
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }

        // This function can be used to query a paprticular db by passing db name, table name , conditions etc
        public DataTable queryDB(string dbName,string tableName, string columnsNeeded, string conditions)
        {
            
            SqlConnection conn = makeConnection(dbName);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = getQueryString(tableName, columnsNeeded,conditions);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Cannot Connect to the DataBase : " + ex.Message.ToString());
                _logger.WriteLog("Exception Occured when Connecting to DB : " + ex.Message.ToString());
            }
            DataTable dt = executeCommand(cmd);
            conn.Close();
            return dt;
        }

        //Used to execute commands when SqlCommand is passed in as a parameter
        private DataTable executeCommand(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            dt.Load(reader);
            return dt;
        }

        //Forms a query by joining the parameters passed into SQL format
        private string getQueryString(string tableName, string columnsNeeded,string conditions)
        {
            string query = "";
            if (conditions.Equals(ConfigurationManager.AppSettings["noConditions"].ToString()))
            {
                query = "SELECT " + columnsNeeded + " FROM " + tableName + ";";
            }
            else
            {
                query = "SELECT " + columnsNeeded + " FROM " + tableName + " WHERE " + conditions + ";";
            }
            return query;
        }

        //Fetches the sequence details of work order through DB 
        public DataTable fetchWorkOrderDetails(string dbName,string workOrder)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = makeConnection(dbName);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from (SELECT [WorkOrder],[DateOfProduction],[InspectionEndDate],LEAD([WorkOrder],1,0) over(order by [DateOfProduction]) as NEXTWORKORDER,LAG([WorkOrder],1,0) over(order by [DateOfProduction]) as PREVIOUSWORKORDER,LEAD([InspectionEndDate],1,0) over(order by [DateOfProduction]) as NEXTWORKORDERENDTIME,LAG([DateOfProduction],1,0)over(order by[DateOfProduction]) as PREVIOUSWORKORDERSTARTTIME FROM [WorkOrderDetails]) AS temp WHERE [WorkOrder] = '" + workOrder + "';"; ;
            try
            {
                conn.Open();
            }
            catch (SqlException ex)
            {
                _logger.WriteLog("Exception Occured when Connecting to DB : " + ex.Message.ToString());
            }
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            dt = executeCommand(cmd);
            conn.Close();
            return dt;
        }
    }
}
