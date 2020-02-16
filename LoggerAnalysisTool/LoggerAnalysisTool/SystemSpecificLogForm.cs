using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 *
 * Takes in a Single Work Order
 * Shows System Specific Logs Of Internal Activities
 * 
 * Used to represent a single WorkOrder on display
 * and related Operations
 * 
 */

namespace LoggerAnalysisTool
{
    public partial class SystemSpecificLogForm : Form
    {
        ErrorLogger _logger = new ErrorLogger();//Used to log the errors
        TextHighlighter _textHighlighter;

        List<string> openedEditorFiles = new List<string>();

        Dictionary<string, Dictionary<string, int>> _syncMap = new Dictionary<string, Dictionary<string, int>>(); //Saves the Dictionary used to synchronize the logs with time
        Dictionary<string, RichTextBox> _tagMap = new Dictionary<string, RichTextBox>(); //Saves the textBox along with the unique tag for each kind of log
        Dictionary<string, int> _lastSyncPosition = new Dictionary<string, int>();//Constructor for initializing form for single work order
        Dictionary<string, int> _CSMasters = new Dictionary<string, int>(); //fetched from DB stores a dictionary with number of masters per each camera set

        DateTime _START = new DateTime(); //Sets the actual start time of the logs (exclusively for Sync Operation)
        DateTime _END = new DateTime(); //Sets the actual end time of the logs (exclusively for Sync Operation)
        DateTime _startTime = new DateTime(); // Used to save the startTime for the logs 
        DateTime _endTime = new DateTime(); //Used to save the end time of logs displayed on the screen

        string _workOrder = ""; //Saves the current workorder in this Log Screen
        string _startTick = ""; // Saves the lowest mentioned system time tick in logs
        string _endTick = ""; //Saves the highest mentioned system tick in logs

        int _cs = 0; //Used to set number of camera sets 
        int _m = 0; //Used to set number of masters
        int _rangeMaxValue = 1000; // Sets the range of the trackbar seen on UI

        bool _isOldBuild = true; // is true if the user selects to synchronize with Number of Lines and not Time
        bool _isLoomSystem = false; // is true if the system is a loom system 
        bool _isFrontEnd = true; //is true if the PC is a front end system
        bool _isTransition = false; // is true if the User wants to see transition
        bool _isCrashWorkOrder = false; //Checks if the user wants to see the last logs available
        bool _scrollToBottom = false;  // is true if the user wants to see the last entered logs of each work order

        //Constructor To Initialize the Form
        public SystemSpecificLogForm(string workOrder,bool checkCrash)
        {
            InitializeComponent();
            this.Icon = Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            _workOrder = workOrder;
            _isCrashWorkOrder = checkCrash;
            GetCSMasters();
            GetTextBoxTags();
            _textHighlighter = new TextHighlighter(_tagMap,Color.Blue);
            SetControlProperties();
            ProcessWorkOrder();
        }
        
        //A Key Press Event to ensure Short Cuts
        private void KeyPressedEvent(object sender, KeyEventArgs e)
        {
            
            if (e.Control && e.KeyCode.ToString() == "F")
            {
                searchTextToolStripMenuItem_Click(new object(), new EventArgs());
            }
        }
        
        //sets all the controls default values 
        private void SetControlProperties()
        {
            this.KeyPreview = true; // Listens to the Key Press Events
            InsertSystemTypeComboBoxValues();
            SetEventHandlers();
            //this.Bounds = Screen.PrimaryScreen.Bounds;
            vbLogTextBox.ReadOnly = true;
            vbEventLogTextBox.ReadOnly = true;
            witStatusLogTextBox.ReadOnly = true;
            CameraSetComboBox.Enabled = false;
            timeTrackBar.Enabled = false;
            MasterComboBox.Enabled = false;
            dataBaseLogDataGridView.RowHeadersVisible = false;
            readMasterMetersToolStripMenuItem.Enabled = true;
            syncLogsToolStripMenuItem.Checked = false;
            SystemTypeComboBox.SelectedItem = SystemTypeComboBox.Items[0];
            MasterComboBox.SelectedItem = MasterComboBox.Items[0];
            CameraSetComboBox.SelectedItem = CameraSetComboBox.Items[0];
            SystemTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            MasterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            CameraSetComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            startTimeLabel.Text = "" ;
            endTimeLabel.Text = "";
            trackBarValueLabel.Text = "";
            SetRightClickEventOnTextBoxes(this);
        }

        private void SetRightClickEventOnTextBoxes(Control ctr)
        {
            ContextMenu rightClick_Menu = new ContextMenu();
            MenuItem openWithEditor = new MenuItem("Open With Notepad ...");
            openWithEditor.Click += new EventHandler(openWithEditor_Clicked); 
            rightClick_Menu.MenuItems.AddRange(new MenuItem[] { openWithEditor }); 

            
            vbLogTextBox.ContextMenu = rightClick_Menu;
            vbEventLogTextBox.ContextMenu = rightClick_Menu;
            serialOutputLogTextBox.ContextMenu = rightClick_Menu;
            witStatusLogTextBox.ContextMenu = rightClick_Menu;
        }

        private void openWithEditor_Clicked(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var contextMenu = menuItem.GetContextMenu();
            Control textBox = contextMenu.SourceControl;
            string file_TXT = textBox.Text;
            string name = textBox.Name;

            OpenWithNotepad.Open(file_TXT);
        }   
        
        //Inserts the system types as mentioned in App.Config
        private void InsertSystemTypeComboBoxValues()
        {
            List<string> comboBoxOptions = ConfigurationManager.AppSettings["SystemTypeComboBoxValues"].ToString().Split(',').ToList<string>();
            foreach (string opt in comboBoxOptions)
            {
                SystemTypeComboBox.Items.Add(opt);
            }
        }

        //Initializes all the event handlers for different kinds of controls
        private void SetEventHandlers()
        {
            searchTextToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+F";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPressedEvent);
            SystemTypeComboBox.SelectedIndexChanged += new EventHandler(SystemTypeComboBox_OnIndexChanged);
            CameraSetComboBox.SelectedIndexChanged += new EventHandler(CameraSetComboBox_OnIndexChanged);
            showTransitionsToolStripMenuItem.CheckedChanged += new EventHandler(ShowTransitions);
            timeTrackBar.ValueChanged += new EventHandler(TimeTrackBar_ScrollEvent);
            autoScrollToBottomMenuItem.CheckedChanged += new EventHandler(BringTextBoxesToBottomAction);
        }
        
        //Processes the work order passed to the form
        private void ProcessWorkOrder()
        {
            InititalizeBoxes();
            SetScreenToSystemType();
            SetUpWorkOrder();
        }

        //Gets the number of Camera Sets And Masters from the DataBase
        private void GetCSMasters()
        {
            DBMaster dbMaster = new DBMaster();
            DataTable cameraSetDt = dbMaster.queryDB(ConfigurationManager.AppSettings["webSpectorDBName"].ToString(), "CameraSets","CSID,CSNUMPCs",ConfigurationManager.AppSettings["noConditions"].ToString());
            MasterComboBox.Items.Clear();
            CameraSetComboBox.Items.Clear();
            CheckForLoomSystem(cameraSetDt);
            SetComboBoxValues(cameraSetDt);            
        }

        //Checks if the system is a Loom System
        private void CheckForLoomSystem(DataTable cameraSetDt)
        {
            _isLoomSystem = true;
            foreach (DataRow dr in cameraSetDt.Rows)
            {
                if (!(Int32.Parse(dr["CSNumPCs"].ToString()) == 1))
                {
                    _isLoomSystem = false;
                    break;
                }
            }

            //FOR PINCROFT /E-Leather
            _isLoomSystem = false;
        }

        //Sets the Combobox values for all kinds of Masters
        private void SetComboBoxValues(DataTable cameraSetDt)
        {
            for (int i = 0; i < cameraSetDt.Rows.Count; i++)
            {
                _CSMasters.Add(cameraSetDt.Rows[i]["CSID"].ToString(), Int32.Parse(cameraSetDt.Rows[i]["CSNumPCs"].ToString()));
                CameraSetComboBox.Items.Add(cameraSetDt.Rows[i]["CSID"].ToString());
            }
            string key = CameraSetComboBox.Items[0].ToString();
            int totalMasters = _CSMasters[key];
            for (int i = 1; i <= totalMasters; i++)
            {
                MasterComboBox.Items.Add(i.ToString());
            }
        }

        //Sets the value of each camera set from the values dtored in dictionary CSMasters
        private void CameraSetComboBox_OnIndexChanged(object sender, EventArgs e)
        {
            MasterComboBox.Items.Clear();
            string key = CameraSetComboBox.SelectedItem.ToString();
            int totalMasters = _CSMasters[key];
            for(int i = 1;i<=totalMasters;i++)
            {
                MasterComboBox.Items.Add(i.ToString());
            }
            MasterComboBox.SelectedIndex = 0;
        }

        //Sets Enabled property of multiple controls when the System type is changed from Master to front end or vice versa
        private void SystemTypeComboBox_OnIndexChanged(object sender, EventArgs e)
        {
            SetScreenToSystemType();
        }

        //Checks for separate settings for Master and FrontEnd
        private void SetScreenToSystemType()
        {
            if (_isCrashWorkOrder)
            {
                SetCrashWorkOrderSettings();
            }
            if (SystemTypeComboBox.SelectedItem.ToString().Equals("Master"))
            {
                _isFrontEnd = false;
                SetMasterProperties();
            }
            else
            {
                _isFrontEnd = true;
                SetFrontEndProperties();
            }
        }

        private void SetCrashWorkOrderSettings()
        {
            FindLastWorkOrder();
            autoScrollToBottomMenuItem.Checked = true;
            _scrollToBottom = true;
        }

        //Sets Up Properties for Masters
        private void SetMasterProperties()
        {
            _cs = Int32.Parse(CameraSetComboBox.SelectedItem.ToString());
            _m = Int32.Parse(MasterComboBox.SelectedItem.ToString());
            CameraSetComboBox.Enabled = true;
            MasterComboBox.Enabled = true;
        }

        //Sets up properties for FrontEnd
        private void SetFrontEndProperties()
        {
            CameraSetComboBox.Enabled = false;
            MasterComboBox.Enabled = false;
            _cs = 0;
            _m = 1;
        }

        //Sets up every work order data and values respective to workOrder requested
        private void SetUpWorkOrder()
        {
            Cursor.Current = Cursors.WaitCursor; 
            WorkOrderLoader loader = GetLoader();
            GetWorkOrderDisplay(loader);
            GetLogs(loader);
            CheckAndScrollToBottom();
            SetPropertiesIfLoomSystem();
            Cursor.Current = Cursors.Default;
        }

        //Sets properties for the System if the System is a loom System
        private void SetPropertiesIfLoomSystem()
        {
            if (_isLoomSystem)
            {
                MasterComboBox.Enabled = false;
                MasterComboBox.SelectedIndex = 0;
            }
        }

        //Sets the data for Displaying the WorkOrder in focus
        private void GetWorkOrderDisplay(WorkOrderLoader loader)
        {
            WorkOrderNumberLabel.Text = "Work Order : " + loader._workOrderNum;
            WorkOrderTimeLabel.Text = "Date : " + loader._dateTimeStart;
            nextWorkOrderLabel.Text = "Next Work Order :" + loader._nextWorkOrder;
            previousWorkOrderLabel.Text = "Previous Work Order :" + loader._previousWorkOrder;
            DateTimeParser.Parse(loader._dateTimeStart, out _startTime);
            DateTimeParser.Parse(loader._dateTimeEnd, out _endTime);
        }
        
        //fetches the data for each workOrder
        private void GetLogs(WorkOrderLoader loader)
        {
            try
            {
                vbEventLogTextBox.Text = string.Join("\n", loader._logs[ConfigurationManager.AppSettings["vbEventLogKey"].ToString()]);
            }
            catch(Exception ex)
            {
                _logger.WriteLog("Exception ---------- : "+ex.Message);
            }
            try
            {
                vbLogTextBox.Text = string.Join("\n", loader._logs[ConfigurationManager.AppSettings["vbLogKey"].ToString()]);
            }
            catch (Exception ex)
            {
                _logger.WriteLog("Exception ---------- : " + ex.Message);
            }
            try
            {
                witStatusLogTextBox.Text = string.Join("\n", loader._logs[ConfigurationManager.AppSettings["witStatusLogKey"].ToString()]);
            }
            catch (Exception ex)
            {
                _logger.WriteLog("Exception ---------- : " + ex.Message);
            }
            try
            {
                mainLogTextBox.Text = string.Join("\n", loader._logs[ConfigurationManager.AppSettings["mainLogKey"].ToString()]);
            }
            catch (Exception ex)
            {
                _logger.WriteLog("Exception ---------- : " + ex.Message);
            }
            try
            {
                serialOutputLogTextBox.Text = string.Join("\n\n", loader._logs[ConfigurationManager.AppSettings["serialOutputLogKey"].ToString()]);
            }
            catch (Exception ex)
            {
                _logger.WriteLog("Exception ---------- : " + ex.Message);
            }
        }
        
        //Checks and Scrolls each Text Box to Bottom
        private void CheckAndScrollToBottom()
        {
            if(_isCrashWorkOrder)
            {
                _scrollToBottom = true;
                autoScrollToBottomMenuItem.Checked = true;
            }
            if (_scrollToBottom)
            {
                foreach (var entry in _tagMap)
                {
                    entry.Value.Text += " ";
                    entry.Value.Focus();
                    entry.Value.Select(entry.Value.Text.Length - 1, 1);
                    entry.Value.DeselectAll();
                }
            }
        }

        //Scrolls to the bottom when the setting is checked in the tools menu item of menu strip
        private void BringTextBoxesToBottomAction(object sender, EventArgs e)
        {
            CheckAndScrollToBottom();
        }

        //Fetches the data from LogFilesGrabber Class
        private Dictionary<string, List<string>> GetWorkOrderDetails()
        {
            Dictionary<string, List<string>> fetchedData = new Dictionary<string, List<string>>();
            try
            {
                LogFilesGrabber obj = new LogFilesGrabber(_workOrder);
                obj.ProcessSystemSpecificLogs(_cs, _m, _isFrontEnd, _isTransition, _isLoomSystem);
                fetchedData = obj.GetFetchedData();
                dataBaseLogDataGridView.DataSource = obj.GetDBLog();
                logIntervalLabel.Text = obj.getStartEndTime();
            }
            catch(IndexOutOfRangeException)
            {
                this.Close();
            }
            return fetchedData;
        }

        //Closes the application
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Sets up the form for each work Order when Go is clicked
        private void GoButton_Click(object sender, EventArgs e)
        {
            ProcessWorkOrder();
        }

        private void PrepareForNewWorkOrder()
        {
            SwitchOffSyncIfOn();
            SetScreenToSystemType();
            readMasterMetersToolStripMenuItem.Enabled = _isFrontEnd;
        }

        //Initializes each box with Empty Strings
        private void InititalizeBoxes()
        {
            vbLogTextBox.Text = "";
            vbEventLogTextBox.Text = "";
            witStatusLogTextBox.Text = "";
            mainLogTextBox.Text = "";
            serialOutputLogTextBox.Text = "";
        }

        //Gets the WorkOrder in WorkOrderLoader data type so that its easy to access and pass in methods
        private WorkOrderLoader GetLoader()
        {
            Dictionary<string, List<string>> fetchedData = GetWorkOrderDetails();
            WorkOrderLoader loader = new WorkOrderLoader(_workOrder,fetchedData);
            return loader;
        }

        //Finds the next workOrder and sets up the Form according to new WorkOrder
        private void FindNextButton_Click(object sender, EventArgs e)
        {
            _workOrder = nextWorkOrderLabel.Text.Split(':')[1].ToString();
            _isCrashWorkOrder = false;
            ProcessWorkOrder();
        }

        //Finds the previous workOrder and sets up the Form according to new WorkOrder
        private void FindPreviousButton_Click(object sender, EventArgs e)
        {
            _workOrder = previousWorkOrderLabel.Text.Split(':')[1].ToString();
            _isCrashWorkOrder = false;
            ProcessWorkOrder();  
        }

        //Checks the sync tool menu strip item when ckicked and tries to sync the logs fetched by the systems selected
        private void SyncLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (syncLogsToolStripMenuItem.Checked)
            {
                SwitchOffSyncIfOn();
            }
            else
            {
                SetSyncSettings();
            }
        }

        //Resets the Sync Properties
        private void SwitchOffSyncIfOn()
        {
            syncLogsToolStripMenuItem.Checked = false;
            timeTrackBar.Enabled = false;
            startTimeLabel.Text = "";
            endTimeLabel.Text = "";
            timeTrackBar.Value = 0;
            trackBarValueLabel.Text = "";
            _textHighlighter.RemoveHighLights();
        }

        //Removes all the highlighted portions of sync operation
        private void RemoveHighlights()
        {
            foreach(var entry in _tagMap)
            {
                entry.Value.SelectionStart = _lastSyncPosition[entry.Key];
                entry.Value.SelectionLength = 30;
                entry.Value.SelectionColor = Color.Black;
                entry.Value.DeselectAll();
            }
        }

        //Sets the syncSettings by setting up the range and enabling track bar
        private void SetSyncSettings()
        {
            syncLogsToolStripMenuItem.Checked = true;
            _isOldBuild = LogsSynchronizer.SetStartEndTime(_tagMap, _isOldBuild, out _END,out _START);
            SetTrackBarRange(_rangeMaxValue);
            if (!_isOldBuild)
            {
                _isOldBuild = LogsSynchronizer.SyncWithTime(_tagMap,out _syncMap,out _startTick,out _endTick);
            }
            timeTrackBar.Enabled = true;
        }

        //Sets the range for Track Bar 
        private void SetTrackBarRange(int x)
        {
            timeTrackBar.SetRange(0, x);
            startTimeLabel.Text = _START.ToString();
            endTimeLabel.Text = _END.ToString();
        }
        
        //Combines current work Order with logs of last and next work Order
        private void ShowTransitionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showTransitionsToolStripMenuItem.Checked)
            {
                _isTransition = false;
                showTransitionsToolStripMenuItem.Checked = false;
                
            }
            else
            {
                _isTransition = true;
                showTransitionsToolStripMenuItem.Checked = true;
            }
        }

        //Actual logic of show Transitions
        private void ShowTransitions(object sender, EventArgs e)
        {
            ProcessWorkOrder();
        }

        //Gets the latest WorkOrder number and sets it as the _WorkOrder
        public void FindLastWorkOrder() 
        {
            DBMaster dbmaster = new DBMaster();
            DataTable dt = dbmaster.queryDB(ConfigurationManager.AppSettings["workOrdersDBName"].ToString(), "WorkOrderDetails", "WorkOrder", "DateOfProduction = (select MAX(DateOfProduction) from WorkOrderDetails);");
            string latestWorkOrder = dt.Rows[0][0].ToString();
            _workOrder = latestWorkOrder;  
        }

        //Click Event of AUTO SCROLL TO BOTTOM
        private void AutoScrollToBottomMenuItem_Click(object sender, EventArgs e)
        {
            if (autoScrollToBottomMenuItem.Checked)
            {
                _scrollToBottom = false;
                autoScrollToBottomMenuItem.Checked = false;
            }
            else
            {
                _scrollToBottom = true;
                autoScrollToBottomMenuItem.Checked = true;
            }
        }

        //Reads the master meters
        private void ReadMasterMetersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MasterMeterReader obj = new MasterMeterReader();
            DataTable dt = obj.GetMasterMeterReadings(_workOrder,vbEventLogTextBox.Text.ToString());
            DisplayMasterMeterForm objForm = new DisplayMasterMeterForm(dt);
            objForm.ShowDialog();
        }
        
        //Dynamiccaly finds every textBox related to logs
        private void GetTextBoxTags()
        {
            var allGroupBoxes = this.Controls.OfType<GroupBox>();
            List<string> logTags = ConfigurationManager.AppSettings.AllKeys.Where(key => key.Contains("LogKey")).Select(key => ConfigurationManager.AppSettings[key]).ToList<string>();
            foreach (var gBox in allGroupBoxes)
            {
                string searchGroupBox = "DisplayGroupBox";
                if (gBox.Name.ToString().ToLower().Contains(searchGroupBox.ToLower()))
                {
                    var panels = gBox.Controls.OfType<Panel>();
                    foreach (var p in panels)
                    {
                        var allChildGroupBox = p.Controls.OfType<GroupBox>();
                        foreach (var cgBox in allChildGroupBox)
                        {
                            var allRichTextBoxes = cgBox.Controls.OfType<RichTextBox>();
                            foreach (var richTB in allRichTextBoxes)
                            {
                                foreach(string tag in logTags)
                                {
                                    if(richTB.Name.ToLower().Contains(tag))
                                    {
                                        _tagMap.Add(tag, richTB);
                                        _lastSyncPosition.Add(tag, 0);
                                    }
                                }           
                            }
                        }
                    }
                }
            }
        }       

        //Closes the window
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        //Event triggered every time track bar is moved
        public void TimeTrackBar_ScrollEvent(object sender, EventArgs e)
        {
            SetValLabelValue();
            double rangeValsInterval = 0.0;
            bool normalLabel = GetRangeValsInterval(out rangeValsInterval);
            string labelText = "";
            Dictionary<string, int> posTags = new Dictionary<string, int>();
            LogsSynchronizer.GetScrollPositionForCurrentVal(_tagMap,_START,_END,_startTick,_endTick, _syncMap, _isOldBuild, timeTrackBar.Value, out posTags, out labelText);
            trackBarValueLabel.Text = labelText;
            ScrollToPositions(posTags);
        }

        private bool GetRangeValsInterval(out double rangeValsInterval)
        {
            bool normalLabel = true;
            double startTick = 0.0;
            double endTick = 0.0;
            try
            {
                startTick = Double.Parse(_startTick);
                endTick = Double.Parse(_endTick);
            }
            catch (FormatException ex)
            {
                ErrorLogger logger = new ErrorLogger();
                logger.WriteLog("Exception when Setting Track Bar Value Label : " + ex.Message);
                normalLabel = false;
            }
            rangeValsInterval = endTick - startTick;
            return normalLabel;
        }

        //Scrolls the RichTextBoxes to positions Given bby LogsSynchronizer
        private void ScrollToPositions(Dictionary<string, int> posTags)
        {
            
            foreach (var item in _tagMap)
            {
                int position = 0;
                try
                {
                    position = posTags[item.Key];
                }
                catch(Exception ex)
                {
                    _logger.WriteLog("Exception Encountered : The given key wan't available in the Tags when looking to scroll to a particular location : "+item.Key + " : "+ex.Message);
                }
                _textHighlighter.RemoveHighLights(item.Key);
                _textHighlighter.HighLightText(position, 30, item.Key);
                item.Value.ScrollToCaret();
            }
            
        }

        //Sets the value of the label in center of the trackl bar which denotes the value passed by the track bar to sync logs
        private void SetValLabelValue()
        {
            string labelString = "";
            double ss = 0.0;
            double startTick = 0.0;
            double endTick = 0.0;
            bool normalLabel = true;

            try
            {
                startTick = Double.Parse(_startTick);
                endTick = Double.Parse(_endTick);
            }
            catch (FormatException ex)
            {
                _logger.WriteLog("Exception when Setting Track Bar Value Label : " + ex.Message);
                normalLabel = false;
            }

            double rangeValsInterval = endTick - startTick;
            double rangeUnit = rangeValsInterval / 1000;
            double calculatedValue = startTick + (rangeUnit * timeTrackBar.Value);
            double valTrack = timeTrackBar.Value;
            double val = valTrack / 1000;

            double diff = (_END - _START).TotalMilliseconds;
            diff = val * diff;

            int seconds = (Int32)diff / 1000;
            double milliSeconds = diff % 1000;


            DateTime labelTimeValue = _START;
            labelTimeValue = labelTimeValue.AddSeconds(seconds);
            labelTimeValue = labelTimeValue.AddMilliseconds(milliSeconds);

            int fractionOfMilliSecond = (Int32)(diff * 100) % 100000;
            int tempss = (Int32)calculatedValue / 1000;

            ss = tempss;

            double fff = calculatedValue % 1000;
            fff = fff * 100;

            int tempFFF = (Int32)fff;
            fff = tempFFF;
            fff = fff / 100;

            labelString = labelTimeValue.ToString("d/M/yy HH:mm");

            if (normalLabel)
            {
                ss = (ss * 1000) + fff;
                trackBarValueLabel.Text = labelString + ":" + ss.ToString();
            }
            else
            {
                trackBarValueLabel.Text = labelString;
            }
        }

        // Event Handler for Advanced Operation Button (Opens A new Window)
        private void advancedOperationButton_Click(object sender, EventArgs e)
        {
            AdvancedOperationsForm obj = new AdvancedOperationsForm(_workOrder,_isFrontEnd,_isTransition,_isLoomSystem,_isCrashWorkOrder,_START,_END);
            obj.ShowDialog();
        }

        //Gets triggered (Event Handler when User clicks on search keyword button)
        private void searchTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchTextDialog obj = new SearchTextDialog(_tagMap);
            obj.Show(this);
        }

       
    }
}


