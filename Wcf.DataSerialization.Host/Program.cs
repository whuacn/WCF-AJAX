using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wcf.DataSerialization.Service;

namespace Wcf.DataSerialization.Host
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
                Console.WriteLine("主机启动成功，服务状态:{0}", host.State);
                Console.Read();
            }
        }
    }
}
