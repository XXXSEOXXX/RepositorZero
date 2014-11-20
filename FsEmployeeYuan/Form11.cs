using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

namespace FsEmployeeYuan
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = GetPhysicalMemory();
            richTextBox1.Text += GetCPUID();
            richTextBox1.Text += GetHardDisk();
            richTextBox1.Text += GetMotherBoard();
        }

        private string GetCPUID()
        {
            try
            {
                ManagementClass mc = new ManagementClass("WIN32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                string strCPUID = "";
                foreach (ManagementObject mo in moc)
                {
                    strCPUID = mo.Properties["Name"].Value.ToString()+"\n";
                    break;
                }
                return strCPUID;
            }
            catch
            {
                return "";
            }
        }

        private string GetPhysicalMemory()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_PhysicalMemory");
                ManagementObjectCollection moc = mc.GetInstances();
                string strMemory = "";
                foreach (ManagementObject mo in moc)
                {
                    strMemory += mo["Capacity"].ToString() + "\n";
                }
                return strMemory;
            }
            catch
            {
                return "";
            }
        }

        private string GetHardDisk()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc = mc.GetInstances();
                string strMemory = "";
                foreach (ManagementObject mo in moc)
                {
                    strMemory += mo["Model"].ToString() + "\n";
                }
                return strMemory;
            }
            catch
            {
                return "";
            }
        }

        private string GetMotherBoard()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_BaseBoard");
                ManagementObjectCollection moc = mc.GetInstances();
                string strMoBo = "";
                foreach (ManagementObject mo in moc)
                {
                    strMoBo += mo["Product"].ToString() + "\n";
                }
                return strMoBo;
            }
            catch
            {
                return "";
            }
        }
    }
}
