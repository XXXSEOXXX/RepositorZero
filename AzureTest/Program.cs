using System;
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

            List<Computer> computers = new List<Computer>();
            List<Request> requests = new List<Request>();
            List<Record> record = new List<Record>();

            Console.WriteLine("Plase enter the number of times a test:\n");
            int.TryParse(Console.ReadLine(), out t);
            while (CheckT(t))
            {
                Console.WriteLine("The input is not currect,plase try again .\n");
                int.TryParse(Console.ReadLine(), out t);
            }
            for (int i = 0; i < t; i++)
            {
                Console.WriteLine("Plase enter the number of computers and the number of cores:\n");
                string str = Console.ReadLine();
                m = Convert.ToInt16(str.Split(new char[] { ' ' }, 2)[0]);
                q = Convert.ToInt16(str.Split(new char[] { ' ' }, 2)[1]);
                while (CheckM(m) || CheckQ(q))
                {
                    Console.WriteLine("The input is not currect,plase try again .\n");
                    str=Console.ReadLine();
                    m = Convert.ToInt16(str.Split(new char[] { ' ' }, 2)[0]);
                    q = Convert.ToInt16(str.Split(new char[] { ' ' }, 2)[1]);
                }

                Console.WriteLine(string.Format("Plase enter number of cores for {0} computers", m.ToString()));

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
                        Console.WriteLine("The input is not currect,plase try again .\n");
                        int.TryParse(Console.ReadLine(), out ci);
                    }
                    comp.core = ci;
                    comp.coreStatus = new int[ci];

                    computers.Add(comp);
                }

                Console.WriteLine(string.Format("Plase enter {0} requests",q.ToString()));

                for (int qi = 0; qi < q; qi++)
                {
                    Request req = new Request();
                    req.tID = i;
                    req.reqID = qi;

                    string strReq = Console.ReadLine();
                    char reqType=' ';
                    int cq = 0;
                    char.TryParse(strReq.Split(new char[] { ' ' }, 2)[0], out reqType);
                    int.TryParse(strReq.Split(new char[] { ' ' }, 2)[1], out cq);
                    while (CheckQtype(reqType) || CheckCi(cq))
                    {
                        Console.WriteLine("The input is not currect,plase try again .\n");
                        char.TryParse(strReq.Split(new char[] { ' ' }, 2)[0], out reqType);
                        int.TryParse(strReq.Split(new char[] { ' ' }, 2)[1], out cq);
                    }
                    req.reqType = reqType;
                    req.reqNum = cq;

                    requests.Add(req);
                }
            }

            Console.WriteLine("Output:\n");
            for (int ti = 0; ti < t; ti++)
            {
                Console.WriteLine(string.Format("Case #{0}:\n",ti.ToString()));
                for (int qi = 0; qi < q; qi++)
                {
                    var rTemp = requests.Where(z => z.tID == ti && z.reqID == qi).FirstOrDefault();
                    string str=Solution(rTemp);
                }
            }

        }

        private static string Solution(Request rTemp)
        {
            if(rTemp.reqType=='A')
            {

            }
            return "";
        }

        private static bool CheckT(int input)
        {
            if (input <= 0 || input > 20)
                return true;
            return false;
        }

        private static bool CheckM(int input)
        {
            if (input <= 0 || input > 10000)
                return true;
            return false;
        }

        private static bool CheckQ(int input)
        {
            if (input <= 0 || input > 1000000)
                return true;
            return false;
        }

        private static bool CheckCi(int input)
        {
            if (input <= 0 || input > 128)
                return true;
            return false;
        }

        private static bool CheckQtype(char input)
        {
            if (input != 'A' && input != 'F')
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
