using System.Windows.Forms;

namespace GTX_Client
{
    partial class Form1
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
            this.Text = "GTX Tool – Read/Write - Create by Do Duy Cop";
            this.Width = 640;
            this.Height = 600;

            // IP / Port
            Label lblIP = new Label { Text = "IP Address:", Left = 10, Top = 20,AutoSize=true };
            txtIP = new TextBox { Left = 100, Top = 18, Width = 100, Text = "192.168.1.2" };

            Label lblPort = new Label { Text = "Port:", Left = 220, Top = 20, AutoSize = true };
            txtPort = new TextBox { Left = 270, Top = 18, Width = 60, Text = "2004" };

            // Mode
            Label lblMode = new Label { Text = "Mode:", Left = 10, Top = 60, AutoSize = true };
            cmbMode = new ComboBox { Left = 100, Top = 58, Width = 100 };
            cmbMode.Items.AddRange(new[] { "READ", "WRITE" });
            cmbMode.SelectedIndex = 0;

            // PC No, Unit No, Step No
            Label lblPC = new Label { Text = "PC No:", Left = 220, Top = 60, AutoSize = true };
            txtPCNo = new TextBox { Left = 270, Top = 58, Width = 40, Text = "0" };

            Label lblUnit = new Label { Text = "Unit No:", Left = 320, Top = 60, AutoSize = true };
            txtUnitNo = new TextBox { Left = 390, Top = 58, Width = 40, Text = "0" };

            Label lblStep = new Label { Text = "Step No:", Left = 440, Top = 60, AutoSize = true };
            txtStepNo = new TextBox { Left = 510, Top = 58, Width = 40, Text = "1" };

            // Address, Count
            Label lblAddr = new Label { Text = "Address (D/M):", Left = 10, Top = 100, AutoSize = true };
            txtAddress = new TextBox { Left = 130, Top = 98, Width = 100, Text = "D100" };

            Label lblCount = new Label { Text = "Count:", Left = 250, Top = 100, AutoSize = true };
            txtCount = new TextBox { Left = 310, Top = 98, Width = 60, Text = "2" };

            // Send button
            btnSend = new Button { Text = "Send", Left = 400, Top = 95, Width = 80, Height=30 };
            btnSend.Click += BtnSend_Click;

            // TX, RX logs
            Label lblTx = new Label { Text = "TX Frame:", Left = 10, Top = 140, AutoSize = true };
            txtTxLog = new TextBox { Left = 10, Top = 160, Width = 580, Height = 120, Multiline = true, ScrollBars = ScrollBars.Both };

            Label lblRx = new Label { Text = "RX Frame:", Left = 10, Top = 290, AutoSize = true };
            txtRxLog = new TextBox { Left = 10, Top = 310, Width = 580, Height = 200, Multiline = true, ScrollBars = ScrollBars.Both };

            this.Controls.AddRange(new Control[] {
                lblIP, txtIP, lblPort, txtPort,
                lblMode, cmbMode, lblPC, txtPCNo, lblUnit, txtUnitNo, lblStep, txtStepNo,
                lblAddr, txtAddress, lblCount, txtCount, btnSend,
                lblTx, txtTxLog, lblRx, txtRxLog
            });
        }

        #endregion

        private ComboBox cmbMode;
        private TextBox txtPCNo, txtUnitNo, txtStepNo, txtAddress, txtCount, txtIP, txtPort;
        private Button btnSend;
        private TextBox txtTxLog, txtRxLog;
    }
    
}

