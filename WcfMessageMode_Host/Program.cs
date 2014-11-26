using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfMessageMode_Service;

namespace WcfMessageMode_Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Service)))
            {
                if (host.State != CommunicationState.Opening)
                {
                    host.Open();
                }
                Console.WriteLine("主机开启，服务状态为:{0}",host.State);
                Console.Read();
            }
        }
    }
}
