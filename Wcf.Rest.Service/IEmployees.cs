using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Wcf.Rest.Model;

namespace Wcf.Rest.Service
{
    [ServiceContract(Namespace = "http://www.startcaft.com")]//服务契约
    public interface IEmployees
    {
        /*
         * 注意这里不再使用OperationContractAttribute特性。
         * 替换OperationContractAttribute特性的分别是WebGetAttribute和WebInvokeAttribute
         * 它们同一定义在System.ServiceModel.Web程序集中
         */

        [WebGet(UriTemplate = "all")]
        IEnumerable<Employee> GetAll();

        [WebGet(UriTemplate = "{id}")]
        Employee Get(string id);

        [WebInvoke(UriTemplate = "/", Method = "POST")]
        void Create(Employee employee);

        [WebInvoke(UriTemplate = "/",Method = "PUT")]
        void Update(Employee employee);

        [WebInvoke(UriTemplate = "{id}",Method = "DELETE")]
        void Delete(string id);
    }
}
