using PortScan.ConstructIp;
using PortScan.IpDect;
using System.Net;
using System.Windows.Forms;

namespace PortScan.Extensions
{
    public static class IpExtensions
    {
        /// <summary>
        /// Valida se é um IP valido. . 
        /// </summary>
        public static bool IsValidIp(this IIP ip)
        {
            const string DEFAULT_IP_RANGE = "/24";

            if (ip.Ip.Contains(DEFAULT_IP_RANGE))
                return true;

            if (IPAddress.TryParse(ip.Ip, out _))
                return true;

            MessageBox.Show($"Invalid IP address: {ip.Ip}", "Invalid IP Address", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
}