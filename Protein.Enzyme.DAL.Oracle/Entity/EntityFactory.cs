using System;
using System.Collections.Generic;
using System.Text; 
using Protein.Enzyme.DAL;
using Protein.Enzyme.DAL.Oracle;
namespace Protein.Enzyme.DAL.Oracle.Entity
{
    /// <summary>
    /// 实体工厂
    /// </summary>
    public class EntityFactory : Protein.Enzyme.DAL.IEntityFactory
    {
        public EntityFactory(Protein.Enzyme.DAL.IDBInfo Dbh)
        {
            this.dbHelper = Dbh;
            this.TypeAdapter = new EntityTypeAdapterLog();
            //this.TypeAdapter.s
        }
        private Protein.Enzyme.DAL.IDBInfo dbHelper = null;
        public Protein.Enzyme.DAL.IDBInfo DbHelper
        {
            get
            {
                return this.dbHelper; ;
            }
            set
            {
                this.dbHelper = value; ;
            }
        }

        public EntityTypeAdapter TypeAdapter
        {
            get;
            set;
        }


        #region 创建实体类对象实例
        

        /// <summary>
        /// 创建实体对象实例
        /// </summary>
        public virtual T CreateEntityInstance<T>()
        {
            if (this.TypeAdapter != null)
            {
                return this.TypeAdapter.Definition<T>(typeof(T));
            }
            return default(T);
        }

        ///// <summary>
        ///// 创建实例
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        //protected T CreateInstance<T>(Type NewType)
        //{
        //    T ins = (T)Activator.CreateInstance(NewType);
        //    return ins;
        //}

        #endregion
        
         
        /// <summary>
        /// 创建表格操作驱动对象
        /// </summary>
        /// <returns></returns>
        public IDvTable CreateDriveTable(Protein.Enzyme.DAL.IEntityBase Entity) 
        {
            IDalSql dsql = new DalSql(this.dbHelper); 
            return CreateDriveTable(Entity,dsql);
        }

        /// <summary>
        /// 创建表格操作驱动对象
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="DalSql"></param>
        /// <returns></returns>
        public IDvTable CreateDriveTable(Protein.Enzyme.DAL.IEntityBase Entity,IDalSql DalSql)
        {
            IDvTable dvt = new DvTable(DalSql);
            dvt.Entity = Entity;
            return dvt;
        }

        /// <summary>
        /// 创建表格批量操作驱动对象
        /// </summary>
        /// <returns></returns>
        public IDvTableBatch CreateDriveTableBatch()
        {
            IDalSql dsql = new DalSql(this.dbHelper);
            DlgCreateDvTableIns dlgcdt = new DlgCreateDvTableIns(CreateDriveTable);
            IDvTableBatch dvt = new DvTableBatch(dsql,dlgcdt); 
            return dvt;
        }

 
        public IDALManager CreateDALmanager()
        { 
            IDALManager dlm = new DALManager(this.dbHelper);
            return dlm;
        }






        public void AddAdapter(EntityTypeAdapter NewAdapter)
        {
            this.TypeAdapter.SetNextEntityType(NewAdapter);
        }


         
    }
}
