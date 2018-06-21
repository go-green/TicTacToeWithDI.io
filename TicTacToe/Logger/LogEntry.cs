using System;


namespace TicTacToe.Core.Logger
{
    public class LogEntry
    {
        public LoggingEventType Severity;
        public string Message;
        public Exception Exception;

        public LogEntry(LoggingEventType severity, string message, Exception exception = null)
        {
            if (message == null) throw new ArgumentNullException("message");
            if (message == string.Empty) throw new ArgumentException("empty", "message");

            this.Severity = severity;
            this.Message = message;
            this.Exception = exception;
        }
    }
}
