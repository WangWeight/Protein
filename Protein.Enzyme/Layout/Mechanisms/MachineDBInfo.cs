using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.DAL;
using Protein.Enzyme.Layout.Configuration;
using System.Security.Cryptography;
using Protein.Enzyme.Repository;

namespace Protein.Enzyme.Layout.Mechanisms
{
    /// <summary>
    /// 数据库信息
    /// 目前包含不属于该实体的类型信息
    /// 这里的职责不单一
    /// 先这么写吧偷个懒
    /// </summary>
    public class MachineDBInfo:IDBInfo
    {
 

        #region IDBInfo 成员

        public string GetConnectString()
        {
            ProteinConfig pconfig = ProteinConfig.GetInstance();
            if (!pconfig.DataBaseConfig.Secrecy)
            {
                //OutputDecryptString(pconfig.DataBaseConfig.ConnectionStr);
                return pconfig.DataBaseConfig.ConnectionStr;
            }
            else
            {
                return pconfig.DataBaseConfig.ConnectionStr.CipherDecryptDES();
            }
        } 


        #endregion

        /// <summary>
        ///  自动数据加密连接字符串,该功能暂时屏蔽
        /// </summary>
        /// <param name="EncryptString"></param>
        protected virtual void OutputDecryptString(string EncryptString)
        { 
            string filename = this.GetType().Assembly.GetAssemblyPath();
            if (filename == null)
            {
                filename = "c:\\";
            }
            filename = filename + "\\ProteinEncrypt.txt";
            string erContent = EncryptString.CipherEncryptDES();
            TxtHelper.Write(filename, erContent);
        }   

    }



}
