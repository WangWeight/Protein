using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.ComponentModel;

namespace Protein.Enzyme.Repository
{
    /// <summary>
    ///  获取说明的扩展工具类
    /// </summary>
    public static class DescriptionExtensions
    {
        #region 枚举的
        /// <summary>  
        /// 获取枚举变量值的 Description 属性  
        /// </summary>  
        /// <param name="obj">枚举变量</param>  
        /// <returns>如果包含 Description 属性，则返回 Description 属性的值，否则返回枚举变量值的名称</returns>  
        public static string GetEnumDescription(this object obj)
        {
            return GetEnumDescription(obj, false);

        }
         
        /// <summary>  
        /// 获取枚举变量值的 Description 属性  
        /// </summary>  
        /// <param name="obj">枚举变量</param>  
        /// <param name="isTop">是否改变为返回该类、枚举类型的头 Description 属性，而不是当前的属性或枚举变量值的 Description 属性</param>  
        /// <returns>如果包含 Description 属性，则返回 Description 属性的值，否则返回枚举变量值的名称</returns> 
        public static string GetEnumDescription(this object obj, bool isTop)
        {

            if (obj == null)
            {
                return string.Empty;

            }

            try
            {
                Type _enumType = obj.GetType();
                DescriptionAttribute dna = null;
                if (isTop)
                {
                    dna = (DescriptionAttribute)Attribute.GetCustomAttribute(_enumType, typeof(DescriptionAttribute));
                }

                else
                {

                    FieldInfo fi = _enumType.GetField(Enum.GetName(_enumType, obj));
                    dna = (DescriptionAttribute)Attribute.GetCustomAttribute(
                    fi, typeof(DescriptionAttribute));

                }

                if (dna != null && string.IsNullOrEmpty(dna.Description) == false)
                {
                    return dna.Description;
                }

            } 
            catch (Exception ex)
            {

            } 
            return obj.ToString();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public static Protein.Enzyme.UI.ListItem GetListItemFormEnum(this object Obj )
        {
            Protein.Enzyme.UI.ListItem item = new UI.ListItem();
            item.Name = Obj.GetEnumDescription();
            item.Value = Obj;
            return item;
        }

        #endregion

        #region 类的

        public static string GetClassDescription(this object Obj,string FieldName)
        {
            string result = "";
            ////不用反射 获取属性的特性  
            PropertyDescriptor pd = TypeDescriptor.GetProperties(Obj.GetType())[FieldName];
            DescriptionAttribute description = pd == null ? null : pd.Attributes[typeof(DescriptionAttribute)] as DescriptionAttribute;
            result = description == null ? "" : description.Description;
            return result;
        }


        #endregion
    }
}
