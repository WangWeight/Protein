using System;
using System.Collections.Generic;
using System.Text;

namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// 查询过滤语句 包含聚合函数
    /// </summary>
    public interface  IFilter
    {
        /// <summary>
        /// 筛选的字段
        /// </summary>
        System.Reflection.PropertyInfo Usefield { get;set;}
        /// <summary>
        /// 字段输出
        /// </summary>
        string OutPutFieldChar { get;}
        /// <summary>
        /// 操作符号
        /// </summary>
        Operator OperatorSign { get;set;}

        /// <summary>
        /// 设置过滤 操作符号 操作字段
        /// </summary>
        void SetFilter(System.Reflection.PropertyInfo Field, Operator Oprt);


    }
}
