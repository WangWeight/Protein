using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.DAL;
using System.Data.OracleClient;
using Protein.Enzyme.DAL.Oracle.FieldType;
using System.Reflection;
namespace Protein.Enzyme.DAL.Oracle
{
    /// <summary>
    /// 创建表格对象
    /// 暂时不写入实体对象的注释到oracle
    /// </summary>
    public class CreateTable:ICreateTable
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

        /// <summary>
        /// 
        /// </summary>
        protected virtual  void CreateScript()
        {
            string field = SetFields(); 
            string script = "create table " + this.Entity.GetType().Name + "(" + field + ")";
        }

        /// <summary>
        /// 1、字段名称2、oracle类型3、主键标识
        /// </summary>
        /// <returns></returns>
        protected virtual string  SetFields()
        {
            TypeToOraclePar ttop = new TypeToOraclePar();
            string result = "";
            foreach (PropertyInfo pi in this.Entity.GetFields())
            {
                OracleParameter op= ttop.ParType(pi, this.Entity, pi.Name); 
                string fieldChar = op.ParameterName + " " + FieldTypeName(op.OracleType) + FieldTypeLength(op.OracleType) + " ";

                //判断是否是主键
                if (this.Entity.PrimaryKey() == pi)
                {
                    fieldChar = fieldChar + " not null";
                }
                if (result == "")
                {
                    result = fieldChar;
                }
                else
                { 
                    result=result+","+fieldChar;
                }
            }
            return result;
        }

        /// <summary>
        /// 字段类型名称
        /// </summary>
        /// <param name="OrclType"></param>
        /// <returns></returns>
        protected virtual string FieldTypeName(OracleType OrclType)
        {
            switch (OrclType)
            {
                case OracleType.NVarChar:
                    return "NVARCHAR2";
                case OracleType.NChar:
                    return "NCHAR";
                case OracleType.Number:
                    return "NUMBER";
                case OracleType.VarChar:
                    return "VARCHAR2";
                default:
                    return "VARCHAR2";
            }
        }
        /// <summary>
        /// 字段宽度 这里不完善
        /// </summary>
        /// <param name="OrclType"></param>
        /// <returns></returns>
        protected virtual string FieldTypeLength(OracleType OrclType)
        {
            switch (OrclType)
            { 
                case OracleType.NVarChar:
                    return "(500)"; 
                case OracleType.NChar:
                    return "(200)";
                case OracleType.Number:
                    return ""; 
                default:
                    return "";
            }
            //if(OrclType==OracleType.
        }

    }
}
