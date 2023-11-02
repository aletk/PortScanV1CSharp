using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortScan.Logger
{
    public class LoggerConfiguration
    {
        public LogLevel MinimumLogLevel { get; set; } = LogLevel.Information;
        public bool LogToConsole { get; set; } = true;
        public string LogFileName { get; set; } = "log.txt";
    }
}
