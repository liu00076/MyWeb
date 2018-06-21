using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper.Helper.File;

namespace TestClass
{
    public class UploadFileTest
    {

        public void TestUploadFile()
        {
            NameValueCollection data = new NameValueCollection();
            data.Add("name", "木子屋");
            data.Add("fileName","a");
            data.Add("url", "http://www.mzwu.com/");
            Console.WriteLine(UploadFileHelper.HttpUploadFile("http://localhost:35330/File/Upload", new string[] { @"E:\Index.htm", @"E:\test.rar" }, data));

        }
    }
}
