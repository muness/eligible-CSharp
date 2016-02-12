using NLog;
using NLog.Config;
using NLog.Targets;

namespace EligibleService.Common
{
    public class Logging
    {
        public Logging()
        {
            var config = new LoggingConfiguration();
           
            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);
            fileTarget.FileName = "${basedir}/Logs/EligibleLog.log";
            fileTarget.ArchiveEvery = FileArchivePeriod.Day;
            fileTarget.MaxArchiveFiles = 10;
            fileTarget.Footer = "${newline}";
            fileTarget.ConcurrentWrites = true;
            fileTarget.KeepFileOpen = false;
            fileTarget.ArchiveFileName = "${basedir}/Logs/Archives/EligibleLog.{#}.log";
            fileTarget.ArchiveNumbering = ArchiveNumberingMode.DateAndSequence;
            fileTarget.ArchiveDateFormat = "yyyy-MM-dd";
            fileTarget.Layout = @"${date:format=yyyy-MM-dd HH\:mm\:ss} ${logger} ${level}: ${message} ${newline}";

            var fileRule = new LoggingRule("*", LogLevel.Info, fileTarget);
            config.LoggingRules.Add(fileRule);

            var consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);
            consoleTarget.Footer = "${newline}";
            consoleTarget.Layout = @"${date:format=yyyy-MM-dd HH\:mm\:ss} ${logger} ${level}: ${message}";

            var consoleRule = new LoggingRule("*", LogLevel.Info, consoleTarget);
            config.LoggingRules.Add(consoleRule);

            DebugTarget = new DebugTarget();
            DebugTarget.Layout = @"${message}";

            var debugRule = new LoggingRule("*", LogLevel.Error, DebugTarget);
            config.LoggingRules.Add(debugRule);

            LogManager.Configuration = config;
        }

        public static DebugTarget DebugTarget { get; set; }

        public static string GetLastMessage()
        {
            return DebugTarget.LastMessage;
        }
    }
}
