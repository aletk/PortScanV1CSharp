using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using PortScan.ConstructIp;

using System.Text.RegularExpressions;
using System.Net.Sockets;
using PortScan.Extensions;

namespace PortScan.IpDect
{
    class IpGenerator
    {
        public List<IP> IpList { get; private set; }
        public IP HostNameResolve { get; set; }
        private string HostNameOrIp { get; set; }
        private const string DEFAULT_IP_RANGE = "0/24";

        public IpGenerator(string hostNameOrIp)
        {
            HostNameOrIp = hostNameOrIp;
            IpList = GenerateIpList();
        }

        public List<IP> GenerateIpList()
        {
            var ipList = new List<IP>();
            try
            {
                ResolveHost(false);

                if (HostNameResolve.IsValidIp())
                    ipList.AddRange(GenerateListIpAddresse(HostNameResolve, DEFAULT_IP_RANGE));
            }
            catch (DnsResolutionException ex)
            {
                Console.WriteLine($"DnsResolutionException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            return ipList;
        }

        private void ResolveHost(bool useIpv6)
        {
            if (IsHostName(HostNameOrIp))
                HostNameResolve = DnsResolver.ResolveDns(HostNameOrIp, useIpv6);
            else
                HostNameResolve = new Ipv4(HostNameOrIp);
        }
        private bool IsHostName(string input)
        {
            string pattern = "[a-zA-Z]";
            var regex = new Regex(pattern);
            return regex.IsMatch(input);
        }

        private List<IP> GenerateListIpAddresse(IP baseIp, string ipRange)
        {
            var ListIpAddresses = new List<IP>();

            CropIpAddress(baseIp.Ip, out string rangeip, out string cutIp);

            if (rangeip == ipRange)
            {
                var ipRangeList = Enumerable.Range(0, 255).ToList();

                ipRangeList.ForEach(range => ListIpAddresses.Add(new Ipv4() { Ip = $"{cutIp}.{range}", ListPorta = GetDefaultDoors() })); ;
                return ListIpAddresses;
            }
            ListIpAddresses.Add(new Ipv4(baseIp.Ip) { ListPorta = GetDefaultDoors() });


            return ListIpAddresses;
        }

        private void CropIpAddress(string baseIp, out string range, out string cutIp)
        {
            var octets = baseIp.Split('.').ToList();
            range = octets.LastOrDefault();
            octets.RemoveAt(3);
            cutIp = string.Join(".", octets);
        }

        private List<int> GetDefaultDoors() => new List<int> { 80, 443, 22, 21, 20, 25, 53, 110, 143, 445, 3389 };



    }
}
