using System;
using System.Collections.Generic;
using System.Text;

namespace Protein.Enzyme.Message
{
    /// <summary>
    /// 消息处理过程委托
    /// </summary>
    /// <param name="Content"></param>
    public delegate void ProteinMessageProcessor(MessageObject Content);

    /// <summary>
    /// 消息处理器
    /// </summary>
    public interface IProcessor
    { 
        /// <summary>
        ///  处理消息
        /// </summary>
        /// <param name="Content"></param>
        void ProcessMessage(MessageObject Content);
    }
}
