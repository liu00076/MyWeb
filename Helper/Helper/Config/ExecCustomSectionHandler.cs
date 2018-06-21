using System.Configuration;
using System.Xml;

namespace Helper.Config {
    //用自定义处理config节点程序
    public class ExecCustomSectionHandler:IConfigurationSectionHandler {
        /// <summary>
        /// 实现接口中的对象，详细信息，请查看接口说明。
        /// </summary>
        public object Create(object parent, object configContext, XmlNode section) {
            //section 为自定义节点，通过处理section 获取对象的详细信息。
            return null;
        }
        /*对应的configSections配置为：
         * <section name="sectionName" type="type,namespace"/>
         * 节点配置没有严格的要求，因为这个节点是自己自定义读取的。
         * client调用：
         * object o = ConfigurationManager.GetSection("sectionName");
         */
    }
}
