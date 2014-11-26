using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication_Client.MyServiceReference;

namespace ConsoleApplication_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //生成HTTP wsHttBiding绑定方式的代理,字符串WSHttpBinding_IMyService是根据客户端自动生成的配置文件来的
            MyServiceReference.MyServiceClient httpProxy = new MyServiceReference.MyServiceClient("WSHttpBinding_IMyService");
            //通过代理调用服务
            Console.WriteLine(httpProxy.SayHello("startcaft WSHTTPBinding"));
            MyServiceReference.User user = new MyServiceReference.User();
            user.FirstName = "WSHttpBinding";
            user.LastName = "Kai";
            Console.WriteLine(httpProxy.SayHelloToUser(user));

            //生成TCP NetTcpBinding_IMyService  绑定的代理
            MyServiceClient tcpProxy = new MyServiceClient("NetTcpBinding_IMyService");
            //通过代理调用服务
            Console.WriteLine(tcpProxy.SayHello("startcaft WSHTTPBinding"));
            User uTcp = new User();
            uTcp.FirstName = "NetTcpBinding";
            uTcp.LastName = "Kai";
            Console.WriteLine(tcpProxy.SayHelloToUser(uTcp));

            Console.Read();
        }
    }
}
