using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFService
{
    //1，定义服务契约---需要添加System.ServiceModel.dll的引用
    [ServiceContract(Namespace = "http://www.cnblogs.com/startcaft/")]
    public interface IWCFService
    {
        //操作契约-服务所公开的操作
        [OperationContract]
        string SayHello(string name);

        [OperationContract]
        string SayHelloToUser(User user);
    }

    //2.服务类，实现接口，实现服务契约
    public class WCFService : IWCFService
    {
        public string SayHello(string name)
        {
            Console.WriteLine("Hello! {0},Using string ...", name);
            return "Hello! " + name;
        }

        public string SayHelloToUser(User user)
        {
            Console.WriteLine("Hello! {0}   {1},Usiing DataContract ...", user.FirstName, user.LastName);
            return "Hello! " + user.FirstName + " " + user.LastName;
        }
    }

    //3.数据序列，可序列化为XML，作为元数据封装到服务里---需要添加对System.Runtime.Serialization.dll的引用
    [DataContract]
    public struct User
    {
        [DataMember]
        public string FirstName;
        [DataMember]
        public string LastName;
    }
}
