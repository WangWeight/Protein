using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.ExtendConfig;
using Protein.Enzyme.Layout.Configuration;
using System.IO;
using System.Xml.Serialization;
using Protein.Enzyme.Design;
using System.Reflection;
using Protein.Enzyme.Repository;
namespace Protein.Enzyme.Layout.Mechanisms
{
    /// <summary>
    /// 初始化扩展配置内容
    /// </summary>
    internal class MachineExConfig
    {
        private static MachineExConfig mec = null;
        private static ECC excc = null;

        /// <summary>
        /// 扩展配置
        /// </summary>
        protected ECC ExtendConfig
        {

            get { return excc; }

        }

        /// <summary>
        /// 初始化扩展配置内容
        /// </summary>
        private MachineExConfig()
        {
            InisExConfig();
        
        }
        //private string ExPath { get; set; }


        /// <summary>
        /// 获取实体工厂的实例
        /// </summary>
        /// <returns></returns>
        public static ECC GetExtendConfig()
        {
            if (mec == null)
            {
                mec = new MachineExConfig();
            }
            return mec.ExtendConfig;

        }


        /// <summary>
        /// 初始化扩展配置
        /// </summary>
        protected  virtual void InisExConfig()
        {
            excc =new ECC();
            ProteinConfig pconfig = ProteinConfig.GetInstance(); 
            foreach (ExConfig config in pconfig.ExConfigs)
            {
                string xmlfilepath = this.GetType().Assembly.GetAssemblyPath()
                    + config.ConfigXMLPath + "/" + config.ConfigXML;
                string dllfilepath = this.GetType().Assembly.GetAssemblyPath()
                    + config.TypeFlagPath + "/" + config.TypeFlag;
                excc.AddExtendConfig(xmlfilepath, dllfilepath,config); 
                 
            } 
        }
         
         
    }
}
