using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();
        }

        WCFService.WCFServicesClient client = new WCFService.WCFServicesClient();

        private void button1_Click(object sender, EventArgs e)
        {
            int i = client.BuyTickets(2);
            if (i == 1)
            {
                label1.Text = "购买成功\n" + "剩余车票：" + client.GetRemainingNum().ToString();
            }
            else
            {
                label1.Text = "购买失败,剩余车票不足！";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label1.Text = "剩余车票：" + client.GetRemainingNum().ToString();
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //cn.com.webxml.www.WeatherWebService w = new Client.cn.com.webxml.www.WeatherWebService();
            //string[] s = w.getWeatherbyCityName("佛山");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //fsbus2.RecieveInfoPortTypeClient c = new Client.fsbus2.RecieveInfoPortTypeClient();
            

            System.ServiceModel.Channels.Binding binding = new System.ServiceModel.BasicHttpBinding();
            string url = "http://124.207.12.71:9999/fsbus/services/RecieveInfo.RecieveInfoHttpSoap11Endpoint";
            System.ServiceModel.EndpointAddress add = new System.ServiceModel.EndpointAddress(url);

            fsbus2.RecieveInfoPortTypeClient c = new Client.fsbus2.RecieveInfoPortTypeClient(binding, add);
            //textBox1.Text = c.deleteVehicleRefuel("1");
        }
    }
}
