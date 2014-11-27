using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Wcf.DataSerialization.Service
{
    [ServiceContract(Namespace="http://www.cnblogs.com/startcaft")]//服务契约
    public interface IWCFService
    {
        [OperationContract]//操作契约
        bool AddNewUser(UserDataContract user);

        [OperationContract]
        UserDataContract GetUserByName(string name);
    }

    //服务类，继承服务契约并实现之
    public class WCFService : IWCFService
    {

        #region IWCFService 成员

        public bool AddNewUser(UserDataContract user)
        {
            //这里可以定义数据持久化操作，访问数据库==
            Console.WriteLine("Hello! ,This an DataContract demo for WCF Service ");
            Console.WriteLine("UserName: {0} ",user.Name);
            Console.WriteLine("UserEmail: {0}",user.Email);
            Console.WriteLine("Mobile: {0}",user.Mobile);
            return true;
        }

        public UserDataContract GetUserByName(string name)
        {
            UserDataContract user = new UserDataContract();
            user.Address = "ShangHai China";
            user.Email = "frank_xl@163.com";
            user.Name = "Frank Xu Lei";
            Console.WriteLine("Hello! {0},This an overloading demo WCF Service ", name);
            return user;
        }

        #endregion
    }
}
