using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Protein.Enzyme.Message 
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// 支持平台调试信息，用于丰富消息层次
        /// </summary>
        [Description("PtDebug")]
        PtDebug = 5,
        /// <summary>
        /// 调试信息,调试程序信号量
        /// </summary>
        [Description("Debug")]
        Debug = 4,
        /// <summary>
        /// 系统内部消息
        /// </summary>
        [Description("InsideInfo")]
        InsideInfo = 3,
        /// <summary>
        /// 提示 普通提示消息
        /// </summary>
        [Description("Note")]
        Note = 2,
        /// <summary>
        /// 警告消息
        /// </summary>
        [Description("Warning")]
        Warning = 1,
        /// <summary>
        /// 异常
        /// </summary>
        [Description("Error")]
        Error = 0,  
        
    }
}
