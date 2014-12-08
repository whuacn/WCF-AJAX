using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Wcf.Web.Http.ReturnStream.Service;

namespace Wcf.Web.Http.ReturnStream.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            //服务基地址
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            using (ServiceHost host = new ServiceHost(typeof(MyService),new Uri(baseAddress)))
            {
                host.AddServiceEndpoint(typeof(IImageServer), new WebHttpBinding(), "").EndpointBehaviors.Add(new WebHttpBehavior());
                host.Open();

                Console.WriteLine("Service is running");
                Console.Write("Press ENTER to close the host");
                Console.ReadLine();
            }
        }
    }
}
