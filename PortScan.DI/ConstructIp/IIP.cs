using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using TypeScanConst;

namespace PortScan.ConstructIp
{
    /// <summary>
    /// Essa interface é a representação de uma IP. 
    /// </summary>
    public interface IIP
    {
        List<int> ListPorta { get; set; }
        string Ip { get; set; }
        string openPorts { get; set; }
        AddressFamily FamilyAddress { get; }
        TypeScan TypeScan { get; set; }
    }
}
