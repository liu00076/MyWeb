using System.Collections.Specialized;
using System.IO;
using System.Reflection;

namespace Helper
{
    public class AssemblyHelper
    {
        /// <summary>
        /// 从此程序集加载指定的清单资源。
        /// 资源必须是嵌入项目的资源，调用时是:项目命名空间.资源文件所在文件夹名.资源文件名(有类型)
        /// </summary>        
        /// <param name="name">所请求的清单资源的名称，包含文件类型</param>
        /// <returns></returns>
        public static Stream GetStreams(string name)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetAssemblyName() + "." + name);
            return stream;
        }
        /// <summary>
        /// 获取当前程序集的名称
        /// </summary>
        /// <returns>当前程序集的名称</returns>
        public static string GetAssemblyName()
        {
            string projectName = Assembly.GetExecutingAssembly().GetName().Name.ToString();
            return projectName;
        }

        #region 将匿名模型对象转换成 NameValueCollection 格式

        /// <summary>
        /// 将匿名模型对象转换成 NameValueCollection 格式
        /// </summary>
        /// <param name="sender">要转换的匿名模型</param>
        /// <returns></returns>
        public static NameValueCollection Convert(object sender)
        {
            var collection = new NameValueCollection();
            var properties = sender.GetType().GetProperties();
            foreach (var item in properties)
            {
                collection[item.Name] = item.GetValue(item, null).ToString();
            }
            return collection;
        }

        /// <summary>
        /// 将匿名模型对象转换成 NameValueCollection 格式
        /// </summary>
        /// <param name="T">要转换的匿名模型</param>
        /// <returns></returns>
        public static NameValueCollection Convert<T>(T t) where T : new()
        {
            var collection = new NameValueCollection();
            var properties = t.GetType().GetProperties();
            foreach (var item in properties)
            {
                collection[item.Name] = item.GetValue(item, null).ToString();
            }
            return collection;
        }

        #endregion

        #region 将NameValueCollection格式转换成模型

        /// <summary>
        /// 将NameValueCollection格式转换成模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static T Convert<T>(NameValueCollection sender) where T : new()
        {
            if (sender == null) return default(T);
            T t = new T();
            var properties = t.GetType().GetProperties();
            foreach (var item in properties)
            {
                if (sender[item.Name] != null)
                {
                    item.SetValue(t, sender[item.Name], null);
                }
            }
            return t;
        }

        #endregion
    }
}
