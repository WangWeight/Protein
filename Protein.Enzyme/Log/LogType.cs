using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
namespace Protein.Enzyme.Log
{
    /// <summary>
    /// 日志类型
    /// </summary>
    public  enum LogType
    {
        /// <summary>
        /// all
        /// </summary>
        [Description("all")]
        All = 99,
        /// <summary>
        /// info
        /// </summary>
        [Description("info")]
        info = 1,
        /// <summary>
        /// debug
        /// </summary>
        [Description("debug")]
        debug = 2,
        /// <summary>
        /// error
        /// </summary>
        [Description("error")]
        error = 3,
        /// <summary>
        /// nothing
        /// </summary>
        [Description("nothing")]
        nothing = -99, 
    }
}
