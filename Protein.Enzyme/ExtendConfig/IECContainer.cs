using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.Layout.Configuration;
namespace Protein.Enzyme.ExtendConfig
{
    /// <summary>
    /// 扩展配置容积接口
    /// </summary>
    public interface IECContainer
    {
        /// <summary>
        /// 扩展配置对象
        /// </summary>
        T GetExtendConfig<T>();
        /// <summary>
        /// 添加扩展配置对象到容器
        /// </summary> 
        /// <param name="NewObject"></param>
        void AddExtendConfig(object NewObject);

        void AddExtendConfig(string XmlFile, string DllFile, ExConfig ExConfig);
    }
}
