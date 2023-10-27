﻿using Microsoft.Extensions.Logging;
using PortScan.IpDect;
using System;
using System.Runtime.InteropServices;
using PortScan.Logger;
using PortScan.Controllers;
using TypeScanConst;

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

            var ping = new Controller("172.16.26.0/24",TypeScan.ICMP);
            ping.ExecController();
            Console.ReadKey();

        }
    }
}
