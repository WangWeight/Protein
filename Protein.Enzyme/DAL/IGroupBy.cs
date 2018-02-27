using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// 分组聚合接口
    /// </summary>
    public interface IGroupBy
    {
        /// <summary>
        /// 聚合的字段
        /// </summary>
        //System.Reflection.PropertyInfo Usefield { get; set; }
        List<string> UseField { get; set; }
        /// <summary>
        /// 字段输出
        /// </summary>
        string OutPutFieldChar { get; }

        /// <summary>
        /// 设置过滤 操作符号 操作字段
        /// </summary>
        void SetField(string FieldName);

    }
}
