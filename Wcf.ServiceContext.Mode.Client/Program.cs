using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wcf.ServiceContext.Mode.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------单调服务--------------");
            //1,单调服务代理实例化，每次调用操作，都会创建不同的服务实例
            WCFServicePerCall.WCFServiceClient perCallProxy = new WCFServicePerCall.WCFServiceClient();
            //循环调用服务
            for (int i = 0; i < 2; i++)
            {
                perCallProxy.SayHello();
            }
            perCallProxy.Close();


            Console.WriteLine("--------------服务会话--------------");
            //2，服务会话代理实例化，一个客户端代理对应一个服务实例
            WCFServicePerSession.WCFServiceClient perSessionProxy = new WCFServicePerSession.WCFServiceClient();
            for (int i = 0; i < 2; i++)
            {
                perSessionProxy.SayHello();
            }
            perSessionProxy.Close();//关闭

            WCFServicePerSession.WCFServiceClient perSessionProxy2 = new WCFServicePerSession.WCFServiceClient();
            for (int i = 0; i < 2; i++)
            {
                perSessionProxy2.SayHello();
            }
            perSessionProxy2.Close();


            Console.WriteLine("--------------单例服务模式--------------");
            //3，单例服务代理 实例化，也叫单件模式。所有的服务只有一个服务实例
            WCFServiceSingleTon.WCFServiceClient singletonProxy = new WCFServiceSingleTon.WCFServiceClient();
            for (int i = 0; i < 2; i++)
            {
                singletonProxy.SayHello();
            }
            singletonProxy.Close();

            WCFServiceSingleTon.WCFServiceClient singletonProxy2 = new WCFServiceSingleTon.WCFServiceClient();
            for (int i = 0; i < 2; i++)
            {
                singletonProxy2.SayHello();
            }
            singletonProxy2.Close();

            Console.Read();
        }
    }
}
