using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfMessageMode_Client.WCFServiceReference;

namespace WcfMessageMode_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IService responseService = new ServiceClient();
            string result = responseService.GetRequestAndResponseModeMessage();
            Console.WriteLine(result);

            responseService.GetSingleModeMessage();

            Console.ReadKey();
        }
    }
}
