using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Wcf.DataSerialization.Service
{
    /*
     * 序列化基本概念：
     * 1，为什么要序列化？
     *      当一个系统或平台需要别的系统或平台交互时，两个系统之间需要一个特定的公开的可以公用的行业标准
     *      来支持这个数据信息的交互。目前来说支持这个数据交互传递的语言载体就是XML。
     * 2，是序列化？
     *      序列化是指将对象实例的状态存储到存储媒体的过程。此过程中，先将对象的公共字段和私有字段以及类的名称(包括类所在的程序集)
     *      转换成字节流，然后再把字节流写入数据流。在随后对对象进行反序列化时，将创建出与源对象完全相同的副本。
     * 3，序列化的目的？
     *      以某种存储形式使自定义对象持久化；
     *      将对象从一个地方传递到另一个地方。序列化就是把本地消息或数据的类型进行封装，转换为标准的可以跨平台，语言的信息集，
     *      为别的系统或服务使用。
     * 4，序列化机制？
     *      .Net的序列化是通过反射机制自动实现对象的序列化和反序列化。首先.Net能够捕获每个对象字段的值，然后进行序列化。
     *      反序列化时，.Net创建一个对应类型的新的对象，读取持久化的值，然后设置字段的值。
     *      .Net Framework提供三种序列化技术:
     *      1，BinaryFormatter二进制序列化保持类型保真度。(所有的类成员,包括只读的，都可以被序列化，性能高)
     *      2，调用System.Runtime.Serialization.Formatter.Soap下的SoapFormatter类进行序列化和反序列化，序列化之后的文件
     *      是Soap格式的文件。(跨平台，互操作性好，不依赖二进制，可读性强)
     *      3，XML序列化需要引用System.Xml.Serialization，使用XmlSerialize类进行序列化和反序列化，它仅序列化公共属性和字段，
     *      且不保持类型保真度，基于XML标准，支持跨平台数据交互。
     *      
     * WCF序列化机制：
     *      由于.Net格式化固有的缺点，WCF提供了专门用户序列化和反序列化的类:DataContractSerializer，在System.Runtime.Serialization命名空间里。
     */
    [DataContract]//数据契约
    public class UserDataContract
    {
        [DataMember(Name="UserName")]//数据成员标记，支持别名定义
        public string Name { get; set; }

        [DataMember(Name="UserEmail")]//数据成员标记，支持别名定义
        public string Email { get; set; }

        [DataMember]
        public string Mobile { get; set; }

        public string Address { get; set; }//没有[DataMember]声明，不会被序列化
    }
}
