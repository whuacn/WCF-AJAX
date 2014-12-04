using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Wcf.Rest.Model;
using Wcf.Rest.Service;

namespace Wcf.Rest.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ChannelFactory<IEmployees> channelFactory = new ChannelFactory<IEmployees>("employeeService"))
            {
                IEmployees proxy = channelFactory.CreateChannel();
                Console.WriteLine("所有员工列表:");
                Array.ForEach<Employee>(proxy.GetAll().ToArray(), e => Console.WriteLine(e));

                Console.WriteLine("\n添加一个新员工(004):");
                proxy.Create(new Employee
                {
                    Id = "004",
                    Name = "赵六",
                    Grade = "G9",
                    Department = "行政部"
                });
                Array.ForEach<Employee>(proxy.GetAll().ToArray(), e => Console.WriteLine(e));

                Console.WriteLine("\n修改员工(004):");
                proxy.Update(new Employee
                {
                    Id = "004",
                    Name = "赵六",
                    Grade = "G11",
                    Department = "行政部"
                });
                Array.ForEach<Employee>(proxy.GetAll().ToArray(), e => Console.WriteLine(e));

                Console.WriteLine("\n删除员工(004)信息:");
                proxy.Delete("003");
                Array.ForEach<Employee>(proxy.GetAll().ToArray(), e => Console.WriteLine(e));

                Console.Read();
            }
        }
    }
}
