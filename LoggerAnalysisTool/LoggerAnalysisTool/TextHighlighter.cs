using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoggerAnalysisTool
{
    class TextHighlighter
    {
        public Dictionary<string, RichTextBox> _keyTextMap;
        public List<HighlightedTextKeeper> _highlightedTextKeeperObject;
        public System.Drawing.Color _color;
        public TextHighlighter(Dictionary<string,RichTextBox> keyTextMap, System.Drawing.Color color)
        {
            _keyTextMap = keyTextMap;
            _highlightedTextKeeperObject = new List<HighlightedTextKeeper>();
            _color = color;
            InitializeKeeperList();
            
        }

        private void InitializeKeeperList()
        {
            foreach (var entry in _keyTextMap)
            {
                HighlightedTextKeeper obj = new HighlightedTextKeeper(0, 0, entry.Value,entry.Key);
                _highlightedTextKeeperObject.Add(obj);
            }
        }

        public void HighLightText(int startIndex, int length, string key)
        {
            foreach (var obj in _highlightedTextKeeperObject)
            {
                if(obj._key.Equals(key))
                {
                    obj._pos = startIndex;
                    obj._length = length;
                    obj._richTextBox.Focus();
                    obj._richTextBox.SelectionStart = startIndex;
                    obj._richTextBox.SelectionLength = length;
                    obj._richTextBox.SelectionColor = _color;
                    obj._richTextBox.DeselectAll();
                }
            }
        }
        public void RemoveHighLights()
        {
            
            foreach (var obj in _highlightedTextKeeperObject)
            {
                obj._richTextBox.SelectionStart = obj._pos;
                obj._richTextBox.SelectionLength = obj._length;
                obj._richTextBox.SelectionColor = System.Drawing.Color.Green;
                obj._pos = 0;
                obj._length = 0;
            }

        }


        public void ResetToBlack()
        {
            foreach (var obj in _highlightedTextKeeperObject)
            {

                obj._richTextBox.SelectionStart = 0;
                obj._richTextBox.SelectionLength = obj._richTextBox.Text.Length;
                obj._richTextBox.SelectionColor = System.Drawing.Color.Black;
                obj._richTextBox.DeselectAll();
                obj._pos = 0;
                obj._length = 0;

            }
        }

        public void RemoveHighLights(string key)
        {

            foreach (var obj in _highlightedTextKeeperObject)
            {
                if (obj._key.Equals(key))
                {
                    obj._richTextBox.SelectionStart = obj._pos;
                    obj._richTextBox.SelectionLength = obj._length;
                    obj._richTextBox.SelectionColor = System.Drawing.Color.Green;
                    obj._pos = 0;
                    obj._length = 0;
                }
            }

        }
    }
}
