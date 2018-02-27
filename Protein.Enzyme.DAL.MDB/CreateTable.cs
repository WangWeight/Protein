using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.DAL;
using Protein.Enzyme.DAL.MDB.FieldType;
using System.Data.OleDb;
using System.Reflection;

namespace Protein.Enzyme.DAL.MDB
{
    class CreateTable : ICreateTable
    {
        public CreateTable(IEntityBase TargetEntity)
        {
            this.Entity = TargetEntity;
        }

        #region ICreateTable 成员

        public virtual void ExecuteScript()
        {
            CreateScript();
        }

        public IEntityBase Entity
        {
            get;
            set;
        }
        
        #endregion


        protected virtual void CreateScript()
        {
            string field = SetFields();
            string script = "create table" + this.Entity.GetType().Name + "(" + field + ")";
        }

        /// <summary>
        /// 1、字段名称2、oracle类型3、主键标识
        /// </summary>
        /// <returns></returns>
        protected virtual string SetFields()
        {
            TypeToAccessPar ttap = new TypeToAccessPar();
            string result = "";
            //foreach (PropertyInfo pi in this.Entity.GetFields())
            //{
            //    OleDbParameter op = ttap.ParType(pi, this.Entity, pi.Name, t.Filterlist[this.Entity.GetFields().IndexOf(pi)].OperatorSign);
            //    string fieldChar = op.ParameterName + " " + FieldTypeName(op.OleDbType) + FieldTypeLength(op.OleDbType) + " ";

            //    //判断是否是主键
            //    if (this.Entity.PrimaryKey() == pi)
            //    {
            //        fieldChar = fieldChar + " not null";
            //    }
            //    if (result == "")
            //    {
            //        result = fieldChar;
            //    }
            //    else
            //    {
            //        result = result + "," + fieldChar;
            //    }
            //}
            return result;
        }

        /// <summary>
        /// 字段类型名称
        /// </summary>
        /// <param name="AccType"></param>
        /// <returns></returns>
        protected virtual string FieldTypeName(OleDbType AccType)
        {
            switch (AccType)
            {
                case OleDbType.VarWChar:
                    return "VarWChar";
                case OleDbType.VarChar:
                    return "VarChar";
                case OleDbType.WChar:
                    return "WChar";
                case OleDbType.LongVarChar:
                    return "LongVarChar";
                case OleDbType.LongVarWChar:
                    return "LongVarWChar";
                default:
                    return "VarWChar";
            }
        }

        /// <summary>
        /// 字段宽度 这里不完善
        /// </summary>
        /// <param name="AccType"></param>
        /// <returns></returns>
        protected virtual string FieldTypeLength(OleDbType AccType)
        {
            switch (AccType)
            {
                case OleDbType.VarWChar:
                    return "";
                case OleDbType.VarChar:
                    return "";
                case OleDbType.WChar:
                    return "";
                case OleDbType.LongVarChar:
                    return "";
                case OleDbType.LongVarWChar:
                    return "";
                default:
                    return "";
            }
        }
    }
}
