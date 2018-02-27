using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Protein.Enzyme.Layout.Configuration
{ 
    /// <summary>
    ///  扩展配置节点要素
    /// </summary>
    public class ExConfig : ConfigurationElement
    {
        public ExConfig()
        {
             

        }
        public ExConfig(string newName, string typeFlag, string configXML)
        {
              Name = newName;
              TypeFlag = typeFlag;
              ConfigXML = configXML;
        }
        public ExConfig(string newName)
        {
            Name = newName; 
        }
        /// <summary>
        /// Name
        /// </summary>
        [ConfigurationProperty("Name", DefaultValue = "", IsRequired = true)]
        public String Name
        {
            get
            {
                return (String)this["Name"];
            }
            set
            {
                this["Name"] = value;
            }
        }

        /// <summary>
        /// TypeFlag
        /// </summary>
        [ConfigurationProperty("TypeFlag", DefaultValue = "", IsRequired = true)]
        public String TypeFlag
        {
            get
            {
                return (String)this["TypeFlag"];
            }
            set
            {
                this["TypeFlag"] = value;
            }
        }

        /// <summary>
        /// ConfigXML
        /// </summary>
        [ConfigurationProperty("ConfigXML", DefaultValue = "", IsRequired = true)]
        public String ConfigXML
        {
            get
            {
                return (String)this["ConfigXML"];
            }
            set
            {
                this["ConfigXML"] = value;
            }
        }

        /// <summary>
        /// ConfigXMLPath
        /// </summary>
        [ConfigurationProperty("ConfigXMLPath", DefaultValue = "", IsRequired = true)]
        public String ConfigXMLPath
        {
            get
            {
                return (String)this["ConfigXMLPath"];
            }
            set
            {
                this["ConfigXMLPath"] = value;
            }
        }

        /// <summary>
        /// TypeFlagPath
        /// </summary>
        [ConfigurationProperty("TypeFlagPath", DefaultValue = "", IsRequired = true)]
        public String TypeFlagPath
        {
            get
            {
                return (String)this["TypeFlagPath"];
            }
            set
            {
                this["TypeFlagPath"] = value;
            }
        }


    }
}
