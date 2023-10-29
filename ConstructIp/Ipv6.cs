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
        private TypeScan _typeScan { get; set; }
        TypeScan IP.TypeScan { get => _typeScan; set => _typeScan = value; }
        public string openPorts
        {
            get
            {
                return string.Join(";", ListPorta);
            }
            set { }
        }

        public Ipv6() { }
        public Ipv6(string ip, TypeScan typeScan)
        {
            Ip = ip;
            _typeScan = typeScan; 
        }
    }
}
