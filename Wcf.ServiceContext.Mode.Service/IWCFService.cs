using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

/*
 * WCF支持三种实例激活的模式:  InstranceContextMode枚举定义了这三种模式,PerSession;PerCall;Single
 * 1，单调服务(Call Service)：每次的【客户端请求】都会分配一个新的服务实例。服务实例的生命周期仅限于一次调用的开始与结束。
 *      类似于.Net Remoting的SingleCall模式。
 *      (1)客户端调用服务代理，代理将调用转发给服务。
 *      (2)WCF创建一个服务代理，然后调用服务实例的方法。
 *      (3)当方法返回时，如果对象实现了IDisposable接口，WCF将调用IDisposable.Dispose()方法。
 *      开发配置：使用[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]来配置服务行为。
 *      Tips：[ServiceBehavior]标签只能作用类上
 *      
 * 2，会话服务(Sessionful Service)：为每次【客户端的连接】分配一个服务实例，类似于.Net Remoting的客户端激活模式。
 *      为每个客户端创建一个专门的服务实例，只要会话没有结束，该实例就不会被销毁。对于会话服务而言，是一个客户端代理
 *      对应一个服务实例。也就是说，会话服务中的服务与代理是相应的，而不是对应于一个客户端。
 *      开发配置：使用[ServiceBehavior(InstanceContextMode = InstanContextMode.PerSession)]来配置服务行为。
 *      Tips：1，[ServiceBehavior]标签只能作用类上；
 *               2，服务类配置好之后，需要在服务契约以及配置[ServiceContract(SessionMode = SessionMode.Allowed)]
 *               来确定服务是否启用了会话模式，SessionMode为枚举类型:Allowed;Required;NotAllowed;
 *               3，不是所有的绑定协议都支持会话传输模式的，HTTP为状态连接，无法保证其与客户端的会话连接。
 *
 * 3，单例服务(Singleton Service)：单例模式服务，针对所有客户端而言，都只有一个服务实例，它的生存期不受GC管理，
 *      不会终止，只有在关闭宿主时，才会被释放，创建宿主时，单例服务的实例就会被创建。
 *      开发配置：使用[ServiceBehavior(InstanceContextMode = InstanContextMode。Single)]来配置服务行为
 *      Tips：单例服务同一时间只能相应一个客户端请求。因此在系统的吞吐量，效率，性能上都存在严重的瓶颈
 *               
 */
namespace Wcf.ServiceContext.Mode.Service
{
    #region 单调服务的示例

    //服务契约-允许会话(不是强制的)
    [ServiceContract(SessionMode = SessionMode.Allowed,Namespace="http://www.cnblogs.com/startcaft")]
    public interface IWCFService
    {
        [OperationContract]//操作契约
        void SayHello();
    }

    //服务类---单调服务()
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class WCFServicePerCall : IWCFService, IDisposable
    {
        private int instanceCount = 0;//服务实例计数器

        //构造
        public WCFServicePerCall()
        {
            Console.WriteLine("WCFServicePerCall 实例已经被创建...");
        }

        public void SayHello()
        {
            instanceCount++;
            Console.WriteLine("WCFServicePerCall 实例个数为:{0}", instanceCount);
        }

        public void Dispose()
        {
            Console.WriteLine("WCFServicePerCall 实例已经被销毁...");
        }
    }

    #endregion

    #region 服务会话的示例

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class WCFServicePerSession : IWCFService,IDisposable
    {
        private int instanceCount = 0;

        public WCFServicePerSession()
        {
            Console.WriteLine("WCFServicePerSession 实例已经被创建...");
        }

        public void SayHello()
        {
            instanceCount++;
            Console.WriteLine("WCFServicePerSession 实例个数为: {0} ", instanceCount);
        }

        public void Dispose()
        {
            Console.WriteLine("WCFServicePerSession 实例已经被销毁...");
        }
    }

    #endregion

    #region 单例服务的示例

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class WCFServiceSingleTon : IWCFService, IDisposable
    {
        //服务实例计数
        private int mCcount = 0;
        public WCFServiceSingleTon()
        {
            Console.WriteLine("WCFServiceSingleTon 实例已经被创建...");
        }

        public void SayHello()
        {
            mCcount++;
            Console.WriteLine("WCFServiceSingleTon 实例个数为: {0} ", mCcount);
        }

        public void Dispose()
        {
            Console.WriteLine("WCFServiceSingleTon 实例已经被销毁...");
        }
    }

    #endregion
}
