// File:    SDPT_LOG.cs
// Author:  Administrator
// Created: 2011��12��23�� 16:29:48
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
        /// ��־���
        private long _LOGCODE;
        /// <summary>
        /// ��־���
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
         
        /// ����
        private string _CONTENT;
        /// <summary>
        /// ����
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
        /// ʱ��
        private DateTime _LOGTIME;
        /// <summary>
        /// ʱ��
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
        /// ��־����
        private string _LOGTYPE;
        /// <summary>
        /// ��־����
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