using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

/*
     * WCF的通信模式有三种：
     * 1，请求响应模式：客户端调用服务器端，并且只有在服务器段响应后客户端才能执行后续操作(异步调用除外)，这是WCF的默认通信消息模式
     * 2，单工模式：客户端调用服务器端，服务器端不任何响应
     * 3，双工模式：客户端和服务器端能相互调用，客户端得实现一个接口的类用于服务器端调用；
     *                      客户端不用等待服务器端的响应就可以继续执行后续操作；
     *                      服务器端自动调用在客户端中的接口实现类的方法。
     */
namespace WcfMessageMode_Service
{
    [ServiceContract]//默认请求响应消息模式
    public interface IService
    {
        [OperationContract]//默认消息模式为：请求响应
        string GetRequestAndResponseModeMessage();

        [OperationContract(IsOneWay=true)]//设置消息模式为:单工模式,不能有返回值，参数列表中不能有out，ref关键字
        void GetSingleModeMessage();
    }
}
