using System;
using System.Collections.Generic;
using System.Text;

namespace Protein.Enzyme.Message
{
    /// <summary>
    /// ��Ϣ�������ί��
    /// </summary>
    /// <param name="Content"></param>
    public delegate void ProteinMessageProcessor(MessageObject Content);

    /// <summary>
    /// ��Ϣ������
    /// </summary>
    public interface IProcessor
    { 
        /// <summary>
        ///  ������Ϣ
        /// </summary>
        /// <param name="Content"></param>
        void ProcessMessage(MessageObject Content);
    }
}
