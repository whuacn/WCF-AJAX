using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Wcf.Rest.Model;

namespace Wcf.Rest.Service
{
    public class EmployeesService : IEmployees
    {
        private static IList<Employee> employees = new List<Employee>
        {
            new Employee{ Id = "001", Name="张三", Department="开发部", Grade = "G7"}, 
            new Employee{ Id = "002", Name="李四", Department="人事部", Grade = "G6"},
            new Employee{ Id = "003", Name="王五", Department="销售部", Grade = "G8"}
        };

        public IEnumerable<Model.Employee> GetAll()
        {
            return employees;
        }

        public Model.Employee Get(string id)
        {
            Employee e = employees.FirstOrDefault(f => f.Id == id);
            if (null == e)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            return e;
        }

        public void Create(Model.Employee employee)
        {
            employees.Add(employee);
        }

        public void Update(Model.Employee employee)
        {
            Delete(employee.Id);
            employees.Add(employee);
        }

        public void Delete(string id)
        {
            Employee e = this.Get(id);
            if (null != e)
            {
                employees.Remove(e);
            }
        }
    }
}
