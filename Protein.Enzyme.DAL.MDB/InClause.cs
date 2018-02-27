using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Protein.Enzyme.DAL.MDB.ClauseType;

namespace Protein.Enzyme.DAL.MDB
{ 
    /// <summary>
    /// in条件处理
    /// </summary>
    public class InClause : InClauseOperator
    {
        /// <summary>
        /// 这里也是职责和策略
        /// </summary>
        /// <param name="PInfo"></param>
        /// <returns></returns>
        public override string GetClause(PropertyInfo PInfo)
        {
            if (PInfo.PropertyType == typeof(string))
            {
                return GetClauseString(PInfo);
            }
            else
            {
                return GetClauseString(PInfo);
            }
        }

        /// <summary>
        /// 获取in条件字符串
        /// </summary>
        /// <param name="PInfo"></param>
        /// <returns></returns>
        protected virtual string GetClauseString(PropertyInfo PInfo)
        {
            string result = "";
            if (this.ClauseValues.ContainsKey(PInfo))
            {
                foreach (object obj in this.ClauseValues[PInfo])
                {
                    if (result == "")
                    {
                        result = obj.ToString();
                    }
                    else
                    {
                        result = result + "," + obj.ToString();
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 判断类型
        /// </summary>
        /// <returns></returns>
        protected virtual string ClauseType(PropertyInfo PInfo,object Obj)
        {
            ClauseTypeBase ctNum = new ClauseTypeNum();
            ClauseTypeBase ctString = new ClauseTypeString();
            ctNum.SetNextFieldSetType(ctString);
            return ctNum.Definition(PInfo, Obj).ToString();
        }

    }
}
