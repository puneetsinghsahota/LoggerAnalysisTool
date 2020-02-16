﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoggerAnalysisTool
{
    public partial class DisplayMasterMeterForm : Form
    {
        public DisplayMasterMeterForm(DataTable dt)
        {
            InitializeComponent();
            this.Icon = Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            masterMeterGridView.RowHeadersVisible = false;
            masterMeterGridView.DataSource = dt;
            if(dt.Rows.Count<1)
            {
                MessageBox.Show("Cannot Find Master Meter Readings inside searched Logs.");
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
