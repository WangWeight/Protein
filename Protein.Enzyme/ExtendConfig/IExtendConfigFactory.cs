using System; 


namespace Protein.Enzyme.ExtendConfig
{
    /// <summary>
    /// 扩展配置工厂接口 创建扩展配置对象
    /// </summary>
    public interface IExtendConfigFactory
    { 
        /// <summary>
        /// 从xml文件创建扩展配置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T CreateConfigFormXML<T>();
    }
}
