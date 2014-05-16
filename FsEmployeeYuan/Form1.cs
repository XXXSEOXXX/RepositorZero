using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel=Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data.OleDb;
namespace FsEmployeeYuan
{
    public partial class Form1 : Form
    {
        string myconn = "Data Source=192.168.1.115;uid=sa;pwd=123;Initial Catalog=EmployeeYuan";
        public Form1()
        {
            InitializeComponent();
            comboboxLoad();
        }

        private void comboboxLoad()
        {
            string sqlcbl = "SELECT ID FROM 员工资料";
            SqlConnection myconnection = new SqlConnection(myconn);
            myconnection.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlcbl, myconnection);
            DataSet ds = new DataSet();
            sda.Fill(ds, "11");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                comboBox1.Items.Add(dr["ID"]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string s = textBox2.Text.Insert(0, "  ");
            string mysql = string.Format("EXEC EMPyuan '{0}','{1}','{2}','{3}','{4}')", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, checkBox2.Checked);
           
            SqlConnection myconnection = new SqlConnection(myconn);
            myconnection.Open();

            SqlCommand mycommand = new SqlCommand();
            mycommand.Connection = myconnection;
            mycommand.CommandText = mysql;
            //  SqlCommand mycommand2 = new SqlCommand(mysql2, myconnection); 
            int att = mycommand.ExecuteNonQuery();//执行SQL命令

            //mycommand.CommandText = mysql2;
            //att = mycommand.ExecuteNonQuery();//执行SQL命令

            MessageBox.Show("value=" + att);
            myconnection.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“employeeYuanDataSet.员工资料”中。您可以根据需要移动或移除它。
            this.员工资料TableAdapter.Fill(this.employeeYuanDataSet.员工资料);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strSQL = "EXEC LoadTable";
            SqlConnection myconnection = new SqlConnection(myconn);
            myconnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(strSQL, myconnection);
            DataSet ds = new DataSet();
            da.Fill(ds, "表1");
            myconnection.Close();
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count < 1)
            { return; }
            int row = dataGridView1.SelectedCells[0].RowIndex;
            string numID = dataGridView1["ID", row].Value.ToString();
            string str姓名 = dataGridView1["姓名", row].Value.ToString();
            string str编号 = dataGridView1["编号", row].Value.ToString();
            string str身份证 = dataGridView1["身份证", row].Value.ToString();
            string str入职日期 = dataGridView1["入职日期", row].Value.ToString();
            string str测试 = dataGridView1["测试", row].Value.ToString();
            string mysql = string.Format("UPDATE 员工资料 SET 姓名='{0}',编号='{1}',身份证='{2}',入职日期='{3}',测试='{4}' where ID='{5}'", str姓名, str编号, str身份证, str入职日期,str测试 ,numID);
            SqlConnection myconnection = new SqlConnection(myconn);
            myconnection.Open();
            SqlCommand mycommand = new SqlCommand(mysql, myconnection);
            mycommand.ExecuteNonQuery();
            button2_Click(null, null);
            myconnection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count < 1)
            { return; }
            int row = dataGridView1.SelectedCells[0].RowIndex;
            string id = dataGridView1["ID", row].Value.ToString();
            string str姓名 = dataGridView1["姓名", row].Value.ToString();
            if (MessageBox.Show("是否删除资料:" + str姓名 + "?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)//弹出是否删除资料对话框
            {
                string mysql = string.Format("delete 员工资料 where ID={0}", id);
                SqlConnection myconnection = new SqlConnection(myconn);
                myconnection.Open();
                SqlCommand mycommand = new SqlCommand(mysql, myconnection);
                mycommand.ExecuteNonQuery();
                myconnection.Close();
                string strSQL = "SELECT * FROM 员工资料";
                myconnection.Open();
                SqlDataAdapter da = new SqlDataAdapter(strSQL, myconnection);
                DataSet ds = new DataSet();
                da.Fill(ds, "表1");
                myconnection.Close();
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                textBox1.Enabled = false;
                label1.Enabled = false;
                textBox2.Enabled = false;
                label2.Enabled = false;
                textBox3.Enabled = false;
                label3.Enabled = false;
                textBox4.Enabled = false;
                label4.Enabled = false;
            }
            else
            {
                textBox1.Enabled = true;
                label1.Enabled = true;
                textBox2.Enabled = true;
                label2.Enabled = true;
                textBox3.Enabled = true;
                label3.Enabled = true;
                textBox4.Enabled = true;
                label4.Enabled = true;
            }
        }
        
        private void pnt打印_Click(object sender, EventArgs e)
        {
          

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";

            saveFileDialog.FilterIndex = 0;

            saveFileDialog.RestoreDirectory = true;

            saveFileDialog.CreatePrompt = true;

            saveFileDialog.Title = "Export Excel File To"; 


            saveFileDialog.ShowDialog();


            Stream myStream;

            myStream = saveFileDialog.OpenFile();

            //StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));

            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));

            string str = "";

            try

            {

                //写标题

                for (int i = 0; i < dataGridView1.ColumnCount; i++)

                {

                    if (i > 0)

                    {

                        str += "\t";

                    }

                    str += dataGridView1.Columns[i].HeaderText;

                }


                sw.WriteLine(str);



                //写内容

                for (int j = 0; j < dataGridView1.Rows.Count; j++)

                {

                    string tempStr = "";

                    for (int k = 0; k < dataGridView1.Columns.Count; k++)

                    {

                        if (k > 0)

                        {

                            tempStr += "\t";

                        }

                        tempStr += dataGridView1.Rows[j].Cells[k].Value.ToString();

                    }

                    

                    sw.WriteLine(tempStr);                    

                }

                sw.Close();

                myStream.Close();

            }

            catch (Exception e1)

            {

                MessageBox.Show(e1.ToString());

            }

            finally

            {

                sw.Close();

                myStream.Close();

            }           

      }
        OpenFileDialog ofd = new OpenFileDialog();
        private void btn选择文件_Click(object sender, EventArgs e)
        {
           
            //ofd.ShowDialog();
            ofd.Filter = "All File(*.*)|*.*|Excel 2003(*.xls)|*.xls|Excel 2007(*.xlsx)|*.xlsx";
            ofd.ValidateNames = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox文件路径.Text = ofd.FileName.ToString();
            }
        }

        private void btn导入_Click(object sender, EventArgs e)
        {
           
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(ofd.FileName);
                string filePath = fileInfo.FullName;
                string connExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=Excel 8.0";

                try
                {
                    OleDbConnection oleDbConnection = new OleDbConnection(connExcel);
                    oleDbConnection.Open();

                    //获取excel表
                    System.Data.DataTable dataTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    //获取sheet名，其中[0][1]...[N]: 按名称排列的表单元素
                    string tableName = dataTable.Rows[0][2].ToString().Trim();
                    tableName = "[" + tableName.Replace("'", "") + "]";
                    //利用SQL语句从Excel文件里获取数据
                    //string query = "SELECT classDate,classPlace,classTeacher,classTitle,classID FROM " + tableName;
                    string query = "SELECT 日期,开课城市,讲师,课程名称,持续时间 FROM " + tableName;
                    DataSet dt = new DataSet();
                    //OleDbCommand oleCommand = new OleDbCommand(query, oleDbConnection);
                    //OleDbDataAdapter oleAdapter = new OleDbDataAdapter(oleCommand);
                    OleDbDataAdapter oleAdapter = new OleDbDataAdapter(query, connExcel);

                    oleAdapter.Fill(dt, "gch_Class_Info");
                    //dataGrid1.DataSource = dataSet;
                    //dataGrid1.DataMember = tableName;
                    //dataGridView1.SetDataBinding(dt, "gch_Class_Info");
                    //从excel文件获得数据后，插入记录到SQL Server的数据表
                    System.Data.DataTable dataTable1 = new System.Data.DataTable();

                    SqlDataAdapter sqlDA1 = new SqlDataAdapter(@"SELECT classID, classDate,
classPlace, classTeacher, classTitle, durativeDate FROM test", myconn);

                    SqlCommandBuilder sqlCB1 = new SqlCommandBuilder(sqlDA1);

                    sqlDA1.Fill(dataTable1);
                    foreach (DataRow dataRow in dt.Tables["test"].Rows)
                    {
                        DataRow dataRow1 = dataTable1.NewRow();

                        dataRow1["classDate"] = dataRow["日期"];
                        dataRow1["classPlace"] = dataRow["开课城市"];
                        dataRow1["classTeacher"] = dataRow["讲师"];
                        dataRow1["classTitle"] = dataRow["课程名称"];
                        dataRow1["durativeDate"] = dataRow["持续时间"];
                        dataTable1.Rows.Add(dataRow1);
                    }
                    Console.WriteLine("新插入 " + dataTable1.Rows.Count.ToString() + " 条记录");
                    sqlDA1.Update(dataTable1);

                    oleDbConnection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

        }

        //int ix = 0;
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            //dataGridView1.ClearSelection();
            //if (e.KeyChar ==(char)13)
            //{
            //    if(dataGridView1.Rows.Count>0)
            //    {         
            //    ix = dataGridView1.SelectedRows[0].Index;
            //    if(dataGridView1.Rows[ix].Cells["姓名"].Value.ToString().Contains(textBox5.Text))
            //        ix=ix+1;
            //    else
            //        ix=0;

            //        for (int i=ix; i < dataGridView1.Rows.Count; i++)
            //        {
            //            if(dataGridView1.Rows[ix].Cells["姓名"].Value.ToString().Contains(textBox5.Text))
            //            {
            //                dataGridView1.Rows[i].Selected=true;
            //                dataGridView1.Rows[i].Cells["姓名"].Selected = true;
            //                dataGridView1.FirstDisplayedScrollingRowIndex=i;
            //                break;
            //            }
            //        }
            //    }
            //}
            if (e.KeyChar == (char)13)
            {
                int row = 0;
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    row = dataGridView1.SelectedRows[0].Index;
                    if (dataGridView1.Rows[row].Cells["姓名"].Value.ToString().Contains(textBox5.Text.Trim()))
                    {
                        row = row + 1;
                    }
                    else
                    {
                        row = 0;
                    }
                }

                if (row >= dataGridView1.Rows.Count+1)
                    row = 0;

                dataGridView1.ClearSelection();
                for (int i = row; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["姓名"].Value.ToString().Contains(textBox5.Text.Trim()))
                    {
                        dataGridView1.Rows[i].Selected = true;
                        dataGridView1.Rows[i].Cells["姓名"].Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Cells[1, 1] = (string)dataGridView1[1, 1].Value;
            excel.Visible = false;
            excel.SaveWorkspace(@"c:/123.xls");
            excel.Workbooks.Close();
            excel.Quit();
        }



        }
}
