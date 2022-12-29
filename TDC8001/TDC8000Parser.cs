using System.Globalization;
using Types;

namespace TDC8001
{
    public class TDC8000Parser
    {


        public static TriggerTimes TDC8000StringToTriggerTimes(string stringFromStopWatch)
        {
            var returnTriggerTime = new TriggerTimes();

            /*
            xNNNNxC4xxHH:MM:SS.zhtqxxxxxxxx(CR)
            " 0001 C4  12:34:56.7890        "
            ?NNNNxC1xxHH:MM:SS.zhtqxxxxxxxx(CR)
            "?NNNN C1  HH:MM:SS.zhtq        "
            cNNNNxC4xxHH:MM:SS.zhtqxxxxxxxx(CR)
            "cNNNN C4  HH:MM:SS.zhtq        "
            cNNNNxC1xxHH:MM:SS.zhtqxxxxxxxx(CR)
            "cNNNN C1  HH:MM:SS.zhtq        "
            */
            string stringFromStopWatchWithoutFirst = String.Empty;

            stringFromStopWatchWithoutFirst = stringFromStopWatch.Substring(1);



            string[] subStrings = new string[10];
            for (int i = 0; i < 10; i++)
            {
                subStrings[i] = String.Empty;
            }

            int length = stringFromStopWatch.Length;
            if (length < 24)
            {
                return null;
            }

            if (stringFromStopWatch.StartsWith(" "))
            {
                returnTriggerTime.Status = "normal";
            }
            else if (stringFromStopWatch.StartsWith("?"))
            {
                returnTriggerTime.Status = "invalid_Time";
            }
            else if (stringFromStopWatch.StartsWith("c"))
            {
                returnTriggerTime.Status = "deleted_Time";
            }
            else { return null; }


            subStrings = stringFromStopWatchWithoutFirst.Split(" ", 6);
            returnTriggerTime.Startnummer = int.Parse(subStrings[0]);
            returnTriggerTime.Channel = subStrings[1];
            if (subStrings[1].EndsWith("M"))
            {
                returnTriggerTime.TriggerTime = DateTime.ParseExact(subStrings[2], "HH:mm:ss.ffff", System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                returnTriggerTime.TriggerTime = DateTime.ParseExact(subStrings[3], "hh:MM:ss.ffff", System.Globalization.CultureInfo.InvariantCulture);
            }

            return returnTriggerTime;
        }
    }
}