using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using Protein.Enzyme.DAL.MDB.Command;
using Protein.Enzyme.DAL;

namespace Protein.Enzyme.DAL.MDB
{
    /// <summary>
    /// 表格批量操作
    /// </summary>
    public class DvTableBatch : Protein.Enzyme.DAL.IDvTableBatch
    {

       
        public DvTableBatch(IDalSql Setup, DlgCreateDvTableIns DlgDvTableIns)
        {
            setup = Setup;
            this.dlgDvTableIns = DlgDvTableIns;
        }

        #region IDvTableBatch 成员

        protected List<IDvTable> insertList = new List<IDvTable>();
        protected List<IDvTable> updateList = new List<IDvTable>();
        protected List<IDvTable> deleteList = new List<IDvTable>();

        IDalSql setup = null;
        /// <summary>
        /// 
        /// </summary>
        public IDalSql DalSql
        {
            get { return this.setup; }
            set { this.setup = value; }
        }

        DlgCreateDvTableIns dlgDvTableIns = null;

        public DlgCreateDvTableIns DlgCreateDriveTableIns
        {
            set
            {
                this.dlgDvTableIns = value;
            }
        }

        /// <summary>
        /// 根据批量操作的IDalSql对象和参数传入的实体对象创建表格操作驱动对象实例
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public IDvTable CreateDriveTable(IEntityBase Entity)
        {
            return this.dlgDvTableIns(Entity, this.DalSql);
        }

        /// <summary>
        /// 添加插入操作
        /// </summary>
        /// <param name="Entity"></param>
        public void AddInsert(IEntityBase Entity)
        {
            this.insertList.Add(this.CreateDriveTable(Entity));
        }

        /// <summary>
        /// 添加更新操作
        /// </summary>
        /// <param name="Table"></param>
        public void AddUpdate(IDvTable Table)
        {
            this.updateList.Add(Table);
        }

        /// <summary>
        /// 添加删除操作
        /// </summary>
        /// <param name="Table"></param>
        public void AddDelete(IDvTable Table)
        {
            this.deleteList.Add(Table);
        }


        public int Execute()
        {
            int i = 0;
            i = this.setup.InsertTran(this.insertList, false);
            i = i + this.setup.UpdateTran(this.updateList, false);
            i = i + this.setup.DeleteTran(this.deleteList, false);
            return i;
        }

         

        public int ExecuteUpdate(List<IDvTable> TableList, bool IsRollBack)
        {
            int i = 0;
            i = this.setup.UpdateTran(TableList, IsRollBack); 
            return i;
        }

        public int ExecuteInsert(List<IEntityBase> EntityList, bool IsRollBack)
        {
            int i = 0;
            List<IDvTable> tmpInsertList = new List<IDvTable>();
            foreach (IEntityBase eb in EntityList)
            {
                tmpInsertList.Add(this.CreateDriveTable(eb));
            }
            i = this.setup.InsertTran(tmpInsertList, IsRollBack);
            return i;
        }

        public int ExecuteDelete(List<IDvTable> TableList, bool IsRollBack)
        {
            int i = 0;
            i = this.setup.DeleteTran(TableList, IsRollBack);
            return i;
        }

        #endregion

    }
}
