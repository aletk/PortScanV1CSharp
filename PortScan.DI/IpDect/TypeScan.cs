using PortScan.Converts;
using System;
using System.ComponentModel;

namespace TypeScanConst
{
    public enum TypeScan
    {
        [Description("TCP")]
        TCP,

        [Description("UDP")]
        UDP,

        [Description("ICMP")]
        ICMP,
    }
}