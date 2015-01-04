using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FSEMIStool
{
    public partial class Form1 : Form
    {
        List<string> pathList = new List<string>();//路径列表

        public Form1()
        {
            InitializeComponent();
            //读取路径文件
            string path = Application.StartupPath;
            FileStream fs = new FileStream(path+"\\pathList.dat", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            if (fs.Length > 0)
            {
                pathList = bf.Deserialize(fs) as List<string>;
            }
            foreach (var s in pathList)
            {
                listBoxPath.Items.Add(s.ToString());
            }
            fs.Close();

            //载入需要复制的文件名列表
            listBoxFile.Items.Add("fsqyEIMS.exe");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath.ToString();
                if (path.EndsWith(@"\"))
                    path = path.Replace(@"\", "");
                pathList.Add(path);
                listBoxPath.Items.Add(path);
            }
            SaveListToDat();
        }

        private void SaveListToDat()
        {
            string path = Application.StartupPath;
            FileStream fs = new FileStream(path + "\\pathList.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, pathList);
            fs.Close();
        }


        private void btnCopy_Click(object sender, EventArgs e)
        {
            btnCopy.Enabled = false;
            bw.RunWorkerAsync();//异步复制文件
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                listBoxFile.Items.Add(ofd.SafeFileName.ToString());
            }
        }

        private void listBoxPath_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxPath.SelectedItems.Count < 1)
                return;
            int index = listBoxPath.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                string strPath = listBoxPath.SelectedItem.ToString();
                listBoxPath.Items.Remove(strPath);
                pathList.Remove(strPath);
                SaveListToDat();
            }
        }

        private void listBoxFile_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxFile.SelectedItems.Count < 1)
                return;
            int index = listBoxFile.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                string strPath = listBoxFile.SelectedItem.ToString();
                listBoxFile.Items.Remove(strPath);
            }
        }

        List<string> copyFailList = new List<string>();
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            string appPath = Application.StartupPath;
            try
            {
                int i = 0;
                foreach (var s in listBoxFile.Items)
                {
                    //检查复制文件是否存在
                    string sourceFile = appPath + "\\" + s.ToString();
                    if (!File.Exists(sourceFile))
                    {
                        string message = s.ToString() + "不存在";
                        MessageBox.Show(message);
                        return;
                    }
                    //检查目标路径并且开始复制
                    foreach (var p in listBoxPath.Items)
                    {
                        string targetFile = p.ToString()+"\\" + s.ToString();
                        if (Directory.Exists(p.ToString()))
                        {
                            File.Copy(sourceFile, targetFile, true);
                        }
                        else
                        {
                            copyFailList.Add(p.ToString());
                        }
                        bw.ReportProgress((i + 1) *100/( listBoxFile.Items.Count * listBoxPath.Items.Count));
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (copyFailList.Count < 1)
            {
                MessageBox.Show("复制完成");
            }
            else
            {
                string message = "以下路径复制失败:"+Environment.NewLine;
                foreach (var s in copyFailList)
                {
                    message += s.ToString() + Environment.NewLine;
                }
                MessageBox.Show(message);
            }
            btnCopy.Enabled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,
                                    Color.Gray, 0, ButtonBorderStyle.None,
                                    Color.Gray, 0, ButtonBorderStyle.None,
                                    Color.FromKnownColor(KnownColor.ScrollBar), 1, ButtonBorderStyle.Solid,
                                    Color.Gray, 0, ButtonBorderStyle.None);
        }
    }
}
