using System;
using System.Collections.Generic;
using System.Text;

namespace Protein.Enzyme.Message
{
    /// <summary>
    /// ��Ϣ����
    /// </summary>
    public class MessageObject
    {
        /// <summary>
        /// ��Ϣ����
        /// </summary>
        /// <param name="MsgType"></param>
        public MessageObject(MessageType MsgType)
        {
            this.type = MsgType;
            this.message = "";
        }
        private MessageType type;
        /// <summary>
        /// 
        /// </summary>
        public MessageType Type
        {
            get { return type; }
            set { type = value; }
        }

        private object message;
        /// <summary>
        /// 
        /// </summary>
        public object Message
        {
            get { return message; }
            set { message = value; }
        }
    }
}
