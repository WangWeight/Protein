using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Reflection;  
using System.ComponentModel;
using Protein.Enzyme.DAL;
using Protein.Enzyme.DAL.Oracle.FieldType;
namespace Protein.Enzyme.DAL.Oracle.Command
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
        List<OracleParameter> pravale = new List<OracleParameter>();

        /// <summary>
        /// 参数列表
        /// </summary>
        public List<OracleParameter> Parameter
        {
            get { return pravale; }
            set { pravale = value; }
        }
        /// <summary>
        /// 添加参数 根据不同类型设置参数类型 
        /// </summary>
        /// <param name="Pi"></param>
        public void AddPar(PropertyInfo Pi, IEntityBase Entity) 
        {
            this.pravale.Add(ParType(Pi,Entity,Pi.Name)); 
        }
        /// <summary>
        /// 条件子语句参数添加访法 Where
        /// </summary>
        /// <param name="Pi"></param>
        /// <param name="Entity"></param>
        public void AddParWhere(PropertyInfo Pi, IEntityBase Entity)
        {
            this.pravale.Add(ParType(Pi, Entity, "Where" + Pi.Name)); 
        } 
        /// <summary>
        /// 参数类型 这里还没做完 
        /// </summary>
        protected virtual OracleParameter ParType(PropertyInfo Pi
            ,IEntityBase Entity
            ,string ParKey)
        {
            OracleParameter result = null;
            FieldSetBase fsbString = new FieldSetString();
            FieldSetBase fsblong = new FieldSetLong();
            FieldSetBase fsbDateTime = new FieldSetDateTime();
            FieldSetBase fsbInt = new FieldSetInt();
            fsbString.SetNextFieldSetType(fsblong);
            fsblong.SetNextFieldSetType(fsbDateTime);
            fsbDateTime.SetNextFieldSetType(fsbInt); 
            result = fsbString.Definition(Pi, Entity, ParKey);
            
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
