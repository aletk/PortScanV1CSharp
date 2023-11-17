using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using TypeScanConst;

namespace PortScan.ConstructIp
{
    public class Ipv4 : IIP
    {
        AddressFamily IIP.FamilyAddress => AddressFamily.InterNetwork;
        public List<int> ListPorta { get; set; }
        public string Ip { get; set; }
        private TypeScan _typeScan { get; set; }
        TypeScan IIP.TypeScan { get => _typeScan; set => _typeScan = value; }
        public string openPorts
        {
            get;
            set;
        }

        public Ipv4() { }

        public Ipv4(TypeScan typeScan)
        {
            _typeScan = typeScan;
        }

        public Ipv4(string ip, TypeScan typeScan)
        {
            Ip = ip;
            _typeScan = typeScan;
        }
    }
}
