using System.Windows.Forms;
using System;
using PortScan.Controllers;
using TypeScanConst;
using PortScan.Forms;

namespace PortScan
{


    class Program
    {
        [STAThread]
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

            //var ping = new Controller("192.168.0.0/24", TypeScan.ICMP);
            //ping.ExecController();
            //Console.ReadKey();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PortScanUI());
        }
    }
}
