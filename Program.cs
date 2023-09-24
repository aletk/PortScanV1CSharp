using PortScan.IpDect;
using System;

namespace PortScan
{


    class Program
    {
        static void Main()
        {
            var ips = new IpGenerator("192.168.0.0/24");
            
            foreach (var ip in ips.IpList)
            {
                Console.WriteLine(ip.Ip);
            }

            Console.ReadKey();
        }
    }
}
