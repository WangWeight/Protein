using System;
using System.Data;
using System.Configuration; 
using System.Data.OracleClient;

namespace Protein.Enzyme.DAL.Oracle
{ 
    /// <summary>
    ///OraDBHelper ��ժҪ˵��
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
        #region �������ݿ����Ӷ���
        /// <summary>   
        /// �������ݿ�����   
        /// </summary>   
        /// <returns>����һ�����ݿ������OracleConnection����</returns>   
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

        #region ����OracleCommand����
        /// <summary>   
        /// ����OracleCommand����          
        /// </summary>   
        /// <param name="cmd">OracleCommand���� </param>   
        /// <param name="cmdText">�����ı�</param>   
        /// <param name="cmdType">��������</param>   
        /// <param name="cmdParms">��������</param>   
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

        #region ִ�д�������sql��䣬������Ӧ��DataSet����
        /// <summary>   
        /// ִ�д�������sql��䣬������Ӧ��DataSet����   
        /// </summary>   
        /// <param name="cmdText">sql���</param>   
        /// <returns>������Ӧ��DataSet����</returns>   
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

        #region ִ����Ӧ��sql��䣬������Ӧ��DataSet����
        /// <summary>   
        /// ִ����Ӧ��sql��䣬������Ӧ��DataSet����   
        /// </summary>   
        /// <param name="sqlstr">sql���</param>   
        /// <returns>������Ӧ��DataSet����</returns>   
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

        #region ִ����Ӧ��sql��䣬������Ӧ��DataSet����
        /// <summary>   
        /// ִ����Ӧ��sql��䣬������Ӧ��DataSet����   
        /// </summary>   
        /// <param name="sqlstr">sql���</param>   
        /// <param name="tableName">����</param>   
        /// <returns>������Ӧ��DataSet����</returns>   
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

        #region ִ�в�������sql��䣬������Ӱ�������
        /// <summary>   
        /// ִ�в�������sql��䣬������Ӱ�������   
        /// </summary>   
        /// <param name="cmdstr">����ɾ����sql���</param>   
        /// <returns>������Ӱ�������</returns>   
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

        #region ִ�д�����sql����洢���̣�������Ӱ�������

        /// <summary>   
        ///  ִ�д�����sql����洢���̣�������Ӱ�������   
        /// </summary>   
        /// <param name="cmdText">��������sql���ʹ洢������</param>   
        /// <param name="cmdType">��������</param>   
        /// <param name="cmdParms">��������</param>   
        /// <returns>������Ӱ�������</returns>   
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

        #region ִ�в�������sql��䣬����һ��������Դ��ȡ���ݵ�OracleDataReader����
        /// <summary>   
        /// ִ�в�������sql��䣬����һ��������Դ��ȡ���ݵ�OracleDataReader����   
        /// </summary>   
        /// <param name="cmdstr">��Ӧ��sql���</param>   
        /// <returns>����һ��������Դ��ȡ���ݵ�OracleDataReader����</returns>   
        public  OracleDataReader ExecuteReader(string cmdText)
        {
            OracleDataReader reader;
         
            init();
            cmd = new OracleCommand(cmdText, conn);
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);             
            return reader;
        }
        #endregion

        #region ִ�д�������sql����洢���̣�����һ��������Դ��ȡ���ݵ�OracleDataReader����
        /// <summary>   
        /// ִ�д�������sql����洢���̣�����һ��������Դ��ȡ���ݵ�OracleDataReader����   
        /// </summary>   
        /// <param name="cmdText">sql����洢������</param>   
        /// <param name="cmdType">��������</param>   
        /// <param name="cmdParms">��������</param>   
        /// <returns>����һ��������Դ��ȡ���ݵ�OracleDataReader����</returns>   
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

        #region ִ�в�������sql���,���ؽ�����������е�ֵobject
        /// <summary>   
        /// ִ�в�������sql���,���ؽ�����������е�ֵobject   
        /// </summary>   
        /// <param name="cmdstr">��Ӧ��sql���</param>   
        /// <returns>���ؽ�����������е�ֵobject</returns>   
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

        #region ִ�д�����sql����洢����,���ؽ�����������е�ֵobject
        /// <summary>   
        /// ִ�д�����sql����洢����,���ؽ�����������е�ֵobject   
        /// </summary>   
        /// <param name="cmdText">sql����洢������</param>   
        /// <param name="cmdType">��������</param>   
        /// <param name="cmdParms">���ؽ�����������е�ֵobject</param>   
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

        #region ִ�д�����sql��������ÿ�β�������Ӱ������
        /// <summary>
        /// ��ʼ����
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
        /// ִ���������  
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
        /// �ع�����
        /// </summary>
        public void RollBackTran()
        {
            this.tran.Rollback();
        } 
        /// <summary>
        /// �ύ����
        /// </summary>
        public void CommitTran()
        {
            this.tran.Commit();
            this.conn.Close(); 
        }
        
        #endregion
    }   


}
