using System;
using System.Collections.Generic;
using System.Text; 
using System.Diagnostics;
using System.IO;
namespace Protein.Enzyme.ExtendConfig
{
    /// <summary>
    /// ���ù���
    /// </summary>
    internal class ExtendConfigFactory : IExtendConfigFactory
    {

        
        #region IExtendConfigFactory ��Ա

        public T CreateConfigFormXML<T>()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
