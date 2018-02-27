using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.Data.OleDb;
using Protein.Enzyme.DAL;
using System.Diagnostics;
//using 

namespace Protein.Enzyme.DAL.MDB.FieldType
{
    /// <summary>
    /// 语句字段赋值类型处理基类
    /// </summary>
    public abstract class FieldSetBase
    {
        protected FieldSetBase nextFieldSet = null;

        /// <summary>
        /// 设置下一个字段处理方式
        /// </summary>
        /// <param name="FieldSet"></param>
        public virtual void SetNextFieldSetType(FieldSetBase FieldSet)
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
        public virtual OleDbParameter Definition(PropertyInfo Pi, IEntityBase Entity, string ParKey)
        {
            OleDbParameter result = null;
            if (IsType(Pi))
            {
                result = SetVale(ParKey, Pi.GetValue(Entity, null)); 
            }
            else if (this.nextFieldSet != null)
            {
                result = this.nextFieldSet.Definition(Pi, Entity, ParKey);
            }
            //Debug.WriteLine("[FieldSet][" + ParKey + "][" + result.OleDbType.ToString() + "][" + result.DbType.ToString() + "]");
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
        protected abstract OleDbParameter SetVale(string ParKey,object Value);

        /// <summary>
        /// 设置空值时的问题
        /// </summary>
        /// <param name="Pi"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        protected abstract object NullValue(object Value);
    }
}
