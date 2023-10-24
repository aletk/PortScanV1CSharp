using Microsoft.Extensions.Logging;
using PortScan.IpDect;
using PortScan.Logger;
using System;
using TypeScanConst;

namespace PortScan.Controllers
{
    public class Controller
    {
        private readonly ILogger _log;
        public string _typeScan = string.Empty ;
        public string IP { get; set; }

        public Controller(string ipscan, string typescan)
        {
            IP = ipscan;
            _typeScan = typescan;
            _log = new Logs(typescan, new LoggerConfiguration());
        }

        public void ExecController()
        {
            switch (_typeScan)
            {
                case TypeScan.TCP:
                    PingScan pingTcp = new PingScan(IP, _log);
                    pingTcp.ExecScan();
                    break;
                
                case TypeScan.ICMP:
                    PingScan pings = new PingScan(IP, _log);
                    pings.ExecScan();
                    break;
            }
        }
    }
}
