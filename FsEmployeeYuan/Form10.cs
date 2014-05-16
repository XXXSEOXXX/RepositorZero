using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace FsEmployeeYuan
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        Entities ef = new Entities();
        SqliteTest lef = new SqliteTest();
        int i = 2;
        private void button1_Click(object sender, EventArgs e)
        {
            //var q = ef.订单Detail.Where(i => i.ID < 100);
            //dgv.DataSource = q.ToList();

            //foreach (var gp in q)
            //{
            //    if (gp.ID>0)
            //    {

            //    }
            //}
            Panel panelTemp = new Panel();
            panelTemp.Name = "Panel"+i.ToString();
            i++;
            panelTemp.Size = new Size(100, 28);
            panelTemp.Visible = true;
            panelTemp.Dock = DockStyle.Top;
            this.Controls.Add(panelTemp);

            button2.Parent = panelTemp;
            button2.Location = new Point(100, 1);
            button3.Parent = panelTemp;
            button3.Location = new Point(195, 1); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var q = from t in ef.订单Detail
                    where t.ID == 3
                    select t;
            dgv.DataSource = q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Expression<Func<int, int, int>> exp = (a, b) => a * b + 2;
            Func<int, int, int> lambda = exp.Compile();
            tb1.Text = lambda(10, 2).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Access 2013(*.accdb)|*.accdb";
            ofd.ValidateNames = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.ShowDialog();

            string filePath = ofd.FileName.ToString();
            string conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath+";Jet OLEDB:Database Password=123456";
            OleDbConnection connect = new OleDbConnection(conStr);
            connect.Open();

            string sql = "SELECT * FROM Table1";
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, connect);
            da.Fill(ds, "Table1");
            dgv.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (Control cl in this.Controls)
            {
                if (cl is Panel)
                    MessageBox.Show(cl.Name);
            }
        }
    }
}
