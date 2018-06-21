using System.Configuration;

namespace Helper.Config {
    /// <summary>
    /// 自定义读取config节的类
    /// </summary>
    public class ConfigProperty : ConfigurationSection {
        //这里的username，url和节点的属性对应
        [ConfigurationProperty("username", IsRequired = true)]
        public string UserName {
            get { return this["username"].ToString(); }
            set { this["username"] = value; }
        }
        [ConfigurationProperty("url", IsRequired = true)]
        public string Url {
            get { return this["url"].ToString(); }
            set { this["url"] = value; }
        }
    }
    /*web config的配置：
     * <configSections>中的配置：
     * <section name="**" type="Type,NameSpace"/>
     * 子节点配置：
     *  <** username="Luu" password="LuuKai0694"></**>
     * 调用：
     * ConfigProperty ConfigProperty = ConfigurationManager.GetSection("**") as ConfigProperty;
     */
}
