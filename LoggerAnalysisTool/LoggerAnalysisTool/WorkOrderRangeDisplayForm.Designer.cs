namespace LoggerAnalysisTool
{
    partial class WorkOrderRangeDisplayForm
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
            this.WorkOrderDetailsGridView = new System.Windows.Forms.DataGridView();
            this.watchButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.WorkOrderDetailsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // WorkOrderDetailsGridView
            // 
            this.WorkOrderDetailsGridView.AllowUserToAddRows = false;
            this.WorkOrderDetailsGridView.AllowUserToDeleteRows = false;
            this.WorkOrderDetailsGridView.AllowUserToOrderColumns = true;
            this.WorkOrderDetailsGridView.AllowUserToResizeColumns = false;
            this.WorkOrderDetailsGridView.AllowUserToResizeRows = false;
            this.WorkOrderDetailsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.WorkOrderDetailsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WorkOrderDetailsGridView.Location = new System.Drawing.Point(12, 12);
            this.WorkOrderDetailsGridView.MultiSelect = false;
            this.WorkOrderDetailsGridView.Name = "WorkOrderDetailsGridView";
            this.WorkOrderDetailsGridView.ReadOnly = true;
            this.WorkOrderDetailsGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.WorkOrderDetailsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WorkOrderDetailsGridView.Size = new System.Drawing.Size(385, 267);
            this.WorkOrderDetailsGridView.TabIndex = 0;
            // 
            // watchButton
            // 
            this.watchButton.Location = new System.Drawing.Point(322, 285);
            this.watchButton.Name = "watchButton";
            this.watchButton.Size = new System.Drawing.Size(75, 27);
            this.watchButton.TabIndex = 1;
            this.watchButton.Text = "Watch >>";
            this.watchButton.UseVisualStyleBackColor = true;
            this.watchButton.Click += new System.EventHandler(this.watchButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(239, 285);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(77, 27);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // WorkOrderRangeDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 317);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.watchButton);
            this.Controls.Add(this.WorkOrderDetailsGridView);
            this.MaximizeBox = false;
            this.Name = "WorkOrderRangeDisplayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Work Orders";
            ((System.ComponentModel.ISupportInitialize)(this.WorkOrderDetailsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WorkOrderDetailsGridView;
        private System.Windows.Forms.Button watchButton;
        private System.Windows.Forms.Button closeButton;
    }
}