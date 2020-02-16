namespace LoggerAnalysisTool
{
    partial class DisplayMasterMeterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.masterMeterGridView = new System.Windows.Forms.DataGridView();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.masterMeterGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // masterMeterGridView
            // 
            this.masterMeterGridView.AllowUserToAddRows = false;
            this.masterMeterGridView.AllowUserToDeleteRows = false;
            this.masterMeterGridView.AllowUserToResizeColumns = false;
            this.masterMeterGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.masterMeterGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.masterMeterGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.masterMeterGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.masterMeterGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.masterMeterGridView.Location = new System.Drawing.Point(1, 2);
            this.masterMeterGridView.MultiSelect = false;
            this.masterMeterGridView.Name = "masterMeterGridView";
            this.masterMeterGridView.ReadOnly = true;
            this.masterMeterGridView.ShowEditingIcon = false;
            this.masterMeterGridView.Size = new System.Drawing.Size(265, 407);
            this.masterMeterGridView.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(181, 415);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // DisplayMasterMeterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 442);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.masterMeterGridView);
            this.MaximizeBox = false;
            this.Name = "DisplayMasterMeterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Master Meter Readings";
            ((System.ComponentModel.ISupportInitialize)(this.masterMeterGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView masterMeterGridView;
        private System.Windows.Forms.Button closeButton;
    }
}