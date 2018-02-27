using System;
using System.Collections.Generic; 
using System.Text;
using System.ComponentModel;

namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// 条件子语句要素类
    /// 临时的 这里考虑在IDvTable接口中做类似功能的抽象
    /// 联立查询还是在客户端直接做
    /// </summary>
    public sealed class ClauseElement
    {
        /// <summary>
        /// 实体类类型
        /// </summary>
        public Type EntityType { get; set; }
        /// <summary>
        /// 条件子语句的字段名称
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 操作符
        /// </summary>
        public Operator Opr { get; set; }
        /// <summary>
        /// 连接操作符
        /// </summary>
        public LinkOperator LinkOpr { get; set; }
    }
}
