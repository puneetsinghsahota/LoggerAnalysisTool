namespace LoggerAnalysisTool
{
    partial class LogKeySpecificLogForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.displayPanel = new System.Windows.Forms.Panel();
            this.WorkOrderLabel = new System.Windows.Forms.Label();
            this.StartEndTimeLabel = new System.Windows.Forms.Label();
            this.SystemsShownLabel = new System.Windows.Forms.Label();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.syncButton = new System.Windows.Forms.Button();
            this.trackBarValueLabel = new System.Windows.Forms.Label();
            this.searchTextButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.displayPanel);
            this.groupBox1.Location = new System.Drawing.Point(-2, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1221, 701);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log Key Specific Display";
            // 
            // displayPanel
            // 
            this.displayPanel.AutoScroll = true;
            this.displayPanel.Location = new System.Drawing.Point(6, 19);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(1209, 676);
            this.displayPanel.TabIndex = 0;
            // 
            // WorkOrderLabel
            // 
            this.WorkOrderLabel.AutoSize = true;
            this.WorkOrderLabel.Location = new System.Drawing.Point(33, 24);
            this.WorkOrderLabel.Name = "WorkOrderLabel";
            this.WorkOrderLabel.Size = new System.Drawing.Size(35, 13);
            this.WorkOrderLabel.TabIndex = 1;
            this.WorkOrderLabel.Text = "label1";
            // 
            // StartEndTimeLabel
            // 
            this.StartEndTimeLabel.AutoSize = true;
            this.StartEndTimeLabel.Location = new System.Drawing.Point(33, 46);
            this.StartEndTimeLabel.Name = "StartEndTimeLabel";
            this.StartEndTimeLabel.Size = new System.Drawing.Size(35, 13);
            this.StartEndTimeLabel.TabIndex = 2;
            this.StartEndTimeLabel.Text = "label2";
            // 
            // SystemsShownLabel
            // 
            this.SystemsShownLabel.AutoSize = true;
            this.SystemsShownLabel.Location = new System.Drawing.Point(33, 69);
            this.SystemsShownLabel.Name = "SystemsShownLabel";
            this.SystemsShownLabel.Size = new System.Drawing.Size(35, 13);
            this.SystemsShownLabel.TabIndex = 3;
            this.SystemsShownLabel.Text = "label3";
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(419, 69);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(794, 45);
            this.trackBar.TabIndex = 4;
            // 
            // syncButton
            // 
            this.syncButton.Location = new System.Drawing.Point(1170, 36);
            this.syncButton.Name = "syncButton";
            this.syncButton.Size = new System.Drawing.Size(39, 23);
            this.syncButton.TabIndex = 5;
            this.syncButton.Text = "Sync";
            this.syncButton.UseVisualStyleBackColor = true;
            this.syncButton.Click += new System.EventHandler(this.syncButton_Click);
            // 
            // trackBarValueLabel
            // 
            this.trackBarValueLabel.AutoSize = true;
            this.trackBarValueLabel.Location = new System.Drawing.Point(817, 46);
            this.trackBarValueLabel.Name = "trackBarValueLabel";
            this.trackBarValueLabel.Size = new System.Drawing.Size(35, 13);
            this.trackBarValueLabel.TabIndex = 6;
            this.trackBarValueLabel.Text = "label1";
            // 
            // searchTextButton
            // 
            this.searchTextButton.Location = new System.Drawing.Point(1079, 7);
            this.searchTextButton.Name = "searchTextButton";
            this.searchTextButton.Size = new System.Drawing.Size(130, 23);
            this.searchTextButton.TabIndex = 7;
            this.searchTextButton.Text = "<< KeyWord Search >>";
            this.searchTextButton.UseVisualStyleBackColor = true;
            this.searchTextButton.Click += new System.EventHandler(this.searchTextButton_Click);
            // 
            // LogKeySpecificLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 828);
            this.Controls.Add(this.searchTextButton);
            this.Controls.Add(this.trackBarValueLabel);
            this.Controls.Add(this.syncButton);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.SystemsShownLabel);
            this.Controls.Add(this.StartEndTimeLabel);
            this.Controls.Add(this.WorkOrderLabel);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "LogKeySpecificLogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Log Key Specific Display";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel displayPanel;
        private System.Windows.Forms.Label WorkOrderLabel;
        private System.Windows.Forms.Label StartEndTimeLabel;
        private System.Windows.Forms.Label SystemsShownLabel;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Button syncButton;
        private System.Windows.Forms.Label trackBarValueLabel;
        private System.Windows.Forms.Button searchTextButton;
    }
}