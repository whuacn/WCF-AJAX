using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WCFService;

namespace WCFHost
{
    /*
     * WCF全称Windows Communication Foundation，
     * 是Microsoft为构建面向服务的应用提供的分布式通信编程框架，
     * 是.NET Framework 3.5的重要组成部分。
     * 使用该框架，开发人员可以构建跨平台、安全、可靠和支持事务处理的企业级互联应用解决方案
     */
    class Program
    {
        /*
         * 每个WCF服务均有三个部分构成：
         * 1，服务类，采用基于CLR的语言编写，实现一个或多个方法。通常包含服务器契约，操作契约和数据契约。
         * 2，宿主，一种应用程序域或进程，服务将在该环境中运行。如ASP.NET,EXE,WPF,Window Forms，NT Services，COM+作为宿主(Host)。
         * 3，终结点，服务暴露uchulai的地址，由客户端用于访问服务，WCF中的ABC，即地址(Address)，绑定(Binding)和契约(Contract)。
         */
        static void Main(string[] args)
        {
            //基于WCF服务的类型((typeof(WCFService.WCFService))创建一个ServiceHost对象,通过反射方式创建的
            using (ServiceHost host = new ServiceHost(typeof(WCFService.WCFService)))
            {

                //相同的服务可以注册多个基地址
                //Uri tcpAddress = new Uri("http://localhost:8001/WCFService");
                //Uri httpAddress = new Uri("http://localhost:8002/WCFService");

                //为服务添加一个终结点，采用WSHttpBinding绑定，并指定了服务契约的类型IWCFService
                host.AddServiceEndpoint(typeof(IWCFService), new WSHttpBinding(), "http://127.0.0.1:9999/WcfServices");

                /*
                 * 松耦合是SOA的一个基本的特征，WCF应用中客户端和服务端的松耦合体现在客户端只需要了解WCF服务基本的描述，
                 * 而无须知道具体的实现细节，就可以正常的服务调用。WCF服务的描述通过元数据(Metadata)的形式发布出来。
                 * WCF中元数据的发布通过一个特殊的服务行为ServiceMetadataBehavior实现
                 * 
                 * 正式环境中，这些配置最好使用配置文件来实现。
                 */
                if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                {
                    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;
                    behavior.HttpGetUrl = new Uri("http://127.0.0.1:9999/WcfServices/metadata");
                    host.Description.Behaviors.Add(behavior);
                }

                host.Opened += delegate
                {
                    Console.WriteLine("WCFService服务已经启动，按任意键终止服务!");
                };

                host.Open();
                Console.Read();
            }
        }
    }
}
