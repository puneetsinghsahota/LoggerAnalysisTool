using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoggerAnalysisTool
{
    class LogsSynchronizer
    {
        public static bool SyncWithTime(Dictionary<string, RichTextBox> tagMap, out Dictionary<string, Dictionary<string, int>> syncMap, out string startTick, out string endTick)
        {
            Cursor.Current = Cursors.WaitCursor;
            ErrorLogger logger = new ErrorLogger();
            syncMap = new Dictionary<string, Dictionary<string, int>>();
            bool oldBuild = false;
            List<double> findStartEndTime = new List<double>();
            foreach (var entry in tagMap)
            {
                string text = entry.Value.Text;
                List<string> lines = text.Split('\n').ToList<string>();
                string tempLine = "";
                string tempTime = "";
                bool setSettings = true;

                Dictionary<string, int> posDict = new Dictionary<string, int>();
                foreach (string line in lines)
                {
                    if (!String.IsNullOrEmpty(line))
                    {
                        if (line.Contains(","))
                        {
                            tempLine = line;
                            string time = line.Split(',')[1].Replace('\"', ' ').Trim();
                            string milliSeconds = line.Split(',')[2].Replace('\"', ' ').Trim();
                            DateTime parsedTime = new DateTime();
                            DateTimeParser.Parse(time, out parsedTime);
                            time = parsedTime.ToString("HH:mm") + ":" + milliSeconds;
                            try
                            {
                                findStartEndTime.Add(Double.Parse(milliSeconds));
                                if (setSettings)
                                {
                                    setSettings = false;
                                    tempTime = time;
                                }
                                if (!tempTime.Equals(time))
                                {
                                    posDict.Add(tempTime, entry.Value.Find(line));
                                    tempTime = time;
                                }
                            }
                            catch (FormatException ex)
                            {
                                oldBuild = true;
                                logger.WriteLog("Moving to Old Build : Reason: " + ex.Message);
                            }
                        }
                    }
                }
                posDict.Add(tempTime, entry.Value.Find(tempLine));
                syncMap.Add(entry.Key, posDict);
            }
            if (oldBuild)
            {
                MessageBox.Show("Old Build Detected : Only Approximate Synchronization Available.");
            }
            endTick = findStartEndTime.Max<double>().ToString();
            startTick = findStartEndTime.Min<double>().ToString();
            Cursor.Current = Cursors.Default;
            return oldBuild;
        }

        public static bool SetStartEndTime(Dictionary<string, RichTextBox> tagMap,bool isOldBuild, out DateTime end, out DateTime start)
        {
            List<DateTime> listTimes = new List<DateTime>();
            foreach (var entry in tagMap)
            {
                isOldBuild = ParseEachTextBoxForTime(entry, listTimes,isOldBuild, out listTimes);
            }
            if (isOldBuild)
            {
                MessageBox.Show("Old Build Detected : Only Approximate Synchronization Available.");
            }
            SettingMinMaxTimesAsStartEnd(listTimes, out end, out start);
            return isOldBuild;
        }
        
        private static void SettingMinMaxTimesAsStartEnd(List<DateTime> listTimes, out DateTime end, out DateTime start)
        {
            ErrorLogger logger = new ErrorLogger();
            start = new DateTime();
            end = new DateTime();
            try
            {
                end = listTimes.Max<DateTime>();
                start = listTimes.Min<DateTime>();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Cannot find any Text.");
                logger.WriteLog("Exception Occured : Cannot Find any Text : Reason :" + ex.Message);
            }
        }
        
        private static bool ParseEachTextBoxForTime(KeyValuePair<string, RichTextBox> textBoxTag, List<DateTime> listTimes, bool isOldBuild , out List<DateTime> resultList)
        {
            resultList = new List<DateTime>();
            isOldBuild = false;
            List<string> lines = textBoxTag.Value.Text.Split('\n').ToList<string>();
            foreach (string line in lines)
            {
                if (!String.IsNullOrEmpty(line) && !textBoxTag.Key.ToLower().Equals("mainlog"))
                {
                    isOldBuild = CheckLineForSync(line, listTimes,out listTimes,isOldBuild);

                }
            }
            resultList.AddRange(listTimes);
            return isOldBuild;
        }

        private static bool CheckLineForSync(string line, List<DateTime> listTimes,out List<DateTime> resultList ,bool isOldBuild)
        {
            resultList = new List<DateTime>();
            DateTime createdTime = new DateTime();
            bool ExceptionOccured = ParseLineForTimeStamp(line, out createdTime);
            if (ExceptionOccured)
            {
                isOldBuild = true;
            }
            else
            {
                listTimes.Add(createdTime);
            }
            resultList.AddRange(listTimes);
            return isOldBuild;
        }

        private static bool ParseLineForTimeStamp(string line, out DateTime createdTime)
        {
            ErrorLogger logger = new ErrorLogger();
            string time = line.Split(',')[0].Replace('\"', ' ').Trim() + " " + line.Split(',')[1].Replace('\"', ' ').Trim();
            DateTimeParser.Parse(time, out createdTime);
            bool ExceptionOccured = false;
            try
            {
                double value = Double.Parse(line.Split(',')[2]);
                int seconds = (Int32)value / 1000;
                int milliSeconds = (Int32)value % 1000;
                createdTime = createdTime.AddSeconds(seconds);
                createdTime = createdTime.AddMilliseconds(milliSeconds);
            }
            catch (FormatException ex)
            {
                ExceptionOccured = true;
                logger.WriteLog("Moving to Old Build : Reason: " + ex.Message);
            }
            return ExceptionOccured;
        }

        public static void GetScrollPositionForCurrentVal(Dictionary<string, RichTextBox> tagMap, DateTime START, DateTime END, string startTick, string endTick,Dictionary<string, Dictionary<string, int>> syncMap,bool isOldBuild,int value,out Dictionary<string, int> posTags,out string labelText)
        {
            labelText = SetLabelValue(START,END,value,startTick,endTick);
            posTags = new Dictionary<string, int>();
            if (isOldBuild)
            {
                posTags = scrollThroughLines(tagMap,value);
            }
            else
            {
                posTags = scrollThroughTimes(labelText, tagMap, syncMap);
            }
        }

        private static string SetLabelValue(DateTime START, DateTime END, int value, string start, string end)
        {
            string labelText = "";
            string labelString = "";
            double ss = 0.0;
            bool normalLabel = true;

            
            double startTick = 0.0;
            double endTick = 0.0;
            try
            {
                startTick = Double.Parse(start);
                endTick = Double.Parse(end);
            }
            catch (FormatException ex)
            {
                ErrorLogger logger = new ErrorLogger();
                logger.WriteLog("Exception when Setting Track Bar Value Label : " + ex.Message);
                normalLabel = false;
            }

            double rangeValsInterval = endTick - startTick;

            double rangeUnit = rangeValsInterval / 1000;
            double calculatedValue = startTick + (rangeUnit * value);
            double valTrack = value;
            double val = valTrack / 1000;

            double diff = (END - START).TotalMilliseconds;
            diff = val * diff;

            int seconds = (Int32)diff / 1000;
            double milliSeconds = diff % 1000;


            DateTime labelTimeValue = START;
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
                labelText = labelString + ":" + ss.ToString();
            }
            else
            {
                labelText = labelString;
            }
            return labelText;
        }

        private static Dictionary<string, int> scrollThroughLines(Dictionary<string, RichTextBox> tagMap, int value)
        {
            Dictionary<string, int> posTags = new Dictionary<string, int>();
            double currentTrackBarValue = value;
            double unit = currentTrackBarValue / 1000;


            foreach (var entry in tagMap)
            {
                


                int n = entry.Value.Lines.Count<string>();
                int linePos = 0;
                if (n > 2)
                {
                    linePos = (Int32)(unit * n);
                    if (unit == 1)
                    {
                        linePos = linePos - 1;
                    }
                    entry.Value.Focus();
                    if (!String.IsNullOrEmpty(entry.Value.Lines[linePos]))
                    {
                        int position = entry.Value.Find(entry.Value.Lines[linePos]);
                        posTags.Add(entry.Key, position);
                    }

                }
            }
            return posTags;
        }

        private static Dictionary<string, int> scrollThroughTimes(string labelValueText,Dictionary<string,RichTextBox> tagMap, Dictionary<string, Dictionary<string, int>> syncMap)
        {
            Dictionary<string, int> posTags = new Dictionary<string, int>();
            if (!String.IsNullOrEmpty(labelValueText.ToString()))
            {

                DateTime scrollerValue = new DateTime();
                List<string> labels = labelValueText.Split(' ')[1].Split(':').ToList<string>();
                string trackbarString = labels[0] + ":" + labels[1];
                DateTimeParser.Parse(trackbarString, out scrollerValue);
                string checkString = labels[2];
                double milliSecondsCheck = Double.Parse(checkString);

                foreach (var item in tagMap)
                {
                    double minDiff = 0.00;
                    string finalKey = "";
                    bool setUpLoop = true;
                    foreach (var entry in syncMap[item.Key])
                    {
                        if (!String.IsNullOrEmpty(entry.Key))
                        {
                            string label = entry.Key;
                            List<string> timeSplit = label.Split(':').ToList<string>();
                            string hour = timeSplit[0];
                            int hr = Int32.Parse(hour);
                            string minute = timeSplit[1];
                            int min = Int32.Parse(minute);
                            string milliSeconds = timeSplit[2];
                            double ms = Double.Parse(milliSeconds);
                            DateTime hashMapTime = new DateTime();
                            DateTimeParser.Parse(hr + ":" + min, out hashMapTime);
                            if (scrollerValue == hashMapTime)
                            {

                                double diff = ms - milliSecondsCheck;

                                if (diff < 0)
                                {
                                    diff *= (-1);
                                }
                                if (setUpLoop)
                                {
                                    setUpLoop = false;
                                    minDiff = diff;
                                    finalKey = entry.Key;
                                }
                                else if (diff < minDiff)
                                {
                                    minDiff = diff;
                                    finalKey = entry.Key;
                                }
                            }
                        }
                    }
                    if (!String.IsNullOrEmpty(finalKey))
                    {
                     int position = syncMap[item.Key][finalKey];
                        posTags.Add(item.Key, position);

                    }

                }
            }
            return posTags;
        }
    }
}
