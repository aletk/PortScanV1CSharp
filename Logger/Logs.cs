using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using PortScan;
using PortScan.Logger;
using System;
using System.IO;

namespace PortScan
{

    class Logs : ILogger
    {

        private readonly string Name;
        private readonly LoggerConfiguration _config;
        private readonly object Lock = new object();

        public Logs(string name, LoggerConfiguration config)
        {
            Name = name;
            _config = config;
        }


        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => logLevel >= _config.MinimumLogLevel;


        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var message = formatter(state, exception);

            lock (Lock)
            {
                if (_config.LogToConsole)
                {
                    Console.WriteLine($"[{logLevel}] - {Name}: {message}");
                }

                if (!string.IsNullOrEmpty(_config.LogFileName)) 
                {
                    File.AppendAllText(_config.LogFileName, $"[{DateTime.Now}] - [{logLevel}] - {Name}: {message}{Environment.NewLine}");
                }
            }
        }
    }
}