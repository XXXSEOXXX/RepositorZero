using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.ServiceModel.Configuration;
using System.ServiceModel;
using System.Net;
using System.Text.RegularExpressions;
using System.Reflection;

namespace Client
{
    public partial class FrmConfigSelect : Form
    {
        public FrmConfigSelect()
        {
            InitializeComponent();
        }

        private void FrmConfigSelect_Load(object sender, EventArgs e)
        {
           
        }

        private void GetConfigValue(int i)
        {
            ExeConfigurationFileMap cfgmap=new ExeConfigurationFileMap();

            cfgmap.ExeConfigFilename="fsqyEIMS.exe.config";
            Configuration fsqyconfig = ConfigurationManager.OpenMappedExeConfiguration(cfgmap, ConfigurationUserLevel.None);
            cfgmap.ExeConfigFilename = "FSEMISUpDate2.exe.config";
            Configuration updateconfig = ConfigurationManager.OpenMappedExeConfiguration(cfgmap, ConfigurationUserLevel.None);

            ServiceModelSectionGroup smsg = fsqyconfig.GetSectionGroup("system.serviceModel") as ServiceModelSectionGroup;
            ServiceModelSectionGroup smsg2 = updateconfig.GetSectionGroup("system.serviceModel") as ServiceModelSectionGroup;

            ClientSection cs = smsg.Client;
            string port = cs.Endpoints[0].Address.Port.ToString();
            string ipAddress = "192.168.4.3";
            if (i == 1)
                ipAddress = "183.234.49.190";

            //更改fsqyEMIS.exe.config的IP
            foreach (ChannelEndpointElement item in cs.Endpoints)
            {
                string pattern = "://.*/CityBusEMIS/";
                string replacement = string.Format("://{0}:{1}/CityBusEMIS/", ipAddress, port);
                string address = item.Address.ToString();
                address = Regex.Replace(address, pattern, replacement);
                item.Address = new Uri(address);
            }

            cs = smsg2.Client;
            //更改FSEMISUpDate2.exe.config的IP
            foreach (ChannelEndpointElement item in cs.Endpoints)
            {
                string pattern = "://.*/CityBusEMIS/";
                string replacement = string.Format("://{0}:{1}/CityBusEMIS/", ipAddress, port);
                string address = item.Address.ToString();
                address = Regex.Replace(address, pattern, replacement);
                item.Address = new Uri(address);
            }

            fsqyconfig.Save(ConfigurationSaveMode.Modified);
            updateconfig.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("system.serviceModel");
        }

        /// <summary>
        /// 调用方案一
        /// </summary>
        /// <param name="serverAddress">服务器地址</param>
        private static void CallFirstScheme(string serverAddress)
        {
            ///*
            ///*----------------------方案一：对于使用代理类-----------------------------------------*/
            //Console.WriteLine("方案一：");
            ////1.测试连接(不使用身份验证)
            //Console.WriteLine("1.1.1 创建代理对象 userNamePwdValidator.");
            //EndpointAddress address = new EndpointAddress("net.tcp://" + serverAddress + ":8086/UserNamePwdValidator/UserNamePwdValidatorService");
            //UserNamePwdValidatorClient userNamePwdValidator
            //    = new UserNamePwdValidatorClient("UserNamePwdValidatorService", address);
            //bool result = userNamePwdValidator.Validate(string.Empty, string.Empty);
            //Console.WriteLine("1.1.2 测试连接成功.");

            ////2.验证用户名和密码（与测试连接调用同样的接口，不使用身份验证）
            ////bool result = userNamePwdValidator.Validate("admin", admin);

            ////3.调用服务(使用身份验证)
            //Console.WriteLine("1.2.1 创建服务代理对象 user.");

            //UserClient user = new UserClient("UserService");
            //user.Endpoint.Address = new EndpointAddress(new Uri("net.tcp://" + serverAddress + ":8086/User"),
            //    user.Endpoint.Address.Identity, user.Endpoint.Address.Headers);
            //user.ClientCredentials.UserName.UserName = "admin";
            //user.ClientCredentials.UserName.Password = "admin";
            //user.Insert();

            //Console.WriteLine("1.2.2 调用服务成功.\n");
            /*----------------------方案一：结束-------------------------------------------------*/
        }

        private void btnIntranet_Click(object sender, EventArgs e)
        {
            GetConfigValue(0);
        }

        private void btnExtranet_Click(object sender, EventArgs e)
        {
            GetConfigValue(1);
        }
    }
}
