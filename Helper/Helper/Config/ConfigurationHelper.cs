using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;

namespace Helper.Config
{
    public class ConfigurationHelper
    {

        /// <summary>
        /// 根据值获取appsetting配置中的value
        /// </summary>
        /// <param name="key">appsetting中的key</param>
        /// <returns>appsetting中对应的value</returns>
        public static string GetAppSetting(string key)
        {
            string value = ConfigurationManager.AppSettings.Get(key);
            return value;
        }
        /// <summary>
        /// 获取配置文件中的Appsetting配置
        /// </summary>
        /// <returns>Appsetting中的对应值</returns>
        public static NameValueCollection GetValueCollection()
        {
            NameValueCollection collection = ConfigurationManager.AppSettings;
            return collection;
        }

        /*对应的configSections配置为：
         * <section name="sectionName" type="System.Configuration.SingleTagSectionHandler"/>
         * 节点配置为：
         * <sectionName key1="**" key2="**" />
         */
        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <returns></returns>
        public static Hashtable GetHash(string sectionName)
        {
            if (string.IsNullOrEmpty(sectionName)) return null;
            return (Hashtable)ConfigurationManager.GetSection(sectionName);
        }

        /*对应的configSections配置为：
         * <section name="sectionName" type="System.Configuration.DictionarySectionHandler"/>
         * 节点配置为：
         *<sectionName>
         *   <add key="Name" value="LuuKai" />
         *   <add key="Age" value="30" />
         *</sectionName>
         */
        /// <summary>
        /// 根据配置文件获取Idictionary对象
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static IDictionary GetDict(string sectionName)
        {
            if (string.IsNullOrEmpty(sectionName)) return null;
            return (IDictionary)ConfigurationManager.GetSection(sectionName);
        }

        /*对应的configSections配置为：
         * <section name="sectionName" type="System.Configuration.NameValueSectionHandler"/>
         * 节点配置为：
         *<sectionName>
         *   <add key="Name" value="LuuKai" />
         *   <add key="Age" value="30" />
         *</sectionName>
         */
        /// <summary>
        /// 根据配置文件获取NameValueCollection对象
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public static NameValueCollection GetNameValue(string sectionName)
        {
            if (string.IsNullOrEmpty(sectionName)) return null;
            return (NameValueCollection)ConfigurationManager.GetSection(sectionName);
        }
        
        /// <summary>
        /// 获取用户自定义的config文件，文件的样式为：.config,
        /// 在客户端可以通过自定义section重新设置config中的配置。
        /// </summary>
        /// <returns></returns>
        public static Configuration GetCustomConfig(string customConfig)
        {
            if (string.IsNullOrEmpty(customConfig)) return null;
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string result = Path.Combine(path, customConfig);
            Configuration config = ConfigurationManager.OpenExeConfiguration(result);
            return config;
        }
    }
}