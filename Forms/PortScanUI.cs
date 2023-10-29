using PortScan.Controllers;
using PortScan.Converts;
using PortScan.IpDect;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;
using TypeScanConst;

namespace PortScan.Forms
{
    public partial class PortScanUI : Form
    {
        public PortScanUI()
        {
            InitializeComponent();
        }

        private async void StartScanButton_Click(object sender, EventArgs e)
        {
            var myIp = MyIpTextBox.Text.Trim();
            if (string.IsNullOrEmpty(myIp))
            {
                MessageBox.Show("O endereço de IP vazio, é preciso preencher ou dar um get no seu ip");
                return;
            }

            var radioButtonSelecionado = Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).AccessibleName.To<int>();

            var controller = new Controller(myIp, (TypeScan)radioButtonSelecionado);
            var result = await controller.ExecController();
            
            IpsOpenPanel.DataSource = null;
            IpsOpenPanel.AutoGenerateColumns = true;
            IpsOpenPanel.AutoResizeColumns();

            IpsOpenPanel.DataSource = result ;

        }

        private void MyIpButton_Click(object sender, EventArgs e)
        {
            var t = DnsResolver.ResolveMyLocalIp();
            MyIpTextBox.Text = t.FirstOrDefault().ToString();
        }
    }
}
