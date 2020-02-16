using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerAnalysisTool
{
    /**
        This Class reads the master meters inside the VBEvent Logs of the FrontEnd System 
        Uses simple parsing techniques to get the Master Meter readings.


     */
    class MasterMeterReader
    {
        List<string> _lines = new List<string>();
        List<double> _listNum = new List<double>();
        DataTable _dt = new DataTable();
        List<string> _name = new List<string>();
        
        int _flag = 0;
        int _breakFlag = 0;
        string _tempName = "";
        int _count = 0;

        /// <summary>
        /// Parsing Logic of the VBEvent Log File in order to find the Master Meter Readings which have been recorded in the Log Files(Sent by the MASTER PCs)
        /// </summary>
        /// <param name="_workOrder"> WorkOrder Number</param>
        /// <param name="allText"> All text inside the Log File Corresponding to the WorkOrder Number Mentioned</param>
        /// <returns></returns>
        public DataTable GetMasterMeterReadings(string _workOrder, string allText)
        {
            string checkWorkOrderNum = _workOrder;
            _lines = allText.Split('\n').ToList<string>();
            _dt.Columns.Add("PCName");
            _dt.Columns.Add("MasterMeterReadings");
            foreach (string line in _lines)
            {
                if(!String.IsNullOrEmpty(line))
                {

                    if (line.Contains("FrontEnd:Opening \\GR1F1\\inres\\"))
                    {
                        _workOrder = line;
                        _workOrder = _workOrder.Split('\\').Last<string>().Split('.')[0];
                        if (_workOrder.Contains("_"))
                        {
                            _workOrder = _workOrder.Split('_')[0];
                        }
                        if (!_workOrder.Equals(_tempName))
                        {
                            if(_breakFlag == 1)
                            {
                                break;
                            }
                            if (_workOrder.Equals(checkWorkOrderNum))
                            {
                                _breakFlag = 1;
                            }
                            
                            _tempName = _workOrder;
                            _count = 0;
                            _listNum.Clear();
                            _name.Clear();
                        }
                    }
                    if (_flag > 0)
                    {
                        _flag++;
                    }
                    if (line.Contains("FrontEnd:>>RAW DATA IN on CS"))
                    {
                        if (line.Contains("|"))
                        {
                            string[] wordArray = line.Split(' ');
                            foreach (string s in wordArray.OfType<string>().ToList())
                            {           
                                if (s.Contains("CS"))
                                {
                                    _name.Add(s);
                                }
                            }
                            string focus = line.Split('|')[1];
                            focus = focus.Split('!')[0];
                            _count++;
                            if (focus.Contains("."))
                            {
                                double val = Convert.ToDouble(focus);
                                _listNum.Add(val);
                                _flag = 1;
                            }
                        }
                    }
                    if (_count == 24 && _flag < 3)
                    {
                        _count = 0;
                        int i = 0;
                        if (_workOrder.Equals(checkWorkOrderNum))
                        {
                            foreach (double val in _listNum)
                            {
                                DataRow dr = _dt.NewRow();
                                dr["PCName"] = _name[i].ToString();
                                dr["MasterMeterReadings"] = val.ToString();
                                _dt.Rows.Add(dr);
                                i++;
                            }
                        }
                        _flag = 0;
                        _listNum.Clear();
                    }
                }
            }
            return _dt;
        }
    }
}
