using System;
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
    public partial class LogKeySpecificLogForm : Form
    {
        ErrorLogger _logger = new ErrorLogger();
        TextHighlighter _textHighlighter;

        private Dictionary<string, DataTable> _dbLogs = new Dictionary<string, DataTable>();
        private Dictionary<string, List<string>> _keySpecificLogs = new Dictionary<string, List<string>>();
        private Dictionary<string, Dictionary<string, int>> _syncMap = new Dictionary<string, Dictionary<string, int>>();
        private Dictionary<string, RichTextBox> _tagsDictionary = new Dictionary<string, RichTextBox>();
        
        
        private string _workOrder = "";
        private string _key;
        private string _startTick = "";
        private string _endTick = "";

        private bool _isFrontEnd;
        private bool _isTransition;
        private bool _isCrashWorkOrder;
        private bool _isLoomSystem;
        private bool _isOldBuild = false;

        private DateTime _START = new DateTime();
        private DateTime _END = new DateTime();
        
        private int _rangeMaxValue = 1000;
        
        public LogKeySpecificLogForm(string workOrder, DataTable selectedSystems, string selectedLogType, bool isFrontEnd, bool isTransition, bool isCrashWorkOrder, bool isLoomSystem)
        {
            InitializeComponent();
            this.Icon = Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Cursor.Current = Cursors.WaitCursor;
            this.KeyPreview = true; // Listens to the Key Press Events
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPressedEvent);
            _isFrontEnd = isFrontEnd;
            _isTransition = isTransition;
            _isCrashWorkOrder = isCrashWorkOrder;
            _isLoomSystem = isLoomSystem;
            _workOrder = workOrder;
            
            LogFilesGrabber obj = new LogFilesGrabber(_workOrder);
            Dictionary<string, List<string>> keySpecificLogs = new Dictionary<string, List<string>>();
            Dictionary<string, DataTable> dbLogs = new Dictionary<string, DataTable>();
            obj.ProcessLogKeySpecificLogs(selectedSystems, selectedLogType, _isTransition, _isLoomSystem, out keySpecificLogs, out dbLogs);
            StartEndTimeLabel.Text = obj.getStartEndTime();
            _key = selectedLogType;
            _keySpecificLogs = keySpecificLogs;
            _dbLogs = dbLogs;
            setControlProperties();
            _textHighlighter = new TextHighlighter(_tagsDictionary,Color.Blue);
            Cursor.Current = Cursors.Default;
        }

        private void KeyPressedEvent(object sender, KeyEventArgs e)
        {
           if(e.Control && e.KeyCode.ToString() == "F")
            {
                searchTextButton_Click(new object(), new EventArgs());
            }
        }

        private void setControlProperties()
        {
            trackBar.Scroll += new EventHandler(trackBar_ScrollEvent);
            syncButton.BackColor = Color.AntiqueWhite;
            WorkOrderLabel.Text = "WorkOrder : " + _workOrder;
            syncButton.Enabled = false;
            SystemsShownLabel.Text = "Log Type : ["+_key+"]";
            if (_key.ToLower().Contains("dblog"))
            {
                drawDataTables();
            }
            else
            {
                drawRichTextBoxes();
            }
            trackBarValueLabel.Text = "";
            trackBar.Enabled = false;
            
        }

        private void trackBar_ScrollEvent(object sender, EventArgs e)
        {
            double rangeValsInterval = 0.0;
            bool normalLabel = GetRangeValsInterval(out rangeValsInterval);
            string labelText = "";
            Dictionary<string, int> posTags = new Dictionary<string, int>();
            LogsSynchronizer.GetScrollPositionForCurrentVal(_tagsDictionary, _START, _END, _startTick, _endTick, _syncMap, _isOldBuild, trackBar.Value, out posTags, out labelText);
            ScrollToPosition(posTags);
            trackBarValueLabel.Text = labelText;
        }

        private void ScrollToPosition(Dictionary<string, int> posTags)
        {
            foreach (var item in _tagsDictionary)
            {
                int position = 0;
                try
                {
                    position = posTags[item.Key];
                }
                catch (Exception ex)
                {
                    _logger.WriteLog("Exception Encountered : The given key wasn't available in the Tags when looking to scroll to a particular location : " + item.Key + " : " + ex.Message);
                }
                _textHighlighter.RemoveHighLights(item.Key);
                _textHighlighter.HighLightText(position,30,item.Key);
                item.Value.ScrollToCaret();
            }
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

        private void SetTrackBarLabelValue()
        {
            throw new NotImplementedException();
        }

        private void drawDataTables()
        {
            int x = 0;
            int y = 40;
            displayPanel.VerticalScroll.Enabled = false;
            displayPanel.HorizontalScroll.Enabled = true;
            foreach (var entry in _dbLogs)
            {
                Label componentName = new Label();
                componentName.Name = entry.Key.ToString() + "Label";
                componentName.Text = entry.Key.ToString();
                componentName.Size = new Size(50, 30);
                componentName.Font = new Font("Arial", 14, FontStyle.Bold);
                componentName.Location = new Point(x, (y - 35));
                displayPanel.Controls.Add(componentName);

                DataGridView dataGrid = new DataGridView();
                dataGrid.DataSource = entry.Value;
                dataGrid.Name = entry.Key;
                dataGrid.Height = displayPanel.Height - 100;
                dataGrid.RowHeadersVisible = false;
                dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGrid.ReadOnly = true;
                dataGrid.Width = displayPanel.Width/2;
                dataGrid.Location = new Point(x, y);
                displayPanel.Controls.Add(dataGrid);
                x = x + (displayPanel.Width / 2);
            }
        }

        private void drawRichTextBoxes()
        {
            syncButton.Enabled = true;
            int x = 0;
            int y = 40;
            displayPanel.VerticalScroll.Enabled = false;
            displayPanel.HorizontalScroll.Enabled = true;
            foreach (var entry in _keySpecificLogs)
            {
                Label componentName = new Label();
                componentName.Name = entry.Key.ToString()+"Label";
                componentName.Text = entry.Key.ToString();
                componentName.Font = new Font("Arial", 14, FontStyle.Bold);
                componentName.Size = new Size (300,30);
                componentName.Location = new Point(x, (y - 35));
                displayPanel.Controls.Add(componentName);

                RichTextBox richTextBox = new RichTextBox();
                richTextBox.Name = entry.Key.ToString() + "TextBox";
                richTextBox.Text = String.Join("\n",entry.Value.ToArray<string>());
                richTextBox.Name = entry.Key;
                richTextBox.ReadOnly = true;
                richTextBox.Height = displayPanel.Height - 100;
                richTextBox.Width = displayPanel.Width / 2;
                richTextBox.Location = new Point(x, y);
                displayPanel.Controls.Add(richTextBox);
                x = x + (displayPanel.Width / 2);
                _tagsDictionary.Add(entry.Key.ToString(), richTextBox);
               
            }
        }

        private void syncButton_Click(object sender, EventArgs e)
        {
            if(syncButton.BackColor == Color.AntiqueWhite)
            {
                SetSyncSettings();
            }
            else
            {
                SwitchOffSyncIfOn();
            }
        }

        private void SetSyncSettings()
        {
            syncButton.BackColor = Color.LightGreen;
            _isOldBuild = LogsSynchronizer.SetStartEndTime(_tagsDictionary,_isOldBuild,out _END, out _START);
            SetTrackBarRange(_rangeMaxValue);
            if(!_isOldBuild)
            {
                _isOldBuild = LogsSynchronizer.SyncWithTime(_tagsDictionary, out _syncMap, out _startTick, out _endTick);
            }
            trackBar.Enabled = true;
        }

        private void SwitchOffSyncIfOn()
        {
            _textHighlighter.RemoveHighLights();
            syncButton.BackColor = Color.AntiqueWhite;
            trackBar.Enabled = false;
            trackBarValueLabel.Text = "";
            trackBar.Value = 0;
            
        }

       

        private void SetTrackBarRange(int x)
        {
            trackBar.SetRange(0, x);
        }

        private void searchTextButton_Click(object sender, EventArgs e)
        {
            SearchTextDialog obj = new SearchTextDialog(_tagsDictionary);
            obj.Show(this);
        }
    }
}
