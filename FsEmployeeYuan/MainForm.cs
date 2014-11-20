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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Form1");
            comboBox1.Items.Add("Form2");
            comboBox1.Items.Add("Form3");
            comboBox1.Items.Add("Form4");
            comboBox1.Items.Add("Form5");
            comboBox1.Items.Add("Form7");
            comboBox1.Items.Add("Form8");
            comboBox1.Items.Add("Form9");
            comboBox1.Items.Add("Form10");
            comboBox1.Items.Add("Form11");
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.BackColor = Color.White;
            this.comboBox1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Form1")
            {
                Form1 frm = new Form1();
                frm.Show();
            }
            if (comboBox1.Text == "Form2")
            {
                Form2 frm = new Form2();
                frm.Show();
            }
            if (comboBox1.Text == "Form3")
            {
                Form3 frm = new Form3();
                frm.Show();
            }
            if (comboBox1.Text == "Form4")
            {
                Form4 frm = new Form4();
                frm.Show();
            }
            if (comboBox1.Text == "Form5")
            {
                Form5 frm = new Form5();
                frm.Show();
            }
            if (comboBox1.Text == "Form7")
            {
                Form7 frm = new Form7();
                frm.Show();
            }
            if (comboBox1.Text == "Form8")
            {
                Form8 frm = new Form8();
                frm.Show();
            }
            if (comboBox1.Text == "Form9")
            {
                Form9 frm = new Form9();
                frm.Show();
            }
            if (comboBox1.Text == "Form10")
            {
                Form10 frm = new Form10();
                frm.Show();
            }
            if (comboBox1.Text == "Form11")
            {
                Form11 frm = new Form11();
                frm.Show();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text.Trim() == "")
                return;
            if (e.KeyChar == 13)
            {
                try
                {
                    Type myType = Type.GetType("FsEmployeeYuan.Form" + textBox1.Text.Trim());
                    object obj = Activator.CreateInstance(myType);
                    if (obj is Form)
                    {
                        Form form = (Form)obj;
                        //form.Name = "Form" + textBox1.Text.Trim();
                        //form.ShowInTaskbar = false;
                        form.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
