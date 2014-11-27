using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wcf.ServiceContext.Mode.Service;

namespace Wcf.ServiceContext.Mode.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            //1，单调服务WCFServicePerCall
            ServiceHost perCall = new ServiceHost(typeof(WCFServicePerCall));
            if (perCall.State != CommunicationState.Opening)
            {
                perCall.Open();
            }
            Console.WriteLine("WCFServicePerCall主机已经开启，服务状态为:{0}", perCall.State);

            //2，会话服务WCFServicePerSession
            ServiceHost perSession = new ServiceHost(typeof(WCFServicePerSession));
            if (perSession.State != CommunicationState.Opening)
            {
                perSession.Open();
            }
            Console.WriteLine("WCFServicePerSession主机已经开启，服务状态为:{0}", perSession.State);

            //3，单例服务WCFServiceSingleTon
            ServiceHost singleTon = new ServiceHost(typeof(WCFServiceSingleTon));
            if (singleTon.State != CommunicationState.Opening)
            {
                singleTon.Open();
            }
            Console.WriteLine("WCFServiceSingleTon主机已经开启，服务状态为:{0}", singleTon.State);

            Console.Read();


            //关闭
            perCall.Close();
            perSession.Close();
            singleTon.Close();
        }
    }
}
