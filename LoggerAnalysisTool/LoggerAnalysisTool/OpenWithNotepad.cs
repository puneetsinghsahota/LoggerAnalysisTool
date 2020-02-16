using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;


namespace LoggerAnalysisTool
{
    static class OpenWithNotepad
    {
        public static void Open(string message)
        {
            string filePath = "Log.txt";

            System.IO.File.WriteAllText(filePath, "");

            System.IO.File.WriteAllLines(filePath,message.Split('\n'));

            Process notepad = Process.Start("notepad.exe", "Log.txt");
        }
    }
}
