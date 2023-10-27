using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PortScan.ConstructIp;
using TypeScanConst;

namespace PortScan.IpDect
{
    internal class PingScan : IpGenerator
    {
        private readonly ILogger _logger;
        private TypeScan _typeScan;

        public PingScan(string ipadress, TypeScan typeScan, ILogger logger)
            : base(ipadress, typeScan)
        {
            _typeScan = typeScan;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async void ExecScan()
        {
            var tasks = new List<Task>();
            switch (_typeScan)
            {
                case TypeScan.ICMP:
                    IpList.ForEach(ip => tasks.Add(PingIcmp(ip.Ip)));
                    break;

                case TypeScan.TCP:
                    IpList.ForEach(ip => ip.ListPorta.ForEach(port => tasks.Add(PingIpAsync(ip.Ip, port))));
                    break;
            }

            await Task.WhenAll(tasks);
            _logger.LogInformation("Verificação de portas concluída.");
        }

        public async Task PingIpAsync(string ipAddress, int port)
        {
            using (Socket sock = new Socket(SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    await sock.ConnectAsync(ipAddress, port);
                    _logger.LogInformation($"Porta Aberta: {port}, IP: {ipAddress}");
                }
                catch
                {
                    _logger.LogError($"Porta não encontrada: {port}, IP: {ipAddress}");
                }
            }
        }

        public async Task PingIcmp(string ipAddress)
        {
            Ping pingSender = new Ping();
            PingReply returnPing = await pingSender.SendPingAsync(ipAddress);

            if (returnPing.Status.ToString().Contains("Success"))
                _logger.LogInformation($"ping {returnPing.Status} : IP {returnPing.Address}");
        }

    }
}
