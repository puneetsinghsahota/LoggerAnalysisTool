using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoggerAnalysisTool
{
    public partial class HomeForm : Form
    {
        ErrorLogger _logger = new ErrorLogger(); // The logger for this classs

        public HomeForm() // The initial start up Constructor
        {
            InitializeComponent();
            this.Icon = Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            DBMaster dbMaster = new DBMaster();
            dbMaster.GetDBNames(); //  This method sets all the Database names required for the application to work
            InitialConditions(); //Sets all the conditions (Mainly Display Conditions)
        }
        
        private void InitialConditions()
        {
            fromDatePicker.Format = DateTimePickerFormat.Custom;
            fromDatePicker.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            toDatePicker.Format = DateTimePickerFormat.Custom;
            toDatePicker.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            this.ActiveControl = workOrderTextBox;
            this.AcceptButton = searchButton;
        }

        //Is triggered when the user searches a work Order by inputing a work order number
        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool checkCrash = false;
                SystemSpecificLogForm form = new SystemSpecificLogForm(workOrderTextBox.Text.ToString(),checkCrash);
                form.ShowDialog();
            }
            catch(ObjectDisposedException exception)
            {
                _logger.WriteLog(exception.Message);
            }
        }
        //Is triggered when a user searches all the work order inside a date range
        private void dateRangeSearchButton_Click(object sender, EventArgs e)
        {
            DateTime from = fromDatePicker.Value;
            DateTime to = toDatePicker.Value;
            WorkOrderRangeDisplayForm form = new WorkOrderRangeDisplayForm(from,to);
            form.ShowDialog();
        }

        //Shows the latest logs or the last logs which were entered inside the log files of each type
        private void showLatestWorkOrderButton_Click(object sender, EventArgs e)
        {
            bool checkCrash = true;
            SystemSpecificLogForm form = new SystemSpecificLogForm("",checkCrash);
            form.ShowDialog();
        }
    }
}
