﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Division42.NetworkTools;

namespace NirSoftNetTools
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            WhoisResult_TextBox.Clear();
            WhoisResult_TextBox.Text = WhoisService.WhoIs(domainName_TextBox.Text);
        }

        private void TraceRoute_Button_Click(object sender, EventArgs e)
        {
            string[] buffer = new string[TR_ListView.Columns.Count];
            int counter = 1;
            foreach (var info in TraceRoute.GetTraceRoute(TR_InputTextBox.Text))
            {
                buffer[0] = counter++.ToString();
                buffer[1] = info.ElapsedTime.ToString();
                buffer[2] = info.IP.ToString();
               
                TR_ListView.Items.Add(new ListViewItem(buffer));
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string mac = textBox3.Text;
            textBox4.Text = VendorMAC.VendMAC(mac);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string Number = textBox5.Text;
            textBox6.Text = Operator.OpMobNUM(Number);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
            string BIN = textBox8.Text;
            string[] res = BINCARD.BankByBIN(BIN);
            textBox7.Text += "Платёжная система: " + res[0] + Environment.NewLine;
            textBox7.Text += "Страна: " + res[1] + Environment.NewLine;
            textBox7.Text += "Банк: " + res[2] + Environment.NewLine;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            string Number = textBox5.Text;
            textBox6.Text = Operator.OpNUM(Number);
        }

        private void Resolver_Button_Click(object sender, EventArgs e)
        {
            string data = Resolver_InputTB.Text;

            string[] buffer = new string[Resolver_listView.Columns.Count];

            IPAddress ip;
            if (IPAddress.TryParse(data, out ip)) {
                string domain = NTResolver.IPToDomain(ip);
                buffer[0] = ip.ToString();
                buffer[1] = data;
                Resolver_listView.Items.Add(new ListViewItem(buffer));
            }
            else {
                IPAddress[] list = NTResolver.DomainToIP(data);
                foreach (var item in list) {
                    buffer[0] = data;
                    buffer[1] = item.ToString();
                    Resolver_listView.Items.Add(new ListViewItem(buffer));
                }
            }
        }

        private void IMEI_button_Click(object sender, EventArgs e)
        {
            string[] result = VendorIMEI.Lookup(IMEI_input_tb.Text);
            if (result != null)
                IMEI_ListView.Items.Add(new ListViewItem(result));
            else
                MessageBox.Show("IMEI не найден.");
        }
    }
}
