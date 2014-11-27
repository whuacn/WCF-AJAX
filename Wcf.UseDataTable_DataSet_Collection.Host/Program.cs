using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wcf.UseDataTable_DataSet_Collection.Service;

namespace Wcf.UseDataTable_DataSet_Collection.Host
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
                Console.WriteLine("host is opened...");
                Console.Read();
            }
        }
    }
}
