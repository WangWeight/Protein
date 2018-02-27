using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Protein.Enzyme.Repository
{
    /// <summary>
    /// 标准的处理函数 通用与类库功能
    /// </summary>
    public static class NormalIO
    {
        /// <summary>
        /// 将程序集名称扩展到完全路径名 同一级目录
        /// </summary>
        /// <param name="AssemblyName"></param>
        /// <returns></returns>
        public static string ExtComposeAssemblyFullName(this string AssemblyName)
        {

            return typeof(NormalIO).Assembly.GetAssemblyPath() + "\\" + AssemblyName + ".dll";

        }


        /// <summary>
        /// 获取程序集的运行路径
        /// </summary>
        ///<returns></returns>
        public static string GetAssemblyPath(this System.Reflection.Assembly Ably)
        {
            string _CodeBase = Ably.CodeBase; 
            _CodeBase = _CodeBase.Substring(8, _CodeBase.Length - 8);    // 8是file:// 的长度 
            string[] arrSection = _CodeBase.Split(new char[] { '/' }); 
            string _FolderPath = "";
            for (int i = 0; i < arrSection.Length - 1; i++)
            {
                _FolderPath += arrSection[i] + @"\";
            } 
            return _FolderPath;
        }

        /// <summary>
        /// 获取指定类型的属性的默认值
        /// 自动根据类型初始化实例对象获取值，如果没有默认值可能是null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="TypeObj"></param>
        /// <param name="PropertyName"></param>
        /// <returns></returns>
        public static T GetTypePropertyValue<T>(this Type TypeObj,string PropertyName)
        {
            object obj = Activator.CreateInstance(TypeObj);  
            System.Reflection.PropertyInfo propertyInfo = TypeObj.GetProperty(PropertyName);     
            T value = (T)propertyInfo.GetValue(obj, null);
            return value;
        }


        /// <summary> 
        /// 对象序列化成 XML String  
        /// </summary> 
        public static string XmlSerialize<T>(string path, Encoding encoding, T obj)
        {

            string xmlString = string.Empty;
            System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            { 
                xmlSerializer.Serialize(ms, obj); 
                xmlString = Encoding.UTF8.GetString(ms.ToArray()); 
            } 
            System.IO.File.WriteAllText(path, xmlString, encoding); 
            return xmlString;

        }
    }
}
