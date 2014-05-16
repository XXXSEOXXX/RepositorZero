using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
namespace FsEmployeeYuan
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        string myconn = "Data Source=192.168.1.115;uid=sa;pwd=123;Initial Catalog=EmployeeYuan";
        private void button1_Click(object sender, EventArgs e)
        {
            ExcelToDataSet(dataGridView1);
        }

        /// <summary>
        /// 返回Excel数据源
        /// </summary>
        /// <param name="filename">文件路径</param>
        /// <returns></returns>
         public void ExcelToDataSet(DataGridView dgv)
        {
            DataSet ds;
            string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                            "Extended Properties=Excel 8.0;" +
                            "data source=test.xls";
            OleDbConnection myConn = new OleDbConnection(strCon);
            string strCom = " SELECT * FROM [Sheet1$]";
            myConn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
            ds = new DataSet();
            myCommand.Fill(ds);
            myConn.Close();
            dgv.DataSource = ds.Tables[0];  
        }

         private void button2_Click(object sender, EventArgs e)
         {
             if (dataGridView1.SelectedCells.Count < 1)
             { return; }
             SqlCommand mycommand = new SqlCommand();
             SqlConnection myconnection = new SqlConnection(myconn);
             myconnection.Open();
             mycommand.Connection = myconnection;
             int i = 0;
             if (MessageBox.Show("确定导入?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
             {
                 string mysql="";
                 foreach (DataGridViewRow dr in this.dataGridView1.Rows)
                 {
                     mysql = string.Format("INSERT INTO 员工资料(姓名,编号,身份证,入职日期)VALUES('{0}','{1}','{2}','{3}')",
                         dr.Cells["CSBH"].Value.ToString(), dr.Cells["CSMC"].Value.ToString(), dr.Cells["DI"].Value.ToString(),Convert.ToDateTime(dr.Cells["FZR_XM"].Value).Date);
                     //mysql = string.Format("INSERT INTO 员工资料(姓名,编号,身份证,入职日期)VALUES('{0}','{1}','{2}','{3}')",
                     //    1, 2, 3, 2011-1-1);
                     mycommand.CommandText = mysql;
                     mycommand.ExecuteNonQuery();
                     i++;
                 }
                 myconnection.Close();
             }
             MessageBox.Show("i=" + i);
         }


         //导出到execl  
         public void DgvToExcel(DataGridView dataGridView1)
         {   
             try
             {
                 //没有数据的话就不往下执行     
                 if (dataGridView1.Rows.Count == 0)
                     return;
                 //实例化一个Excel.Application对象     
                 Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

                 //让后台执行设置为不可见，为true的话会看到打开一个Excel，然后数据在往里写     
                 excel.Visible = true;

                 //新增加一个工作簿，Workbook是直接保存，不会弹出保存对话框，加上Application会弹出保存对话框，值为false会报错     
                 excel.Application.Workbooks.Add(true);
                 //生成Excel中列头名称     
                 for (int i = 0; i < dataGridView1.Columns.Count; i++)
                 {
                     excel.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                 }
                 //把DataGridView当前页的数据保存在Excel中     
                 for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                 {
                     for (int j = 0; j < dataGridView1.Columns.Count; j++)
                     {
                         if (dataGridView1[j, i].ValueType == typeof(string))
                         {
                             excel.Cells[i + 2, j + 1] = "'" + dataGridView1[j, i].Value.ToString();
                         }
                         else
                         {
                             excel.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();
                         }
                     }
                 }

                 //设置禁止弹出保存和覆盖的询问提示框     
                 excel.DisplayAlerts = true;
                 excel.AlertBeforeOverwriting = false;

                 //保存工作簿     
                 //excel.Application.Workbooks.Add(true).Save();
                 //保存excel文件     
                 //excel.Save("D:" + "\\KKHMD.xls");
                 // excel.Save(saveFileName);

                 //确保Excel进程关闭     
                 //excel.Quit();
                 //excel = null;

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "错误提示");
             }
         }

         private void button3_Click(object sender, EventArgs e)
         {
             DgvToExcel(dataGridView1);
         }

    }
}
