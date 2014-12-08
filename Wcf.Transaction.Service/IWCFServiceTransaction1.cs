using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Wcf.Transaction.Service
{
    //服务契约
    [ServiceContract(Namespace = "http://www.cnblogs.com/frank_xl/", SessionMode = SessionMode.Required)]
    public interface IWCFServiceTransaction1
    {
        //操作契约,禁止事务流，启用事务
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.NotAllowed)]
        bool AddDataUsingAdapter(string name);
    }

    //服务类，实现契约
    //事务有30分钟的超时限制
    [ServiceBehavior(IncludeExceptionDetailInFaults = true,TransactionTimeout="00:30:00",InstanceContextMode=InstanceContextMode.PerCall)]
    public class WCFServiceTransaction1 : IWCFServiceTransaction1
    {
        //实现接口定义的方法
        //需要事务环境，启用事务
        [OperationBehavior(TransactionScopeRequired=true)]
        public bool AddDataUsingAdapter(string name)
        {
            System.Transactions.Transaction transaction = System.Transactions.Transaction.Current;
            //断言是一个本地事务
            Debug.Assert(System.Transactions.Transaction.Current.TransactionInformation.DistributedIdentifier == Guid.Empty);
            //输出事务信息
            Console.WriteLine("Create a new Transaction at {0}", System.Transactions.Transaction.Current.TransactionInformation.CreationTime);
            Console.WriteLine("WCFService 1 Transaction Status is {0}", System.Transactions.Transaction.Current.TransactionInformation.Status);
            Console.WriteLine("WCFService 1 Transaction LocalIdentifier is {0}", System.Transactions.Transaction.Current.TransactionInformation.LocalIdentifier);
            Console.WriteLine("WCFService 1 Transaction DistributedIdentifier is {0}", System.Transactions.Transaction.Current.TransactionInformation.DistributedIdentifier);
            //启动事务
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    //操作序列1
                    Console.WriteLine("Calling WCF Transaction{0} length is:{1} at : {2}", name, name.Length,DateTime.Now.ToString());
                    Console.WriteLine("Calling WCF Transaction{0} length is:{1} at : {2}", name, name.Length, DateTime.Now.ToString());
                }
                catch (Exception e)
                {
                    System.Transactions.Transaction.Current.Rollback();
                    Console.WriteLine("Calling WCF Transaction error:{0}", e.Message);
                    return false;
                }
                ts.Complete();
                return true;
            }
        }
    }
}
