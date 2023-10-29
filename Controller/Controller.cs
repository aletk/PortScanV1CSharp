using Microsoft.Extensions.Logging;
using PortScan.ConstructIp;
using PortScan.Converts;
using PortScan.IpDect;
using PortScan.Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
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

        public async Task<List<IP>> ExecController()
        {
            if(_typeScan == TypeScan.TCP ||  _typeScan == TypeScan.ICMP)
            {
                PingScan pingTcp = new PingScan(IP, _typeScan, _log);

                return await pingTcp.ExecScan();
            }
            return new List<IP>();
        }
    }
}
