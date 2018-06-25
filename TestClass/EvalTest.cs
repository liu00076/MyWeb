using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Helper.Helper.File;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestClass
{
    [TestClass]
    public static class EvalTest
    {

        public static T GetEval<T>(this System.Type type, string propertyPath)
        {
            var func = System.Linq.Dynamic.DynamicExpression.ParseLambda(type, null, propertyPath);
            var objParameter = Expression.Parameter(typeof(object), "obj");
            var objConvert = Expression.Convert(objParameter, type);

            var objInvoke = Expression.Invoke(func, objConvert);

            var resultExpression = Expression.Lambda<T>(objInvoke, objParameter);

            return resultExpression.Compile();

        }

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
            var do3 = typeof(TT). GetEval<Func<object, object>>("T1+(T3*100).ToString() ");
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

    }

    public class TT
    {
        public string T1 { get; set; }

        public int T3 { get; set; }
    }


}
