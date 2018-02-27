using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protein.Enzyme.DAL.MDB
{
    /// <summary>
    /// 分组聚合功能类
    /// </summary>
    public class GroupBy : IGroupBy
    {
        /// <summary>
        /// 使用的字段
        /// </summary>
        public List<string> UseField{get;set;}

        public GroupBy()
        {
            this.UseField = new List<string>();
        }
        public string OutPutFieldChar
        {
            get { return " Group by "; }
        }
        /// <summary>
        /// 设置字段
        /// </summary>
        /// <param name="FieldName"></param>
        public void SetField(string FieldName)
        {
            this.UseField.Add(FieldName);
        }
    }
}
