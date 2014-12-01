using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
 * WCF的流处理机制需要使用.Net FrameWork定义的Stream类(它是FileStream，NetworkStream，MemoryStream的父类)
 * 它可以作为返回数据，参数，输出参数的类型，也可以作为单调服务的操作参数(PerCall)
 * 这里使用的参数必须是可序列化的，例如MemoryStream。而FileStream不知序列化。
 * 
 * 流处理机制必须在特定的绑定协议中才能使用。目前是BasicHttpBinding,NetTcpBinding和NetNamePipeBinding支持流处理模型。
 * 但是在默认情况下，WCF禁止流处理模式。
 * 
 * 流处理模式使用TransferMode进行配置，TransferMode为枚举类型
 * Buffered = 0，The request and response messages are both buffered
 * Streamed = 1，The request and response messages are both streamed
 * StreamedRequest = 2，The request message is streamed and the response message is buffered
 * StreamedResponse = 3，The request message is buffered and the response message is streamed
 */
namespace Wcf.Streaming.Service
{
    [ServiceContract(Namespace = "http://www.cnblogs.com/startcaft/")]
    public interface IWCFService
    {
        [OperationContract]//操作契约，获取数据流
        MemoryStream DownLoadStreamData(string fileName);

        [OperationContract]//操作契约，输出数据流
        void DownLoadStreamDataOut(out MemoryStream stream, string fileName);

        [OperationContract(IsOneWay=true)]//操作契约，上载数据流，单向操作
        void UpLoadStreamData(Stream stream);
    }

    public class WCFService : IWCFService
    {
        public MemoryStream DownLoadStreamData(string fileName)
        {
            byte[] file = new byte[200000];//初始化一个byte数组，
            string filePath = AppDomain.CurrentDomain.BaseDirectory + @"/" + fileName;//初始化文件路径
            file = File.ReadAllBytes(filePath);//打开一个文件，并将内容塞进byte[]数组中。
            MemoryStream ms = new MemoryStream(file);//使用饱满的byte[]数组来初始化一个内存流对象
            return ms;
        }

        public void DownLoadStreamDataOut(out MemoryStream stream, string fileName)
        {
            byte[] file = new byte[200000];
            string filePath = AppDomain.CurrentDomain.BaseDirectory + @"/" + fileName;
            file = File.ReadAllBytes(filePath);
            MemoryStream ms = new MemoryStream(file);
            stream = ms;
        }

        public void UpLoadStreamData(Stream stream)
        {
            Console.WriteLine("The Stream length is {0}", stream.Length);
        }
    }
}
