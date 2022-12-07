namespace Hole.Runtime.Services.TimeFormatter
{
    public class TimeFormatter
    {
        private static TimeFormatter _instance;

        public string FromSecondsToMinuteAndSeconds(int seconds)
        {
            var minutesValue = seconds / 60;
            var secondsValue = seconds % 60;

            var endValueString = "";

            if (minutesValue < 10)
                endValueString += "0" + minutesValue;
            else
                endValueString += minutesValue;

            endValueString += ":";

            if (secondsValue < 10)
                endValueString += "0" + secondsValue;
            else
                endValueString += secondsValue;

            return endValueString;
        }
    }
}