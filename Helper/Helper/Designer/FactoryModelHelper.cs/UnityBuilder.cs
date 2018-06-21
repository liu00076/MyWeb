using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Helper.Helper.Designer.FactoryModelHelper.cs
{
    /// <summary>
    /// Unity依賴注入抽象基類
    /// </summary>
    public abstract class UnityBuilder
    {
        /// <summary>
        /// 容器
        /// </summary>
        protected IUnityContainer Container;

        /// <summary>
        /// 默認構造函數
        /// </summary>
        protected UnityBuilder()
        { }

        /// <summary>
        /// 構造函數
        /// </summary>
        /// <param name="configName">配置文件名稱</param>
        /// <param name="sectionName">節點名稱</param>
        /// <param name="containerName">容器名稱</param>
        protected UnityBuilder(string configName, string sectionName, string containerName)
        {
            this.BuildFactory(configName, sectionName, containerName);
        }

        /// <summary>
        /// 根據配置文件，加載Unity 容器
        /// </summary>
        /// <param name="configName"></param>
        /// <param name="sectionName"></param>
        /// <param name="containerName"></param>
        protected virtual void BuildFactory(string configName, string sectionName, string containerName)
        {
            try
            {
                this.Container = new UnityContainer();
                DirectoryInfo i = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                string configFilePath = Path.Combine(Path.Combine(i.FullName, ConfigurationManager.AppSettings["SOLUCTION_ROOT_PATH"]), configName);
                ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                map.ExeConfigFilename = configFilePath;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                UnityConfigurationSection unitySection = config.GetSection(sectionName) as UnityConfigurationSection;
                this.Container.LoadConfiguration(unitySection, containerName);
            }
            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
                throw ex;
            }
        }

        /// <summary>
        /// 獲取指定接口的默認配置的實例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        /// <summary>
        /// 根據register 名稱加載接口實例
        /// </summary>
        /// <typeparam name="T">接口類型</typeparam>
        /// <param name="name">register 名稱</param>
        /// <returns></returns>
        public virtual T Resolve<T>(string name)
        {
            return Container.Resolve<T>(name);
        }

        /// <summary>
        /// 根據register名稱及構造函數的參數加載接口實例
        /// unityBuilder.Resolve(register的name,new ParameterOverride(, entity));
        /// </summary>
        /// <typeparam name="T">接口類型</typeparam>
        /// <param name="name">register 名稱</param>
        /// <param name="parameters">構造參數</param>
        /// <returns></returns>
        public virtual T Resolve<T>(string name, ResolverOverride parameters)
        {
            return Container.Resolve<T>(name, parameters);
        }

        /// <summary>
        /// 獲取指定接口的默認配置的實例
        /// </summary>
        /// <typeparam name="T">接口類型</typeparam>
        /// <param name="parameters">構造參數</param>
        /// <returns></returns>
        public virtual T Resolve<T>(ResolverOverride parameters)
        {
            return Container.Resolve<T>(parameters);
        }

        /// <summary>
        /// 獲取指定接口的所用配置的實例集合
        /// </summary>
        /// <typeparam name="T">接口類型</typeparam>
        /// <returns>實例集合</returns>
        public IEnumerable<T> ResolveAll<T>()
        {
            return Container.ResolveAll<T>();
        }
    }
}
