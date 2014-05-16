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
    public partial class Form4 : Form
    {
        public Form4()  
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(1000);
            this.TopMost = true;
            this.timer1.Start();
        }

        private void Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //System.Diagnostics.Process.Start("http://localhost:8081");
            webBrowser1.Navigate("http://www.21cn.com");
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (this.Visible == true)
            //    this.Visible = false;
            //else
            //{
            //    this.Visible = true;
            //    this.TopMost = true;
            //    this.TopMost = false;
            //}


            this.Show(); 
            this.WindowState = FormWindowState.Normal;
            this.Activate(); 
            this.timer1.Interval = 2000;
            switch (this.StopAanhor)
            { 
              case AnchorStyles.Top:this.Location = new Point(this.Location.X, 0); break;
              case AnchorStyles.Left:this.Location = new Point(0, this.Location.Y); break;
              case AnchorStyles.Right:this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, this.Location.Y); break;
              case AnchorStyles.Bottom:this.Location = new Point(this.Location.X, Screen.PrimaryScreen.Bounds.Height - this.Height); break;
            }

        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            progressBar1.Value = (int)((e.MaximumProgress / e.CurrentProgress) * 100);
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void linkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Link_LinkClicked(null, null);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Form4_LocationChanged(object sender, EventArgs e)
        {
            this.mStopAnhor();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Interval = 50;
            if (this.Bounds.Contains(Cursor.Position)) 
            { 
                switch (this.StopAanhor) 
                { 
                    case AnchorStyles.Top:this.Location = new Point(this.Location.X, 0); break;
                    case AnchorStyles.Left:this.Location = new Point(0, this.Location.Y); break; 
                    case AnchorStyles.Right:this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, this.Location.Y); break;
                    case AnchorStyles.Bottom:this.Location = new Point(this.Location.X, Screen.PrimaryScreen.Bounds.Height - this.Height); break;
                }
            }
            else
            { 
                switch (this.StopAanhor)
                { 
                    case AnchorStyles.Top:this.Location = new Point(this.Location.X, (this.Height - 4) * (-1)); break;
                    case AnchorStyles.Left:this.Location = new Point((-1) * (this.Width - 4), this.Location.Y); break;
                    case AnchorStyles.Right:this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 4, this.Location.Y); break; 
                    case AnchorStyles.Bottom:this.Location = new Point(this.Location.X, (Screen.PrimaryScreen.Bounds.Height - 4)); break; 
                }
            }
        }

        internal AnchorStyles StopAanhor = AnchorStyles.None;

        private void mStopAnhor()
        {
            if (this.Top <= 0 && this.Left <= 0) 
            {
                StopAanhor = AnchorStyles.None; 
            } 
            else
                if (this.Top <= 0) 
                {
                    StopAanhor = AnchorStyles.Top;
                }
                else
                    if (this.Left <= 0)           
                    {              
                        StopAanhor = AnchorStyles.Left;    
                    }            
                    else 
                        if (this.Left >= Screen.PrimaryScreen.Bounds.Width - this.Width)         
                        {                
                            StopAanhor = AnchorStyles.Right;        
                        }           
                        else 
                            if (this.Top >= Screen.PrimaryScreen.Bounds.Height - this.Height)          
                            {             
                                StopAanhor = AnchorStyles.Bottom;      
                            }         
                            else      
                            {        
                                StopAanhor = AnchorStyles.None;    
                            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Show(); 
            this.WindowState = FormWindowState.Normal; 
            this.Activate();
            this.timer1.Interval = 2000;
            switch (this.StopAanhor)
            {
                case AnchorStyles.Top:this.Location = new Point(this.Location.X, 0); break;
                case AnchorStyles.Left:this.Location = new Point(0, this.Location.Y); break; 
                case AnchorStyles.Right:this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, this.Location.Y); break; 
                case AnchorStyles.Bottom:this.Location = new Point(this.Location.X, Screen.PrimaryScreen.Bounds.Height - this.Height); break;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false; this.notifyIcon1.Visible = false; this.Close(); this.Dispose(); Application.Exit();
        }

        private void Form4_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) { this.Hide(); }
        }

    }
}
