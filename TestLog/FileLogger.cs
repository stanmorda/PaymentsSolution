using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace TestLog
{
    public class FileLogger : ILogger, IDisposable
    {
        private readonly string _fileName;
        private readonly object _syncLogFile = new object();

        public FileLogger(string fileName)
        {
            _fileName = fileName;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return this;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            lock (_syncLogFile)
            {
                File.AppendAllText(_fileName, $"{formatter(state, exception)}{Environment.NewLine}");
            }
        }

        public void Dispose()
        {
            return;
        }
    }
}