using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

 
namespace Protein.Enzyme
{
    /// <summary>
    /// 支撑类库异常类型1
    /// </summary>
    public enum ProteinErrorType
    {
        /// <summary>
        /// 类工厂程序集文件路径错误
        /// </summary>
        [Description("类工厂程序集文件路径错误")]
        e0 = 0x1000,
        /// <summary>
        /// 在从指定的路径中加载程序集时发生异常，可能是dll文件不是.net程序集
        /// </summary>
        [Description(" 在从指定的路径中加载程序集时发生异常，可能是dll文件不是.net程序集")]
        e1 = 0x1001,
    }
}
