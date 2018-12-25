using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace Helper
{
    public class FileHelper
    {
        /// <summary>
        /// 创建一个文件，OpenOrCreate
        /// </summary>
        /// <param name="path">要创建的文件路径</param>
        /// <param name="content">文件内容</param>
        public static void CreatFiles(string path, byte[] content)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                fs.Write(content, 0, content.Length);
                fs.Flush();
            }
        }
        /// <summary>
        /// 向文件中添加内容
        /// </summary>
        /// <param name="path">要添加文件的路径</param>
        /// <param name="content">要添加到文件中的内容</param>
        public static void AppendContext(string path, byte[] content)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(content);
                sw.Flush();
            }
        }
        /// <summary>
        /// 读取文件中的内容
        /// </summary>
        /// <param name="path">要读取的文件路径</param> 
        /// <param name="index">开始读取的位置</param> 
        /// <param name="length">读取的长度</param> 
        public static string ReadFiles(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                StreamReader reader = new StreamReader(fs);
                return reader.ReadToEnd();
            }
        }
        /// <summary>
        /// 从服务器上下载东西到指定文件中
        /// </summary>
        /// <param name="path">文件在服务器中的路径</param>
        /// <param name="goalPath">下载下来的文件路径,文件名与服务器上的文件名相同</param>
        /// <retrun></retrun>
        public static string UploadFile(string path, string goalPath)
        {
            WebRequest webq = WebRequest.Create(path);
            WebResponse webp = webq.GetResponse();
            string strPath = webp.ResponseUri.AbsoluteUri;
            string fileName = strPath.Substring(strPath.LastIndexOf("/"));
            goalPath += fileName;
            Stream respStream = webp.GetResponseStream();
            int length = (int)webp.ContentLength;
            BinaryReader br = new BinaryReader(respStream, Encoding.UTF8);
            using (FileStream fs = File.Create(goalPath))
            {
                fs.Write(br.ReadBytes(length), 0, length);
                br.Close();
            }
            return goalPath;
        }

        /// <summary>
        /// 返回存储路径加日期后的文件路径，如果文件路径不存在自动创建
        /// </summary>
        /// <param name="fileRootDir">存储的根目录</param>
        /// <returns></returns>
        public static string GetNewFilePath(string fileRootDir)
        {
            string fullPath = string.Empty;
            DateTime n = DateTime.Now;
            StringBuilder sb = new StringBuilder(fileRootDir);
            sb.Append(n.ToString("yyyy"))  //year
              .Append('\\')
              .Append(n.ToString("MM"))  //month
              .Append('\\')
              .Append(n.ToString("dd"))  //day
              .Append('\\');

            fullPath = sb.ToString();

            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);
            return fullPath;
        }

        /// <summary>
        /// 获取根据时间返回的组合路径字符串
        /// </summary>
        /// <returns>yyyy/mm/dd/</returns>
        public static string GetTimePath()
        {
            string fullPath = string.Empty;
            DateTime n = DateTime.Now;
            StringBuilder sb = new StringBuilder();
            sb.Append(n.ToString("yyyy"))  //year
              .Append('/')
              .Append(n.ToString("MM"))  //month
              .Append('/')
              .Append(n.ToString("dd"))  //day
              .Append('/');
            fullPath = sb.ToString();
            return fullPath;
        }

        /// <summary>
        /// 替换文件扩展名称为指定的扩展名
        /// </summary>
        /// <param name="filename">原始文件名</param>
        /// <param name="extName">指定的扩展名</param>
        /// <returns></returns>
        public static string ReplaceFileExtensionName(string filename, string extName)
        {
            string strFilename = filename;
            //文件名是否以extName结尾
            if (!filename.EndsWith("." + extName))
            {
                int index = filename.LastIndexOf(".");
                if (index > -1)
                {
                    //去掉结尾的扩展名，并为文件附加上需要的扩展名
                    strFilename = filename.Substring(0, index) + "." + extName;
                }
                else
                {
                    strFilename = filename + "." + extName;
                }
            }

            return strFilename;
        }

        /// <summary>
        /// 判断文件是否为指定的文件类型
        /// </summary>
        /// <param name="filname">原始文件名</param>
        /// <param name="fileExtNames">文件扩展名集合，用|分割</param>
        /// <returns></returns>
        public static bool IsFileInExtensions(string filname, string fileExtNames)
        {
            //取得文件扩展名
            string fileExtName = filname.Substring(filname.LastIndexOf(".")).ToLower();

            bool isContain = false;
            string[] exts = fileExtNames.Split(new char[] { '|' });
            for (int i = 0; i < exts.Length; i++)
            {
                if (exts[i].ToLower() == fileExtName.ToLower())
                {
                    isContain = true;
                    break;
                }
            }

            return isContain;
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="sourceFile">原文件</param>
        /// <param name="destFile">目的文件</param>
        public static void MoveFile(string sourceFile, string destFile)
        {
            if (!String.IsNullOrEmpty(sourceFile) && !String.IsNullOrEmpty(destFile))
            {
                string source = HttpContext.Current.Server.MapPath(sourceFile);
                string dest = HttpContext.Current.Server.MapPath(destFile);

                string sourceDir = source.Substring(0, source.LastIndexOf("\\") + 1);
                string destDir = dest.Substring(0, dest.LastIndexOf("\\") + 1);

                if (!Directory.Exists(sourceDir))
                    Directory.CreateDirectory(sourceDir);

                if (!Directory.Exists(destDir))
                    Directory.CreateDirectory(destDir);

                if (File.Exists(dest))
                    File.Delete(dest);

                File.Move(source, dest);
            }
        }

        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool FileIsExists(string filename)
        {
            string fullFilename = HttpContext.Current.Server.MapPath(filename);
            return File.Exists(fullFilename);
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static void DeleteFile(string filename)
        {
            string fullFilename = HttpContext.Current.Server.MapPath(filename);
            File.Delete(fullFilename);
        }
    }
}
