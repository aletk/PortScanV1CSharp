using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace PortScan.IpDect
{
    internal class PingScan : IpGenerator
    {
        private readonly ILogger _logger;

        public PingScan(string ipadress, ILogger logger)
            : base(ipadress)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
                    _logger.LogInformation($"Porta não encontrada: {port}, IP: {ipAddress}");
                }
            }
        }
    }
}
