using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.Log;
using Protein.Enzyme.Design; 
using Protein.Enzyme.DAL;
using Protein.Enzyme.Design;

namespace Protein.Enzyme.DAL.MDB.Entity
{
    /// <summary>
    /// oracle中的日志记录
    /// </summary>
    public class ProteinLogger : Protein.Enzyme.Log.ILogger
    {
        /// <summary>
        /// 实体对象创建者
        /// </summary>
        IEntityFactory entityfactory;
        /// <summary>
        /// 获取和设置数据实体操作对象工厂对象
        /// </summary>
        public IEntityFactory EntityFactory
        {
            get {
                return this.entityfactory;
            }
            set {
                this.entityfactory = value;
            }
        }
        /// <summary>
        /// oracle中的日志记录
        /// </summary>
        public ProteinLogger()
        {
        }
        ///// <summary>
        ///// oracle中的日志记录
        ///// </summary>
        ///// <param name="Dbh">数据库连接信息</param>
        //public ProteinLogger(IDBInfo Dbh)
        //{  
        //    //ClassDrive cd = new Design.ClassDrive(); 
        //    //this.entityfactory = cd.Instance<IEntityFactory>(typeof(EntityFactory),Dbh);
        //    this.entityfactory = new EntityFactory(Dbh);
        //}


        #region ILogger 成员
        /// <summary>
        /// 保存消息
        /// </summary>
        /// <param name="Message"></param>
        public void Info(object Message)
        {
            SaveLog(Message, LogType.info);
        }

        public void Debug(object Message)
        {
            SaveLog(Message, LogType.debug);
        }

        public void Debug(object Message, Exception Exp)
        {
            
            if (Exp.StackTrace != null)
            {
                SaveLog(Message.ToString() + Environment.NewLine + Exp.StackTrace, LogType.debug);
            }
            else
            {
                SaveLog(Message.ToString() + Environment.NewLine + Exp.Message, LogType.debug);
            }
        }

        public void Error(Exception Exp)
        {
            if (Exp.StackTrace != null)
            {
                SaveLog(Exp.Message.ToString() + Environment.NewLine + Exp.StackTrace, LogType.error);
            }
            else
            {
                SaveLog(Exp.Message, LogType.error);
            }

        }

        public void Error(object Message, Exception Exp)
        {
            if (Exp.StackTrace != null)
            {
                SaveLog(Message.ToString() + Environment.NewLine + Exp.StackTrace, LogType.error);
            }
            else
            {
                SaveLog(Message.ToString() + Environment.NewLine + Exp.Message, LogType.error);
            }
           
        }

        #endregion

        /// <summary>
        /// 保存日志对象实例
        /// </summary>
        protected virtual void SaveLog(object Message,LogType Type)
        { 
            DataHelper dh = new DataHelper();
            ILog log =this.entityfactory.CreateEntityInstance<ILog>();  
            log.LOGCODE = (dh.GetMaxField(log, "LOGCODE", this.entityfactory) + 1);
            log.LOGTIME = DateTime.Now;
            log.CONTENT = Message.ToString();
            log.LOGTYPE = Type.ToString();
            IDvTable dvt = entityfactory.CreateDriveTable(log);
            int i = dvt.Insert(); 
        }

         
        public LogType ReadinLogLevel
        {
            get;
            set;
        }
 
    }
}
