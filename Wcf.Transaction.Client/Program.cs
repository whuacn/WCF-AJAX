using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wcf.Transaction.Client.ServiceReference;

namespace Wcf.Transaction.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WCFServiceTransaction1Client proxy = new WCFServiceTransaction1Client())
            {
                try
                {
                    Console.WriteLine("input  name please ");
                    string name = Console.ReadLine();
                    proxy.AddDataUsingAdapter(name);
                    Console.WriteLine("{0} length is :{1}", name, name.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception Message1 is : {0}", ex.Message);
                }

                Console.Read();
            }
        }
    }
}
