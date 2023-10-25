using Microsoft.Extensions.Logging;
using PortScan.Converts;
using PortScan.IpDect;
using PortScan.Logger;
using System;
using System.ComponentModel.DataAnnotations;
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
            const string TCP = "TCP";
            const string ICMP = "ICMP";

            switch (_typeScan)
            {//TypeScan.TCP.GetDescription()
                case TCP:
                    PingScan pingTcp = new PingScan(IP, _log);
                    pingTcp.ExecScan();
                    break;
                
                case ICMP:
                    PingScan pings = new PingScan(IP, _log);
                    pings.ExecScan();
                    break;
            }
        }
    }
}
