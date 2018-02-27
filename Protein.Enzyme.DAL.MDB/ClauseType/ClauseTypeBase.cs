using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using Protein.Enzyme.DAL;
using System.Diagnostics; 

namespace Protein.Enzyme.DAL.MDB.ClauseType
{
    /// <summary>
    /// 语句字段赋值类型处理基类
    /// </summary>
    public abstract class ClauseTypeBase
    {
        /// <summary>
        /// 
        /// </summary>
        protected ClauseTypeBase nextFieldSet = null;

        /// <summary>
        /// 设置下一个字段处理方式
        /// </summary>
        /// <param name="FieldSet"></param>
        public virtual void SetNextFieldSetType(ClauseTypeBase FieldSet)
        {
            if (this.nextFieldSet == null)
            {
                this.nextFieldSet = FieldSet;
            }
            else
            {
                this.nextFieldSet.SetNextFieldSetType(FieldSet);
            }
        }

        /// <summary>
        /// 定义类型
        /// </summary>
        /// <param name="Pi"></param>
        /// <param name="Entity"></param>
        /// <param name="ParKey"></param>
        /// <returns></returns>
        public virtual object Definition(PropertyInfo Pi, object value)
        {
            object result = null;
            if (IsType(Pi))
            {
                result = SetVale( value); 
            }
            else if (this.nextFieldSet != null)
            {
                result = this.nextFieldSet.Definition(Pi, value);
            } 
            return result;
        }

       
        /// <summary>
        /// 判断处理类型
        /// </summary>
        /// <param name="Pi"></param>
        /// <returns></returns>
        protected abstract bool IsType(PropertyInfo Pi);

        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="Pi"></param>
        /// <param name="Entity"></param>
        /// <param name="ParKey"></param>
        /// <returns></returns>
        protected abstract object SetVale(object value);

        
    }
}
