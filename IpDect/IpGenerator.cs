using System;
using System.Collections.Generic;
using System.Linq;
using PortScan.ConstructIp;
using System.Text.RegularExpressions;
using PortScan.Extensions;
using TypeScanConst;
using Microsoft.Extensions.Logging;

namespace PortScan.IpDect
{
    class IpGenerator
    {
        private const string DEFAULT_IP_RANGE = "0/24";
        private string _hostNameOrIp { get; set; }
        private TypeScan _typeScan { get; set; }
        public IP HostNameResolve { get; set; }
        public List<IP> IpList { get; private set; }
        protected ILogger _logger;

        public IpGenerator(string hostNameOrIp, TypeScan typeScan, ILogger logger)
        {
            _hostNameOrIp = hostNameOrIp;
            _typeScan = typeScan;
            IpList = GenerateIpList();
            _logger = logger;
        }

        public List<IP> GenerateIpList()
        {
            var ipList = new List<IP>();
            try
            {
                ResolveHost(false);

                if (HostNameResolve.IsValidIp())
                    ipList.AddRange(GenerateListIpAddresse(HostNameResolve, DEFAULT_IP_RANGE, _typeScan));
            }
            catch (DnsResolutionException ex)
            {
                _logger.LogError($"DnsResolutionException: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"An unexpected error occurred:: {ex.Message}");
            }

            return ipList;
        }

        private void ResolveHost(bool useIpv6)
        {
            if (IsHostName(_hostNameOrIp))
                HostNameResolve = DnsResolver.ResolveDns(_hostNameOrIp, useIpv6);
            else
                HostNameResolve = new Ipv4(_hostNameOrIp, _typeScan);
        }

        private bool IsHostName(string input)
        {
            const string PATTERN_REGEX = "[a-zA-Z]";
            var regex = new Regex(PATTERN_REGEX);

            return regex.IsMatch(input);
        }

        private List<IP> GenerateListIpAddresse(IP baseIp, string ipRange, TypeScan typeScan)
        {
            var ListIpAddresses = new List<IP>();

            var ipCutOff = CropIpAddress(baseIp.Ip);

            if (ipCutOff.range == ipRange)
            {
                var ipRangeList = Enumerable.Range(0, 255).ToList();
                ipRangeList.ForEach(range => ListIpAddresses.Add(new Ipv4(typeScan) { Ip = $"{ipCutOff.cutIp}.{range}", ListPorta = GetDefaultDoors() })); ;

                return ListIpAddresses;
            }
            ListIpAddresses.Add(new Ipv4(baseIp.Ip, typeScan) { ListPorta = GetDefaultDoors() });

            return ListIpAddresses;
        }

        private (string range, string cutIp) CropIpAddress(string baseIp)
        {
            var octets = baseIp.Split('.').ToList();
            var range = octets.LastOrDefault();
            octets.RemoveAt(3);
            var cutIp = string.Join(".", octets);

            return (range, cutIp);
        }

        private List<int> GetDefaultDoors() => new List<int> { 80, 443, 22, 21, 20, 25, 53, 110, 143, 445, 3389 };

    }
}
