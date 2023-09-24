using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;

namespace PortScan.IpDect
{
    public class DnsResolver
    {
        public string HostDns { get; set; }
        public string ResolvedDns { get; set; }
        public bool UseIpv6 { get; set; }


        public DnsResolver(string dns, bool useIpv6 = false)
        {
            HostDns = dns;
            ResolvedDns = ResolveDns(useIpv6);
        }

        private string ResolveDns(bool useIpv6)
        {
            try
            {
                var addressFamily = useIpv6 ? AddressFamily.InterNetworkV6 : AddressFamily.InterNetwork;
                var addresses = Dns.GetHostAddresses(HostDns);
                var address = addresses.FirstOrDefault(addr => addr.AddressFamily == addressFamily)
                              ?? addresses.FirstOrDefault();

                return address == null ? throw new DnsResolutionException("No IP addresses found.") : address.ToString();
            }
            catch (SocketException ex)
            {
                throw new DnsResolutionException($"SocketException: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new DnsResolutionException($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
    public class DnsResolutionException : Exception
    {
        public DnsResolutionException(string message) : base(message)
        {
        }
    }

    public class InvalidIpAddressException : Exception
    {
        public InvalidIpAddressException(string message) : base(message)
        {
        }
    }
}
