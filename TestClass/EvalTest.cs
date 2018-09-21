using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper.Helper.File;
using System.Diagnostics;
using Helper.Helper.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestClass
{
    [TestClass]
    public static class EvalTest
    {


        [TestMethod]
        public static void Test()
        {
            var list = new List<TT>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new TT() { T1 = i.ToString(), T3 = i });
            }

            Stopwatch sw = new Stopwatch();
            var do1 = typeof(TT).GetEval<Func<TT, string>>("T1+ (T3*100).ToString()");
            var do2 = typeof(TT).GetEval<Func<object, string>>("T1+ (T3*100).ToString() ");
            var do3 = typeof(TT).GetEval<Func<object, object>>("T1+(T3*100).ToString() ");
            sw.Start();
            list.ForEach(p => do1(p));
            Console.WriteLine(sw.Elapsed);
            sw.Restart();
            list.ForEach(p => do2(p));
            Console.WriteLine(sw.Elapsed);
            sw.Restart();
            list.ForEach(p => do3(p));
            Console.WriteLine(sw.Elapsed);
            sw.Restart();
            list.ForEach(p => do1.DynamicInvoke(p));
            Console.WriteLine(sw.Elapsed);
            sw.Stop();
            Console.Read();
        }


        [TestMethod]
        public void Test()
        {
            var data = new Info { id = 1, name = "test", birthday = DateTime.Now };
            string[] props = { "id", "birthday" };//可变
            //var fn = "info." + string.Join("+info.", props);//注释掉是因为 id 和 birthday 类型无法相加
            var fn = "Info.id.ToString()+Info.birthday.ToString()";//这里只是举例，具体可以自己拼写可运行的动态条件
            var p = Expression.Parameter(typeof(Info), "Info");
            var lambda = System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { p }, typeof(string), fn);
            var str = lambda.Compile().DynamicInvoke(data);
            Console.WriteLine(str);
        }

        #region 实体类模型

        public class TT
        {
            public string T1 { get; set; }

            public int T3 { get; set; }
        }

        public class Info
        {
            public int id { get; set; }
            public string name { get; set; }
            public DateTime birthday { get; set; }
        }

        #endregion

    }

}
