using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace GTX_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            try
            {
                bool isRead = cmbMode.SelectedItem.ToString() == "READ";
                int pc = int.Parse(txtPCNo.Text);
                int unit = int.Parse(txtUnitNo.Text);
                int step = int.Parse(txtStepNo.Text);
                string addr = txtAddress.Text.Trim();
                int count = int.Parse(txtCount.Text);

                string hexFrame = BuildGTXFrame(isRead, pc, unit, step, addr, count);
                txtTxLog.AppendText(FormatHexWithSpace(hexFrame) + Environment.NewLine);

                byte[] data = HexToBytes(hexFrame);

                using (TcpClient client = new TcpClient(txtIP.Text.Trim(), int.Parse(txtPort.Text.Trim())))
                using (NetworkStream stream = client.GetStream())
                {
                    stream.Write(data, 0, data.Length);

                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string rx = BitConverter.ToString(buffer, 0, bytesRead).Replace("-", " ");
                    txtRxLog.AppendText(rx + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        string FormatHexWithSpace(string hex)
        {
            hex = hex.Replace(" ", "");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hex.Length; i += 2)
            {
                if (i > 0) sb.Append(" ");
                sb.Append(hex.Substring(i, Math.Min(2, hex.Length - i)));
            }
            return sb.ToString().ToUpper();
        }
        private string BuildGTXFrame(bool isRead, int pcNo, int unitNo, int stepNo, string addr, int count)
        {
            string cmd = isRead ? "0F" : "10";
            string pc = pcNo.ToString("X2");
            string unit = unitNo.ToString("X2");
            string step = stepNo.ToString("X2");
            string cnt = count.ToString("X4");

            string addrCode = "";
            addr = addr.ToUpper();
            if (addr.StartsWith("D"))
                addrCode = "D" + int.Parse(addr.Substring(1)).ToString("D3");
            else if (addr.StartsWith("M"))
                addrCode = "M" + int.Parse(addr.Substring(1)).ToString("D3");
            else
                throw new Exception("Địa chỉ phải bắt đầu bằng D hoặc M");

            string payload = cmd + pc + unit + step + cnt + addrCode;
            string asciiPayload = ToAsciiHex(payload);
            string full = "02" + asciiPayload + "03";

            byte[] forBCC = HexToBytes(full);
            byte bcc = 0;
            foreach (var b in forBCC)
                bcc ^= b;

            return full + bcc.ToString("X2");
        }

        private string ToAsciiHex(string hex)
        {
            var sb = new StringBuilder();
            foreach (char c in hex)
                sb.Append(((byte)c).ToString("X2"));
            return sb.ToString();
        }

        private byte[] HexToBytes(string hex)
        {
            hex = hex.Replace(" ", "");
            int len = hex.Length;
            byte[] bytes = new byte[len / 2];
            for (int i = 0; i < len; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
    }
}
