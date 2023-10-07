using Microsoft.Extensions.Logging;
using PortScan.IpDect;
using PortScan.Logger;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortScan.Controllers
{
    public class Controller
    {
        private readonly ILogger _log;
        public string IP { get; set; }

        public Controller(string ipscan, string typescan)
        {
            IP = ipscan;
            _log = new Logs(typescan, new LoggerConfiguration());
        }

        public void ExecController()
        {
            PingScan ping = new PingScan(IP, _log);
            ping.ExecScan();
        }
    }
}
