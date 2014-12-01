using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wcf.Streaming.Service;

namespace Wcf.Streaming.host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WCFService)))
            {
                ////判断是否以及打开连接，如果尚未打开，就打开侦听端口
                if (host.State != CommunicationState.Opening)
                    host.Open();
                //显示运行状态
                Console.WriteLine("Host is runing! and state is {0}", host.State);
                //等待输入即停止服务
                Console.Read();
            }
        }
    }
}
