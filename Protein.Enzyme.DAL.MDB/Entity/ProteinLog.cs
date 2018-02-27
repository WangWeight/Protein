// File:    SDPT_LOG.cs
// Author:  Administrator
// Created: 2011年12月23日 16:29:48
// Purpose: Definition of Class SDPT_LOG

using System; 
using System.Reflection; 
using Protein.Enzyme.DAL;
namespace Protein.Enzyme.DAL.MDB.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class ProteinLog : EntityBase, Protein.Enzyme.Log.ILog
    {
        /// 日志编号
        private long _LOGCODE;
        /// <summary>
        /// 日志编号
        /// </summary>
        public long LOGCODE
        {
            get
            {
                return _LOGCODE;
            }
            set
            {
                _LOGCODE = value;
            }
        }
         
        /// 内容
        private string _CONTENT;
        /// <summary>
        /// 内容
        /// </summary>
        public string CONTENT
        {
            get
            {
                return _CONTENT;
            }
            set
            {
                _CONTENT = value;
            }
        }
        /// 时间
        private DateTime _LOGTIME;
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime LOGTIME
        {
            get
            {
                return _LOGTIME;
            }
            set
            {
                _LOGTIME = value;
            }
        }
        /// 日志类型
        private string _LOGTYPE;
        /// <summary>
        /// 日志类型
        /// </summary>
        public string LOGTYPE
        {
            get
            {
                return _LOGTYPE;
            }
            set
            {
                _LOGTYPE = value;
            }
        }
        public override System.Reflection.PropertyInfo PrimaryKey()
        {
            return this.GetType().GetProperty("LOGCODE", BindingFlags.Public
                    | BindingFlags.Instance | BindingFlags.IgnoreCase);
        }

 
    }
}