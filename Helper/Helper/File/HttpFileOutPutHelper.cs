using System;
using System.Web;

namespace Helper
{
    /// <summary>
    /// web 中浏览器中文件的输出
    /// </summary>
    public class HttpFileOutPutHelper
    {
        /// <summary>
        /// 将指定的文件输出到客户端，用于客户下载
        /// </summary>
        /// <param name="path">文件相对于站点的路径，以"~/"开头</param>
        /// <param name="context">当前请求的Context对象</param>
        public static void ResponseFile(string path, HttpContext context)
        {
            string filename = System.IO.Path.GetFileName(path);
            ResponseFile(path,filename,context);
        }

        /// <summary>
        /// 将指定的文件输出到客户端，用于客户下载
        /// </summary>
        /// <param name="path">文件相对于站点的路径，以"~/"开头</param>
        /// <param name="fileName">客户端获取到的用户名</param>
        /// <param name="context">当前请求的Context对象</param>
        public static void ResponseFile(string path, string fileName, HttpContext context)
        {
            if (context == null)
                context = HttpContext.Current;
            //将文件的相对路径转化成绝对路径
            path = context.Server.MapPath(path);
            System.IO.Stream iStream = null;
            byte[] buffer = new Byte[10000];
            int length;
            long dataToRead;

            try
            {
                iStream = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
                dataToRead = iStream.Length;
                context.Response.ContentType = "application/octet-stream";
                context.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));

                while (dataToRead > 0)
                {
                    if (context.Response.IsClientConnected)
                    {
                        length = iStream.Read(buffer, 0, 10000);
                        context.Response.OutputStream.Write(buffer, 0, length);
                        context.Response.Flush();

                        buffer = new Byte[10000];
                        dataToRead = dataToRead - length;
                    }
                    else
                    {
                        dataToRead = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
            finally
            {
                if (iStream != null)
                {
                    iStream.Close();
                }
            }
        }
    }
}
