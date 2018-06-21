using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Helper.Designer.FactoryModelHelper.cs
{
    /// <summary>
    /// 
    /// </summary>
    public class FactoryHelper : UnityBuilder
    {
        /// <summary>
        /// 領域業務對象倉儲配置文件名稱
        /// 在AppSetting中配置 SOLUCTION_ROOT_PATH，里面的unity config文件
        /// </summary>
        private const string ConfigName = "XXXX.config";

        /// <summary>
        /// 配置節點名稱
        /// </summary>
        private const string Section = "unity";

        /// <summary>
        /// 容器名稱
        /// </summary>
        private const string ContainerName = "registers";

        /// <summary>
        /// 領域業務對象倉儲構造工廠實例
        /// </summary>
        private static readonly FactoryHelper Instance = new FactoryHelper(ConfigName, Section, ContainerName);

        /// <summary>
        /// 私有構造函數
        /// </summary>
        /// <param name="configName">配置文件名稱</param>
        /// <param name="sectionName">節點名稱</param>
        /// <param name="containerName">容器名稱</param>
        private FactoryHelper(string configName, string sectionName, string containerName)
            : base(configName, sectionName, containerName)
        { }

    }
}
