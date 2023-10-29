using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using Microsoft.Extensions.Logging;
using PortScan.Logger;
using PortScan.ConstructIp;

namespace PortScan.IpDect
{
    public static class DnsResolver
    {
        private static readonly string TYPE_CLASS = "DnsResolver";
        private static readonly ILogger _log = new Logs(TYPE_CLASS, new LoggerConfiguration());

        public static IP ResolveDns(string hostDns, bool useIpv6 = false)
        {
            try
            {
                var addressFamily = useIpv6 ? AddressFamily.InterNetworkV6 : AddressFamily.InterNetwork;
                var addresses = Dns.GetHostAddresses(hostDns);

                var address = addresses.FirstOrDefault(addr => addr.AddressFamily == addressFamily).ToString()
                            ?? addresses.FirstOrDefault().ToString();

                if (string.IsNullOrEmpty(address))
                    throw new DnsResolutionException("No IP addresses found.");

                return ReturnIPResolve(address, useIpv6);
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

        private static IP ReturnIPResolve(string ipaddress, bool useIpv6)
        {
            IP ip;

            if (useIpv6)
                ip = new Ipv6() { Ip = ipaddress };
            else
                ip = new Ipv4() { Ip = ipaddress };

            return ip;
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

