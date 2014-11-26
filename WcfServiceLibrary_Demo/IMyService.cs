using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary_Demo
{
    [ServiceContract(Namespace = "http://www.cnblogs.com/startcaft")]
    public interface IMyService
    {
        [OperationContract]
        string SayHello(string name);

        [OperationContract]
        string SayHelloToUser(User user);

        // TODO: 在此添加您的服务操作
    }

    // 数据契约定义/序列化为XML，作为元数据封装到服务中
    [DataContract]
    public class User
    {
        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        public int Age { get; set; }//不会被序列化以及传递
    }
}
