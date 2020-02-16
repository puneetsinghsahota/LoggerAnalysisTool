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
    public partial class SearchTextDialog : Form
    {
        private int startIndex = 0;
        private int endIndex = 0;
        private Dictionary<string, RichTextBox> _keyTextMap;
        private TextHighlighter _textHighLighter;

        public SearchTextDialog(Dictionary<string,RichTextBox> keyTextMap)
        {
            InitializeComponent();
            this.Icon = Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            this.AcceptButton = FindButton;
            _textHighLighter = new TextHighlighter(keyTextMap, Color.Blue);
            _keyTextMap = keyTextMap;
            FindNextButton.Enabled = false;
            searchFromTopRadioButton.Checked = true;
           
            searchKeyWordTextBox.TextChanged += new EventHandler(resetDialog);
            FillInComboBox();
        }

        private void FillInComboBox()
        {
            foreach(var entry in _keyTextMap)
            {
                logsComboBox.Items.Add(entry.Key.ToString());
            }
            
            logsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            logsComboBox.SelectedIndex = 0;
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            FindButton.Enabled = false;
            FindNextButton.Enabled = true;
            this.AcceptButton = FindNextButton;
            logsComboBox.Enabled = false;
            searchFromBottomRadioButton.Enabled = false;
            searchFromTopRadioButton.Enabled = false;
            string searchText = searchKeyWordTextBox.Text.ToString();
            int totalOccCount = FindAll(searchText);
            NumberOfOccurencesLabel.Text = "Number Of Matched Keywords : " + totalOccCount.ToString();
            if (totalOccCount > 0)
            {
                startIndex = 0;
                if (searchFromBottomRadioButton.Checked == true)
                {
                    endIndex = _keyTextMap[logsComboBox.SelectedItem.ToString()].Text.Length;
                }
                FindText(searchText);
            }
            Cursor.Current = Cursors.Default;
        }

        private bool FindText(string searchText)
        {
            string key = logsComboBox.SelectedItem.ToString();
            RichTextBox richTextBox = _keyTextMap[key];
            if (searchFromTopRadioButton.Checked == true)
            {
                startIndex = richTextBox.Find(searchText, startIndex, RichTextBoxFinds.None);
            }
            else if(searchFromBottomRadioButton.Checked == true)
            {
                endIndex = richTextBox.Find(searchText, startIndex,endIndex, RichTextBoxFinds.Reverse);
            }
            
            bool highlight = true;
            
                if (searchFromTopRadioButton.Checked == true)
                {
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                        startIndex = richTextBox.Find(searchText, startIndex, RichTextBoxFinds.None);
                        if (startIndex < 0)
                        {
                            highlight = false;
                            startIndex = 0;
                            MessageBox.Show("No Occurrences Found");
                        }
                    }
                }
                if (searchFromBottomRadioButton.Checked == true)
                {
                    if(endIndex<0)
                    {
                        if (startIndex == 0)
                        {
                            MessageBox.Show("No Occurrences Found");
                            return false;
                        }
                        else
                        {
                            startIndex = 0;
                            endIndex = _keyTextMap[logsComboBox.SelectedItem.ToString()].Text.Length;
                            endIndex = richTextBox.Find(searchText, startIndex, endIndex, RichTextBoxFinds.Reverse);
                            if(endIndex<0)
                            {
                                highlight = false;
                                MessageBox.Show("No Occurrences Found");
                            }
                        }
                    }
                    
                }
            
            
                richTextBox.ScrollToCaret();
                _textHighLighter.RemoveHighLights();
            
            if (highlight)
            {
            
                    if (searchFromTopRadioButton.Checked)
                    {
                        _textHighLighter.HighLightText(startIndex, searchText.Length, key);
                    }
                    else if (searchFromBottomRadioButton.Checked == true)
                    {
                        _textHighLighter.HighLightText(endIndex, searchText.Length, key);
                    }
                
                startIndex = startIndex + searchText.Length;

                return true; //Given Text was Found
            }
            else
            {
                return false; //Can't find given text
            }
            
        }

        private int FindAll(string searchText)
        {
            string key = logsComboBox.SelectedItem.ToString();
            RichTextBox myRtb = _keyTextMap[key];
            int numOccCount = 0;
            startIndex = 0;
            int index = 0;
            while ((index = myRtb.Text.IndexOf(searchText, startIndex)) != -1)
            {
                myRtb.Select(index, searchText.Length);
                myRtb.SelectionColor = Color.Green;
                numOccCount++;
                startIndex = index + searchText.Length;
            }
            return numOccCount;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            _textHighLighter.ResetToBlack();
            startIndex = 0;
            this.Close();

        }

        private void resetDialog(object sender, EventArgs e)
        {
            logsComboBox.Enabled = true;
            
            //searchKeyWordTextBox.ReadOnly = false;
            searchFromBottomRadioButton.Enabled = true;
            searchFromTopRadioButton.Enabled = true;
            startIndex = 0;
            //searchKeyWordTextBox.Text = "";
            NumberOfOccurencesLabel.Text = "";
            _textHighLighter.ResetToBlack();
            FindNextButton.Enabled = false;
            this.AcceptButton = FindButton;
            FindButton.Enabled = true;
        }

        private void FindNextButton_Click(object sender, EventArgs e)
        {
            string searchText = searchKeyWordTextBox.Text.ToString();   
            FindText(searchText);
        }

       
    }
}
