﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using TypeScanConst;

namespace PortScan.ConstructIp
{
    public interface IP
    {
        List<int> ListPorta { get; set; }
        string Ip { get; set; }
        AddressFamily FamilyAddress { get; }
       TypeScan ScanType { get; set; }
    }
}
