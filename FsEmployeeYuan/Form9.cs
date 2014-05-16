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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            Load物料();
            Load订单();
        }
        string myconn = "Data Source=192.168.1.115;uid=sa;pwd=123;Initial Catalog=EmployeeYuan";
        DataTable dt;
        DataTable dt修改 = new DataTable();
        int 订单ID = 0;
        string 订单号 = "";

        private DataTable GetTable(string sql)
        {
            DataTable dt = new DataTable();
            SqlConnection myconnection = new SqlConnection(myconn);
            try
            {
                myconnection.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, myconnection);
                DataSet ds = new DataSet();
                da.Fill(ds, "表1");
                myconnection.Close();
                dt = ds.Tables[0];
            }
            catch
            {
            }
            finally
            {
                myconnection.Close();
            }
            return dt;
        }

        private int ExecSQL(string sql)
        {
            int i = 0;
            SqlConnection myconnection = new SqlConnection(myconn);
            try
            {
                myconnection.Open();
                SqlCommand mycommand = new SqlCommand(sql, myconnection);
                i = mycommand.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                myconnection.Close();
            }
            return i;
        }

        private void Load物料()
        {
            
            //string strSQL = "SELECT * FROM 物料资料";
            //dgv物料.DataSource = GetTable(strSQL);
            dgv物料.Columns["ID"].Visible = false;
        }

        private void Load订单()
        {
            string strSQL = "SELECT * FROM 订单";
            dgv订单.DataSource = GetTable(strSQL);
            dgv订单.Columns["ID"].Visible = false;
        }

        private void btn物料_Click(object sender, EventArgs e)
        {
            Form物料 frm = new Form物料();
            frm.ShowDialog();
            Load物料();
        }

        private void dgv订单_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgv订单.SelectedCells[0].RowIndex;
            订单ID=int.Parse(dgv订单["ID",row].Value.ToString());
            订单号 = dgv订单["订单号", row].Value.ToString();
            string strSQL = string.Format("SELECT * FROM 订单Detail WHERE 订单ID={0}",订单ID);
            dt = GetTable(strSQL);
            dgv订单Detail.DataSource = dt;

            dgv订单Detail.Columns["ID"].Visible = false;
            dgv订单Detail.Columns["订单ID"].ReadOnly = true;
            dgv订单Detail.Columns["单号"].ReadOnly = true;
            dgv订单Detail.Columns["物料编号"].ReadOnly = true;
            dgv订单Detail.Columns["物料名称"].ReadOnly = true;
            dgv订单Detail.Columns["单位"].ReadOnly = true;
        }

        private void dgv物料_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (订单ID == 0)
                return;
            string 物料编号 = dgv物料["物料编号", e.RowIndex].Value.ToString();
            string 物料名称 = dgv物料["物料名称", e.RowIndex].Value.ToString();
            string 单位 = dgv物料["单位", e.RowIndex].Value.ToString();

            int i=0;
            foreach (DataGridViewRow dgvr in dgv订单Detail.Rows)
            {
                if (dgvr.Cells["物料编号"].Value.ToString() == 物料编号)
                {
                    if (dgvr.Visible)
                    {
                        MessageBox.Show("该物料已经添加到表里");
                    }
                    else
                    {
                        dgv订单Detail.Rows[i].Visible = true;
                    }
                    return;
                }
                i++;
            }
            DataRow dr = dt.NewRow();
            dr["订单ID"] = 订单ID;
            dr["单号"] = 订单号;
            dr["物料编号"] = 物料编号;
            dr["物料名称"] = 物料名称;
            dr["单位"] = 单位;
            dr["金额"] = 0.00;
            dt.Rows.Add(dr);
        }

        private void dgv订单Detail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("确定要删除？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                CurrencyManager cm = (CurrencyManager)BindingContext[dgv订单Detail.DataSource];
                cm.SuspendBinding();//挂起数据
                dgv订单Detail.Rows[e.RowIndex].Visible = false;
                cm.ResumeBinding();//恢复绑定数据
            }
        }

        private void dgv订单Detail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgv订单Detail["金额", e.RowIndex].Value = decimal.Parse(Isnull(dgv订单Detail["数量", e.RowIndex].Value.ToString())) * decimal.Parse(Isnull(dgv订单Detail["单价", e.RowIndex].Value.ToString()));
        }

        private string Isnull(string str)
        {
            if (str.Trim() == "" || str.Trim() == null)
                str = "0.00";
            return str;
        }

        private void dgv订单Detail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            decimal dec;
            if (dgv订单Detail.Columns[e.ColumnIndex].HeaderText == "数量")
            {
                if (decimal.TryParse(dgv订单Detail["数量",e.RowIndex].Value.ToString(), out dec) == false)
                    dgv订单Detail["数量", e.RowIndex].Value = 0.00;
            }

            if (dgv订单Detail.Columns[e.ColumnIndex].HeaderText == "单价")
            {
                if (decimal.TryParse(dgv订单Detail["单价", e.RowIndex].Value.ToString(), out dec) == false)
                    dgv订单Detail["单价", e.RowIndex].Value = 0.00;
            }

            if (dgv订单Detail.Columns[e.ColumnIndex].HeaderText == "金额")
            {
                if (decimal.TryParse(dgv订单Detail["金额", e.RowIndex].Value.ToString(), out dec) == false)
                    dgv订单Detail["金额", e.RowIndex].Value = 0.00;
            }

            dgv订单Detail.Rows[e.RowIndex].Tag = 1;
        }

        private void btn保存_Click(object sender, EventArgs e)
        {
            string sql = "";
            int del = 0;//删除条目数
            int add = 0;//新增条目数
            int mod = 0;//修改条目数
            foreach (DataGridViewRow dr in dgv订单Detail.Rows)
            {

                if (dr.Visible == false)//删除操作
                {
                    sql = string.Format("DELETE 订单Detail WHERE ID={0}",dr.Cells["ID"].Value.ToString());
                    int i = ExecSQL(sql);
                    if (i > 0)
                        del++;
                    continue;
                }

                if (dr.Cells["ID"].Value.ToString() == "" || dr.Cells["ID"].Value == null)//新增操作
                {
                    sql = string.Format("INSERT INTO 订单Detail (订单ID, 单号, 物料编号, 物料名称, 单位, 数量, 单价, 金额, 备注) " +
                                         "VALUES ({0},'{1}','{2}','{3}','{4}',{5},{6},{7},'{8}')",
                                         dr.Cells["订单ID"].Value.ToString(), dr.Cells["单号"].Value.ToString(),
                                         dr.Cells["物料编号"].Value.ToString(), dr.Cells["物料名称"].Value.ToString(), dr.Cells["单位"].Value.ToString(),
                                         Isnull(dr.Cells["数量"].Value.ToString()), Isnull(dr.Cells["单价"].Value.ToString()),
                                         Isnull(dr.Cells["金额"].Value.ToString()), dr.Cells["备注"].Value.ToString());
                    int i = ExecSQL(sql);
                    if (i > 0)
                        add++;
                    continue;
                }

                if (dr.Tag!=null)//修改操作
                {
                    sql = string.Format("UPDATE 订单Detail SET 数量={0},单价={1}, 金额={2}, 备注='{3}' WHERE ID={4}",
                                         Isnull(dr.Cells["数量"].Value.ToString()),Isnull(dr.Cells["单价"].Value.ToString()),Isnull(dr.Cells["金额"].Value.ToString()),
                                         dr.Cells["备注"].Value.ToString(),dr.Cells["ID"].Value.ToString());
                    int i = ExecSQL(sql);
                    if (i > 0)
                        mod++;
                }
            }
            MessageBox.Show(string.Format("新增{0}条记录;\n修改{1}条记录;\n删除{2}条记录.",add,mod,del));
            dgv订单_CellDoubleClick(null, null);
        }

        private void dgv订单Detail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("请输入有效数值");
        }
    }

}
