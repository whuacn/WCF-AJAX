using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wcf.Operation.OverLoad.Service
{
    public class WCFService : IWCFOverLoadingService
    {
        #region IWCFOverLoadingService 成员

        public string SayHelloOverLoad()
        {
            Console.WriteLine("Hello! ,This an overloading demo for WCF Service ");
            return "Hello! This an overloading demo for WCF Service  ";
        }

        public string SayHelloOverLoad(string name)
        {
            Console.WriteLine("Hello! {0},This an overloading demo WCF Service ", name);
            return "Hello! " + name + ", This an overloading demo for WCF Service ";
        }

        public string SayHelloOverLoad(string firstName, string lastName)
        {
            Console.WriteLine("Hello! {0}    {1},This an overloading demo WCF Service", firstName, lastName);
            return "Hello! " + firstName + " " + lastName + ", This an overloading demo for WCF Service "; 
        }

        #endregion
    }
}
