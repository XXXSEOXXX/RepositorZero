using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

namespace Server
{
    public partial class Servers : Form
    {
        public Servers()
        {
            InitializeComponent();
        }

        ServiceHost host = null;

        private void button1_Click(object sender, EventArgs e)
        {
            host = new ServiceHost(typeof(Server.WCFServices));
            host.Open();
            label1.Text = "服务已启动";
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (host.State != CommunicationState.Closed)
            {
                host.Close();
                label1.Text = "服务已关闭";
                button1.Enabled = true;
            }
        }
    }
}
