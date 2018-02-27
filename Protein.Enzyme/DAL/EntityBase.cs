using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;
namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// 实体类基类
    /// </summary>
    public abstract class EntityBase : Protein.Enzyme.DAL.IEntityBase
    { 
        /// <summary>
        /// 获取字符串类型的字段列表
        /// </summary>
        /// <returns></returns>
        public virtual List<string> GetStrFields()
        {
            List<string> list = new List<string>();
            foreach (PropertyInfo pi in GetFields())
            {
                list.Add(pi.Name);
            }
            return list; 
        }

        /// <summary>
        /// 获取字段属性集合集合
        /// </summary>
        /// <returns></returns>
        public virtual List<PropertyInfo> GetFields()
        {
            List<PropertyInfo> result = new List<PropertyInfo>();
            Type t = this.GetType();
            foreach (PropertyInfo pi in t.GetProperties(BindingFlags.Instance
                | BindingFlags.Public))
            { 
                 result.Add(pi); 
            }
            return result;
        }

        /// <summary>
        /// 获取一个字段属性
        /// </summary>
        /// <returns></returns>
        public virtual PropertyInfo GetField(string FieldName)
        {
            Type t = this.GetType();
            return t.GetProperty(FieldName);
        }
        /// <summary>
        /// 实体的主键
        /// </summary>
        /// <returns></returns>
        public abstract PropertyInfo PrimaryKey();


        ///// <summary>
        ///// 外联结集合
        ///// </summary>
        ///// <returns></returns>
        //public abstract List<PropertyInfo> ExternalKey();

       
    }
}
