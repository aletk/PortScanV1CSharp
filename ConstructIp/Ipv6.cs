using System.Collections.Generic;
using System.Net.Sockets;
using TypeScanConst;

namespace PortScan.ConstructIp
{
    internal class Ipv6 : IP
    {
        AddressFamily IP.FamilyAddress => AddressFamily.InterNetworkV6;
        public List<int> ListPorta { get; set; }
        public string Ip { get; set; }
        public TypeScan ScanType { get; set; }
        public Ipv6() { }
        public Ipv6(string ip)
        {
            Ip = ip;
        }
    }
}
