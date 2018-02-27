using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.DAL;
namespace Protein.Enzyme.Log
{
    /// <summary>
    /// 日志对象接口
    /// </summary>
    public interface ILog : IEntityBase
    {
        /// <summary>
        /// 日志内容
        /// </summary>
        string CONTENT { get; set; }
        /// <summary>
        /// 日志编码
        /// </summary>
        long LOGCODE { get; set; }
        /// <summary>
        /// 日志时间
        /// </summary>
        DateTime LOGTIME { get; set; }
        /// <summary>
        /// 日志类型
        /// </summary>
        string LOGTYPE { get; set; } 
        
    }
}
