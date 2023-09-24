using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace PortScan.IpDect
{
    public class IP
    {
        public IP() { }
        public IP(string ip)
        {
            Ip = ip;
        }

        public List<int> ListPorta { get; set; }
        public string Ip { get; set; }

    }
}
