using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace Protein.Enzyme.Layout.Configuration
{
    /// <summary>
    ///  日志配置
    /// </summary>
    public class LogOrgan : ConfigurationElement
    {
        
        /// <summary>
        /// 处理消息的类型登记 按照枚举的值大小判断
        /// </summary>
        [ConfigurationProperty("RecordLevel", DefaultValue = Message.MessageType.Error, IsRequired = true)]
        public Message.MessageType RecordLevel
        {
            get
            {
                return (Message.MessageType)this["RecordLevel"];
            }
            set
            {
                this["RecordLevel"] = value;
            }
        }
    }
}
