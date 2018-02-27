using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Protein.Enzyme.Layout.Configuration
{
    /// <summary>
    /// 数据库
    /// </summary>
    public class DataBase : ConfigurationElement
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        [ConfigurationProperty("ConnectionStr", DefaultValue = "", IsRequired = true)]
        public String ConnectionStr
        {
            get
            {
                return (String)this["ConnectionStr"];
            }
            set
            {
                this["ConnectionStr"] = value;
            }
        }

        /// <summary>
        /// 是否加密
        /// </summary>
        [ConfigurationProperty("Secrecy", DefaultValue = false, IsRequired = true)]
        public bool Secrecy
        {
            get
            {
                return (bool)this["Secrecy"];
            }
            set
            {
                this["Secrecy"] = value;
            }
        }
    }
}
