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
    /// ����Ԫ�������û��࣬��������SQL�������
    /// </summary>
    public abstract class StockCmd
    { 
        
        string cmd = "";
        /// <summary>
        /// sql���
        /// </summary>
        public string Cmd
        {
            get { return cmd; }
            set { cmd = value; }
        }
        /// <summary>
        /// �����б�
        /// </summary>
        List<OracleParameter> pravale = new List<OracleParameter>();

        /// <summary>
        /// �����б�
        /// </summary>
        public List<OracleParameter> Parameter
        {
            get { return pravale; }
            set { pravale = value; }
        }
        /// <summary>
        /// ��Ӳ��� ���ݲ�ͬ�������ò������� 
        /// </summary>
        /// <param name="Pi"></param>
        public void AddPar(PropertyInfo Pi, IEntityBase Entity) 
        {
            this.pravale.Add(ParType(Pi,Entity,Pi.Name)); 
        }
        /// <summary>
        /// ��������������ӷ÷� Where
        /// </summary>
        /// <param name="Pi"></param>
        /// <param name="Entity"></param>
        public void AddParWhere(PropertyInfo Pi, IEntityBase Entity)
        {
            this.pravale.Add(ParType(Pi, Entity, "Where" + Pi.Name)); 
        } 
        /// <summary>
        /// �������� ���ﻹû���� 
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
        /// �������ֵΪnullʱ��ȡֵ���� ���ﻹû���� 
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
        /// ��ȡֵ��˵��
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
        /// ����sql����
        /// </summary>
        /// <param name="Table"></param>
        public abstract void CreateCmd(IDvTable Table);

        
    }
}
