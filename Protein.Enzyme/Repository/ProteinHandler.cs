using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.DAL;
using Protein.Enzyme.Layout.Configuration;
using Protein.Enzyme.Layout.Mechanisms;
using Protein.Enzyme.ExtendConfig;
using System.Data;


namespace Protein.Enzyme.Repository
{
    /// <summary>
    /// 支撑功能类库使用入口
    /// </summary>
    public class ProteinHandler
    {
        /// <summary>
        /// 支撑类库配置
        /// </summary>
        /// <returns></returns>
        public static  ProteinConfig GetProteinConfig()
        {
            return ProteinConfig.GetInstance();
        }
        /// <summary>
        /// 获取数据库操作的实体类工厂对象
        /// </summary>
        /// <returns></returns>
        public IEntityFactory GetEntityFactory()
        { 
            return MachineEntityHandler.GetEntityFactory(); 
        }
        /// <summary>
        /// 设置实体类型适配器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TC"></typeparam>
        public void SetEntityTypeAdapter<T, TC>()
            where T : IEntityBase
        {
            IEntityFactory efac = GetEntityFactory(); 
            EntityTypeAdapterGenerics<T, TC> s = new EntityTypeAdapterGenerics<T, TC>();
            efac.AddAdapter(s); 
        }
        /// <summary>
        /// 获取扩展配置对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetExtendConfig<T>()
        {
            ECC ecc = MachineExConfig.GetExtendConfig();
            return (T)ecc.GetExtendConfig<T>();
        }
        /// <summary>
        /// 设置扩展配置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Obj"></param>
        public static void SetExtendConfig<T>(T Obj)
        {
            ProteinConfig pconfig = ProteinConfig.GetInstance();
            ECC ecc = MachineExConfig.GetExtendConfig();
            foreach (ExConfig config in pconfig.ExConfigs)
            {
                if (config.Name == typeof(T).FullName)
                {
                    ecc.SaveExtendConfig<T>(config.GetType().Assembly.GetAssemblyPath() + config.ConfigXMLPath + "\\" + config.ConfigXML, Obj);
                }
            } 
        }
        ///// <summary>
        ///// 获取扩展配置对象
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        //public T ExtendConfig<T>()
        //{
        //    ECC ecc = MachineExConfig.GetExtendConfig();
        //    return (T)ecc.GetExtendConfig<T>();
        //}

        /// <summary>
        /// 添加扩展配置对象
        /// </summary> 
        /// <param name="NewObject"></param>
        public void AddExtendConfig(object NewObject)
        {
            ECC ecc = MachineExConfig.GetExtendConfig();
            ecc.AddExtendConfig(NewObject);
        }

        

        

    }
}
