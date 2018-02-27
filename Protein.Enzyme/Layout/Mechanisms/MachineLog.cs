using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.Log;
using Protein.Enzyme.Layout.Configuration;
using Protein.Enzyme.Repository;
using Protein.Enzyme.DAL;

namespace Protein.Enzyme.Layout.Mechanisms
{
    /// <summary>
    /// 功能日志
    /// </summary>
    public class MachineLog
    {
        private static MachineLog mlog = null;
        protected static ILogger logger = null;

        /// <summary>
        /// 类库日志记录器
        /// </summary>
        protected ILogger ProteinLogger  
        {
            get { return logger; }
        }

        /// <summary>
        /// 
        /// </summary>
        private MachineLog()
        { 
        
        }

        /// <summary>
        /// 创建日志记录器
        /// </summary>
        /// <returns></returns>
        protected static  ILogger CreateLogger()
        { 
            ProteinConfig pconfig = ProteinConfig.GetInstance();
            string aname = pconfig.DAlEntityConfig.AssemblyName;
            string assemblyfile = aname.ExtComposeAssemblyFullName();
            Design.ClassDrive cd = new Design.ClassDrive();
            ILogger logger = cd.Instance<ILogger>(assemblyfile, pconfig.DAlEntityConfig.ProteinLog);// LoggerManager.CreateLogger(assemblyfile, pconfig.DAlEntityConfig.ProteinLog);
            logger.EntityFactory= MachineEntityHandler.GetEntityFactory();
            return logger;
        }

         
        /// <summary>
        /// 获取配置类实例
        /// </summary>
        /// <returns></returns>
        public static ILogger GetLogger()
        {
            if (mlog == null)
            {
                mlog = new MachineLog();
                ProteinCustomSection configsction = (ProteinCustomSection)System.Configuration.ConfigurationManager.GetSection("Protein");
                logger = CreateLogger();
            }
            return mlog.ProteinLogger;

        }
    }
}
