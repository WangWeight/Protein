using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace Protein.Enzyme.Layout.Configuration
{
    /// <summary>
    /// DAL实体对象配置
    /// </summary>
    public class DAlEntity : ConfigurationElement
    {
        /// <summary>
        /// 程序集名称
        /// </summary>
        [ConfigurationProperty("AssemblyName", DefaultValue = "", IsRequired = true)] 
        public String AssemblyName
        {
            get
            {
                return (String)this["AssemblyName"];
            }
            set
            {
                this["AssemblyName"] = value;
            }
        }

        /// <summary>
        /// 程序日志类名
        /// </summary>
        [ConfigurationProperty("ProteinLog", DefaultValue = "", IsRequired = true)]
        public String ProteinLog
        {
            get
            {
                return (String)this["ProteinLog"];
            }
            set
            {
                this["ProteinLog"] = value;
            }
        }

        /// <summary>
        /// 实体工厂类名
        /// </summary>
        [ConfigurationProperty("EntityFactory", DefaultValue = "", IsRequired = true)]
        public String EntityFactory
        {
            get
            {
                return (String)this["EntityFactory"];
            }
            set
            {
                this["EntityFactory"] = value;
            }
        }

        
    }
}
