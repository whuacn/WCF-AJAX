using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFClients.WcfServiceReference;

namespace WCFClients
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * WCF规定客户端不能直接与服务交互，必须通过代理，代理公开的操作与服务一样，代理同时增加了对一些对服务管理的方法
             * 
             * 服务寄宿的目的就是开启一个进程，为WCF服务提供一个运行的环境。
             */

            //创建服务代理对象(在添加对服务的引用时，自动生成)
            using (WCFServiceClient proxy = new WCFServiceClient())
            {
                //通过代理调用SayHello服务
                Console.WriteLine(proxy.SayHello("startcaft"));
                //通过代理调用SayHelloToUser服务,传递对象
                User user = new User();
                user.FirstName = "kai";
                user.LastName = "Pi";
                Console.WriteLine(proxy.SayHelloToUser(user));

                Console.Read();
            }
        }
    }
}
