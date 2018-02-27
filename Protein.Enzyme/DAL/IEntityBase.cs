using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;

 
namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// 实体基本操作接口
    /// </summary>
    public interface IEntityBase
    {
        /// <summary>
        /// 获取类属性字段
        /// </summary>
        /// <param name="FieldName"></param>
        /// <returns></returns>
        System.Reflection.PropertyInfo GetField(string FieldName);
        /// <summary>
        /// 获取类所有的属性字段
        /// </summary>
        /// <returns></returns>
        System.Collections.Generic.List<System.Reflection.PropertyInfo> GetFields();
        /// <summary>
        /// 获取类属性所有字段的名称字符串
        /// </summary>
        /// <returns></returns>
        System.Collections.Generic.List<string> GetStrFields();
        /// <summary>
        /// 获取实体主键 所有主外键都用方法获取 这个主键应该换成一个接口 下面的外联键也应该是一个接口 两者组合使用
        /// </summary>
        /// <returns></returns>
        PropertyInfo PrimaryKey();

        ///// <summary>
        ///// 外联键集合
        ///// </summary>
        ///// <returns></returns>
        //List<PropertyInfo> ExternalKey();
    }
}
