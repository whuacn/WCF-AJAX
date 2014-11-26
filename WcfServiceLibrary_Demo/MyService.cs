using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary_Demo
{
    public class MyService : IMyService
    {
        public string SayHello(string name)
        {
            Console.WriteLine("Hello! {0},Using string ", name);
            return "Hello! " + name;
        }

        public string SayHelloToUser(User user)
        {
            Console.WriteLine("Hello! {0}    {1},Using DataContract ", user.FirstName, user.LastName);
            return "Hello! " + user.FirstName + " " + user.LastName;
        }
    }
}
