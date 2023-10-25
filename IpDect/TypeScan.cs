using PortScan.Converts;
using System;
using System.ComponentModel;

namespace TypeScanConst
{
    public static class TypeScans
    {
        public const string TCP = "TCP";
        public const string UDP = "UDP";
        public const string ICMP = "ICMP";
    }

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