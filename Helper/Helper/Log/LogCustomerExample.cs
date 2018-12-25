using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using log4net.Core;
using log4net.Layout.Pattern;

namespace Helper.Helper.Log
{
    /// <summary>
    /// log 记录到 sql中 配置自定义属性
    /// </summary>
    public class LogCustomerExample
    {

        /// <summary>
        /// 示例类
        /// </summary>
        private class OperateInfo
        {
            public int UserId { get; set; }
        }

        #region 对应的配置文件

        //如果是string类型的自定义属性。必须配置size，eg：
        //<dbType value="String" />
        //<size value="4000" />

        //<parameter>
        //  <parameterName value="@UserId" />
        //  <dbType value="Int64" />
        //  <layout type="Centa.Agency.Domain.Test.UserIdLayout">
        //    <conversionPattern value="%UserId" />
        //  </layout>
        //</parameter>
        
        #endregion

        /// <summary>
        /// 自定义配置项
        /// </summary>
        public class UserIdLayout : log4net.Layout.PatternLayout
        {
            
            /// <summary>
            /// log XML 自定义列配置
            /// </summary>
            public class UserIdPatternConverter : PatternLayoutConverter
            {
                protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
                {
                    OperateInfo logMessage = loggingEvent.MessageObject as OperateInfo;
                    if (logMessage != null)
                        writer.Write(logMessage.UserId);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public UserIdLayout()
            {
                this.AddConverter("UserId", typeof(UserIdPatternConverter));
            }
        }

    }
}
