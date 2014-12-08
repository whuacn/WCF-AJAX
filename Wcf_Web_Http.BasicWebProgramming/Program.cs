using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Wcf_Web_Http.BasicWebProgramming
{
    //服务契约
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet]
        string EchoWithGet(string s);

        [OperationContract]
        [WebInvoke]//WebInvoke默认是POST调用,可通过其Method属性来修改成PUT,DELETE调用
        string EchoWithPost(string s);
    }

    //服务契约的实现
    public class Service : IService
    {
        public string EchoWithGet(string s)
        {
            return "You said " + s;
        }

        public string EchoWithPost(string s)
        {
            return "You said " + s;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //根据服务类，以及基地址来初始化一个服务宿主
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri("Http://localhost:8000/"));
            try
            {
                //初始化服务终结点,切记绑定的协议为WebHttpBinding
                ServiceEndpoint ep = host.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), "");
                host.Open();
                using (ChannelFactory<IService> cf = new ChannelFactory<IService>(new WebHttpBinding(), "http://localhost:8000"))
                {
                    //添加一个服务的终结点行为---WebHttpBehavior实例
                    cf.Endpoint.EndpointBehaviors.Add(new WebHttpBehavior());
                    IService channel = cf.CreateChannel();

                    string s;

                    Console.WriteLine("Calling EchoWithGet via HTTP GET:");
                    s = channel.EchoWithGet("Hello,world");
                    Console.WriteLine(" OutPut:{0}", s);

                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("This can also be accomplished by navigating to");
                    Console.WriteLine("http://localhost:8000/EchoWithGet?s=Hello, world!");
                    Console.WriteLine("in a web browser while this sample is running.");

                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("Calling EchoWithPost via HTTP POST: ");
                    s = channel.EchoWithPost("Hello, world");
                    Console.WriteLine("   Output: {0}", s);
                    Console.WriteLine("");

                    Console.WriteLine("Press <ENTER> to terminate");
                    Console.ReadLine();
                }
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine("An exception occurred: {0}", cex.Message);
                host.Abort();
            }
            finally
            {
                host.Close();
            }
        }
    }
}
