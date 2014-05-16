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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            dt.Columns.Add("c1");
            dt.Columns.Add("c2");
            dt2.Columns.Add("c1");
            dt2.Columns.Add("c2");
            for (int j = 0; j < 10; j++)
            {
                dt.Rows.Add("aaaaaaaaaaaaaaa", "bbbb");
                dt2.Rows.Add("aaaaaaaaaaaaaaa", "bbbb");
            }
            this.dataGridView1.DataSource = dt;
            this.zxyDataGridView1.DataSource = dt2;
            for (int j = 0; j < 10; j++)
            {
                int height = TextRenderer.MeasureText(
                this.dataGridView1[0, j].Value.ToString(),
                this.dataGridView1.DefaultCellStyle.Font).Width;
                this.dataGridView1.Rows[j].Height = height;
            }
            this.dataGridView1.CellPainting += new
            DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1 && e.Value != null)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All
                     & ~DataGridViewPaintParts.ContentForeground);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                sf.FormatFlags = StringFormatFlags.DirectionVertical;
                e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font,
                new SolidBrush(e.CellStyle.ForeColor), e.CellBounds, sf);
                e.Handled = true;
            }
        }


        private void zxyDataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox)
            {

                TextBox tb = e.Control as TextBox;

                tb.AcceptsTab = true;

            }

        }
    }

    class zxyDataGridView : DataGridView
    {
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Tab:
                    return false;
                case Keys.Enter:
                    {
                        if (this.EditingControl != null)
                        {
                            if (this.EditingControl is TextBox)
                            {
                                TextBox tx = this.EditingControl as TextBox;
                                int tmp = tx.SelectionStart;
                                tx.Text = tx.Text.Insert(tx.SelectionStart, Environment.NewLine);
                                tx.SelectionStart = tmp + Environment.NewLine.Length;
                                return true;
                            }
                        }
                    }
                    return false;
            }
            return base.ProcessDataGridViewKey(e);
        }
    }
}
