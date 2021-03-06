﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzureTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = 0;
            int m = 0;
            int q = 0;
            int[] qa;

            List<Computer> computers = new List<Computer>();
            List<Request> requests = new List<Request>();
            List<Record> records = new List<Record>();

            Console.WriteLine("Plase enter the number of times a test:");
            int.TryParse(Console.ReadLine(), out t);
            while (CheckT(t))
            {
                Console.WriteLine("The input is not currect,plase try again .");
                int.TryParse(Console.ReadLine(), out t);
            }

            qa = new int[t];

            for (int i = 0; i < t; i++)
            {
                Console.WriteLine("Plase enter the number of computer and the number of request:");
                string str = Console.ReadLine();
                while (str.Split(new char[] { ' ' }).Count() != 2 || CheckM(str.Split(new char[] { ' ' })[0]) || CheckQ(str.Split(new char[] { ' ' })[1]))
                {
                    Console.WriteLine("The input is not currect,plase try again .");
                    str = Console.ReadLine();
                }
                int.TryParse(str.Split(new char[] { ' ' })[0], out m);
                int.TryParse(str.Split(new char[] { ' ' })[1], out q);

                qa[i] = q;
                //while (CheckM(m) || CheckQ(q))
                //{
                //    Console.WriteLine("The input is not currect,plase try again .");
                //    str=Console.ReadLine();
                //    int.TryParse(str.Split(new char[] { ' ' })[0], out m);
                //    int.TryParse(str.Split(new char[] { ' ' })[1], out q);
                //}

                Console.WriteLine(string.Format("Plase enter number of core for {0} computer:", m.ToString()));

                for (int mi = 0; mi < m; mi++)
                {
                    Computer comp = new Computer();
                    comp.tID = i;
                    comp.compID = mi;
                    comp.core = 0;
                    comp.used = 0;

                    int ci = 0;
                    int.TryParse(Console.ReadLine(), out ci);
                    while (CheckCi(ci))
                    {
                        Console.WriteLine("The input is not currect,plase try again .");
                        int.TryParse(Console.ReadLine(), out ci);
                    }
                    comp.core = ci;
                    comp.coreStatus = new int[ci];

                    computers.Add(comp);
                }

                SortList(computers,i);
                Console.WriteLine(string.Format("Plase enter {0} requests:",q.ToString()));

                for (int qi = 0; qi < q; qi++)
                {
                    Request req = new Request();
                    req.tID = i;
                    req.reqID = qi;

                    string strReq = Console.ReadLine();
                    char reqType=' ';
                    int cq = 0;
                    while (strReq.Split(new char[] { ' ' }).Count() != 2 || CheckQtype(strReq.Split(new char[] { ' ' }, 2)[0]) || CheckReqNum(strReq.Split(new char[] { ' ' }, 2)[1]))
                    {
                        Console.WriteLine("The input is not currect,plase try again .");
                        strReq = Console.ReadLine();
                    }

                    char.TryParse(strReq.Split(new char[] { ' ' }, 2)[0], out reqType);
                    int.TryParse(strReq.Split(new char[] { ' ' }, 2)[1], out cq);

                    //while (CheckQtype(reqType) || CheckCi(cq))
                    //{
                    //    Console.WriteLine("The input is not currect,plase try again .");
                    //    strReq = Console.ReadLine();
                    //    char.TryParse(strReq.Split(new char[] { ' ' }, 2)[0], out reqType);
                    //    int.TryParse(strReq.Split(new char[] { ' ' }, 2)[1], out cq);
                    //}
                    req.reqType = reqType;
                    req.reqNum = cq;

                    requests.Add(req);
                }
            }

            Console.WriteLine("Output:\n");
            for (int ti = 0; ti < t; ti++)
            {
                Console.WriteLine(string.Format("Case #{0}:\n",ti.ToString()));
                for (int qi = 0; qi < qa[ti]; qi++)
                {
                    var rTemp = requests.Where(z => z.tID == ti && z.reqID == qi).FirstOrDefault();
                    string str=Solution(rTemp,computers,records);
                    Console.WriteLine(str + "\n");
                    foreach (Computer cpt in computers)
                    {
                        if (cpt.tID != ti)
                            continue;
                        Console.WriteLine("Computer ID: " + cpt.compID+" Core:"+cpt.core+" Core used:"+cpt.used);
                    }
                }
            }
            Console.ReadLine();
            return;

        }

        private static string Solution(Request rTemp,List<Computer> comList,List<Record> reList)
        {
            string restr = "";
            if (rTemp.reqType == 'A')
            {
                int k = 0;
                foreach (Computer cpt in comList)
                {
                    if (cpt.core - cpt.used < rTemp.reqNum || cpt.tID != rTemp.tID)
                    {
                        k = k + 1;
                        continue;
                    }

                    int rq = rTemp.reqNum;
                    Record rec = new Record();
                    rec.tID = cpt.tID;
                    rec.reqID = rTemp.reqID;
                    rec.compID = cpt.compID;
                    rec.coreused = new int[rq];
                    int ct = rec.coreused.Count();

                    for (int co = 0; co < cpt.coreStatus.Count(); co++)
                    {
                        if (cpt.coreStatus[co] == 1)
                            continue;
                        if (rq <= 0)
                            break;
                        rec.coreused[ct - rq] = co;
                        cpt.coreStatus[co] = 1;
                        rq = rq - 1;
                        cpt.used = cpt.used + 1;
                    }
                    reList. Add(rec);
                    restr = string.Format("{0} {1}", rec.compID.ToString(), rec.coreused[0].ToString());
                    SortDescending(comList, k,rTemp.tID);
                    break;
                }
            }
            else
            {
                var rec2 = reList.Where(z => z.tID == rTemp.tID && z.reqID == rTemp.reqNum).FirstOrDefault();
                if (rec2 != null)
                {
                    int k = 0;
                    foreach (Computer cpt in comList)
                    {
                        if (cpt.tID != rec2.tID || cpt.compID != rec2.compID)
                        {
                            k = k + 1;
                            continue;
                        }

                        foreach (int reused in rec2.coreused)
                        {
                            cpt.coreStatus[reused] = 0;
                            cpt.used = cpt.used - 1;
                        }
                        restr = string.Format("{0} {1}", cpt.compID.ToString(), rec2.coreused[0].ToString());
                        SortAcscending(comList, k,rTemp.tID);
                        break;
                    }
                }
            }

            if (restr == "")
                restr = "-1 -1";
            return restr;
        }

        private static void SortList(List<Computer> clist,int tid)
        {
            Computer cpt = new Computer();
            for (int i = 1; i < clist.Count; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (clist[j].tID != tid)
                        continue;
                    if (clist[j].core - clist[j].used >= clist[j - 1].core - clist[j - 1].used)
                        break;

                    cpt = clist[j - 1];
                    clist[j - 1] = clist[j];
                    clist[j] = cpt;
                }
            }
        }

        private static void SortAcscending(List<Computer> clist,int index,int tid)
        {
            Computer cpt = new Computer();
            for (; index < clist.Count-1; index++)
            {
                if (clist[index].tID != tid)
                    continue;
                if (clist[index].core - clist[index].used <= clist[index + 1].core - clist[index + 1].used)
                    break;
                cpt = clist[index + 1];
                clist[index + 1] = clist[index];
                clist[index] = cpt;
            }
        }

        private static void SortDescending(List<Computer> clist, int index,int tid)
        {
            Computer cpt = new Computer();
            for (; index > 0;index--)
            {
                if (clist[index].tID != tid)
                    continue;
                if (clist[index].core - clist[index].used > clist[index - 1].core - clist[index - 1].used)
                    break;
                cpt = clist[index - 1];
                clist[index - 1] = clist[index];
                clist[index] = cpt;
            }
        }


        private static bool CheckT(int input)
        {
            if (input <= 0 || input > 20)
                return true;
            return false;
        }

        private static bool CheckM(string input)
        {
            int m = 0;
            int.TryParse(input, out m);
            if (m <= 0 || m > 10000)
                return true;
            return false;
        }

        private static bool CheckQ(string input)
        {
            int q = 0;
            int.TryParse(input, out q);
            if (q <= 0 || q > 1000000)
                return true;
            return false;
        }

        private static bool CheckCi(int input)
        {
            if (input <= 0 || input > 128)
                return true;
            return false;
        }

        private static bool CheckQtype(string input)
        {
            char c = '0';
            char.TryParse(input, out c);
            if (c != 'A' && c != 'F')
                return true;
            return false;
        }

        private static bool CheckReqNum(string input)
        {
            int r = 0;
            int.TryParse(input, out r);
            if (r < 0 || r > 128)
                return true;
            return false;
        }
    }

    class Computer
    {
        public int tID;//测试ID
        public int compID;//机器ID
        public int core;//核心数
        public int used;//已使用核心数
        public int[] coreStatus;//核心使用状况
    }

    class Request
    {
        public int tID;//测试ID
        public int reqID;//请求ID
        public char reqType;//请求类型
        public int reqNum;//申请核心数或释放核心ID
    }

    class Record
    {
        public int tID;//测试ID
        public int reqID;//请求ID
        public int compID;//机器ID
        public int[] coreused;//占用的核心编号
    }
}
