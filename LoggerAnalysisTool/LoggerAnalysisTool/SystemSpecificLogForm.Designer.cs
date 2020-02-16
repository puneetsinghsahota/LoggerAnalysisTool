namespace LoggerAnalysisTool
{
    partial class SystemSpecificLogForm
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
            this.SettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.previousWorkOrderLabel = new System.Windows.Forms.Label();
            this.nextWorkOrderLabel = new System.Windows.Forms.Label();
            this.findPreviousButton = new System.Windows.Forms.Button();
            this.findNextButton = new System.Windows.Forms.Button();
            this.typeOfSystemGroupBox = new System.Windows.Forms.GroupBox();
            this.GoButton = new System.Windows.Forms.Button();
            this.SystemTypeComboBox = new System.Windows.Forms.ComboBox();
            this.MasterComboBox = new System.Windows.Forms.ComboBox();
            this.systemTypeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CameraSetComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.WorkOrderTimeLabel = new System.Windows.Forms.Label();
            this.WorkOrderNumberLabel = new System.Windows.Forms.Label();
            this.trackBarValueLabel = new System.Windows.Forms.Label();
            this.DisplayGroupBox = new System.Windows.Forms.GroupBox();
            this.DisplayPanel = new System.Windows.Forms.Panel();
            this.mainLogGroupBox = new System.Windows.Forms.GroupBox();
            this.mainLogTextBox = new System.Windows.Forms.RichTextBox();
            this.serialOutputGroupBox = new System.Windows.Forms.GroupBox();
            this.serialOutputLogTextBox = new System.Windows.Forms.RichTextBox();
            this.vbLogGroupBox = new System.Windows.Forms.GroupBox();
            this.vbLogTextBox = new System.Windows.Forms.RichTextBox();
            this.vbEventLogGroupBox = new System.Windows.Forms.GroupBox();
            this.vbEventLogTextBox = new System.Windows.Forms.RichTextBox();
            this.databaseLogGroupBox = new System.Windows.Forms.GroupBox();
            this.dataBaseLogDataGridView = new System.Windows.Forms.DataGridView();
            this.witStatusLogGroupBox = new System.Windows.Forms.GroupBox();
            this.witStatusLogTextBox = new System.Windows.Forms.RichTextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readMasterMetersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoScrollToBottomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTransitionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logIntervalLabel = new System.Windows.Forms.Label();
            this.endTimeLabel = new System.Windows.Forms.Label();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.timeTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.advancedOperationButton = new System.Windows.Forms.Button();
            this.SettingsGroupBox.SuspendLayout();
            this.typeOfSystemGroupBox.SuspendLayout();
            this.DisplayGroupBox.SuspendLayout();
            this.DisplayPanel.SuspendLayout();
            this.mainLogGroupBox.SuspendLayout();
            this.serialOutputGroupBox.SuspendLayout();
            this.vbLogGroupBox.SuspendLayout();
            this.vbEventLogGroupBox.SuspendLayout();
            this.databaseLogGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseLogDataGridView)).BeginInit();
            this.witStatusLogGroupBox.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsGroupBox
            // 
            this.SettingsGroupBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.SettingsGroupBox.Controls.Add(this.previousWorkOrderLabel);
            this.SettingsGroupBox.Controls.Add(this.nextWorkOrderLabel);
            this.SettingsGroupBox.Controls.Add(this.findPreviousButton);
            this.SettingsGroupBox.Controls.Add(this.findNextButton);
            this.SettingsGroupBox.Controls.Add(this.typeOfSystemGroupBox);
            this.SettingsGroupBox.Controls.Add(this.WorkOrderTimeLabel);
            this.SettingsGroupBox.Controls.Add(this.WorkOrderNumberLabel);
            this.SettingsGroupBox.Location = new System.Drawing.Point(0, 27);
            this.SettingsGroupBox.Name = "SettingsGroupBox";
            this.SettingsGroupBox.Size = new System.Drawing.Size(1275, 79);
            this.SettingsGroupBox.TabIndex = 0;
            this.SettingsGroupBox.TabStop = false;
            this.SettingsGroupBox.Text = "Details";
            // 
            // previousWorkOrderLabel
            // 
            this.previousWorkOrderLabel.AutoSize = true;
            this.previousWorkOrderLabel.Location = new System.Drawing.Point(205, 47);
            this.previousWorkOrderLabel.Name = "previousWorkOrderLabel";
            this.previousWorkOrderLabel.Size = new System.Drawing.Size(0, 13);
            this.previousWorkOrderLabel.TabIndex = 12;
            // 
            // nextWorkOrderLabel
            // 
            this.nextWorkOrderLabel.AutoSize = true;
            this.nextWorkOrderLabel.Location = new System.Drawing.Point(21, 47);
            this.nextWorkOrderLabel.Name = "nextWorkOrderLabel";
            this.nextWorkOrderLabel.Size = new System.Drawing.Size(0, 13);
            this.nextWorkOrderLabel.TabIndex = 11;
            // 
            // findPreviousButton
            // 
            this.findPreviousButton.Location = new System.Drawing.Point(395, 44);
            this.findPreviousButton.Name = "findPreviousButton";
            this.findPreviousButton.Size = new System.Drawing.Size(100, 23);
            this.findPreviousButton.TabIndex = 10;
            this.findPreviousButton.Text = "Find Previous <<";
            this.findPreviousButton.UseVisualStyleBackColor = true;
            this.findPreviousButton.Click += new System.EventHandler(this.FindPreviousButton_Click);
            // 
            // findNextButton
            // 
            this.findNextButton.Location = new System.Drawing.Point(395, 15);
            this.findNextButton.Name = "findNextButton";
            this.findNextButton.Size = new System.Drawing.Size(100, 23);
            this.findNextButton.TabIndex = 9;
            this.findNextButton.Text = "Find Next >>";
            this.findNextButton.UseVisualStyleBackColor = true;
            this.findNextButton.Click += new System.EventHandler(this.FindNextButton_Click);
            // 
            // typeOfSystemGroupBox
            // 
            this.typeOfSystemGroupBox.Controls.Add(this.GoButton);
            this.typeOfSystemGroupBox.Controls.Add(this.SystemTypeComboBox);
            this.typeOfSystemGroupBox.Controls.Add(this.MasterComboBox);
            this.typeOfSystemGroupBox.Controls.Add(this.systemTypeLabel);
            this.typeOfSystemGroupBox.Controls.Add(this.label2);
            this.typeOfSystemGroupBox.Controls.Add(this.CameraSetComboBox);
            this.typeOfSystemGroupBox.Controls.Add(this.label1);
            this.typeOfSystemGroupBox.Location = new System.Drawing.Point(501, 12);
            this.typeOfSystemGroupBox.Name = "typeOfSystemGroupBox";
            this.typeOfSystemGroupBox.Size = new System.Drawing.Size(767, 60);
            this.typeOfSystemGroupBox.TabIndex = 8;
            this.typeOfSystemGroupBox.TabStop = false;
            this.typeOfSystemGroupBox.Text = "Type Of System Details";
            // 
            // GoButton
            // 
            this.GoButton.Location = new System.Drawing.Point(673, 11);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(75, 43);
            this.GoButton.TabIndex = 8;
            this.GoButton.Text = "Go >>";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // SystemTypeComboBox
            // 
            this.SystemTypeComboBox.Location = new System.Drawing.Point(187, 19);
            this.SystemTypeComboBox.Name = "SystemTypeComboBox";
            this.SystemTypeComboBox.Size = new System.Drawing.Size(82, 21);
            this.SystemTypeComboBox.TabIndex = 3;
            // 
            // MasterComboBox
            // 
            this.MasterComboBox.FormattingEnabled = true;
            this.MasterComboBox.Location = new System.Drawing.Point(528, 19);
            this.MasterComboBox.Name = "MasterComboBox";
            this.MasterComboBox.Size = new System.Drawing.Size(34, 21);
            this.MasterComboBox.TabIndex = 7;
            // 
            // systemTypeLabel
            // 
            this.systemTypeLabel.AutoSize = true;
            this.systemTypeLabel.Location = new System.Drawing.Point(71, 22);
            this.systemTypeLabel.Name = "systemTypeLabel";
            this.systemTypeLabel.Size = new System.Drawing.Size(110, 13);
            this.systemTypeLabel.TabIndex = 2;
            this.systemTypeLabel.Text = "Select System Type : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(474, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Master : ";
            // 
            // CameraSetComboBox
            // 
            this.CameraSetComboBox.FormattingEnabled = true;
            this.CameraSetComboBox.Location = new System.Drawing.Point(434, 19);
            this.CameraSetComboBox.Name = "CameraSetComboBox";
            this.CameraSetComboBox.Size = new System.Drawing.Size(34, 21);
            this.CameraSetComboBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Camera Set : ";
            // 
            // WorkOrderTimeLabel
            // 
            this.WorkOrderTimeLabel.AutoSize = true;
            this.WorkOrderTimeLabel.Location = new System.Drawing.Point(205, 20);
            this.WorkOrderTimeLabel.Name = "WorkOrderTimeLabel";
            this.WorkOrderTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.WorkOrderTimeLabel.TabIndex = 1;
            // 
            // WorkOrderNumberLabel
            // 
            this.WorkOrderNumberLabel.AutoSize = true;
            this.WorkOrderNumberLabel.Location = new System.Drawing.Point(21, 20);
            this.WorkOrderNumberLabel.Name = "WorkOrderNumberLabel";
            this.WorkOrderNumberLabel.Size = new System.Drawing.Size(0, 13);
            this.WorkOrderNumberLabel.TabIndex = 0;
            // 
            // trackBarValueLabel
            // 
            this.trackBarValueLabel.AutoSize = true;
            this.trackBarValueLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.trackBarValueLabel.Location = new System.Drawing.Point(377, 60);
            this.trackBarValueLabel.Name = "trackBarValueLabel";
            this.trackBarValueLabel.Size = new System.Drawing.Size(74, 13);
            this.trackBarValueLabel.TabIndex = 14;
            this.trackBarValueLabel.Text = "trackBarValue";
            // 
            // DisplayGroupBox
            // 
            this.DisplayGroupBox.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.DisplayGroupBox.Controls.Add(this.DisplayPanel);
            this.DisplayGroupBox.Location = new System.Drawing.Point(0, 187);
            this.DisplayGroupBox.Name = "DisplayGroupBox";
            this.DisplayGroupBox.Size = new System.Drawing.Size(1281, 724);
            this.DisplayGroupBox.TabIndex = 2;
            this.DisplayGroupBox.TabStop = false;
            this.DisplayGroupBox.Text = "Log Files Display";
            // 
            // DisplayPanel
            // 
            this.DisplayPanel.AutoScroll = true;
            this.DisplayPanel.Controls.Add(this.mainLogGroupBox);
            this.DisplayPanel.Controls.Add(this.serialOutputGroupBox);
            this.DisplayPanel.Controls.Add(this.vbLogGroupBox);
            this.DisplayPanel.Controls.Add(this.vbEventLogGroupBox);
            this.DisplayPanel.Controls.Add(this.databaseLogGroupBox);
            this.DisplayPanel.Controls.Add(this.witStatusLogGroupBox);
            this.DisplayPanel.Location = new System.Drawing.Point(0, 19);
            this.DisplayPanel.Name = "DisplayPanel";
            this.DisplayPanel.Size = new System.Drawing.Size(1271, 698);
            this.DisplayPanel.TabIndex = 2;
            // 
            // mainLogGroupBox
            // 
            this.mainLogGroupBox.Controls.Add(this.mainLogTextBox);
            this.mainLogGroupBox.Location = new System.Drawing.Point(12, 592);
            this.mainLogGroupBox.Name = "mainLogGroupBox";
            this.mainLogGroupBox.Size = new System.Drawing.Size(618, 317);
            this.mainLogGroupBox.TabIndex = 4;
            this.mainLogGroupBox.TabStop = false;
            this.mainLogGroupBox.Text = "Main Log";
            // 
            // mainLogTextBox
            // 
            this.mainLogTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLogTextBox.Location = new System.Drawing.Point(5, 19);
            this.mainLogTextBox.Name = "mainLogTextBox";
            this.mainLogTextBox.Size = new System.Drawing.Size(607, 288);
            this.mainLogTextBox.TabIndex = 3;
            this.mainLogTextBox.Text = "";
            // 
            // serialOutputGroupBox
            // 
            this.serialOutputGroupBox.Controls.Add(this.serialOutputLogTextBox);
            this.serialOutputGroupBox.Location = new System.Drawing.Point(636, 592);
            this.serialOutputGroupBox.Name = "serialOutputGroupBox";
            this.serialOutputGroupBox.Size = new System.Drawing.Size(619, 317);
            this.serialOutputGroupBox.TabIndex = 3;
            this.serialOutputGroupBox.TabStop = false;
            this.serialOutputGroupBox.Text = "Serial Output";
            // 
            // serialOutputLogTextBox
            // 
            this.serialOutputLogTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serialOutputLogTextBox.Location = new System.Drawing.Point(6, 19);
            this.serialOutputLogTextBox.Name = "serialOutputLogTextBox";
            this.serialOutputLogTextBox.Size = new System.Drawing.Size(607, 288);
            this.serialOutputLogTextBox.TabIndex = 4;
            this.serialOutputLogTextBox.Text = "";
            // 
            // vbLogGroupBox
            // 
            this.vbLogGroupBox.Controls.Add(this.vbLogTextBox);
            this.vbLogGroupBox.Location = new System.Drawing.Point(636, 3);
            this.vbLogGroupBox.Name = "vbLogGroupBox";
            this.vbLogGroupBox.Size = new System.Drawing.Size(613, 285);
            this.vbLogGroupBox.TabIndex = 1;
            this.vbLogGroupBox.TabStop = false;
            this.vbLogGroupBox.Text = "VB Log";
            // 
            // vbLogTextBox
            // 
            this.vbLogTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vbLogTextBox.Location = new System.Drawing.Point(6, 19);
            this.vbLogTextBox.Name = "vbLogTextBox";
            this.vbLogTextBox.Size = new System.Drawing.Size(590, 260);
            this.vbLogTextBox.TabIndex = 1;
            this.vbLogTextBox.Text = "";
            // 
            // vbEventLogGroupBox
            // 
            this.vbEventLogGroupBox.Controls.Add(this.vbEventLogTextBox);
            this.vbEventLogGroupBox.Location = new System.Drawing.Point(12, 3);
            this.vbEventLogGroupBox.Name = "vbEventLogGroupBox";
            this.vbEventLogGroupBox.Size = new System.Drawing.Size(618, 285);
            this.vbEventLogGroupBox.TabIndex = 0;
            this.vbEventLogGroupBox.TabStop = false;
            this.vbEventLogGroupBox.Text = "VB Event Log";
            // 
            // vbEventLogTextBox
            // 
            this.vbEventLogTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vbEventLogTextBox.Location = new System.Drawing.Point(5, 19);
            this.vbEventLogTextBox.Name = "vbEventLogTextBox";
            this.vbEventLogTextBox.Size = new System.Drawing.Size(607, 260);
            this.vbEventLogTextBox.TabIndex = 0;
            this.vbEventLogTextBox.Text = "";
            // 
            // databaseLogGroupBox
            // 
            this.databaseLogGroupBox.Controls.Add(this.dataBaseLogDataGridView);
            this.databaseLogGroupBox.Location = new System.Drawing.Point(12, 291);
            this.databaseLogGroupBox.Name = "databaseLogGroupBox";
            this.databaseLogGroupBox.Size = new System.Drawing.Size(618, 295);
            this.databaseLogGroupBox.TabIndex = 2;
            this.databaseLogGroupBox.TabStop = false;
            this.databaseLogGroupBox.Text = "Database Logs";
            // 
            // dataBaseLogDataGridView
            // 
            this.dataBaseLogDataGridView.AllowUserToAddRows = false;
            this.dataBaseLogDataGridView.AllowUserToDeleteRows = false;
            this.dataBaseLogDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataBaseLogDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataBaseLogDataGridView.Location = new System.Drawing.Point(6, 18);
            this.dataBaseLogDataGridView.MultiSelect = false;
            this.dataBaseLogDataGridView.Name = "dataBaseLogDataGridView";
            this.dataBaseLogDataGridView.ReadOnly = true;
            this.dataBaseLogDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataBaseLogDataGridView.Size = new System.Drawing.Size(606, 267);
            this.dataBaseLogDataGridView.TabIndex = 0;
            // 
            // witStatusLogGroupBox
            // 
            this.witStatusLogGroupBox.Controls.Add(this.witStatusLogTextBox);
            this.witStatusLogGroupBox.Location = new System.Drawing.Point(636, 291);
            this.witStatusLogGroupBox.Name = "witStatusLogGroupBox";
            this.witStatusLogGroupBox.Size = new System.Drawing.Size(613, 295);
            this.witStatusLogGroupBox.TabIndex = 1;
            this.witStatusLogGroupBox.TabStop = false;
            this.witStatusLogGroupBox.Text = "Wit Status Log";
            // 
            // witStatusLogTextBox
            // 
            this.witStatusLogTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.witStatusLogTextBox.Location = new System.Drawing.Point(6, 18);
            this.witStatusLogTextBox.Name = "witStatusLogTextBox";
            this.witStatusLogTextBox.Size = new System.Drawing.Size(590, 267);
            this.witStatusLogTextBox.TabIndex = 2;
            this.witStatusLogTextBox.Text = "";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(1110, 917);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(122, 38);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1276, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchTextToolStripMenuItem,
            this.readMasterMetersToolStripMenuItem,
            this.autoScrollToBottomMenuItem,
            this.showTransitionsToolStripMenuItem,
            this.syncLogsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // searchTextToolStripMenuItem
            // 
            this.searchTextToolStripMenuItem.Name = "searchTextToolStripMenuItem";
            this.searchTextToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.searchTextToolStripMenuItem.Text = "Search Text";
            this.searchTextToolStripMenuItem.Click += new System.EventHandler(this.searchTextToolStripMenuItem_Click);
            // 
            // readMasterMetersToolStripMenuItem
            // 
            this.readMasterMetersToolStripMenuItem.Name = "readMasterMetersToolStripMenuItem";
            this.readMasterMetersToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.readMasterMetersToolStripMenuItem.Text = "Read Master Meters";
            this.readMasterMetersToolStripMenuItem.Click += new System.EventHandler(this.ReadMasterMetersToolStripMenuItem_Click);
            // 
            // autoScrollToBottomMenuItem
            // 
            this.autoScrollToBottomMenuItem.Name = "autoScrollToBottomMenuItem";
            this.autoScrollToBottomMenuItem.Size = new System.Drawing.Size(189, 22);
            this.autoScrollToBottomMenuItem.Text = "Auto Scroll to Bottom";
            this.autoScrollToBottomMenuItem.Click += new System.EventHandler(this.AutoScrollToBottomMenuItem_Click);
            // 
            // showTransitionsToolStripMenuItem
            // 
            this.showTransitionsToolStripMenuItem.Name = "showTransitionsToolStripMenuItem";
            this.showTransitionsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.showTransitionsToolStripMenuItem.Text = "Show Transitions";
            this.showTransitionsToolStripMenuItem.Click += new System.EventHandler(this.ShowTransitionsToolStripMenuItem_Click);
            // 
            // syncLogsToolStripMenuItem
            // 
            this.syncLogsToolStripMenuItem.Name = "syncLogsToolStripMenuItem";
            this.syncLogsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.syncLogsToolStripMenuItem.Text = "Sync Logs";
            this.syncLogsToolStripMenuItem.Click += new System.EventHandler(this.SyncLogsToolStripMenuItem_Click);
            // 
            // logIntervalLabel
            // 
            this.logIntervalLabel.AutoSize = true;
            this.logIntervalLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.logIntervalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logIntervalLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.logIntervalLabel.Location = new System.Drawing.Point(21, 109);
            this.logIntervalLabel.Name = "logIntervalLabel";
            this.logIntervalLabel.Size = new System.Drawing.Size(0, 13);
            this.logIntervalLabel.TabIndex = 5;
            // 
            // endTimeLabel
            // 
            this.endTimeLabel.AutoSize = true;
            this.endTimeLabel.Location = new System.Drawing.Point(701, 60);
            this.endTimeLabel.Name = "endTimeLabel";
            this.endTimeLabel.Size = new System.Drawing.Size(35, 13);
            this.endTimeLabel.TabIndex = 9;
            this.endTimeLabel.Text = "label2";
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(7, 60);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(35, 13);
            this.startTimeLabel.TabIndex = 8;
            this.startTimeLabel.Text = "label1";
            // 
            // timeTrackBar
            // 
            this.timeTrackBar.Location = new System.Drawing.Point(10, 12);
            this.timeTrackBar.Name = "timeTrackBar";
            this.timeTrackBar.Size = new System.Drawing.Size(796, 45);
            this.timeTrackBar.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.endTimeLabel);
            this.groupBox1.Controls.Add(this.timeTrackBar);
            this.groupBox1.Controls.Add(this.trackBarValueLabel);
            this.groupBox1.Controls.Add(this.startTimeLabel);
            this.groupBox1.Location = new System.Drawing.Point(456, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(819, 76);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // advancedOperationButton
            // 
            this.advancedOperationButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.advancedOperationButton.Location = new System.Drawing.Point(18, 917);
            this.advancedOperationButton.Name = "advancedOperationButton";
            this.advancedOperationButton.Size = new System.Drawing.Size(160, 38);
            this.advancedOperationButton.TabIndex = 16;
            this.advancedOperationButton.Text = "Log Type Specific Logs >>";
            this.advancedOperationButton.UseVisualStyleBackColor = false;
            this.advancedOperationButton.Click += new System.EventHandler(this.advancedOperationButton_Click);
            // 
            // SystemSpecificLogForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(1276, 961);
            this.Controls.Add(this.advancedOperationButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.logIntervalLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.DisplayGroupBox);
            this.Controls.Add(this.SettingsGroupBox);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "SystemSpecificLogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Work Order Logs Detailer";
            this.SettingsGroupBox.ResumeLayout(false);
            this.SettingsGroupBox.PerformLayout();
            this.typeOfSystemGroupBox.ResumeLayout(false);
            this.typeOfSystemGroupBox.PerformLayout();
            this.DisplayGroupBox.ResumeLayout(false);
            this.DisplayPanel.ResumeLayout(false);
            this.mainLogGroupBox.ResumeLayout(false);
            this.serialOutputGroupBox.ResumeLayout(false);
            this.vbLogGroupBox.ResumeLayout(false);
            this.vbEventLogGroupBox.ResumeLayout(false);
            this.databaseLogGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataBaseLogDataGridView)).EndInit();
            this.witStatusLogGroupBox.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox SettingsGroupBox;
        private System.Windows.Forms.Label WorkOrderTimeLabel;
        private System.Windows.Forms.Label WorkOrderNumberLabel;
        private System.Windows.Forms.Label systemTypeLabel;
        private System.Windows.Forms.ComboBox SystemTypeComboBox;
        private System.Windows.Forms.GroupBox typeOfSystemGroupBox;
        private System.Windows.Forms.ComboBox MasterComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CameraSetComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.GroupBox DisplayGroupBox;
        private System.Windows.Forms.GroupBox databaseLogGroupBox;
        private System.Windows.Forms.GroupBox witStatusLogGroupBox;
        private System.Windows.Forms.GroupBox vbLogGroupBox;
        private System.Windows.Forms.GroupBox vbEventLogGroupBox;
        private System.Windows.Forms.RichTextBox witStatusLogTextBox;
        private System.Windows.Forms.RichTextBox vbLogTextBox;
        private System.Windows.Forms.RichTextBox vbEventLogTextBox;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button findPreviousButton;
        private System.Windows.Forms.Button findNextButton;
        private System.Windows.Forms.Panel DisplayPanel;
        private System.Windows.Forms.Label previousWorkOrderLabel;
        private System.Windows.Forms.Label nextWorkOrderLabel;
        private System.Windows.Forms.GroupBox mainLogGroupBox;
        private System.Windows.Forms.GroupBox serialOutputGroupBox;
        private System.Windows.Forms.RichTextBox mainLogTextBox;
        private System.Windows.Forms.RichTextBox serialOutputLogTextBox;
        private System.Windows.Forms.DataGridView dataBaseLogDataGridView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syncLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readMasterMetersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showTransitionsToolStripMenuItem;
        private System.Windows.Forms.Label logIntervalLabel;
        private System.Windows.Forms.ToolStripMenuItem autoScrollToBottomMenuItem;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.TrackBar timeTrackBar;
        private System.Windows.Forms.Label trackBarValueLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button advancedOperationButton;
        private System.Windows.Forms.ToolStripMenuItem searchTextToolStripMenuItem;
    }
}