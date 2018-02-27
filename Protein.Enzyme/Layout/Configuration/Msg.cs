using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace Protein.Enzyme.Layout.Configuration
{
    /// <summary>
    /// message配置
    /// </summary>
    public class Msg : ConfigurationElement
    {
        
        /// <summary>
        /// 处理消息的类型登记 按照枚举的值大小判断
        /// </summary>
        [ConfigurationProperty("MessageLevel", DefaultValue = Message.MessageType.Error, IsRequired = true)]
        public Message.MessageType MessageLevel
        {
            get
            {
                return (Message.MessageType)this["MessageLevel"];
            }
            set
            {
                this["MessageLevel"] = value;
            }
        }


        /// <summary>
        /// 是否使用历史记录
        /// </summary>
        [ConfigurationProperty("UseHistory", DefaultValue = true, IsRequired = true)]
        public bool UseHistory
        {
            get
            {
                return (bool)this["UseHistory"];
            }
            set
            {
                this["UseHistory"] = value;
            }
        }

        /// <summary>
        /// 历史记录最大数
        /// </summary>
        [ConfigurationProperty("HistoryMaxCount", DefaultValue = 100, IsRequired = true)]
        public int HistoryMaxCount
        {
            get
            {
                return (int)this["HistoryMaxCount"];
            }
            set
            {
                this["HistoryMaxCount"] = value;
            }
        }
    }
}
