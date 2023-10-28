using PortScan.ConstructIp;
using PortScan.IpDect;
using System.Net;

namespace PortScan.Extensions
{
    public static class IpExtensions
    {
        public static bool IsValidIp(this IP ip)
        {
            const string DEFAULT_IP_RANGE = "0/24";

            if (ip.Ip.Contains(DEFAULT_IP_RANGE))
                return true;

            if (!IPAddress.TryParse(ip.Ip, out _))
                return true;

            throw new InvalidIpAddressException($"Invalid IP address: {ip.Ip}");
        }
    }
}