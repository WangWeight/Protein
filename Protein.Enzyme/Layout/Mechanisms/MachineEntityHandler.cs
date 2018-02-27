using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.Log;
using Protein.Enzyme.Design;
using Protein.Enzyme.DAL; 
using Protein.Enzyme.Layout.Configuration;
using Protein.Enzyme.Repository;

namespace Protein.Enzyme.Layout.Mechanisms
{
    /// <summary>
    /// 支撑机制的实体功能
    /// </summary>
    public class MachineEntityHandler
    {
        private static MachineEntityHandler meh = null;
        protected static IEntityFactory entityFac = null;

        /// <summary>
        /// 
        /// </summary>
        private MachineEntityHandler()
        {
            CreateEntityFactory();
        }

        /// <summary>
        /// 创建实体工厂
        /// 数据库连接字符串
        /// 实体类适配器
        /// IDvTable 
        /// </summary>
        protected virtual void CreateEntityFactory()
        {
            MachineDBInfo Dbh = new MachineDBInfo();
            ProteinConfig pconfig = ProteinConfig.GetInstance();
            string entityftc= pconfig.DAlEntityConfig.EntityFactory;
            ClassDrive cd = new Design.ClassDrive();
            entityFac = cd.Instance<IEntityFactory>(pconfig.DAlEntityConfig.AssemblyName.ExtComposeAssemblyFullName(),entityftc, Dbh);
             
        }

        /// <summary>
        /// 实体工厂
        /// </summary>
        protected IEntityFactory EntityFactory { 
            get { return entityFac; } 
        }

        /// <summary>
        /// 获取实体工厂的实例
        /// </summary>
        /// <returns></returns>
        public static IEntityFactory GetEntityFactory()
        {
            if (meh == null)
            {
                meh = new MachineEntityHandler(); 
            }
            return meh.EntityFactory;

        }


        
    }
}
