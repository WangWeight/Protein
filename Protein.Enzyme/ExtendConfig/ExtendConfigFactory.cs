using System;
using System.Collections.Generic;
using System.Text; 
using System.Diagnostics;
using System.IO;
namespace Protein.Enzyme.ExtendConfig
{
    /// <summary>
    /// 配置工厂
    /// </summary>
    internal class ExtendConfigFactory : IExtendConfigFactory
    {

        
        #region IExtendConfigFactory 成员

        public T CreateConfigFormXML<T>()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
