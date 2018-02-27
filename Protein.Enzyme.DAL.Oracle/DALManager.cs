using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
namespace Protein.Enzyme.DAL.Oracle
{
    /// <summary>
    /// 数据管理 暂时绕过dalsql 正常的做法应该是映射数据库内部的对象来操作
    /// </summary>
    public class DALManager:IDALManager
    {
        OraDBHelper odbh = null;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Dbh"></param>
        public DALManager(IDBInfo Dbh)
        {
            this.odbh = new OraDBHelper(Dbh.GetConnectString());
        }
        #region IDALManager 成员

        /// <summary>
        /// 判断实体是否存在数据库中
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public bool IsEntityExist(IEntityBase Entity)
        {
            string sql = "SELECT count(0) FROM user_tables WHERE TABLE_NAME = '" + Entity.GetType().Name + "'";
            DataSet ds=this.odbh.GetDataSet(sql);
            if (ds == null)
            {
                return false;
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (int.Parse(ds.Tables[0].Rows[0][0].ToString()) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        /// <summary>
        ///  暂时不做 需要反向的字段类型转换
        /// </summary>
        protected void ConstructEntityFiled<T>()
        {
            System.Reflection.PropertyInfo[] myPropertyInfo = typeof(T).GetProperties(BindingFlags.Public
                | BindingFlags.Instance);
            foreach (PropertyInfo pi in myPropertyInfo)
            { 
                
            }
        }
        
 
        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public bool CreateEntity(IEntityBase Entity)
        {
            ICreateTable ct = new CreateTable(Entity);
            ct.ExecuteScript();
            return true;
        }

        #endregion
    }
}
