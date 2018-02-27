using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.Message.Processors;
using Protein.Enzyme.Layout.Mechanisms;
namespace Protein.Enzyme.Message
{
    /// <summary>
    /// ��Ϣ��������
    /// </summary>
    public sealed class MessageFactory
    {
        /// <summary>
        /// ��ȡ��Ϣ���߶���
        /// </summary>
        /// <returns></returns>
        public static IMessageBus GetMegBus()
        {
            return MessageBus.GetInstance();
        }
        /// <summary>
        /// ��Ϣ��ʷ
        /// </summary>
        /// <returns></returns>
        public static IMessageHistoryContainer History()
        {
            return MessageHistoryContainer.GetInstance();
        } 
        /// <summary>
        /// �����쳣����Ϣ
        /// </summary>
        /// <param name="Ex"></param>
        /// <returns></returns>
        public static MessageObject CreateMessage(Exception Ex)
        {
            MessageObject msg = new MessageObject(MessageType.Error);
            msg.Message = Ex;
            return msg;
        }
        /// <summary>
        /// ������Ϣ����Ϣ
        /// </summary>
        /// <param name="MsgString"></param>
        /// <returns></returns>
        public static MessageObject CreateMessage(string MsgString)
        {
            MessageObject msg = new MessageObject(MessageType.Warning);
            msg.Message = MsgString;
            return msg;
        } 
        /// <summary>
        /// ������������Ϣ
        /// </summary>
        /// <param name="Debug"></param>
        /// <returns></returns>
        public static MessageObject CreateMessageDebug(string Debug)
        {
            MessageObject msg = new MessageObject(MessageType.Debug);
            msg.Message = Debug;
            return msg;
        } 
        /// <summary>
        /// ������������Ϣ
        /// </summary>
        /// <param name="Debug"></param>
        /// <returns></returns>
        public static MessageObject CreateMessagePtDebug(string Debug)
        {
            MessageObject msg = new MessageObject(MessageType.PtDebug);
            msg.Message = Debug;
            return msg;
        }
    }
}
