using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FsEmployeeYuan
{
    public partial class Form物料 : Form
    {
        public Form物料()
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

        private void Form物料_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM 物料资料";
            dataGridView1.DataSource = GetTable(sql);
        }

        private void btn保存_Click(object sender, EventArgs e)
        {
            string sql = string.Format("INSERT INTO 物料资料 (物料编号, 物料名称, 单位) VALUES ('{0}','{1}','{2}')",tb编号.Text,tb名称.Text,tb单位.Text);
            int i=ExecSQL(sql);
            if (i == 1)
                MessageBox.Show("Success");
            tb编号.Text = "";
            tb名称.Text = "";
            tb单位.Text = "";
            sql = "SELECT * FROM 物料资料";
            dataGridView1.DataSource = GetTable(sql);
        }
    }
}
