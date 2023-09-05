using Microsoft.Extensions.Logging;

namespace TestLog
{
    public class FileLoggerProvider : ILoggerProvider
    {
        private readonly string _path;

        public FileLoggerProvider(string path)
        {
            _path = path;
        }

        public void Dispose()
        {
            return;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new FileLogger(_path);
        }
    }
}