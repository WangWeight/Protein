using System;
namespace Protein.Enzyme.Message
{
    /// <summary>
    /// 消息总线历史接口
    /// </summary>
    public interface IMessageHistoryContainer
    {
        void ClearHistory();
        System.Collections.Generic.List<MessageHistory> FindHistory(MessageType MsgType);
        int HistoryCount { get; }
        MessageHistory this[int Index] { get; }
    }
}
