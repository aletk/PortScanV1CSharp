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
        public string IP { get; set; }
        public string TypeScan { get; set; }

        public Controller(string ipscan, string typescan)
        {
            IP = ipscan;
            TypeScan = typescan;
        }

        public async Task ExecController()
        {
            ILogger _log = new Logs(TypeScan, new LoggerConfiguration());

            PingScan ping = new PingScan(IP, _log);

            var tasks = new List<Task>();

            foreach (var ip in ping.IpList)
            {
                foreach (var port in ip.ListPorta)
                {
                    tasks.Add(ping.PingIpAsync(ip.Ip, port));
                }
            }

            await Task.WhenAll(tasks);
            _log.LogInformation("Verificação de portas concluída.");
        }
    }
}
