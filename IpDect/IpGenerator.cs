using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Text.RegularExpressions;

namespace PortScan.IpDect
{
    class IpGenerator
    {
        public  List<IP> IpList { get; private set; }
        private string HostNameOrIp { get; set; }
        private const string DefaultIpRange = "0/24";
        private readonly List<int> ListDefaultDoors = new List<int> { 80, 443, 22, 21, 20, 25, 53, 110, 143, 445, 3389 };

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
                if (IsHostName(HostNameOrIp))
                {
                    var _dnsResolver = new DnsResolver(HostNameOrIp);
                    HostNameOrIp = _dnsResolver.ResolvedDns;
                }

                if (IsValidIp(HostNameOrIp))
                {
                    ipList.AddRange(GenerateIpAddresses(HostNameOrIp, DefaultIpRange));
                }
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

        private bool IsHostName(string input)
        {
            string pattern = "[a-zA-Z]";
            var regex = new Regex(pattern);
            return regex.IsMatch(input);
        }

        private bool IsValidIp(string input)
        {
            if (input.Contains(DefaultIpRange))
                return true;

            if (IPAddress.TryParse(input, out _))
                return true;

            throw new InvalidIpAddressException($"Invalid IP address: {input}");
        }

        private List<IP> GenerateIpAddresses(string baseIp, string ipRange)
        {
            var ListIpAddresses = new List<IP>();
            var octets = baseIp.Split('.').ToList();
            var range = octets.LastOrDefault();
            octets.RemoveAt(3);
            var cutIp = string.Join(".", octets);

            if (range == ipRange)
            {
                var ipRangeList = Enumerable.Range(0, 256).ToList();

                foreach (var rangeAdress in ipRangeList)
                {
                    ListIpAddresses.Add(new IP() { Ip = $"{cutIp}.{rangeAdress}", ListPorta = ListDefaultDoors });
                }
            }
            else
                ListIpAddresses.Add(new IP(baseIp) { ListPorta = GetDoorOrDefaultDoors() });

            return ListIpAddresses;
        }

        private List<int> GetDoorOrDefaultDoors()
        {
            return ListDefaultDoors;
        }
    }


}
