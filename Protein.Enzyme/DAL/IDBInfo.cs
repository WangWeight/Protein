using System;
using System.Collections.Generic;
using System.Text;

namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// ���ݿ����Ϣ�ӿ�
    /// </summary>
    public interface IDBInfo
    {
        /// <summary>
        /// ��ȡ�����ַ���
        /// </summary>
        /// <returns></returns>
        string GetConnectString();
    }
}
