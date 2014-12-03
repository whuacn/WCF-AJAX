using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Wcf.Rest.Service;

namespace Wcf.Rest.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            //原来使用ServiceHost来进行服务寄宿，现在改成它的子类WebServiceHost
            using (WebServiceHost host = new WebServiceHost(typeof(EmployeesService)))
            {
                if (host.State != CommunicationState.Opening)
                {
                    host.Open();
                }
                Console.WriteLine("主机开启，服务状态为:{0}", host.State);
                Console.Read();
            }
        }
    }
}
