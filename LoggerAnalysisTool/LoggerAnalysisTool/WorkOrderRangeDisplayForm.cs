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
    public partial class WorkOrderRangeDisplayForm : Form
    {
        bool _checkCrash = false;

        public WorkOrderRangeDisplayForm(DateTime from,DateTime to)
        {
            InitializeComponent();
            this.Icon = Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            WorkOrderDetailsGridView.RowHeadersVisible = false;
            DBMaster dbMaster = new DBMaster();
            DataTable dt = dbMaster.queryDB(ConfigurationManager.AppSettings["workOrdersDBName"].ToString(),"WorkOrderDetails","WorkOrder,ProductCode,DateOfProduction", "DateOfProduction >='" + Convert.ToDateTime(from).ToString("yyyy-MM-dd hh:mm:ss tt") + "' AND DateOfProduction <= '" + Convert.ToDateTime(to).ToString("yyyy-MM-dd hh:mm:ss tt") + "';");
            WorkOrderDetailsGridView.DataSource = dt;    
        }

        private void watchButton_Click(object sender, EventArgs e)
        {
            if (WorkOrderDetailsGridView.SelectedRows.Count == 1)
            {
                int selectedrowindex = WorkOrderDetailsGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = WorkOrderDetailsGridView.Rows[selectedrowindex];
                string workOrder = Convert.ToString(selectedRow.Cells["WorkOrder"].Value);
                
                SystemSpecificLogForm form = new SystemSpecificLogForm(workOrder,_checkCrash);
                form.ShowDialog();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
