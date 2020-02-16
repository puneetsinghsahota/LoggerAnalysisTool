using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoggerAnalysisTool
{
    class HighlightedTextKeeper
    {
        // This class just stores the recent highlighted position in each text box which contains logs

        public string _key;
        public int _pos;
        public int _length;
        public RichTextBox _richTextBox;
     
        public HighlightedTextKeeper(int pos, int length,RichTextBox richTextBox, string key)
        {
            _pos = pos;
            _length = length;
            _richTextBox = richTextBox;
            _key = key;
        }
    }
}
