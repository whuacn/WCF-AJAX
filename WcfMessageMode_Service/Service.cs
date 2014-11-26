using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfMessageMode_Service
{
    public class Service : IService
    {
        private string warnMsg = "我在服务器这边休息了5秒，客户端你在还等我吗?";

        public string GetRequestAndResponseModeMessage()
        {
            System.Threading.Thread.Sleep(5000);
            return "请求相应消息模式(只能是客户端调用服务器段，且客户端请求要等待服务器的响应后才继续执行后续操作-异步调用除外)," + warnMsg;
        }

        public void GetSingleModeMessage()
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("被单工模式调用");
        }
    }
}
