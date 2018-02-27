using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protein.Enzyme.Layout.Configuration
{
    /// <summary>
    /// 支撑类库配置管理器
    /// </summary>
    public  class ProteinConfig
    {
        private static ProteinConfig config=null;
        /// <summary>
        /// 配置节
        /// </summary>
        protected ProteinCustomSection CustomConfig { get; set; }

        private ProteinConfig()
        { 
        
        }

        /// <summary>
        /// 获取配置类实例
        /// </summary>
        /// <returns></returns>
        public static ProteinConfig GetInstance()
        {
            if (config == null)
            { 
                config = new ProteinConfig();
                ProteinCustomSection configsction = (ProteinCustomSection)System.Configuration.ConfigurationManager.GetSection("Protein");
                config.CustomConfig = configsction; 
            }
            return config; 
        }
        /// <summary>
        /// 映射操作配置
        /// </summary>
        public DAlEntity DAlEntityConfig
        {
            get {
                return config.CustomConfig.DAlEntity;
            }
        }
        /// <summary>
        /// 数据库配置
        /// </summary>
        public DataBase DataBaseConfig
        {
            get
            {
                return config.CustomConfig.DataBase;
            }
        }

        /// <summary>
        /// 消息总线配置
        /// </summary>
        public Msg MsgConfig
        {
            get
            {
                return config.CustomConfig.Msg;
            }
        }

        /// <summary>
        /// 日志配置
        /// </summary>
        public LogOrgan LogConfig
        {
            get
            {
                return config.CustomConfig.LogOrgan;
            }
        }
        /// <summary>
        /// 扩展配置对象的配置
        /// </summary>
        public ExConfigCollection ExConfigs
        {
            get
            {
                return config.CustomConfig.ExConfigCollection;
            }
        }
    }
}
