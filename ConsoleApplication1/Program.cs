using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] drives = DriveInfo.GetDrives(); // 获取所有驱动器信息。。
            for (int j = 0; j < drives.Count(); j++)
            {
                string dir = drives[j] + @"TMNData\";
                load(dir);
            }
        }
        static void load(string dir)
        {
            try
            {
                String[] dirs = Directory.GetDirectories(dir);
                for (int i = 0; i < dirs.Count(); i++)
                {
                ss:
                    DateTime wenjian;
                    DateTime Dt = DateTime.Now.Date;
                    string dirswork = dirs[i].Replace(dir, "");
                    string dirss = dirswork;
                    try
                    {
                        wenjian = DateTime.Parse(dirswork);
                    }
                    catch
                    {
                        ++i;
                        goto ss;
                    }
                    TimeSpan ss = wenjian.Date - Dt.Date;
                    if (Convert.ToInt32(ss.TotalDays) < -31)
                    {
                        DirectoryInfo di = new DirectoryInfo(dir + dirss);
                        di.Delete(true);

                    }

                }
            }
            catch
            { }
        }
    }
}
