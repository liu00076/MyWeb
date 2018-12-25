using Helper;


namespace TestClass
{
    using System;
    using System.Collections.Specialized;
    using System.IO;
    using System.Reflection;
    public class HelperTest
    {

        public void start()
        {
            Console.WriteLine(JsonHelper.ToJson(new { name = "Liu", age = 25 }));
        }

        public class myName
        {
            public string otherName = "Jing";
            public static string name = "Liu";
            public const string constStr = "HaHa";


            public string OtherName
            {
                get { return otherName; }
                set { otherName = value; }
            }
        }

        public void TestType()
        {
            myName person = new myName();
            MemberInfo[] members = person.GetType().GetMembers();

            foreach (MemberInfo m in members)
            {
                if (m is FieldInfo)
                {
                    TextWriter write = new StringWriter();
                    FieldInfo f = m as FieldInfo;
                    write.Write(f.GetValue(person).ToString());
                    Console.WriteLine("{0}:{1}", f.Name, write.ToString());
                }
            }
        }

        public void TestConvertNameValueCollection()
        {
            NameValueCollection nameValue = new NameValueCollection();
            nameValue.Add("OtherName", "nihao");
            myName name = AssemblyHelper.Convert<myName>(nameValue);
            Console.WriteLine(name.OtherName);
        }
    }
}
