using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wcf.UseDataTable_DataSet_Collection.Client.ServiceReference;

namespace Wcf.UseDataTable_DataSet_Collection.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            WCFServiceClient serviceProxy = new WCFServiceClient("BasicHttpBinding_IWCFService");

            //WCF主要的目标是面向服务，平台无关，使用DataTable,DataSet来传递数据，客户端必须知道ADO.Net关于此类的定义信息，
            //这显然违背了面向服务编程的原则
            Console.WriteLine("from DataTable---");
            DataTable table = serviceProxy.GetDataByTable();
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine(row["func_name"].ToString());
                }
            }

            Console.WriteLine("from DataSet---");
            DataTable dt = serviceProxy.GetDataByDataSet().Tables[0];
            if (dt != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine(row["func_name"].ToString());
                }
            }


            Console.WriteLine("from Collection---");
            //注意这里，服务端使用的List<User>,在客户端被封装成了对应类型的数组
            //WCF为集合类提供了专属的封装机制，客户端范序列化成与之对应类型的数组
            //开发时，推荐使用集合来传递数据
            Func[] funcList = serviceProxy.GetDataByCollection();
            if (funcList.Length > 0)
            {
                foreach (Func f in funcList)
                {
                    Console.WriteLine(f.Name);
                }
            }

            Console.Read();
        }
    }
}
