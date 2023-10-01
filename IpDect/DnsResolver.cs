using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;

namespace PortScan.IpDect
{
    public class DnsResolver
    {
        public string HostDns { get; set; }
        public string ResolvedDns { get; set; }
        public bool UseIpv6 { get; set; }
        public string MyHost { get; set; } = string.Empty;

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

                return string.IsNullOrEmpty(address.ToString())
                        ? throw new DnsResolutionException("No IP addresses found.")
                        : address.ToString();
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

        public List<IPAddress> ResolveMyLocalIp()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                Console.WriteLine("No Network Available");
            }

            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());

            var ipv4Addresses = ipEntry.AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToList();

            if (ipv4Addresses.Any())
            {
                return ipv4Addresses;
            }
            else
            {
                throw new Exception("Endereço IP local não encontrado.");
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

