using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace Helper
{
    /// <summary>
    /// C# 通过WebRequest上传文件
    /// </summary>
    public class UploadFileHelper
    {
        #region 调用示例

        //NameValueCollection data = new NameValueCollection();
        //data.Add("name", "木子屋");
        //data.Add("fileName","a");
        //data.Add("url", "http://www.mzwu.com/");
        //Console.WriteLine(UploadFileHelper.HttpUploadFile("http://localhost:35330/File/Upload", new string[] { @"E:\Index.htm", @"E:\test.rar" }, data));

        #endregion

        private static readonly Encoding Defaultencode = Encoding.UTF8;

        /// <summary>
        ///     HttpUploadFile
        /// </summary>
        /// <param name="url"></param>
        /// <param name="file"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string HttpUploadFile(string url, string file, NameValueCollection data)
        {
            return HttpUploadFile(url, file, data, Defaultencode);
        }

        /// <summary>
        ///     HttpUploadFile
        /// </summary>
        /// <param name="url"></param>
        /// <param name="file"></param>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HttpUploadFile(string url, string file, NameValueCollection data, Encoding encoding)
        {
            return HttpUploadFile(url, new[] { file }, data, encoding);
        }

        /// <summary>
        ///     HttpUploadFile
        /// </summary>
        /// <param name="url"></param>
        /// <param name="files"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string HttpUploadFile(string url, string[] files, NameValueCollection data)
        {
            return HttpUploadFile(url, files, data, Defaultencode);
        }

        /// <summary>
        /// HttpUploadFile
        /// </summary>
        /// <param name="url"></param>
        /// <param name="files"></param>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string HttpUploadFile(string url, string[] files, NameValueCollection data, Encoding encoding)
        {
            var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            var boundarybytes = encoding.GetBytes("\r\n--" + boundary + "\r\n");
            var boundaryEndBytes = encoding.GetBytes("\r\n--" + boundary + "--\r\n");

            //创建WebRequest请求
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.KeepAlive = true;
            request.Credentials = CredentialCache.DefaultCredentials;

            using (var stream = request.GetRequestStream())
            {
                //创建表单数据
                if (data != null)
                {
                    const string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
                    foreach (string key in data.Keys)
                    {
                        stream.Write(boundarybytes, 0, boundarybytes.Length);
                        string formItem = string.Format(formdataTemplate, key, data[key]);
                        stream.Write(encoding.GetBytes(formItem), 0, encoding.GetBytes(formItem).Length);
                    }
                }


                //创建文件实体请求
                foreach (string file in files)
                {
                    stream.Write(boundarybytes, 0, boundarybytes.Length);
                    var buffer = new byte[4096];
                    const string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: application/octet-stream\r\n\r\n";
                    var fileName = Path.GetFileName(file);
                    var header = string.Format(headerTemplate, (fileName??"").Split('.')[0], fileName);
                    stream.Write(encoding.GetBytes(header), 0, encoding.GetBytes(header).Length);
                    using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        var bytesRead = 0;
                        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            stream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
                stream.Write(boundaryEndBytes, 0, boundaryEndBytes.Length);
            }

            //获取返回对象
            var response = (HttpWebResponse)request.GetResponse();
            var responseStream = response.GetResponseStream();
            if (responseStream == null) return "";
            using (var stream = new StreamReader(responseStream))
            {
                return stream.ReadToEnd();
            }
        }
    }
}