using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    // 注意: 如果更改此处的类名 "WCFServices"，也必须更新 App.config 中对 "WCFServices" 的引用。
    public class WCFServices : IWCFServices
    {
        Ticket T = new Ticket();
        /*实现添加票数的方法*/
        public void AddTicket(int count)
        {
            T.HowMany = T.HowMany + count;
        }
        /*实现返回票数的方法*/
        public int GetRemainingNum()
        {
            return T.HowMany;
        }
        /*实现购买车票的方法*/
        public int BuyTickets(int Num)
        {
            if (T.BoolCalue)
            {
                T.HowMany = T.HowMany - Num;
                return 1;
            }
            else
            {
                return 0;
            }
        } 
    }
}
