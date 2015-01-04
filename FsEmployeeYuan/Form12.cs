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
                        string message = string.Format("异步循环显示序号：{0},时间:{1}\n", i.ToString(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        Thread.Sleep(1000);
                        OutputToRichtext(message);
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

        private void OutputToRichtext(string msg)
        {
            if (rtxt.InvokeRequired)
            {
                MethodInvoker mi = delegate { OutputToRichtext(msg); };
                rtxt.Invoke(mi);
                return;
            }
            rtxt.Text += msg;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rtxt.Text = "";
            Task task = new Task(() =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        string message= string.Format("Index:{0},ThreadID:{1}\n", i, Thread.CurrentThread.ManagedThreadId);
                        OutputToRichtext(message);
                        Thread.Sleep(1000);
                    }
                });

            task.ContinueWith(t =>
                {
                    string message= string.Format("执行完毕!,ThreadID:{0}\n", Thread.CurrentThread.ManagedThreadId);
                    OutputToRichtext(message);
                }
            );
            task.Start();
            Awaiter();
        }

        private async void Awaiter()
        {
            string message = string.Format("主线程执行完毕!ThreadID:{0}", Thread.CurrentThread.ManagedThreadId);
            await SleepFunc();
            OutputToRichtext(message);
        }

        private Task SleepFunc()
        {
            return Task.Run(()=>Thread.Sleep(11000));
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Image pic=SmallPic(@"C:\Users\cake\Desktop\p2182583413.jpg", @"C:\Users\cake\Desktop\p1.jpg", picBox1.Width);
            picBox1.Image = pic;
        }

        /// <summary>
        /// 按比例缩小图片，自动调整高度
        /// </summary>
        /// <param name="stroldPic">原图片路径和文件名</param>
        /// <param name="strnewPic">缩小后图片保存路径和文件名</param>
        /// <param name="intWidth">缩小的宽度</param>
        public Image SmallPic(string stroldPic, string strnewPic, int intWidth)
        {
            Bitmap objPic, objnewPic;
            try
            {
                objPic = new Bitmap(stroldPic);
                decimal decHeight = Convert.ToDecimal(intWidth)/Convert.ToDecimal(objPic.Width)*objPic.Height;
                int intHeight = Convert.ToInt16(decHeight);
                objnewPic = new Bitmap(objPic, intWidth, intHeight);
                return objnewPic;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objPic = null;
                objnewPic = null;
            }
        }

        BackgroundWorker bw = null;
        ManualResetEvent mr = new ManualResetEvent(true);
        private void button5_Click(object sender, EventArgs e)
        {
            rtxt.Text = null;
            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;    
            bw.DoWork +=new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            bw.ProgressChanged += (s, args) =>
            {
                rtxt.AppendText(string.Format("Thread is running :{0}%", args.ProgressPercentage) + Environment.NewLine);
                progressBar1.Value = args.ProgressPercentage;
            };
            bw.RunWorkerAsync();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == "Pause")
            {
                mr.Reset();
                b.Text = "Continue";
            }
            else
            {
                mr.Set();
                b.Text = "Pause";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bw.CancelAsync();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <=100; i++)
            {
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                Thread.Sleep(500);
                bw.ReportProgress(i, 0);
            }
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                rtxt.Text += "The thread has stopped";
            }
            else
            {
                rtxt.Text += "The thread has finished";
            }
            Stack<int> a = new Stack<int>(10);
            MessageBox.Show(a.Pop().ToString());
        }

        public class Stack<T>
        {
            public T[] m_item;
            public T Pop() { T t = default(T); return t; }
            public T Push(T item) { return item; }
            public Stack(int i)
            {
                m_item = new T[i];
            }
        }
    }
}
