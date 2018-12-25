using System;
using System.Threading;

namespace TestClass
{
    /// <summary>
    /// 测试timer的基本用法
    /// </summary>
    public class TimerTest
    {

        public void textThread()
        {
            Thread thread = Thread.CurrentThread;
            var objF = new { name = "Luu", age = 25 };
            var objN = new { name = "Liu", age = 24 };
            try
            {
                Monitor.Enter(objF);
                objF = objN;
            }
            catch
            {

            }
            finally
            {
                Monitor.Exit(objF);
            }
            Console.WriteLine();

            string str = "1111";
            char[] chars = str.ToCharArray();
        }
    }
}
