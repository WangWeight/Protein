using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection; 
using System.Data; 
using System.ComponentModel;
using Protein.Enzyme.DAL.Oracle.Command; 
using Protein.Enzyme.DAL;

namespace Protein.Enzyme.DAL.Oracle
{
    /// <summary>
    /// �����������
    /// </summary>
    public class DvTableBatch:Protein.Enzyme.DAL.IDvTableBatch
    {
      
        public DvTableBatch(IDalSql Setup,DlgCreateDvTableIns DlgDvTableIns)
        {
            setup = Setup;
            this.dlgDvTableIns = DlgDvTableIns;

        }



        #region IDvTableBatch ��Ա

        protected List<IDvTable> insertList = new List<IDvTable>();
        protected List<IDvTable> updateList = new List<IDvTable>();
        protected List<IDvTable> deleteList = new List<IDvTable>();


        IDalSql setup = null;
        public IDalSql DalSql
        {
            get
            {
                return this.setup;
            }
            set
            {
                this.setup = value;
            }
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
        /// ��������������IDalSql����Ͳ��������ʵ����󴴽���������������ʵ�� 
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public  IDvTable CreateDriveTable(IEntityBase Entity)
        {
            return this.dlgDvTableIns(Entity, this.DalSql);
            
        }
 
        /// <summary>
        ///  ��Ӳ������
        /// </summary>
        /// <param name="Entity"></param>
        public void AddInsert(IEntityBase Entity)
        { 
            this.insertList.Add(this.CreateDriveTable(Entity));
        }


        /// <summary>
        /// ��Ӹ��²���
        /// </summary>
        /// <param name="Table"></param>
        public void AddUpdate(IDvTable Table)
        {
            this.updateList.Add(Table);
        }
        /// <summary>
        /// ���ɾ������
        /// </summary>
        /// <param name="Table"></param>
        public void AddDelete(IDvTable Table)
        {
            this.deleteList.Add(Table);
        }
        /// <summary>
        /// ִ�в���
        /// </summary>
        public int  Execute()
        {
            int i = 0;
            i = this.setup.InsertTran(this.insertList, false);
            i = i + this.setup.UpdateTran(this.updateList, false);
            i = i + this.setup.DeleteTran(this.deleteList, false);
            return i;
        }

        


        #endregion
    }
}
