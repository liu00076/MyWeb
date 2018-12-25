using System;
using System.Web;

namespace Helper
{
    /// <summary>
    /// 2013年10月16日 ，cookie处理相关
    /// </summary>
    public class CookieHelper
    {
        #region //Cookie处理
        /// <summary>
        /// 读Cookie值
        /// </summary>
        /// <param name="cookieName">cookie名</param>
        /// <returns></returns>
        public static String ReadCookie(String cookieName)
        {
            HttpContext httpContext = HttpContext.Current;
            if (httpContext.Request.Cookies.Count == 0)
            {
                return String.Empty;
            }

            HttpCookie httpCookie = httpContext.Request.Cookies[cookieName];

            if (httpCookie == null)
            {
                return String.Empty;
            }

            return httpCookie.Value;
        }

        public static void WriteCookie(String cookieName, String cookieValue, String cookiePath)
        {
            WriteCookie(cookieName, cookieValue, cookiePath, 10);
        }

        public static void WriteCookie(String cookieName, String cookieValue, String cookiePath, Int32 expireMinutes)
        {
            WriteCookie(cookieName, cookieValue, cookiePath, String.Empty, expireMinutes);
        }

        /// <summary>
        /// 写Cookie
        /// </summary>
        /// <param name="cookieName">cookie名</param>
        /// <param name="cookieValue">cookie值</param>
        /// <param name="cookiePath">cookie路径</param>
        /// <param name="domain">cookie域</param>
        /// <param name="expireMinutes">cookie过期分钟数</param>
        public static void WriteCookie(String cookieName, String cookieValue, String cookiePath, String domain, Int32 expireMinutes)
        {
            HttpContext httpContext = HttpContext.Current;

            HttpCookie clientCookie = new HttpCookie(cookieName);
            clientCookie.Name = cookieName;
            clientCookie.Value = cookieValue;
            clientCookie.Path = cookiePath;
            clientCookie.Domain = domain;
            clientCookie.Expires = DateTime.Now.AddMinutes(expireMinutes);

            httpContext.Response.AppendCookie(clientCookie);
        }
        #endregion
    }
}
