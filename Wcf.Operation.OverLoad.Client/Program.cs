using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wcf.Operation.OverLoad.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //实例化客户端服务代理-以Tcp协议方式-看客户端自动生成的配置文件
            ServiceOverLoad.WCFOverLoadingServiceClient proxy = new ServiceOverLoad.WCFOverLoadingServiceClient("NetTcpBinding_IWCFOverLoadingService");
            Console.WriteLine("Test call service using TCP--------------------.");
            Console.WriteLine(proxy.SayHello1());
            Console.WriteLine(proxy.SayHello2("Frank Xu Lei"));
            Console.WriteLine(proxy.SayHello3("Lei", "Xu"));

            //实例化客户端服务代理-以Http协议方式-看客户端自动生成的配置文件
            ServiceOverLoad.WCFOverLoadingServiceClient proxyHttp = new ServiceOverLoad.WCFOverLoadingServiceClient("BasicHttpBinding_IWCFOverLoadingService");
            Console.WriteLine("Test call service using HTTP--------------------.");
            Console.WriteLine(proxyHttp.SayHello1());
            Console.WriteLine(proxyHttp.SayHello2("Frank Xu Lei"));
            Console.WriteLine(proxyHttp.SayHello3("Lei", "Xu"));

            Console.Read();
        }
    }
}
