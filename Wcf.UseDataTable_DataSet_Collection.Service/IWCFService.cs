using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Wcf.UseDataTable_DataSet_Collection.Service
{
    [ServiceContract(Namespace="http://www.cnblogs.com/startcaft")]//服务契约
    public interface IWCFService
    {
        [OperationContract]//操作契约
        DataTable GetDataByTable();

        [OperationContract]//操作契约
        DataSet GetDataByDataSet();

        [OperationContract]//操作契约
        List<Func> GetDataByCollection();
    }

    public class WCFService : IWCFService
    {
        public DataTable GetDataByTable()
        {
            DataSet ds = new DataSet();
            DataTable dt = null;
            SqlConnection sqlCon = new SqlConnection("server=192.168.1.2;database=HK_ZC;uid=sa;pwd=123456");
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select func_id,func_name,par_func_id from s_func", sqlCon);
                da.Fill(ds, "TableWCF");
                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
                sqlCon.Close();
            }
            Console.WriteLine("Calling WCF Service,Transfer data using DataTable");
            return dt;
        }

        public DataSet GetDataByDataSet()
        {
            DataSet ds = new DataSet();
            SqlConnection sqlCon = new SqlConnection("server=192.168.1.2;database=HK_ZC;uid=sa;pwd=123456");
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select func_id,func_name,par_func_id from s_func", sqlCon);
                da.Fill(ds, "TableWCF");
            }
            catch
            {
            }
            finally
            {
                sqlCon.Close();
            }
            Console.WriteLine("Calling WCF Service,Transfer data using dataSet");
            return ds;
        }

        public List<Func> GetDataByCollection()
        {
            List<Func> list = new List<Func>();
            for (int i = 0; i < 10; i++)
            {
                Func func = new Func();
                func.pId = 20 + i;
                func.Name = string.Format("a{0}b{0}c.aspx", i.ToString());
                list.Add(func);
            }
            Console.WriteLine("Calling WCF Service,Transfer data using Collection");
            return list;
        }
    }

    [DataContract]//数据契约
    public class Func
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int pId { get; set; }
    }
}
