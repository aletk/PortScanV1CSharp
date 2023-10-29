namespace PortScan.Forms
{
    partial class PortScanUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tcpRadioButton = new System.Windows.Forms.RadioButton();
            this.IpsOpenPanel = new System.Windows.Forms.DataGridView();
            this.icmpRadioButton = new System.Windows.Forms.RadioButton();
            this.StartScanButton = new System.Windows.Forms.Button();
            this.MyIpButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MyIpTextBox = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.IpsOpenPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // tcpRadioButton
            // 
            this.tcpRadioButton.AccessibleDescription = "0";
            this.tcpRadioButton.AutoSize = true;
            this.tcpRadioButton.Location = new System.Drawing.Point(355, 231);
            this.tcpRadioButton.Name = "tcpRadioButton";
            this.tcpRadioButton.Size = new System.Drawing.Size(46, 17);
            this.tcpRadioButton.TabIndex = 1;
            this.tcpRadioButton.TabStop = true;
            this.tcpRadioButton.Text = "TCP";
            this.tcpRadioButton.UseVisualStyleBackColor = true;
            // 
            // IpsOpenPanel
            // 
            this.IpsOpenPanel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IpsOpenPanel.Location = new System.Drawing.Point(12, 42);
            this.IpsOpenPanel.Name = "IpsOpenPanel";
            this.IpsOpenPanel.Size = new System.Drawing.Size(337, 259);
            this.IpsOpenPanel.TabIndex = 2;
            // 
            // icmpRadioButton
            // 
            this.icmpRadioButton.AccessibleName = "2";
            this.icmpRadioButton.AutoSize = true;
            this.icmpRadioButton.Location = new System.Drawing.Point(355, 254);
            this.icmpRadioButton.Name = "icmpRadioButton";
            this.icmpRadioButton.Size = new System.Drawing.Size(51, 17);
            this.icmpRadioButton.TabIndex = 5;
            this.icmpRadioButton.TabStop = true;
            this.icmpRadioButton.Text = "ICMP";
            this.icmpRadioButton.UseVisualStyleBackColor = true;
            // 
            // StartScanButton
            // 
            this.StartScanButton.Location = new System.Drawing.Point(355, 277);
            this.StartScanButton.Name = "StartScanButton";
            this.StartScanButton.Size = new System.Drawing.Size(78, 24);
            this.StartScanButton.TabIndex = 7;
            this.StartScanButton.Text = "Start Scan";
            this.StartScanButton.UseVisualStyleBackColor = true;
            this.StartScanButton.Click += new System.EventHandler(this.StartScanButton_Click);
            // 
            // MyIpButton
            // 
            this.MyIpButton.Location = new System.Drawing.Point(355, 12);
            this.MyIpButton.Name = "MyIpButton";
            this.MyIpButton.Size = new System.Drawing.Size(85, 24);
            this.MyIpButton.TabIndex = 9;
            this.MyIpButton.Text = "Get My Ip ";
            this.MyIpButton.UseMnemonic = false;
            this.MyIpButton.UseVisualStyleBackColor = true;
            this.MyIpButton.Click += new System.EventHandler(this.MyIpButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MyIpTextBox
            // 
            this.MyIpTextBox.Location = new System.Drawing.Point(12, 12);
            this.MyIpTextBox.Name = "MyIpTextBox";
            this.MyIpTextBox.Size = new System.Drawing.Size(337, 20);
            this.MyIpTextBox.TabIndex = 11;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(355, 208);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(82, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Scan All Ips";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // PortScanUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 310);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.MyIpTextBox);
            this.Controls.Add(this.MyIpButton);
            this.Controls.Add(this.StartScanButton);
            this.Controls.Add(this.icmpRadioButton);
            this.Controls.Add(this.IpsOpenPanel);
            this.Controls.Add(this.tcpRadioButton);
            this.Name = "PortScanUI";
            this.Text = "PortScanUII";
            ((System.ComponentModel.ISupportInitialize)(this.IpsOpenPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton tcpRadioButton;
        private System.Windows.Forms.DataGridView IpsOpenPanel;
        private System.Windows.Forms.RadioButton icmpRadioButton;
        private System.Windows.Forms.Button StartScanButton;
        private System.Windows.Forms.Button MyIpButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox MyIpTextBox;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}