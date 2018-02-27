using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.IO;
using System.Diagnostics;

namespace Protein.Enzyme.DAL.MDB
{
    /// <summary>
    /// MDBHelper 的摘要说明 
    /// </summary>
    public class MDBHelper
    {
        public OleDbCommand cmd = null;
        public static Dictionary<string, OleDbConnection> connDic;
        public static OleDbConnection conn = null;
        public OleDbTransaction tran = null;
        public string connstr = "";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Conn"></param>
        public MDBHelper(string Conn)
        {
            this.connstr = Conn;
        }

        #region 建立数据库连接
        /// <summary>
        /// 建立数据库连接
        /// </summary>
        /// <returns>返回一个数据库的连接OleDbConnection对象</returns>
        public virtual OleDbConnection init()
        {
            OleDbConnection result=null;
            if (connDic == null)
            {
                connDic = new Dictionary<string, OleDbConnection>();
            }
            if (connDic.ContainsKey(this.connstr))
            { 
                result=connDic[this.connstr];
            }
            if (result == null)
            {
                result = new OleDbConnection(this.connstr);
                connDic.Add(this.connstr, result);
            }
            if (result.State != ConnectionState.Open)
            {
                result.Open();
            }
            return result;
        }

        //protected virtual OleDbConnection CreateConn()
        //{
        
        //}
        #endregion

        #region 设置OleDbCommand对象
        /// <summary>
        /// 设置OleDbCommand对象
        /// </summary>
        /// <param name="cmd">OleDbCommand对象</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdParms">参数集合</param>
        protected virtual  void SetCommand(OleDbCommand cmd, string cmdText, CommandType cmdType, OleDbParameter[] cmdParms)
        {
            cmd.Connection = init();
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                cmd.Parameters.AddRange(cmdParms);

            }
        }

        #endregion

        #region 执行带参数的sql语句，返回相应的DataSet对象
        /// <summary>
        /// 执行带参数的sql语句，返回相应的DataSet对象
        /// </summary>
        /// <param name="cmdText">sql语句</param>
        /// <param name="cmdType"></param>
        /// <param name="cmdParms"></param>
        /// <returns>返回相应的DataSet对象</returns>
        public DataSet GetDataSet(string cmdText, CommandType cmdType, OleDbParameter[] cmdParms)
        {
            DataSet set = new DataSet(); 
            init();
            cmd = new OleDbCommand();
            SetCommand(cmd, cmdText, cmdType, cmdParms);
            OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
            adp.Fill(set);
            cmd.Parameters.Clear(); 
            cmd.Connection = null;
            cmd.Dispose();
            cmd = null;
            //conn.Close();
            //conn.Dispose();
            //conn = null;
            
            return set;
        }

        #endregion

        //#region 执行相应的sql语句，返回相应的DataSet对象
        ///// <summary>
        ///// 执行相应的sql语句，返回相应的DataSet对象
        ///// </summary>
        ///// <param name="sqlstr">sql语句</param>
        ///// <returns>返回相应的DataSet对象</returns>
        //public DataSet GetDataSet(string sqlstr)
        //{
        //    DataSet set = new DataSet();
        //    init();
        //    OleDbDataAdapter adp = new OleDbDataAdapter(sqlstr, conn);
        //    adp.Fill(set);

        //    //conn.Close();

        //    return set;
        //}

        //#endregion

        //#region 执行相应的sql语句，返回相应的DataSet对象
        ///// <summary>
        ///// 执行相应的sql语句，返回相应的DataSet对象
        ///// </summary>
        ///// <param name="sqlstr">sql语句</param>
        ///// <param name="tableName">表名</param>
        ///// <returns>返回相应的DataSet对象</returns>
        //public DataSet GetDataSet(string sqlstr, string tableName)
        //{
        //    DataSet set = new DataSet();
        //    init();
        //    OleDbDataAdapter adp = new OleDbDataAdapter(sqlstr, conn);
        //    adp.Fill(set, tableName);
        //    //conn.Close();

        //    return set;
        //}

        //#endregion

        //#region 执行不带参数sql语句，返回所影响的行数
        ///// <summary>
        ///// 执行不带参数sql语句，返回所影响的行数
        ///// </summary>
        ///// <param name="cmdText">增，删，改sql语句</param>
        ///// <returns>返回所影响的行数</returns>
        //public int ExecuteNonQuery(string cmdText)
        //{
        //    int count;

        //    init();
        //    cmd = new OleDbCommand(cmdText, conn);
        //    count = cmd.ExecuteNonQuery();
        //    //conn.Close();
        //    cmd.Connection = null;
        //    return count;
        //}

        //#endregion

        #region 执行带参数sql语句或存储过程，返回所影响的行数
        /// <summary>
        /// 执行带参数sql语句或存储过程，返回所影响的行数
        /// </summary>
        /// <param name="cmdText">带参数的sql语句和存储过程名</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdParms">参数集合</param>
        /// <returns>返回所影响的行数</returns>
        public int ExecteNonQuery(string cmdText, CommandType cmdType, OleDbParameter[] cmdParms) 
        {
            int count;
            init();
            cmd = new OleDbCommand();
            SetCommand(cmd, cmdText, cmdType, cmdParms);
            foreach (OleDbParameter odbp in cmdParms)
            {
                Debug.WriteLine("[ExecteNonQuery]" + odbp.ParameterName + ":" + odbp.DbType.ToString());
            }
            count = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            cmd.Connection = null;
            cmd.Dispose();
            cmd = null;
            //conn.Close();
            //conn.Dispose();
            //conn = null;
            return count;
        }

        #endregion

        //#region 执行不带参数sql语句，返回一个从数据源读取数据的OleDbDataReader对象
        ///// <summary>
        ///// 执行不带参数sql语句，返回一个从数据源读取数据的OleDbDataReader对象
        ///// </summary>
        ///// <param name="cmdText">相应的sql语句</param>
        ///// <returns>返回一个从数据源读取数据的OleDbDataReader对象</returns>
        //public OleDbDataReader ExecteReader(string cmdText)
        //{
        //    OleDbDataReader reader; 
        //    init();
        //    cmd = new OleDbCommand(cmdText, conn);
        //    reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //    cmd.Connection = null;
        //    return reader;
        //}
        //#endregion

        #region 执行带参数的sql语句或存储过程，返回一个从数据源读取数据的OleDbDataReader对象
        /// <summary>
        /// 执行带参数的sql语句或存储过程，返回一个从数据源读取数据的OleDbDataReader对象
        /// </summary>
        /// <param name="cmdText">sql语句或存储过程名</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdParms">参数集合</param>
        /// <returns>返回一个从数据源读取数据的OleDbDataReader对象</returns>
        public OleDbDataReader ExecuteReader(string cmdText, CommandType cmdType, OleDbParameter[] cmdParms)
        {
            OleDbDataReader reader;

            init();
            cmd = new OleDbCommand();
            SetCommand(cmd, cmdText, cmdType, cmdParms);
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Connection = null;
            return reader;
        }
        #endregion

        //#region 执行不带参数sql语句，返回结果集首行首列的值object
        ///// <summary>
        ///// 执行不带参数sql语句，返回结果集首行首列的值object
        ///// </summary>
        ///// <param name="cndText">相应的sql语句</param>
        ///// <returns>返回结果集首行首列的值object</returns>
        //public object ExecuteScalar(string cmdText)
        //{
        //    object obj;
            
        //    init();
        //    cmd = new OleDbCommand(cmdText, conn);
        //    obj = cmd.ExecuteScalar();
        //    cmd.Connection = null;
        //    //conn.Close();
        //    cmd.Connection = null;
        //    return obj;
        //}
        //#endregion

        #region 执行带参数sql语句或存储过程,返回结果集首行首列的值object

        /// <summary>
        /// 执行带参数sql语句或存储过程,返回结果集首行首列的值object
        /// </summary>
        /// <param name="cmdText">sql语句或存储过程名</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdParms">返回结果集首行首列的值object</param>
        /// <returns></returns>
        public object ExecuteScalar(string cmdText, CommandType cmdType, OleDbParameter[] cmdParms)
        {
            object obj; 
            init();
            cmd = new OleDbCommand();
            SetCommand(cmd, cmdText, cmdType, cmdParms);
            obj = cmd.ExecuteScalar();
            cmd.Connection = null;
            //conn.Close(); 
            return obj;
        }
        #endregion

        #region 执行带参数sql语句的事务，每次操作返回影响行数
        /// <summary>
        /// 开始事务
        /// </summary>
        public void BeginTran()
        {
            conn = init();
            if (conn.State == ConnectionState.Open)
            {
                this.tran = conn.BeginTransaction();
            }
        }
        /// <summary>
        /// 执行事务操作
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public int ExecuteTran(string cmdText, CommandType cmdType, OleDbParameter[] cmdParms)
        {
            try
            {
                int result = -1;
                if (cmdParms != null)
                {
                    OleDbCommand newcmd = this.tran.Connection.CreateCommand();
                    newcmd.Transaction = this.tran;
                    newcmd.CommandText = cmdText;
                    newcmd.CommandType = cmdType;
                    newcmd.Parameters.AddRange(cmdParms);
                    result = newcmd.ExecuteNonQuery();
                    newcmd.Parameters.Clear();
                    newcmd.Connection = null;
                    //newcmd.Connection = null;
                }
                return result;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollBackTran()
        {
            this.tran.Rollback();
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTran()
        {
            this.tran.Commit();
            //this.conn.Close();
        }
        #endregion
    }
}
