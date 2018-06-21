using System.Configuration;

namespace Helper.Config {
    /// <summary>
    /// 自定义读取configuration块的类
    /// </summary>
    public class ConfigElement : ConfigurationSection {
        [ConfigurationProperty("users", IsRequired = true)]
        public MysectionElement Users {
            get { return (MysectionElement)this["users"]; }
        }
    }
    public class MysectionElement : ConfigurationElement {
        [ConfigurationProperty("username", IsRequired = true)]
        public string UserName {
            get { return this["username"].ToString(); }
            set { this["username"] = value; }
        }
        [ConfigurationProperty("password", IsRequired = true)]
        public string PassWord {
            get { return this["password"].ToString(); }
            set { this["password"] = value; }
        }
    }
    /*web config的配置：
     * <configSections>中的配置：
     * <section name="**" type="Type,NameSpace"/>
     * 子节点配置：
     *<**>
     *  <users username="Luu" password="LuuKai0694"></users>
     *</**>
     * 调用：
     * ConfigurationElement configurationElement = ConfigurationManager.GetSection("**") as ConfigurationElement;
    */
}