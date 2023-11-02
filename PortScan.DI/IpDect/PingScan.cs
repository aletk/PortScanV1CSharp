using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PortScan.ConstructIp;
using PortScan.Converts;
using TypeScanConst;

namespace PortScan.IpDect
{
    /// <summary>
    /// Classe responsável por realizar as operações de scan na rede de com requisições async. 
    /// </summary>
    internal class PingScan : IpGenerator
    {
        private TypeScan _typeScan;
        public List<IP> IpOpen = new List<IP>();

        public PingScan(string ipadress, TypeScan typeScan, ILogger logger)
            : base(ipadress, typeScan, logger)
        {
            _typeScan = typeScan;
        }

        /// <summary>
        /// Executa uma task de scan a partir do tipo solicitado pela usuário.
        /// </summary>
        public async Task<List<IP>> ExecScan()
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
            return IpOpen;
            // _logger.LogInformation("Verificação de portas concluída.");
        }

        /// <summary>
        /// Este método realiza uma ping utilizando o protocolo TCP em um ip e porta.
        /// </summary>
        public async Task PingIpAsync(string ipAddress, int port)
        {
            using (Socket sock = new Socket(SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    await sock.ConnectAsync(ipAddress, port);
                    IpOpen.Add(new Ipv4 { Ip = ipAddress, ListPorta = new List<int> { port }, openPorts = port.To<string>() });
                    _logger.LogInformation($"Porta Aberta: {port}, IP: {ipAddress}");
                }
                catch
                {
                    _logger.LogError($"Porta não encontrada: {port}, IP: {ipAddress}");
                }
            }
        }

        /// <summary>
        /// Este método manda um pacote ICMP (ping) para o ip passado, retornando os hosts que responderam ao pacote.
        /// </summary>
        public async Task PingIcmp(string ipAddress)
        {
            Ping pingSender = new Ping();
            PingReply returnPing = await pingSender.SendPingAsync(ipAddress);

            if (returnPing.Status.ToString().Contains("Success"))
            {
                IpOpen.Add(new Ipv4 (ipAddress, _typeScan));
                _logger.LogInformation($"ping {returnPing.Status} : IP {returnPing.Address}");
            }
        }

    }
}
