using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace FsEmployeeYuan
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        string myconn = "Data Source=192.168.1.115;uid=sa;pwd=123;Initial Catalog=EmployeeYuan";

        /// <summary>
        /// 执行数据库操作,获取数据表
        /// </summary>
        /// <param name="sql"></param>
        private DataTable GetTable(string sql)
        {
            DataTable dt = new DataTable();
            SqlConnection myconnection = new SqlConnection(myconn);
            myconnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, myconnection);
            DataSet ds = new DataSet();
            da.Fill(ds, "表1");
            myconnection.Close();
            dt = ds.Tables[0];
            return dt;
        }
        /// <summary>
        /// 执行数据库操作，返回受影响行数
        /// </summary>
        /// <param name="sql"></param>
        private int ExecSQL(string sql)
        {
            int i = 0;
            SqlConnection myconnection = new SqlConnection(myconn);
            myconnection.Open();
            SqlCommand mycommand = new SqlCommand(sql, myconnection);
            i = mycommand.ExecuteNonQuery();
            return i;
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

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = GetTable("select * from cp where 1=2");
            
            for (int i = 1; i < 10; i++)
            {
                DataRow dr = dt.NewRow();
                dr["Chang"] = i.ToString();
                dr["Kuan"] = i.ToString();
                dr["Gao"] = i.ToString();
                dt.Rows.Add(dr);
            }

            SqlConnection cn = new SqlConnection(myconn);
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = @"TEST1";
            SqlParameter p = cmd.Parameters.AddWithValue("@table", dt);
            if (cmd.ExecuteNonQuery()>= 1)
                MessageBox.Show("GOOD");
            else
                MessageBox.Show("BAD");
            cn.Close();
        }
    }
}
