using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Core;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = @"config\Log4Net.config", Watch = true)]
namespace Helper
{
    /*<configSections>节点配置文件
     * <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net"/>
     * <configuration>节点对应的配置内容
     *<log4net configSource="Config\Log4Net.config"/>
     *log4net的注册方式：
     *  1. log4net.Config.XmlConfigurator.Configure(file);
     *  2. 在AssemblyInfo.cs文件中添加 [assembly: log4net.Config .XmlConfigurator()]特性
     */
    /// <summary>
    /// 写日志的帮助类
    /// </summary>
    public class Log4Helper
    {
        private static readonly ILog LogError = log4net.LogManager.GetLogger("LogError");
        private static readonly ILog LogDebugger = log4net.LogManager.GetLogger("LogDebug");

        /// <summary>
        /// 创建Error log ，对应配置文件中的LogError节点
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        public static void ErrorLog(string msg)
        {
            LogError.Error(msg);
        }

        /// <summary>
        /// 创建Error log ，对应配置文件中的LogError节点
        /// </summary>
        /// <param name="descript"></param>
        /// <param name="ex"></param>
        public static void ErrorLog(string descript,Exception ex)
        {
            LogError.Error(descript, ex);
        }

        /// <summary>
        /// 创建Debugger log ，对应配置文件中的LogDebug节点
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        public static void DebuggerLog(string msg)
        {
            LogDebugger.Debug(msg);
        }

        /// <summary>
        /// 创建Debugger log ，对应配置文件中的LogDebug节点
        /// </summary>
        /// <param name="descript"></param>
        /// <param name="ex"></param>
        public static void DebuggerLog(string descript,Exception ex)
        {
            LogDebugger.Debug(descript, ex);
        }
    }
}
