using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wcf.Transaction.Service;

namespace Wcf.Transaction.Host
{
    class Program
    {
        /*
         * 1，事务的概念：
         *      事务是一个数据库系统中的概念。事务(Transaction)是并发控制的基本单位。所谓事务，它是一个操作序列，
         *      这些操作学列，要么都不执行，要么都执行，它是一个不可分割的工作单位。
         * 2，事务属性：
         *      事务也有自己的特性(ACID)
         *      (1)原子性：事务必须是原子工作单位，要么全部执行，要么全部都不执行。
         *      (2)一致性：事务在完成时，必须使所有的数据都保持一直。
         *      (3)隔离性：由并发事务所做的修改必须与任何其他并事务所作的修改隔离。也就是说两个并发的事务不能操作同一项数据。
         *      (4)持久性
         * 
         * WCF支持分布式事务，也就是说事务可以跨越服务边界，进程，近期，网络，在多个客户端和服务之间存在。
         * 3，事务协议：
         *      WCF使用不同的事务协议来控制事务执行范围(execution scope),事务协议的出现是为了实现分布式事务传播。
         *      (1)Lightweight：仅在同一程序域的上下文中传递事务。PS：性能最好的协议，也是最没用的，WCF中没有一种Binding协议支持它。
         *      (2)WS-Atomic(WSAT)：允许事务跨越程序域，进程或机器边界。WSAT是一种工业标准，
         *      采用HTTP协议，TEXT编码，可以跨越防火墙，虽然WAST也能用于Intranet(内部网络)，但多数时它用于Internet环境
         *      
         * WCF在预定义绑定中实现了标准的WSAtomicTransaction(WS-AT)协议和Microsoft专有的OleTx协议,
         * 这些协议可以用来在消息中加入事务状态的信息。OleTx协议将是默认的协议。我们可以编程或者配置文件设置事务协议。
         * <bindings>
         *  <netTcpBinding>
         *      <bindiing name="TransactionalNetTCP"
         *          transactionFlow = "true"
         *          transactionProtocol  = "WSAtomicTransactionOctober2004"/>
         *  <netTcpBinding>
         * </bindings>
         * 
         * 4，事务编程
         *      WCF事务范围可以设计到客户端，服务端，这个取决于项目的具体情况。在WCF的事务模式主要由绑定协议，
         *      事务流属性，事务范围属性决定。在WCF所有的绑定协议中不是所有的协议都支持事务。是事务流属性
         *      TransactionFlowAttribute只能用于服务方法(Operation/Method)上，它允许我们进行不同的事务参与设置。
         *      不能为IsOnWay=true(单工消息模式)的服务设置事务流支持;
         *      TransactionFlowOption.NotAllowed:不参与任何事务。(默认值)
         *      TransactionFlowOption.Allowed:允许参与事务。如果调用方和服务Binding启用了事务，则参与
         *      TransactionFlowOption.Mandatory:强制启用事务，调用方和服务Binding必须启用事务才能调用服务。
         *      
         *      Client/Service Transaction, 最常见的一种事务模型，通常由客户端或服务本身启用一个事务。设置步骤：
         *      -1：选择一个支持事务的Binding，设置TransactionFlow = true。
         *      -2：设置TransactionFlow(TransactionFlowOption.Allowed)。
         *      -3：设置OperationBehavior(TransactionScopeRequired=true)。
         *      
         *      Client Transacion事务模式，强制五福必须参与事务，而且必须是客户端启用事务，设置步骤：
         *      -1：选择一个支持事务的Binding，设置TransactionFlow = true。
         *      -2：设置 TransactionFlow(TransactionFlowOption.Mandatory)。
         *      -3：设置 OperationBehavior(TransactionScopeRequired=true)。
         *      
         *      Service Transaction模式，服务必去启用一个根事务，且不参与任何外部事务。设置步骤：
         *      -1：选择任何一种Binding，设置 TransactionFlow = false(默认)。
         *      -2：设置 TransactionFlow(TransactionFlowOption.NotAllowed)。
         *      -3：设置 OperationBehavior(TransactionScopeRequired=true)。
         */
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WCFServiceTransaction1)))
            {
                if (host.State !=CommunicationState.Opening)
                host.Open();
                //显示运行状态
                Console.WriteLine("Host1 is runing! and state is {0}", host.State);
                //等待输入即停止服务
                Console.Read();
            }
        }
    }
}
