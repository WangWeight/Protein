using System;
using System.Collections.Generic;
using System.Text; 
using Protein.Enzyme.DAL;
using Protein.Enzyme.DAL.MDB;

namespace Protein.Enzyme.DAL.MDB.Entity
{
    /// <summary>
    /// ʵ�幤��
    /// </summary>
    public class EntityFactory : Protein.Enzyme.DAL.IEntityFactory
    {
        public EntityFactory(Protein.Enzyme.DAL.IDBInfo Dbh)
        {
            this.dbHelper = Dbh;
            this.TypeAdapter = new EntityTypeAdapterLog(); 
        }
        private Protein.Enzyme.DAL.IDBInfo dbHelper = null;
        /// <summary>
        /// 
        /// </summary>
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


        #region ����ʵ�������ʵ��
        

        /// <summary>
        /// ����ʵ�����ʵ��
        /// </summary>
        public virtual T CreateEntityInstance<T>()
        {
            if (this.TypeAdapter != null)
            {
                return this.TypeAdapter.Definition<T>(typeof(T));
            }
            return default(T);
        }

        
        #endregion
        
         
        /// <summary>
        /// ������������������
        /// </summary>
        /// <returns></returns>
        public IDvTable CreateDriveTable(Protein.Enzyme.DAL.IEntityBase Entity) 
        {
            IDalSql dsql = new DalSql(this.dbHelper); 
            return CreateDriveTable(Entity,dsql);
        }

        /// <summary>
        /// ������������������
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
        /// �����������������������
        /// </summary>
        /// <returns></returns>
        public IDvTableBatch CreateDriveTableBatch()
        {
            IDalSql dsql = new DalSql(this.dbHelper);
            DlgCreateDvTableIns dlgcdt = new DlgCreateDvTableIns(CreateDriveTable);
            IDvTableBatch dvt = new DvTableBatch(dsql,dlgcdt); 
            return dvt;
        }

 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IDALManager CreateDALmanager()
        {
            IDALManager dlm = null;// new DALManager(this.dbHelper);
            return dlm;
        }

 


        public void AddAdapter(EntityTypeAdapter NewAdapter)
        {
            this.TypeAdapter.SetNextEntityType(NewAdapter);
        }




        public void CloseFactory()
        {
            MDBHelper.connDic[this.dbHelper.GetConnectString()].Close();
            MDBHelper.connDic[this.dbHelper.GetConnectString()].Dispose();
            MDBHelper.connDic[this.dbHelper.GetConnectString()] = null;
            MDBHelper.connDic.Remove(this.dbHelper.GetConnectString());

        }
    }
}
