using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;
namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// ʵ�������
    /// </summary>
    public abstract class EntityBase : Protein.Enzyme.DAL.IEntityBase
    { 
        /// <summary>
        /// ��ȡ�ַ������͵��ֶ��б�
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
        /// ��ȡ�ֶ����Լ��ϼ���
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
        /// ��ȡһ���ֶ�����
        /// </summary>
        /// <returns></returns>
        public virtual PropertyInfo GetField(string FieldName)
        {
            Type t = this.GetType();
            return t.GetProperty(FieldName);
        }
        /// <summary>
        /// ʵ�������
        /// </summary>
        /// <returns></returns>
        public abstract PropertyInfo PrimaryKey();


        ///// <summary>
        ///// �����Ἧ��
        ///// </summary>
        ///// <returns></returns>
        //public abstract List<PropertyInfo> ExternalKey();

       
    }
}
