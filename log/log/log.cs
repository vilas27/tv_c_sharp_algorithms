using System;

namespace log
{
    public class Log
    {
        public enum LOG_TYPE { NONE = 0, ERROR = 1, WARNING = 2, INFO = 3, VERBOSE = 4 };

        private static LOG_TYPE current_log_type_ = LOG_TYPE.INFO;

        public void SetLogType(LOG_TYPE type)
        {
            Information("Current log type changed from (" + current_log_type_.ToString() + ") to (" + type.ToString() + ")");
            current_log_type_ = type;
        }

        public int SetLogType(int type)
        {
            if (type >= 0 && type <= (int)LOG_TYPE.VERBOSE)
            {
                Information("Current log type changed from (" + current_log_type_.ToString() + ") to (" + type.ToString() + ")");
                current_log_type_ = (LOG_TYPE)type;
                return 1;
            }
            else
            {
                Error("Impossible change the current log type because the type does not exist : (" + type.ToString() + ")");
                return 0;
            }
        }

        public static void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            LogMsg(msg, LOG_TYPE.ERROR);
        }

        public static void Warning(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            LogMsg(msg, LOG_TYPE.WARNING);
        }

        public static void Information(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            LogMsg(msg, LOG_TYPE.INFO);
        }

        public static void Verbose(string msg)
        {
            LogMsg(msg, LOG_TYPE.VERBOSE);
        }

        private static void LogMsg(string msg, LOG_TYPE type)
        {
            if (type <= current_log_type_)
            {
                DateTime date_time = new DateTime();
                string date = "[" + date_time.Year.ToString() + "/" + date_time.Month.ToString() + "/" + date_time.Day.ToString() + "]";
                string time = "[" + date_time.Hour.ToString() + ":" + date_time.Minute.ToString() + ":" + date_time.Second.ToString() + ":" + date_time.Millisecond.ToString() + "]";
                string log_type = "[" + type.ToString() + "]";
                Console.WriteLine(date + time + msg);
            }
            Console.ResetColor();
        }
    }
}
