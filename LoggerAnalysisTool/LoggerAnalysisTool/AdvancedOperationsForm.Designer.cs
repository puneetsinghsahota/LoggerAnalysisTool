namespace LoggerAnalysisTool
{
    partial class AdvancedOperationsForm
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
            this.advancedSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.LogTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.SystemsViewerDataGrid = new System.Windows.Forms.DataGridView();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.advancedSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SystemsViewerDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // advancedSettingsGroupBox
            // 
            this.advancedSettingsGroupBox.Controls.Add(this.selectAllButton);
            this.advancedSettingsGroupBox.Controls.Add(this.closeButton);
            this.advancedSettingsGroupBox.Controls.Add(this.LogTypeComboBox);
            this.advancedSettingsGroupBox.Controls.Add(this.label1);
            this.advancedSettingsGroupBox.Controls.Add(this.nextButton);
            this.advancedSettingsGroupBox.Controls.Add(this.SystemsViewerDataGrid);
            this.advancedSettingsGroupBox.Location = new System.Drawing.Point(1, 1);
            this.advancedSettingsGroupBox.Name = "advancedSettingsGroupBox";
            this.advancedSettingsGroupBox.Size = new System.Drawing.Size(421, 358);
            this.advancedSettingsGroupBox.TabIndex = 0;
            this.advancedSettingsGroupBox.TabStop = false;
            this.advancedSettingsGroupBox.Text = "Advanced Settings";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(335, 323);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // LogTypeComboBox
            // 
            this.LogTypeComboBox.FormattingEnabled = true;
            this.LogTypeComboBox.Location = new System.Drawing.Point(118, 25);
            this.LogTypeComboBox.Name = "LogTypeComboBox";
            this.LogTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.LogTypeComboBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Log Type :";
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(254, 323);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 1;
            this.nextButton.Text = "Next >>";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // SystemsViewerDataGrid
            // 
            this.SystemsViewerDataGrid.AllowUserToAddRows = false;
            this.SystemsViewerDataGrid.AllowUserToDeleteRows = false;
            this.SystemsViewerDataGrid.AllowUserToResizeColumns = false;
            this.SystemsViewerDataGrid.AllowUserToResizeRows = false;
            this.SystemsViewerDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SystemsViewerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SystemsViewerDataGrid.Location = new System.Drawing.Point(15, 68);
            this.SystemsViewerDataGrid.Name = "SystemsViewerDataGrid";
            this.SystemsViewerDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SystemsViewerDataGrid.Size = new System.Drawing.Size(396, 249);
            this.SystemsViewerDataGrid.TabIndex = 0;
            // 
            // selectAllButton
            // 
            this.selectAllButton.Location = new System.Drawing.Point(15, 323);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(77, 23);
            this.selectAllButton.TabIndex = 5;
            this.selectAllButton.Text = "< Select All >";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // AdvancedOperationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 359);
            this.Controls.Add(this.advancedSettingsGroupBox);
            this.Name = "AdvancedOperationsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Log Type Specific Logs";
            this.advancedSettingsGroupBox.ResumeLayout(false);
            this.advancedSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SystemsViewerDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox advancedSettingsGroupBox;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.DataGridView SystemsViewerDataGrid;
        private System.Windows.Forms.ComboBox LogTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button selectAllButton;
    }
}