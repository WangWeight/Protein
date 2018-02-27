
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Protein.Enzyme.Layout.Configuration
{ 
    /// <summary>
    /// 扩展配置的系统配置节点集合
    /// </summary>
    [ConfigurationCollection(typeof(ExConfig), AddItemName = "add", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class ExConfigCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ExConfig();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementName"></param>
        /// <returns></returns>
        protected override ConfigurationElement CreateNewElement(string elementName)
        {
            return new ExConfig(elementName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ExConfig)element).Name;
        }

       
        public ExConfig GetElement(string Name)
        {
            return (ExConfig)BaseGet(Name);
        } 


        public int IndexOf(ExConfig Config)
        {
            return BaseIndexOf(Config);
        }



        ///// <summary>
        /////Path
        ///// </summary>
        //[ConfigurationProperty("Path", DefaultValue = "", IsRequired = true)]
        //public String Path
        //{
        //    get
        //    {
        //        return (String)this["Path"];
        //    }
        //    set
        //    {
        //        this["Path"] = value;
        //    }
        //}
        
    }

}