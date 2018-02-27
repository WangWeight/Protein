using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;

namespace Protein.Enzyme.DAL.MDB
{
    public  class JoinEntity : Protein.Enzyme.DAL.IJoinEntity
    {
        List<Protein.Enzyme.DAL.IEntityBase> entitylist = new List<Protein.Enzyme.DAL.IEntityBase>();

        #region IJoinEntity 成员
        /// <summary>
        /// 用于联立的实体类对象
        /// </summary>
        public List<Protein.Enzyme.DAL.IEntityBase> Entitys
        {
            get 
            {
                return entitylist;
            }
            set
            {
                this.entitylist = value;
            }
        }

        /// <summary>
        ///// 联立字段  
        ///// </summary>
        ///// <param name="SourceEntity"></param>
        ///// <param name="JionEntity"></param>
        ///// <returns></returns>
        //public virtual string JoinField(Protein.Enzyme.DAL.IEntityBase SourceEntity
        //    , Protein.Enzyme.DAL.IEntityBase JionEntity)
        //{
        //    string result = "";
        //    string leftchar = SourceEntity.GetType().Name + "." + SourceEntity.PrimaryKey().Name;
        //    string rightchar = "";
        //    MethodInfo method = SourceEntity.GetType().GetMethod(JionEntity.GetType().Name
        //        , BindingFlags.Public 
        //            | BindingFlags.Instance  | BindingFlags.IgnoreCase);
        //    if (method != null)
        //    {
        //        PropertyInfo bfield = (PropertyInfo)method.Invoke(SourceEntity, null);
        //        rightchar = JionEntity.GetType().Name + "." + bfield.Name;
        //    }
        //    if (leftchar != "" && rightchar != "")
        //    {
        //        result = JoinFieldType(leftchar, SourceEntity.PrimaryKey(), rightchar, (PropertyInfo)method.Invoke(SourceEntity, null));
        //    }
        //    return result;
        //}
        //
        ///
        /// 联立字段 自动联立相同的属性 所以相同意义的字段一定要相同 也就是统一key
        /// 先找jion的关联键 然后自动连接到source得同名主键
        /// </summary>
        /// <param name="SourceEntity"></param>
        /// <param name="JionEntity"></param>
        /// <returns></returns>
        public virtual string JoinField(Protein.Enzyme.DAL.IEntityBase SourceEntity
            , Protein.Enzyme.DAL.IEntityBase JionEntity)
        {
             
            string leftchar = "";
            string result = ""; 
            string rightchar = "";
            MethodInfo method = SourceEntity.GetType().GetMethod(JionEntity.GetType().Name
                , BindingFlags.Public
                    | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (method != null)
            {
                PropertyInfo bfield = (PropertyInfo)method.Invoke(SourceEntity, null); 
                rightchar = JionEntity.GetType().Name + "." + bfield.Name;
                leftchar = SourceEntity.GetType().Name + "." + bfield.Name;
            } 
            if (leftchar != "" && rightchar != "")
            {
                result = JoinFieldType(leftchar, SourceEntity.PrimaryKey(), rightchar, (PropertyInfo)method.Invoke(SourceEntity, null));
            }
            return result;
        }

        #endregion

        /// <summary>
        /// 设置类型转换
        /// </summary>
        /// <param name="CmdChar1"></param>
        /// <param name="Property1"></param>
        /// <param name="CmdChar2"></param>
        /// <param name="Property2"></param>
        /// <returns></returns>
        protected virtual string JoinFieldType(string CmdChar1, PropertyInfo Property1, string CmdChar2, PropertyInfo Property2)
        {
            string result = "";
            if (Property1.PropertyType == Property2.PropertyType)
            {
                result = CmdChar1 + "=" + CmdChar2;
            }
            else
            {
                if (Property1.PropertyType == typeof(long) && Property2.PropertyType == typeof(string))
                {
                    result = "to_char(" + CmdChar1 + ")" + "=" + CmdChar2;
                }
                else if (Property2.PropertyType == typeof(long) && Property1.PropertyType == typeof(string))
                {
                    result = CmdChar1 + "=" + "to_char(" + CmdChar2 + ")";
                }
            }
            return result;
        }


    }
}
