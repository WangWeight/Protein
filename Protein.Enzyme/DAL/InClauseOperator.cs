using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
//using Protein.Enzyme.d
namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// 处理in子语句
    /// </summary>
    public abstract class InClauseOperator
    {
        /// <summary>
        /// 子语句值
        /// </summary>
        public Dictionary<PropertyInfo, List<object>> ClauseValues { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public InClauseOperator()
        {
            this.ClauseValues = new Dictionary<PropertyInfo, List<object>>();
        }
        /// <summary>
        /// 添加值
        /// </summary>
        /// <param name="PInfo"></param>
        /// <param name="Value"></param>
        public virtual void AddObjectValue(PropertyInfo PInfo, object Value)
        {
            if (!this.ClauseValues.ContainsKey(PInfo)) 
            {
                this.ClauseValues.Add(PInfo,new List<object>());
            }
            SetAndObjectValue(this.ClauseValues[PInfo], Value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="SList"></param>
        protected virtual void SetAndObjectValue(List<object> SList,object Value)
        {
            if (SList == null)
            {
                SList = new List<object>();
            }
            else
            {
                SList.Add(Value);
            }
        }
        /// <summary>
        /// 子句
        /// </summary>
        /// <param name="PInfo"></param>
        /// <returns></returns>
        public abstract string GetClause(PropertyInfo PInfo);
    }
}
