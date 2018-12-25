using System;
using System.Text;

namespace Helper
{
    /// <summary>
    /// 编码解码帮助类
    /// </summary>
    public class EncodingHelper
    {
        /// <summary>
        /// 字符格式1转到字符格式2
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="src">原格式:UTF-8,GBK,GB2312</param>
        /// <param name="des">新格式:UTF-8,GBK,GB2312</param>
        /// <returns></returns>
        public static string F1ToF2(string str, string previousEncoding, string newEncoding)
        {
            try
            {
                Encoding f1 = Encoding.GetEncoding(previousEncoding);
                Encoding f2 = Encoding.GetEncoding(newEncoding);//Encoding.Default ,936
                byte[] temp = f1.GetBytes(str);
                byte[] temp1 = Encoding.Convert(f1, f2, temp);
                string result = f2.GetString(temp1);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
