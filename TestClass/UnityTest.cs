using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Helper.Helper.Designer.FactoryModelHelper.cs;

namespace TestClass {
    public class UnityTest {

        public void MyList()
        {
            List<int> ids = new List<int> { 1,2,3,4};
            List(ids);
            Console.WriteLine(ids.Count);
        }

        public void List(List<int> ids)
        {
            ids = new List<int>() { 5,6,7,8,9,10};
            ids.Remove(5);
            Console.WriteLine(ids.Count);
        }

        
        public void Closure()
        {
            Func<String> myFunc = CreateFunction();
            String result = myFunc();
            Console.WriteLine(result);
            string secondReslut = myFunc();
            Console.WriteLine(secondReslut);
            myFunc = CreateFunction2();
            string thirdReslut = myFunc();
            Console.WriteLine(thirdReslut);
        }

        public Func<String> CreateFunction()
        {
            String str = "我的幸运数字是";
            int num = 17;
            Func<String> func = () => str + (num++);
            return func;
        }

        public Func<String> CreateFunction2()
        {
            String str = "我的年龄是";
            int num = 22;
            Func<String> func = () => str + (num++);
            return func;
        }
    }
}