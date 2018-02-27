using System;
using System.Data;
using System.Configuration; 
using System.Data.OracleClient;

namespace Protein.Enzyme.DAL.Oracle
{ 
    /// <summary>
    ///OraDBHelper 的摘要说明
    /// </summary> 
    public class OraDBHelper
    {
        public  OracleCommand cmd = null;
        public  OracleConnection conn = null;
        public OracleTransaction tran=null;
        public string connstr = "";  
            
        ///ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
         
        public OraDBHelper(string Conn)
        {
            this.connstr = Conn;
        }
        #region 建立数据库连接对象
        /// <summary>   
        /// 建立数据库连接   
        /// </summary>   
        /// <returns>返回一个数据库的连接OracleConnection对象</returns>   
        public virtual OracleConnection init()
        { 
            conn = new OracleConnection(connstr);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            
            return conn;
        }
        #endregion

        #region 设置OracleCommand对象
        /// <summary>   
        /// 设置OracleCommand对象          
        /// </summary>   
        /// <param name="cmd">OracleCommand对象 </param>   
        /// <param name="cmdText">命令文本</param>   
        /// <param name="cmdType">命令类型</param>   
        /// <param name="cmdParms">参数集合</param>   
        private  void SetCommand(OracleCommand cmd, string cmdText, CommandType cmdType, OracleParameter[] cmdParms)
        {
            cmd.Connection = conn;
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
        /// <returns>返回相应的DataSet对象</returns>   
        public DataSet GetDataSet(string cmdText, CommandType cmdType, OracleParameter[] cmdParms)
        {
            DataSet set = new DataSet();
            
            init();
            cmd = new OracleCommand();
            SetCommand(cmd, cmdText, cmdType, cmdParms);
            OracleDataAdapter adp = new OracleDataAdapter(cmd);
            adp.Fill(set); 
            cmd.Parameters.Clear();
            conn.Close();
             
            return set;
        }
        #endregion

        #region 执行相应的sql语句，返回相应的DataSet对象
        /// <summary>   
        /// 执行相应的sql语句，返回相应的DataSet对象   
        /// </summary>   
        /// <param name="sqlstr">sql语句</param>   
        /// <returns>返回相应的DataSet对象</returns>   
        public  DataSet GetDataSet(string sqlstr)
        {
            DataSet set = new DataSet();
             
                init();
                OracleDataAdapter adp = new OracleDataAdapter(sqlstr, conn);
                adp.Fill(set);
                conn.Close();
             
            return set;
        }
        #endregion

        #region 执行相应的sql语句，返回相应的DataSet对象
        /// <summary>   
        /// 执行相应的sql语句，返回相应的DataSet对象   
        /// </summary>   
        /// <param name="sqlstr">sql语句</param>   
        /// <param name="tableName">表名</param>   
        /// <returns>返回相应的DataSet对象</returns>   
        public  DataSet GetDataSet(string sqlstr, string tableName)
        {
            DataSet set = new DataSet();
             
                init();
                OracleDataAdapter adp = new OracleDataAdapter(sqlstr, conn);
                adp.Fill(set, tableName);
                conn.Close();
             
            return set;
        }
        #endregion

        #region 执行不带参数sql语句，返回所影响的行数
        /// <summary>   
        /// 执行不带参数sql语句，返回所影响的行数   
        /// </summary>   
        /// <param name="cmdstr">增，删，改sql语句</param>   
        /// <returns>返回所影响的行数</returns>   
        public  int ExecuteNonQuery(string cmdText)
        {
            int count;
             
            init();
            cmd = new OracleCommand(cmdText, conn);
            count = cmd.ExecuteNonQuery();
            conn.Close();
           
            return count;
        }
        #endregion

        #region 执行带参数sql语句或存储过程，返回所影响的行数

        /// <summary>   
        ///  执行带参数sql语句或存储过程，返回所影响的行数   
        /// </summary>   
        /// <param name="cmdText">带参数的sql语句和存储过程名</param>   
        /// <param name="cmdType">命令类型</param>   
        /// <param name="cmdParms">参数集合</param>   
        /// <returns>返回所影响的行数</returns>   
        public  int ExecuteNonQuery(string cmdText, CommandType cmdType, OracleParameter[] cmdParms)
        {
            int count; 
            init();
            cmd = new OracleCommand();
            SetCommand(cmd, cmdText, cmdType, cmdParms);
            count = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            conn.Close();
             
            return count;
        }
        #endregion

        #region 执行不带参数sql语句，返回一个从数据源读取数据的OracleDataReader对象
        /// <summary>   
        /// 执行不带参数sql语句，返回一个从数据源读取数据的OracleDataReader对象   
        /// </summary>   
        /// <param name="cmdstr">相应的sql语句</param>   
        /// <returns>返回一个从数据源读取数据的OracleDataReader对象</returns>   
        public  OracleDataReader ExecuteReader(string cmdText)
        {
            OracleDataReader reader;
         
            init();
            cmd = new OracleCommand(cmdText, conn);
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);             
            return reader;
        }
        #endregion

        #region 执行带参数的sql语句或存储过程，返回一个从数据源读取数据的OracleDataReader对象
        /// <summary>   
        /// 执行带参数的sql语句或存储过程，返回一个从数据源读取数据的OracleDataReader对象   
        /// </summary>   
        /// <param name="cmdText">sql语句或存储过程名</param>   
        /// <param name="cmdType">命令类型</param>   
        /// <param name="cmdParms">参数集合</param>   
        /// <returns>返回一个从数据源读取数据的OracleDataReader对象</returns>   
        public  OracleDataReader ExecuteReader(string cmdText, CommandType cmdType, OracleParameter[] cmdParms)
        {
            OracleDataReader reader;
             
            init();
            cmd = new OracleCommand();
            SetCommand(cmd, cmdText, cmdType, cmdParms);
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
         
            return reader;
        }
        #endregion

        #region 执行不带参数sql语句,返回结果集首行首列的值object
        /// <summary>   
        /// 执行不带参数sql语句,返回结果集首行首列的值object   
        /// </summary>   
        /// <param name="cmdstr">相应的sql语句</param>   
        /// <returns>返回结果集首行首列的值object</returns>   
        public  object ExecuteScalar(string cmdText)
        {
            object obj;
             
                init();
                cmd = new OracleCommand(cmdText, conn);
                obj = cmd.ExecuteScalar();
                conn.Close();
            
            return obj;
        }
        #endregion

        #region 执行带参数sql语句或存储过程,返回结果集首行首列的值object
        /// <summary>   
        /// 执行带参数sql语句或存储过程,返回结果集首行首列的值object   
        /// </summary>   
        /// <param name="cmdText">sql语句或存储过程名</param>   
        /// <param name="cmdType">命令类型</param>   
        /// <param name="cmdParms">返回结果集首行首列的值object</param>   
        /// <returns></returns>   
        public  object ExecuteScalar(string cmdText, CommandType cmdType, OracleParameter[] cmdParms)
        {
            object obj;
            
                init();
                cmd = new OracleCommand();
                SetCommand(cmd, cmdText, cmdType, cmdParms);
                obj = cmd.ExecuteScalar();
                conn.Close();
            
            return obj;
        }
        #endregion

        #region 执行带参数sql语句的事务，每次操作返回影响行数
        /// <summary>
        /// 开始事务
        /// </summary>
        public void BeginTran()
        {
            init();
            if (conn.State == ConnectionState.Open)
            {
                this.tran = conn.BeginTransaction();
            } 
        }
        /// <summary>
        /// 执行事务操作  
        /// </summary>
        public int  ExecuteTran(string cmdText, CommandType cmdType, OracleParameter[] cmdParms)
        {
            int result = -1; 
            if (cmdParms != null)
            {
                OracleCommand newcmd = this.conn.CreateCommand();
                newcmd.Transaction = this.tran;
                newcmd.CommandText = cmdText;
                newcmd.CommandType = cmdType;
                newcmd.Parameters.AddRange(cmdParms);
                result = newcmd.ExecuteNonQuery();
                newcmd.Parameters.Clear();
            }  
            return result;
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
            this.conn.Close(); 
        }
        
        #endregion
    }   


}
