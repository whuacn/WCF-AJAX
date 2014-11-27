using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wcf.DataSerialization.Client.ServiceReference;

namespace Wcf.DataSerialization.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            WCFServiceClient proxy = new WCFServiceClient("BasicHttpBinding_IWCFService");
            Console.WriteLine("Test call service using HTTP--------------------.");

            //实例化数据契约对象，设置信息
            UserDataContract user = new UserDataContract();
            user.UserName = "WCF Client: Frank Xu Lei";
            user.UserEmail = "WCF Client: frank_xl@163.com ";
            user.Mobile = "WCF Client:1666666666";

            proxy.AddNewUser(user);

            string name = "WCF Client: Frank Xu";
            UserDataContract user1 = proxy.GetUserByName(name);
            if (user1 != null)
            {
                Console.WriteLine(user1.UserName);
                Console.WriteLine(user1.UserEmail);
                Console.WriteLine(user1.Mobile);
            }

            //Debuging
            Console.WriteLine("Press any key to continue");
            Console.Read();
        }
    }
}
