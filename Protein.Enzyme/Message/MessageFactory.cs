using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.Message.Processors;
using Protein.Enzyme.Layout.Mechanisms;
namespace Protein.Enzyme.Message
{
    /// <summary>
    /// 消息创建工厂
    /// </summary>
    public sealed class MessageFactory
    {
        /// <summary>
        /// 获取消息总线对象
        /// </summary>
        /// <returns></returns>
        public static IMessageBus GetMegBus()
        {
            return MessageBus.GetInstance();
        }
        /// <summary>
        /// 消息历史
        /// </summary>
        /// <returns></returns>
        public static IMessageHistoryContainer History()
        {
            return MessageHistoryContainer.GetInstance();
        } 
        /// <summary>
        /// 创建异常类消息
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
        /// 创建信息类消息
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
        /// 创建调试类消息
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
        /// 创建调试类消息
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
