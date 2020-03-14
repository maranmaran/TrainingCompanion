namespace Backend.Library.Logging.Models
{
    public class LogLevelSettings
    {
        public string Default { get; set; }
    }

    public enum LogLevel
    {
        Trace = 0,
        Debug = 1,
        Warn = 2,
        Info = 3,
        Error = 4,
        Fatal = 5
    }
}
