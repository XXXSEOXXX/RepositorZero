using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace FsEmployeeYuan
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        delegate void MyDelegate(T_test_Linq user);

        private void Form12_Load(object sender, EventArgs e)
        {
            
        }

        public void Update(T_test_Linq user)
        {
            using (Entities context = new Entities())
            {
                DisplayUser("Current", user);
                var obj = context.T_test_Linq.Where(q => q.ID == user.ID).FirstOrDefault();
                if (obj != null)
                    context.ApplyCurrentValues("T_test_Linq", user);

                Thread.Sleep(100);
                context.SaveChanges();  
            }
        }

        public delegate void DeStPa(string message, T_test_Linq oldVer);
        private void DisplayUser(string message, T_test_Linq oldVer)
        {
            //string strDate = string.Format("{0}\n  User Message:\n    ID:{1}    Name:{2}   Sex:{3}   Age:{4}\n    Address:{5}   Telephone:{6}   Email:{7}\n\n\n",
            //                                message,oldVer.ID,oldVer.Name,oldVer.Sex,oldVer.Age,oldVer.Address,oldVer.Telephone,oldVer.Email);

            if (rtxt.InvokeRequired)
            {
                rtxt.Invoke(new DeStPa(DisplayUser),message,oldVer);
                return;
            }
            //if (rtxt.InvokeRequired)
            //{
            //    MethodInvoker del = delegate { DisplayUser(message, oldVer); };
            //    rtxt.Invoke(del);
            //    return;
            //}

            rtxt.Text += string.Format("{0}\n  User Message:\n    ID:{1}    Name:{2}   Sex:{3}   Age:{4}\n    Address:{5}   Telephone:{6}   Email:{7}\n\n\n",
                                            message, oldVer.ID, oldVer.Name, oldVer.Sex, oldVer.Age, oldVer.Address, oldVer.Telephone, oldVer.Email);
            ;
        }

        private T_test_Linq GetUser(int id)
        {
            T_test_Linq user = new T_test_Linq();
            using (Entities context = new Entities())
            {
                user=context.T_test_Linq.Where(q => q.ID == id).FirstOrDefault();
                return user;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtxt.Text = "";
            T_test_Linq oldVer = GetUser(1);
            DisplayUser("Before", oldVer);

            T_test_Linq user1 = new T_test_Linq()
            {
                ID = 1,
                Name = "GOD",
                Sex = "Male",
                Age = 25,
                Address = "Hell",
                Telephone = "12345678910",
                Email = "fyhuman@heaven.com"
            };

            T_test_Linq user2 = new T_test_Linq()
            {
                ID = 1,
                Name = "GOD",
                Sex = "Female",
                Age = 25,
                Address = "Heaven",
                Telephone = "12345678910",
                Email = "fyhuman@heaven.com"
            };

            MyDelegate mydelegate = new MyDelegate(Update);
            mydelegate.BeginInvoke(user1, null, null);
            mydelegate.BeginInvoke(user2, null, null);

            Thread.Sleep(50);
            T_test_Linq newVer = GetUser(1);
            DisplayUser("After", newVer);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rtxt.Text = "";
            rtxt.Text += "--------------------------------------------------------------------\n";
            rtxt.Text += "主线程开始执行,时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n";
            rtxt.Text += "--------------------------------------------------------------------\n";

            //异步操作
            Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(1000);
                        OutputToRichtext(i);
                    }
                });

            //同步操作
            for (int i = 0; i < 5; i++)
            {
                rtxt.Text += string.Format("异步循环显示序号：{0},时间:{1}\n", i.ToString(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            rtxt.Text += "--------------------------------------------------------------------\n";
            rtxt.Text += "主线程执行结束,时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n";
            rtxt.Text += "--------------------------------------------------------------------\n";
            
            //Thread.Sleep(6000);
            //rtxt.Text = msg;
        }

        private void OutputToRichtext(int i)
        {
            if (rtxt.InvokeRequired)
            {
                MethodInvoker mi = delegate { OutputToRichtext(i); };
                rtxt.Invoke(mi);
                return;
            }
            rtxt.Text += string.Format("异步循环显示序号：{0},时间:{1}\n", i.ToString(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}
