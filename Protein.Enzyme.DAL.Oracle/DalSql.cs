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
    /// 数据库操作配置、执行类 
    /// </summary>
    public class DalSql :IDalSql
    {
        /// <summary>
        /// 批量命令委托
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


        #region 创建命令对象
        /// <summary>
        /// 创建选择命令对象
        /// </summary>
        /// <returns></returns>
        protected StockCmd CreateSelectCmd(IDvTable Table)
        {
            StockCmd ss = new SelectCmd();
            ss.CreateCmd(Table);
            return ss;
        }
        /// <summary>
        /// 创建更新命令对象
        /// </summary>
        /// <returns></returns>
        protected StockCmd CreateUpdateCmd(IDvTable Table)
        {
            StockCmd isert = new UpdateCmd();
            isert.CreateCmd(Table);
            return isert;
        }

        /// <summary>
        /// 创建插入命令对象
        /// </summary>
        /// <returns></returns>
        protected StockCmd CreateInsertCmd(IDvTable Table)
        {
            StockCmd isert = new InsertCmd();
            isert.CreateCmd(Table);
            return isert;
        }

        /// <summary>
        /// 创建删除命令对象
        /// </summary>
        /// <returns></returns>
        protected StockCmd CreateDeleteCmd(IDvTable Table)
        {
            StockCmd isert = new DeleteCmd();
            isert.CreateCmd(Table);
            return isert;
        }

        #endregion

        #region 单次操作
        /// <summary>
        ///  查询语句 
        /// 支持多查询条件
        /// </summary>
        /// <returns></returns>
        public DataSet SelectSingle(IDvTable Table) 
        {
            StockCmd ss = CreateSelectCmd(Table);
            CommandType cmdtype = CommandType.Text;
            return this.oradbh.GetDataSet(ss.Cmd, cmdtype, ss.Parameter.ToArray()); 
        } 
 
        /// <summary>
        /// 把表对象的属性都作为字段添加到插入语句中
        /// </summary>
        /// <param name="Table"></param>
        public int Insert(IDvTable Table)
        {
            StockCmd isert = CreateInsertCmd(Table); 
            CommandType cmdtype = CommandType.Text;
            return this.oradbh.ExecuteNonQuery(isert.Cmd, cmdtype, isert.Parameter.ToArray()); 　
        }
         /// <summary>
         /// 删除表格对象
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
        /// 修改数据
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
       
        #region 批量操作

        /// <summary>
        /// 批量插入数据库记录
        /// </summary>
        /// <param name="Tables"></param>
        /// <param name="IsRollBack">是否允许在操作异常时回滚，true为发生异常是回滚所有操作，false忽略异常记录</param>
        /// <returns>影响的记录数量</returns>
        public int InsertTran(List<IDvTable> Tables, bool IsRollBack)
        {
            return TranOpration(Tables, IsRollBack, new DlgTranStockCmd(CreateInsertCmd)); 
        }
        /// <summary>
        /// 批量更新数据库记录
        /// </summary>
        /// <param name="Tables"></param>
        /// <param name="IsRollBack">是否允许在操作异常时回滚，true为发生异常是回滚所有操作，false忽略异常记录</param>
        /// <returns>影响的记录数量</returns>
        public int UpdateTran(List<IDvTable> Tables, bool IsRollBack)
        {
            return TranOpration(Tables, IsRollBack, new DlgTranStockCmd(CreateUpdateCmd)); 
        }
        /// <summary>
        /// 批量删除数据库记录
        /// </summary>
        /// <param name="Tables"></param>
        /// <param name="IsRollBack">是否允许在操作异常时回滚，true为发生异常是回滚所有操作，false忽略异常记录</param>
        /// <returns>影响的记录数量</returns>
        public int DeleteTran(List<IDvTable> Tables, bool IsRollBack)
        {
            return TranOpration(Tables, IsRollBack, new DlgTranStockCmd(CreateDeleteCmd)); 
        }
        
        /// <summary>
        /// 事务操作
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
