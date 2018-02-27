using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// 创建表接口
    /// </summary>
    public interface ICreateTable
    {
        ///// <summary>
        ///// 脚本
        ///// </summary>
        //string Script { get; set; }

        /// <summary>
        /// 实体
        /// </summary>
        IEntityBase Entity { get; set; } 

        /// <summary>
        /// 执行脚本
        /// </summary>
        void ExecuteScript();
    }
}
