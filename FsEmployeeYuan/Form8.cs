using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using fsqyEIMS;

namespace FsEmployeeYuan
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            Binding bd = new Binding("Rtf", bindingSource1, "Rich", true);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myconn = "Data Source=192.168.1.115;uid=sa;pwd=123;Initial Catalog=EmployeeYuan";
            string mycmd = string.Format("UPDATE 员工资料 SET Rich='{0}' WHERE ID=136",richTextBox1.Text);
            SqlConnection myconnection = new SqlConnection(myconn);
            myconnection.Open();
            SqlCommand mycommand = new SqlCommand(mycmd, myconnection);
            int i =mycommand.ExecuteNonQuery();
            myconnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string myconn = "Data Source=192.168.1.115;uid=sa;pwd=123;Initial Catalog=EmployeeYuan";
            string mycmd = "select Rich from 员工资料 where ID=136";
            SqlConnection myconnection = new SqlConnection(myconn);
            myconnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(mycmd, myconnection);
            DataSet ds = new DataSet();
            da.Fill(ds, "表1");
            myconnection.Close();
            richTextBox1.Text = ds.Tables[0].Rows[0]["Rich"].ToString();
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            int[] arr=getRandomNum(6,1,20); //从1至20中取出6个互不相同的随机数
            int i=0;
            string temp="";
            while (i<=arr.Length-1)
            {
                temp+=arr[i].ToString()+" ";
                i++ ;
            }
            richTextBox2.Text=temp; //显示在label1中

        }


        public int[] getRandomNum(int num, int minValue, int maxValue)
        {
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            int[] arrNum = new int[num];
            int tmp = 0;
            for (int i = 0; i <= num - 1; i++)
            {
                tmp = ra.Next(minValue, maxValue); //随机取数
                arrNum[i] = getNum(arrNum, tmp, minValue, maxValue, ra,i); //取出值赋到数组中
            }
            return arrNum;
        }



        public int getNum(int[] arrNum, int tmp, int minValue, int maxValue, Random ra,int i)
        {
            int n = 0;
            while (n < i)
            {
                if (arrNum[n] == tmp) //利用循环判断是否有重复
                {
                    tmp = ra.Next(minValue, maxValue); //重新随机获取。
                    tmp=getNum(arrNum, tmp, minValue, maxValue, ra,i);//递归:如果取出来的数字和已取得的数字有重复就重新随机获取。
                }
                n++;
            }
            return tmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = string.Format("");
        }

        private void button4_Click(object sender, EventArgs e)
        {   
        }
    }
}
