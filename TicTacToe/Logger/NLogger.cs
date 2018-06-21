using System;
using NLog;
using ILogger = TicTacToe.Core.Logger.Contracts.ILogger;

namespace TicTacToe.Core.Logger
{
    public class NLogger : ILogger
    {
        private NLog.Logger _logger;
        public NLogger()
        {
            _logger = NLog.LogManager.GetCurrentClassLogger();
        }

        public void Log(LogEntry entry)
        {
            switch (entry.Severity)
            {
                case LoggingEventType.Debug:
                    LogHelper(LogLevel.Debug, entry);
                    break;
                case LoggingEventType.Information:
                    LogHelper(LogLevel.Info, entry);
                    break;
                case LoggingEventType.Warning:
                    LogHelper(LogLevel.Warn, entry);
                    break;
                case LoggingEventType.Error:
                    LogHelper(LogLevel.Error, entry);
                    break;
                case LoggingEventType.Fatal:
                    LogHelper(LogLevel.Fatal, entry);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void LogHelper(LogLevel level, LogEntry entry)
        {
            if (entry.Exception != null)
            {
                _logger.Log(level, entry.Exception);
            }
            else
            {
                _logger.Log(level, entry.Message);
            }
        }
    }
}
