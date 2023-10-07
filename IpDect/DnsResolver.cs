using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.Runtime.Remoting.Messaging;
using Microsoft.Extensions.Logging;
using PortScan.Logger;

namespace PortScan.IpDect
{
    public static class DnsResolver
    {
        static readonly string TYPE_CLASS = "DnsResolver";
        static readonly ILogger _log = new Logs(TYPE_CLASS, new LoggerConfiguration());
        public static string ResolveDns(string hostDns, bool useIpv6 = false)
        {
            try
            {
                var addressFamily = useIpv6 ? AddressFamily.InterNetworkV6 : AddressFamily.InterNetwork;
                var addresses = Dns.GetHostAddresses(hostDns);

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

        public static List<IPAddress> ResolveMyLocalIp()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                _log.LogError("No Network Available");

            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            var ipv4Addresses = ipEntry.AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToList();

            if (ipv4Addresses.Any())
                return ipv4Addresses;
            else
                throw new InvalidIpAddressException("Endereço IP local não encontrado.");
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

