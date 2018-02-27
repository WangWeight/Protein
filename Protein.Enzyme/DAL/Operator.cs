using System;
using System.Collections.Generic; 
using System.Text;
using System.ComponentModel;

namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// 操作符
    /// </summary>
    public enum Operator:int
    {
        /// <summary>
        /// Deng
        /// </summary>
        [Description("=")]
        Deng = 0,
        /// <summary>
        /// Deng
        /// </summary>
        [Description(">")]
        Da = 1,
        /// <summary>
        /// Deng
        /// </summary>
        [Description("<")]
        Xiao = 2,
        /// <summary>
        /// 
        /// </summary>
        [Description("<>")]
        BuDeng = 3,
        /// <summary>
        /// Deng
        /// </summary>
        [Description(">=")]
        Da_Deng = 4,
        /// <summary>
        /// Deng
        /// </summary>
        [Description("<=")]
        Xiao_Deng = 5, 
        /// <summary>
        /// 全部字段
        /// </summary>
        [Description("*")]
        Fun_All = 6, 
        /// <summary>
        /// 最大
        /// </summary>
        [Description("MAX")]
        Fun_Max = 7,
        /// <summary>
        /// in
        /// </summary>
        [Description("IN")]
        In = 8,
        /// <summary>
        /// Count
        /// </summary>
        [Description("COUNT")]
        Count = 9,
        /// <summary>
        /// LikeStart
        /// </summary>
        [Description("LIKE")]
        LikeStart = 10,
        /// <summary>
        /// LikeEnd
        /// </summary>
        [Description("LIKE")]
        LikeEnd = 11,
        /// <summary>
        /// LikeAll
        /// </summary>
        [Description("LIKE")]
        LikeAll = 12,
    }
}
