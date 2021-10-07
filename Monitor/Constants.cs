
namespace Observing
{
    public static class Constants
    {
        //User messages
        public const string MSG = "Monitoring";
        public const string ENDING_MSG = "Closing process in ";
        public const string WARNING = "This utility should only take 3 arguments!";
        public const string HELP = "This utility is monitoring life time of tasks and application that running in windows enviroment." +
            "\nWhrite your arguments in following order: monitor.exe ApplicationName LifeTime(minutes) CheckTime(minutes).";
        public const string FORMAT = "Name WholeNumber WholeNumber";
        
        internal const int MINUTE = 60000; //this constant can be changed for DEBUG perpouses

    }
}
