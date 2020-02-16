using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoggerAnalysisTool
{
    class DateTimeParser
    {
        //Parses the date by matching it to all mentioned date time formats in appsettings
        public static  bool Parse(string dateTimeString, out DateTime parsedDate)
        {
            parsedDate = DateTime.Now;

            bool isSuccess = false;
            List<string> dateTimeFormats = ConfigurationManager.AppSettings["DateTimeFormats"].ToString().Split(',').ToList<string>();
            isSuccess = getDateTime(dateTimeString, dateTimeFormats, out parsedDate);

            return isSuccess;
        }

        // taked into account all the available date time formats and gives out the relevant out put as the parsed date time
        private static bool getDateTime(string dateTimeString, List<string> dateTimeFormats, out DateTime parsedDate)
        {
            bool isSuccess = false;
            DateTime tempParsedDateTime = DateTime.MinValue;

            isSuccess = DateTime.TryParse(dateTimeString, out tempParsedDateTime);
            if(isSuccess)
            {
                parsedDate = tempParsedDateTime;
                return isSuccess;
            }
            foreach(string format in dateTimeFormats)
            {
                isSuccess = DateTime.TryParseExact(dateTimeString,format,CultureInfo.InvariantCulture,DateTimeStyles.None,out tempParsedDateTime);
                if(isSuccess)
                {
                    parsedDate = tempParsedDateTime;
                    return isSuccess;
                }
            }
            parsedDate = tempParsedDateTime;
            return isSuccess;
        }
    }
}
