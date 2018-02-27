using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection; 
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using Protein.Enzyme.DAL.Oracle.Command;
using Protein.Enzyme.DAL;
namespace Protein.Enzyme.DAL.Oracle
{
    /// <summary>
    /// ���ݿ�������á�ִ���� 
    /// </summary>
    public class DalSql :IDalSql
    {
        /// <summary>
        /// ��������ί��
        /// </summary>
        /// <returns></returns>
        protected delegate StockCmd DlgTranStockCmd(IDvTable Table); 
        private OraDBHelper oradbh = null;

        public DalSql(IDBInfo Dbh)
        {
            this.dbHelper = Dbh;
            if (this.dbHelper != null)
            {
                this.oradbh = new OraDBHelper(this.dbHelper.GetConnectString());
            }
        }

        private IDBInfo dbHelper = null;

        public IDBInfo DbHelper
        {
            get
            {
                return this.dbHelper;
            }
            set
            {
                this.dbHelper = value; ;
            }
        }


        #region �����������
        /// <summary>
        /// ����ѡ���������
        /// </summary>
        /// <returns></returns>
        protected StockCmd CreateSelectCmd(IDvTable Table)
        {
            StockCmd ss = new SelectCmd();
            ss.CreateCmd(Table);
            return ss;
        }
        /// <summary>
        /// ���������������
        /// </summary>
        /// <returns></returns>
        protected StockCmd CreateUpdateCmd(IDvTable Table)
        {
            StockCmd isert = new UpdateCmd();
            isert.CreateCmd(Table);
            return isert;
        }

        /// <summary>
        /// ���������������
        /// </summary>
        /// <returns></returns>
        protected StockCmd CreateInsertCmd(IDvTable Table)
        {
            StockCmd isert = new InsertCmd();
            isert.CreateCmd(Table);
            return isert;
        }

        /// <summary>
        /// ����ɾ���������
        /// </summary>
        /// <returns></returns>
        protected StockCmd CreateDeleteCmd(IDvTable Table)
        {
            StockCmd isert = new DeleteCmd();
            isert.CreateCmd(Table);
            return isert;
        }

        #endregion

        #region ���β���
        /// <summary>
        ///  ��ѯ��� 
        /// ֧�ֶ��ѯ����
        /// </summary>
        /// <returns></returns>
        public DataSet SelectSingle(IDvTable Table) 
        {
            StockCmd ss = CreateSelectCmd(Table);
            CommandType cmdtype = CommandType.Text;
            return this.oradbh.GetDataSet(ss.Cmd, cmdtype, ss.Parameter.ToArray()); 
        } 
 
        /// <summary>
        /// �ѱ��������Զ���Ϊ�ֶ���ӵ����������
        /// </summary>
        /// <param name="Table"></param>
        public int Insert(IDvTable Table)
        {
            StockCmd isert = CreateInsertCmd(Table); 
            CommandType cmdtype = CommandType.Text;
            return this.oradbh.ExecuteNonQuery(isert.Cmd, cmdtype, isert.Parameter.ToArray()); ��
        }
         /// <summary>
         /// ɾ��������
         /// </summary>
         /// <param name="Table"></param>
         /// <returns></returns>
        public int Delete(IDvTable Table)
        {
            StockCmd isert = CreateDeleteCmd(Table); 
            CommandType cmdtype = CommandType.Text;
            return this.oradbh.ExecuteNonQuery(isert.Cmd, cmdtype, isert.Parameter.ToArray()); 
             
        }

        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="Table"></param>
        /// <returns></returns>
        public int Update(IDvTable Table)
        {
            StockCmd isert = CreateUpdateCmd(Table); 
            CommandType cmdtype = CommandType.Text;
            return this.oradbh.ExecuteNonQuery(isert.Cmd, cmdtype, isert.Parameter.ToArray());
        }
        #endregion
       
        #region ��������

        /// <summary>
        /// �����������ݿ��¼
        /// </summary>
        /// <param name="Tables"></param>
        /// <param name="IsRollBack">�Ƿ������ڲ����쳣ʱ�ع���trueΪ�����쳣�ǻع����в�����false�����쳣��¼</param>
        /// <returns>Ӱ��ļ�¼����</returns>
        public int InsertTran(List<IDvTable> Tables, bool IsRollBack)
        {
            return TranOpration(Tables, IsRollBack, new DlgTranStockCmd(CreateInsertCmd)); 
        }
        /// <summary>
        /// �����������ݿ��¼
        /// </summary>
        /// <param name="Tables"></param>
        /// <param name="IsRollBack">�Ƿ������ڲ����쳣ʱ�ع���trueΪ�����쳣�ǻع����в�����false�����쳣��¼</param>
        /// <returns>Ӱ��ļ�¼����</returns>
        public int UpdateTran(List<IDvTable> Tables, bool IsRollBack)
        {
            return TranOpration(Tables, IsRollBack, new DlgTranStockCmd(CreateUpdateCmd)); 
        }
        /// <summary>
        /// ����ɾ�����ݿ��¼
        /// </summary>
        /// <param name="Tables"></param>
        /// <param name="IsRollBack">�Ƿ������ڲ����쳣ʱ�ع���trueΪ�����쳣�ǻع����в�����false�����쳣��¼</param>
        /// <returns>Ӱ��ļ�¼����</returns>
        public int DeleteTran(List<IDvTable> Tables, bool IsRollBack)
        {
            return TranOpration(Tables, IsRollBack, new DlgTranStockCmd(CreateDeleteCmd)); 
        }
        
        /// <summary>
        /// �������
        /// </summary>
        protected int TranOpration(List<IDvTable> Tables, bool IsRollBack,DlgTranStockCmd Dtsc)
        {
            int result = 0;
            this.oradbh.BeginTran();
            CommandType cmdtype = CommandType.Text;
            foreach (IDvTable tab in Tables)
            {
                StockCmd cmd = Dtsc(tab);
                int i = this.oradbh.ExecuteTran(cmd.Cmd, cmdtype, cmd.Parameter.ToArray());
                if (IsRollBack && i == 0)
                {
                    this.oradbh.RollBackTran();
                    return 0;
                }
                result = result + i;
            }
            this.oradbh.CommitTran();
            return result;
 
        }
        #endregion

       
    }
}
