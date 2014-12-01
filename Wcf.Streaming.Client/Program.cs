using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wcf.Streaming.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string fileName = "xxx.jpg";
                ServiceReference.WCFServiceClient tcpProxy = new ServiceReference.WCFServiceClient("NetTcpBinding_IWCFService");
                Console.WriteLine("Client Chanel state is : {0}", tcpProxy.State);

                //测试1，上传文件，
                string filePath = AppDomain.CurrentDomain.BaseDirectory + fileName;

                //读取文件数据
                byte[] upFile = File.ReadAllBytes(filePath);
                MemoryStream ms = new MemoryStream(upFile);
                tcpProxy.UpLoadStreamData(ms);
                //输出上传数据流的信息
                Console.WriteLine("UpLoadingStream data length is {0}", ms.Length);

                //测试2，下载文件
                Stream stream = tcpProxy.DownLoadStreamData(fileName);
                Console.WriteLine("DownLoadingStream data length is : {0}", stream.Length);


                ////测试3，下载文件，使用流下载文件 错误
                //Stream streamOut = tcpProxy.DownLoadStreamDataOut(fileName);
                //Console.WriteLine("DownLoadingStream data length is : {0}", streamOut.Length);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Console.WriteLine("");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }
    }
}
