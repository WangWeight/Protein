using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.ComponentModel;
using Protein.Enzyme.DAL;
using Protein.Enzyme.DAL.MDB.FieldType; 

namespace Protein.Enzyme.DAL.MDB.Command
{
    /// <summary>
    /// 操作元数据配置基类，用于配置SQL操作语句
    /// </summary>
    public abstract class StockCmd
    {
        string cmd = "";
        /// <summary>
        /// sql语句
        /// </summary>
        public string Cmd
        {
            get { return cmd; }
            set { cmd = value; }
        }
        /// <summary>
        /// 参数列表
        /// </summary>
        List<OleDbParameter> pravale = new List<OleDbParameter>();

        /// <summary>
        /// 参数列表
        /// </summary>
        public List<OleDbParameter> Parameter
        {
            get { return pravale; }
            set { pravale = value; }
        }
        /// <summary>
        /// 添加参数 根据不同类型设置参数类型
        /// </summary>
        /// <param name="Pi"></param>
        /// <param name="Entity"></param>
        public void AddPar(PropertyInfo Pi, IEntityBase Entity)
        {
            this.pravale.Add(ParType(Pi, Entity, Pi.Name));
        }
        /// <summary>
        /// 条件子语句参数添加方法 Where
        /// </summary>
        /// <param name="Pi"></param>
        /// <param name="Entity"></param>
        public void AddParWhere(PropertyInfo Pi, IEntityBase Entity, Operator  OperatorObj)
        {
            OleDbParameter oledbp = ParType(Pi, Entity, "Where" + Pi.Name);
            oledbp.Value = ValueConfirm(OperatorObj, oledbp.Value);
            this.pravale.Add(oledbp);
        }
        /// <summary>
        /// 条件子语句参数添加方法 Where
        /// </summary>
        /// <param name="Pi"></param>
        /// <param name="Entity"></param>
        public void AddParWhere(PropertyInfo Pi, IEntityBase Entity, Operator OperatorObj, IDvTable DvTable)
        { 
            
            OleDbParameter oledbp = ParType(Pi, Entity, "Where" + Pi.Name);
            oledbp.Value = DvTable.InClause.GetClause(Pi);// ValueConfirm(OperatorObj, oledbp.Value);
            this.pravale.Add(oledbp);
        }
        /// <summary>
        /// 确定值
        /// </summary>
        /// <returns></returns>
        protected virtual object ValueConfirm(Operator OperatorObj, object SourceValue)
        {
            object result = null;
            if (SourceValue != null)
            {
                // 
                if (OperatorObj == Operator.LikeAll)
                {
                    result = "%" + SourceValue + "%";
                }
                else if (OperatorObj == Operator.LikeStart)
                {
                    result = "%" + SourceValue;
                }
                else if (OperatorObj == Operator.LikeEnd)
                {
                    result = SourceValue + "%";
                }
                else 
                {
                    result = SourceValue;
                } 
            }
            return result;
        }

        /// <summary>
        /// 参数类型 这里还没做完 
        /// </summary>
        /// <param name="Pi"></param>
        /// <param name="Entity"></param>
        /// <param name="ParKey"></param>
        /// <returns></returns>
        protected virtual OleDbParameter ParType(PropertyInfo Pi, IEntityBase Entity, string ParKey)
        {
            OleDbParameter result = null;
            FieldSetBase fsbString = new FieldSetString();
            FieldSetBase fsblong = new FieldSetLong();
            FieldSetBase fsbDateTime = new FieldSetDateTime();
            FieldSetBase fsbInt = new FieldSetInt();
            FieldSetBase fsbFloat = new FieldSetFloat();
            FieldSetBase fsbDouble = new FieldSetDouble();
            FieldSetBase fsbByteAry = new FieldSetByteArray();
            fsbString.SetNextFieldSetType(fsblong);
            fsbString.SetNextFieldSetType(fsbDateTime);
            fsbString.SetNextFieldSetType(fsbInt);
            fsbString.SetNextFieldSetType(fsbFloat);
            fsbString.SetNextFieldSetType(fsbDouble);
            fsbString.SetNextFieldSetType(fsbByteAry);

            result = fsbString.Definition(Pi, Entity, ParKey);
            if (result == null)
            {
                throw new Exception("数据映射对象的实体字段类型在参数化时无法处理");
            }
            return result;
        }


        /// <summary>
        /// 处理参数值为null时的取值问题 这里还没做完
        /// </summary>
        /// <param name="Pi"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        protected virtual object NullValue(PropertyInfo Pi, object Value)
        {
            object result = Value;
            if (result == null)
            {
                if (Pi.PropertyType == typeof(string))
                {
                    result = "";
                }
                if (Pi.PropertyType == typeof(long))
                {
                    result = -1;
                }
            }
            return result;
        }
        /// <summary>
        /// 获取值域说明
        /// </summary>
        /// <param name="Pi"></param>
        /// <returns></returns>
        protected string GetCodomain(PropertyInfo Pi)
        {
            foreach (object obj in Pi.GetCustomAttributes(false))
            {
                if (obj is DescriptionAttribute)
                {
                    return (obj as DescriptionAttribute).Description;
                }
            }
            return "";
        }
        /// <summary>
        /// 创建sql命令
        /// </summary>
        /// <param name="Table"></param>
        public abstract void CreateCmd(IDvTable Table);
         
    }
}
