using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Protein.Enzyme.Message 
{
    /// <summary>
    /// ��Ϣ����
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// ֧��ƽ̨������Ϣ�����ڷḻ��Ϣ���
        /// </summary>
        [Description("PtDebug")]
        PtDebug = 5,
        /// <summary>
        /// ������Ϣ,���Գ����ź���
        /// </summary>
        [Description("Debug")]
        Debug = 4,
        /// <summary>
        /// ϵͳ�ڲ���Ϣ
        /// </summary>
        [Description("InsideInfo")]
        InsideInfo = 3,
        /// <summary>
        /// ��ʾ ��ͨ��ʾ��Ϣ
        /// </summary>
        [Description("Note")]
        Note = 2,
        /// <summary>
        /// ������Ϣ
        /// </summary>
        [Description("Warning")]
        Warning = 1,
        /// <summary>
        /// �쳣
        /// </summary>
        [Description("Error")]
        Error = 0,  
        
    }
}
