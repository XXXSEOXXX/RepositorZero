using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FsEmployeeYuan
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Form2 f1 = new Form2();
            f1.TopLevel = false;
            f1.Visible = true;
            f1.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(f1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s=@"C:\Users\cake\Desktop\Program\FsEmployeeYuan\FsEmployeeYuan\bin\Debug\s.txt";
            string s1 = @"C:\Users\cake\Desktop\Program\FsEmployeeYuan\FsEmployeeYuan\bin\Debug";
            if (!System.IO.File.Exists(s1))
            {
                if (!System.IO.Directory.Exists(s))
                {
                    System.IO.Directory.CreateDirectory(s1);
                    System.IO.StreamWriter sw = System.IO.File.CreateText(s);
                    StringBuilder sb = new StringBuilder();
                    long i = 0;
                    for (i = 100; i < 200; i++)
                    {
                        sb.Append(i.ToString() + "@qq.com\r\n");
                    }
                    sw.WriteLine(sb);
                    sw.Dispose();
                }
                else
                {
                    System.IO.StreamWriter sw = System.IO.File.CreateText(s);
                    StringBuilder sb = new StringBuilder();
                    long i = 0;
                    for (i = 100; i < 200; i++)
                    {
                        sb.Append(i.ToString() + "@qq.com\r\n");
                    }
                    sw.WriteLine(sb);
                    sw.Dispose();
                }
            }
            else
            {
                System.IO.File.Delete(s);
            }
        }


    }
}
