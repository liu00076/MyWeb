using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helper.Helper;

namespace Helper
{
    /// <summary>
    /// 将对象进行base64编码和解码
    /// </summary>
    public class Base64CovertHelper
    {
        /// <summary>
        /// 将对象转换成base64位的字符串
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="t">对象</param>
        /// <returns></returns>
        public static string EncryptBase64<T>(T t) where T : class, new()
        {
            string result = string.Empty;
            if (t == null) return result;
            byte[] bytes = SerializerHelper.ConverToBytes(t);
            result = Convert.ToBase64String(bytes, Base64FormattingOptions.None);
            return result;
        }

        /// <summary>
        /// 将通过Base64加密的字符串转换成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T DecryptBase64<T>(string str) where T : class, new()
        {
            if (string.IsNullOrEmpty(str)) return default(T);
            byte[] bytes = Convert.FromBase64String(str);
            T t = SerializerHelper.ConvertToObject<T>(bytes);
            return t;
        }
		
		#region 生成短 Token

        /// <summary>
        /// 生成短Token
        /// </summary>
        /// <param name="targetStr"></param>
        /// <returns></returns>
        public static string ShortToken(string targetStr)
        {
            //将字符串转换成Base64编码
            string result = null;
            byte[] tokenData = new UnicodeEncoding().GetBytes(targetStr);
            result = Convert.ToBase64String(tokenData).TrimEnd('=');
            return result;
        }

        #endregion
    }
}
