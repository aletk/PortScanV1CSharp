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
        private TypeScan _typeScan {get; set;}
        public string IP { get; set; }

        public Controller(string ipscan, TypeScan typescan)
        {
            IP = ipscan;
            _typeScan = typescan;
            _log = new Logs(typescan.GetDescription(), new LoggerConfiguration());
        }

        public void ExecController()
        {
            if(_typeScan == TypeScan.TCP ||  _typeScan == TypeScan.ICMP)
            {
                PingScan pingTcp = new PingScan(IP, _typeScan, _log);
                pingTcp.ExecScan();
            }
        }
    }
}
