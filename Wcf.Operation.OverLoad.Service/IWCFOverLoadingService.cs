using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Wcf.Operation.OverLoad.Service
{
    /*
     * C#支持方法重载，方法名相同，但参数类型不同，参数个数不同。这是编译时多态的一种实现机制。
     * WCF服务支持核心的web服务协议，同样其元数据交换也是基于XML语言描述，客户端通过WSDL文件来了解服务方法相关的信息。
     * 包括参数的个数，类型，返回值，调用顺序等。
     * 但是WSDL不支持方法的重载，因此我们的WCF服务操作重载就无法通过WSDL暴露给客户端了。
     * 这时候OperationContract特性的Name属性可以出场了
     */
    [ServiceContract]//服务契约
    public interface IWCFOverLoadingService
    {
        [OperationContract(Name="SayHello1")]//操作契约利用Name属性重命名
        string SayHelloOverLoad();
        [OperationContract(Name = "SayHello2")]
        string SayHelloOverLoad(string name);
        [OperationContract(Name = "SayHello3")]
        string SayHelloOverLoad(string firstName, string lastName);
    }
}
