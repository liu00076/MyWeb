
using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Helper {
    public class DecodeHelper
    {

        #region System.Web.HttpUtility是处理编码和解码的主要类
        /// <summary>
        /// 字符串转换URL编码
        /// </summary>
        /// <param name="urlToEncode"></param>
        /// <returns></returns>
        public static string UrlEncode(string urlToEncode) {
            if(string.IsNullOrEmpty(urlToEncode))
                return urlToEncode;

            return System.Web.HttpUtility.UrlEncode(urlToEncode);
        }
        /// <summary>
        /// URL编码转换字符串
        /// </summary>
        /// <param name="urlToDecode"></param>
        /// <returns></returns>
        public static string UrlDecode(string urlToDecode) {
            if(string.IsNullOrEmpty(urlToDecode))
                return urlToDecode;

            return System.Web.HttpUtility.UrlDecode(urlToDecode);
        }        
        #endregion
    }
}
