using System;


namespace Helper.Attributes
{
    /// <summary>
    /// 自定义的特性
    /// </summary>
    public class TrimsAttribute : System.Attribute
    {

        public TrimsAttribute() { }
        public TrimsAttribute(string name, int age)
        {
            _name = name;
            _age = age;
        }

        //定义字段
        private string _name;
        private int _age;
        private string _memo;

        //定义属性
        public string Name
        {
            get { return _name == null ? string.Empty : _name; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }
        //定义方法
        public void ShowName()
        {
            Console.WriteLine("Hello, {0}", _name == null ? "world !" : _name);
        }
    }

    /// <summary>
    /// 用mytest测试特性使用
    /// </summary>
    [Trims("Luu", 20, Memo = "Luu is a particular people", Age = 56)]
    public class Mytest
    {
        public static void SayHello(string name)
        {
            Console.WriteLine("Hello , {0} .net world.", name);
        }
    }

    /// <summary>
    /// 演示特性的方法
    /// </summary>
    //public class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        //如何以反射确定特性信息
    //        Type tp = typeof(Mytest);
    //        //MemberInfo info = tp;
    //        TrimsAttribute myAttribute = (TrimsAttribute)Attribute.GetCustomAttribute(tp, typeof(TrimsAttribute));
    //        if (myAttribute != null)
    //        {
    //            //在运行时查看注释内容
    //            Console.WriteLine("Name:{0}", myAttribute.Name);
    //            Console.WriteLine("Age:{0}", myAttribute.Age);
    //            Console.WriteLine("Memo of {0} is {1}", myAttribute.Name, myAttribute.Memo);
    //            myAttribute.ShowName();
    //        }

    //        //多点反射
    //        object obj = Activator.CreateInstance(tp);
    //        MethodInfo mi = tp.GetMethod("SayHello");
    //        object[] objParams = new object[1] { myAttribute.Name };
    //        mi.Invoke(obj, objParams);
    //        Console.ReadKey();
    //    }
    //}

}
