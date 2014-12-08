using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wcf_Web_Http_UriTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * UriTeplate标识统一资源标识符(URI)模版的类,它继承自System.Object
             * 其位于System.ServiceModel程序集中(System.ServiceModel.dll)
             * 
             * URI模版，可以定义一组结构相似的URI。模版由两部分组成，即路径和查询。路径由一些列反斜杠(/)分隔的段组成。
             * 每个段可都可以具有文本值，变量值(书写在大括号中({})且被选址为仅与一个段的内容匹配)或必须出现在路径末端的通配符(书写为型号*，与"路径的其余部分"匹配)。
             * 查询表达式可以完全忽略，如果出现表达式，则它指定一组无序的名称/值对，查询表达式的元素可以是文本对(?x=2)
             * 也可以是变量对(?x={val})。不允许使用不成对的值
             */

            UriTemplate template = new UriTemplate("weather/{state}/{city}?forecast={day}");
            Uri prefix = new Uri("http://localhost");

            Console.WriteLine("路径片段所有的变量名称:");
            foreach (string  name in template.PathSegmentVariableNames)
            {
                Console.WriteLine("     {0}", name);
            }

            Console.WriteLine("查询表达式中的变量名称:");
            foreach (string name in template.QueryValueVariableNames)
            {
                Console.WriteLine("     {0}", name);
            }

            Uri positionaUri = template.BindByPosition(prefix, "Washington", "Redmond", "Today");
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("state", "Washington");
            parameters.Add("city", "Redmond");
            parameters.Add("day", "Today");
            Uri nameUri = template.BindByName(prefix, parameters);

            Uri fullUri = new Uri("http://localhost/weather/Washington/Redmond?forecast=today");
            UriTemplateMatch result = template.Match(prefix, fullUri);

            Console.WriteLine("Matching {0} to {1}", template.ToString(), fullUri.ToString());

            if (result != null)
            {
                foreach (string variableName in result.BoundVariables.Keys)
                {
                    Console.WriteLine("     {0}:{1}", variableName, result.BoundVariables[variableName]);
                }
            }

            Console.Read();
        }
    }
}
