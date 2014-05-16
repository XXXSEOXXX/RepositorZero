using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FsEmployeeYuan
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            //int start, end;
            //int i, j, k;
            //double x, y, z;
            //x = 1;
            //y = 1001;
            //z = 2001;
            //start = System.Environment.TickCount;
            //for (i = 0; i < 1000; i++)
            //    for (j = 0; j < 1000; j++)
            //        for (k = 0; k < 10000; k++)
            //            x = z * i + y * j - y * z + z / y + k;
            //end = System.Environment.TickCount;
            //int r = end - start;
            //string str;
            //str = r.ToString();
            //MessageBox.Show(str);

            //str = x.ToString();
            //MessageBox.Show(str);
     

        }

        Form2 frm2 = new Form2();
        private void button1_Click(object sender, EventArgs e)
        {
            frm2.ExcelToDataSet(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm2.DgvToExcel(dataGridView1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder strBu = new StringBuilder();
            DriveInfo[] allDrive = DriveInfo.GetDrives();
            try
            {
                foreach (DriveInfo di in allDrive)
                {
                    if (di.IsReady)
                    {
                        strBu.AppendLine("分区盘符：" + di.Name);
                        strBu.AppendLine("分区卷符：" + di.VolumeLabel);
                        strBu.AppendLine("分区类型：" + di.DriveType.ToString());
                        strBu.AppendLine("分区格式：" + di.DriveFormat);
                        strBu.AppendLine("分区容量："+di.TotalSize+" KB");
                        strBu.AppendLine("分区可用容量：" + di.TotalFreeSpace+" KB");
                        strBu.AppendLine("----------------------------------------");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            richTextBox1.Text = strBu.ToString();
        }
    }
}
