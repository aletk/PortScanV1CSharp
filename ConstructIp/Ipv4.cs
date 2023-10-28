using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TypeScanConst;

namespace PortScan.ConstructIp
{
    public class Ipv4 : IP
    {
        AddressFamily IP.FamilyAddress => AddressFamily.InterNetwork;
        public List<int> ListPorta { get; set; }
        public string Ip { get; set; }
        private TypeScan _typeScan { get; set; }
        TypeScan IP.TypeScan { get => _typeScan; set => _typeScan = value; }

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
