using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TypeScanConst;

namespace PortScan.ConstructIp
{
    internal class Ipv4 : IP
    {
        AddressFamily IP.FamilyAddress => AddressFamily.InterNetwork;
        public List<int> ListPorta { get; set; }
        public string Ip { get; set; }
        public TypeScan ScanType { get; set; }

        public Ipv4() { }
        public Ipv4(string ip)
        {
            Ip = ip;
        }
    }
}
