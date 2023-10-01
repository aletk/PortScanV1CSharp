using Microsoft.Extensions.Logging;
using PortScan.IpDect;
using System;
using System.Runtime.InteropServices;
using PortScan.Logger;
using PortScan.Controllers;

namespace PortScan
{


    class Program
    {
        static void Main()
        {
            //var ips = new IpGenerator("192.168.0.0/24");

            //foreach (var ip in ips.IpList)
            //{
            //    Console.WriteLine(ip.Ip);
            //}

            //var dns = new DnsResolver("inventsoftware.com.br");

            //var ips = dns.ResolveMyLocalIp();

            //foreach (var ip in ips)
            //{
            //    Console.WriteLine(ip.ToString());
            //}
            //Console.ReadKey();

            ILogger _log = new Logs("ScanTcp", new LoggerConfiguration());

            var ping = new Controller("192.168.0.0/24", "TCP");
            _ = ping.ExecController();
            Console.ReadKey();

        }
    }
}
