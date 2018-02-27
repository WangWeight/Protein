using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Reflection;
using Protein.Enzyme.DAL;
namespace Protein.Enzyme.DAL.Oracle.FieldType
{
    /// <summary>
    /// 字段赋值类型处理基类
    /// </summary>
    public abstract class FieldSetBase
    {
        protected FieldSetBase nextFieldSet = null;

        /// <summary>
        /// 设置下一个字段处理方式
        /// </summary>
        /// <param name="Successor"></param>
        public virtual void SetNextFieldSetType(FieldSetBase FieldSet)
        {
            this.nextFieldSet = FieldSet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual OracleParameter Definition(PropertyInfo Pi, IEntityBase Entity, string ParKey)
        {
            OracleParameter result = null;
            if (IsType(Pi))
            {
                result = SetVale(Pi, Entity, ParKey);
            }
            else if (this.nextFieldSet != null)
            {
                result = this.nextFieldSet.Definition(Pi, Entity, ParKey);
            }
            return result;
        }
        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="Pi"></param>
        /// <param name="Entity"></param>
        /// <param name="ParKey"></param>
        /// <returns></returns>
        protected abstract OracleParameter SetVale(PropertyInfo Pi, IEntityBase Entity, string ParKey);
        /// <summary>
        /// 判断处理类型
        /// </summary>
        /// <param name="NewModule"></param>
        /// <returns></returns>
        protected abstract bool IsType(PropertyInfo Pi);
        /// <summary>
        /// 设置空值时的问题
        /// </summary>
        /// <param name="Pi"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        protected abstract object NullValue(PropertyInfo Pi, object Value);
    }
}
