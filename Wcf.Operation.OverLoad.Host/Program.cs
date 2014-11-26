using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wcf.Operation.OverLoad.Service;

namespace Wcf.Operation.OverLoad.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WCFService)))
            {
                if (host.State != CommunicationState.Opening)
                {
                    host.Open();
                }
                Console.WriteLine("主机启动完成，服务状态为:{0}", host.State);
                Console.Read();
            }
        }
    }
}
