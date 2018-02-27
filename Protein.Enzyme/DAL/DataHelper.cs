using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;
namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// ���ݲ���ͨ�÷�����
    /// ֻ�������󵽽ӿڲ���Ĳ���������ʵ��
    /// </summary>
    public class DataHelper
    {

        /// <summary>
        /// ��ȡָ�������ֶε����ֵ
        /// </summary>
        /// <param name="Entity">ʵ��</param>
        /// <param name="FieldName">�ֶ���</param>
        /// <param name="Entityfactory">�ֶ���</param>
        /// <returns></returns>
        public virtual  Int64 GetMaxField(IEntityBase Entity, string FieldName, IEntityFactory Entityfactory)
        {
            Regex re = new Regex("^[0-9]*[1-9][0-9]*$");
            Int64 i = -99999;
            IDvTable dvt = Entityfactory.CreateDriveTable(Entity);
            dvt.SetFilter(Operator.Fun_Max, FieldName);
            DataSet ds = dvt.Select();
            if (ds.Tables.Count > 0)
            {
                if (re.IsMatch(ds.Tables[0].Rows[0][0].ToString()))
                {
                    i = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
            }
            if (i == -99999)
            {
                i = 0;
            }
            return i;
        }

        /// <summary>
        /// ת��DataSet��ʵ��
        /// </summary>
        /// <returns></returns>
        public virtual List<object> Convert(Type InsType, DataSet Ds)
        {
             
            List<object> list = this.ConvertToEntity(InsType, Ds);
            return list;
        }
        /// <summary>
        /// ת�������б���������
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="List"></param>
        /// <returns></returns>
        public virtual List<T> Convert<T>(List<object> List)
        {
            List<T> result = new List<T>();
            foreach (object obj in List)
            {
                result.Add((T)obj);
            }
            return result;
        }
        /// <summary>
        /// ����ָ��������ת�����󵽷�������
        /// </summary>
        /// <param name="InsType"></param>
        /// <param name="Ds"></param>
        /// <returns></returns>
        public virtual List<T> Convert<T>(Type InsType, DataSet Ds)
        {
            List<object> list = this.Convert(InsType, Ds);
            return this.Convert<T>(list);

        }
        /// <summary>
        /// ����ָ������ת�����������ͺ��ȡָ��������ֵ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="InsType"></param>
        /// <param name="Ds"></param>
        /// <param name="Index"></param>
        /// <returns></returns>
        public virtual T Convert<T>(Type InsType, DataSet Ds, int Index)
        {
            List<T> list = Convert<T>(InsType, Ds);
            if (list.Count > Index)
            {
                return list[Index];
            }
            else
            {
                return default(T);
            }
        } 

        /// <summary>
        /// ת��ʵ����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ds"></param>
        /// <returns></returns>
        public List<T> ConvertToEntity<T>(DataSet ds)
        {
            List<T> l = new List<T>();
            if (ds.Tables.Count > 0 || ds.Tables[0].Rows.Count > 0)
            { 
                if (ds.Tables[0].Columns[0].ColumnName.ToLower() == "rowId".ToLower())
                {
                    ds.Tables[0].Columns.Remove("rowId");
                } 
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    T model = default(T);
                    model = Activator.CreateInstance<T>();
                    SplitDataRow(model, dr);
                    l.Add(model);
                }
            }
            return l; 
        }

 
        /// <summary>
        /// ���dataset���� ������ֵ
        /// </summary>
        /// <param name="ObjType"></param>
        /// <param name="Ds"></param>
        /// <returns></returns>
        public List<object> ConvertToEntity(Type ObjType, DataSet Ds)
        {
            List<object> objlist = new List<object>();
            if (Ds.Tables.Count > 0 || Ds.Tables[0].Rows.Count>0)
            {
                if (Ds.Tables[0].Columns[0].ColumnName.ToLower() == "rowId".ToLower())
                {
                    Ds.Tables[0].Columns.Remove("rowId");
                }
                foreach (DataRow dr in Ds.Tables[0].Rows)
                {
                    object model = Activator.CreateInstance(ObjType);
                    //�����ʼ�������ִ�й���
                    InitializeObject();
                    objlist.Add(SplitDataRow(model, dr));
                }
            }
            return objlist;
        }
        /// <summary>
        /// 
        /// </summary>
        public void InitializeObject()
        { 
        
        }

        /// <summary>
        /// ���dataset���� ������ֵ
        /// </summary>
        /// <param name="TemplateObj"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        protected  object SplitDataRow(object TemplateObj, DataRow dr)
        {
            foreach (DataColumn dc in dr.Table.Columns)
            {
                //���˿��ܴ��ڵ�.
                string columnname = "";
                if (dc.ColumnName.IndexOf(".") > -1)
                {
                    columnname = dc.ColumnName.Substring(dc.ColumnName.IndexOf(".")+1, dc.ColumnName.Length - dc.ColumnName.IndexOf(".")-1);
                }
                else
                {
                    columnname = dc.ColumnName;
                }

                if (TemplateObj.GetType().GetProperty(columnname, BindingFlags.Public
                    | BindingFlags.Instance | BindingFlags.IgnoreCase) == null)
                {
                    continue;
                }
                PropertyInfo pi = TemplateObj.GetType().GetProperty(columnname, BindingFlags.Public
                    | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (dr[dc.ColumnName] != DBNull.Value)
                {
                    SetValueIns(pi, TemplateObj, dr, dc.ColumnName); 
                }
                else
                {
                    pi.SetValue(TemplateObj, null, null);
                }
            }
            return TemplateObj;
        }

        /// <summary>
        /// ����ʵ��ֵ
        /// </summary>
        protected virtual void SetValueIns(PropertyInfo Pinfo, object TemplateObj,DataRow Dr,string  ColumnName)
        {
            object v = Dr[ColumnName];
            if (Dr[ColumnName].GetType() == typeof(decimal))
            {
               
                if (Pinfo.PropertyType == typeof(int))
                {
                    int i = int.Parse(v.ToString());
                    Pinfo.SetValue(TemplateObj, i, null);
                }
                else if (Pinfo.PropertyType == typeof(long))
                {
                    long l = long.Parse(v.ToString());
                    Pinfo.SetValue(TemplateObj, l, null);
                }
            }
            else
            {
                if (Pinfo.PropertyType == typeof(double))
                {
                    double i = double.Parse(v.ToString());
                    Pinfo.SetValue(TemplateObj, i, null);
                }
                else if (Pinfo.PropertyType == v.GetType())
                {
                    Pinfo.SetValue(TemplateObj, v, null);
                }
                else
                {
                    Pinfo.SetValue(TemplateObj, v, null);
                }
            }
           
        }
        /// <summary> 
        /// ��ʵ����ת����DataTable 
        /// </summary> 
        /// <typeparam name="T"></typeparam> 
        /// <param name="objlist"></param> 
        /// <returns></returns> 
        public DataTable ConvertToTable<T>(IList<T> objlist)
        {
            if (objlist == null || objlist.Count <= 0)
            {
                return null;
            }
            DataTable dt = new DataTable(typeof(T).Name);
            DataColumn column;
            DataRow row;
            System.Reflection.PropertyInfo[] myPropertyInfo = typeof(T).GetProperties(BindingFlags.Public 
                | BindingFlags.Instance);
            foreach (T t in objlist)
            {
                if (t == null)
                {
                    continue;
                }
                row = dt.NewRow();
                for (int i = 0, j = myPropertyInfo.Length; i < j; i++)
                {
                    System.Reflection.PropertyInfo pi = myPropertyInfo[i];
                    string name = pi.Name;
                    if (dt.Columns[name] == null)
                    {
                        column = new DataColumn(name, pi.PropertyType);
                        dt.Columns.Add(column);
                    }
                    row[name] = pi.GetValue(t, null);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary>
        /// ת�������ݼ�
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ObjectList"></param>
        /// <returns></returns>
        public DataSet ConvertToSet<T>(List<T> ObjectList )
        {
            DataTable dt = ConvertToTable<T>(ObjectList);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

    }
}

