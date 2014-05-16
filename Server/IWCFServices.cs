using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    // 注意: 如果更改此处的接口名称 "IWCFServices"，也必须更新 App.config 中对 "IWCFServices" 的引用。
    [ServiceContract]
    public interface IWCFServices
    {
        [OperationContract]
        /* 增加车票的方法*/
        void AddTicket(int count);
        [OperationContract]
        /*购买车票的方法*/
        int BuyTickets(int Num);
        [OperationContract] //服务契约 即提供服务的实现方法 
        /*查询车票的方法*/
        int GetRemainingNum();
        // 任务: 在此处添加服务操作 
    }
    // 使用下面示例中说明的数据约定将复合类型添加到服务操作。 
    [DataContract] //数据契约 
    public class Ticket
    {
        bool boolCount = true;//判断是否还有车票 
        int howmany = 10;//还有多少车票 
        [DataMember]
        /*判断是否还有票*/
        public bool BoolCalue
        {
            get { return boolCount; }
            set
            {
                if (HowMany > 0)
                {
                    boolCount = false;
                }
                else
                {
                    boolCount = true;
                }
            }
        }
        [DataMember]
        /*返回票数*/
        public int HowMany
        {
            get { return howmany; }
            set { howmany = value; }
        }
    } 
}
