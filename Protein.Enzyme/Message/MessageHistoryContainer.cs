using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protein.Enzyme.Message
{
    /// <summary>
    /// 消息存储
    /// </summary>
    internal class MessageHistoryContainer:IProcessor, Protein.Enzyme.Message.IMessageHistoryContainer
    {
        //在这里存储 分类存储 便于读取 在总线中加入读取接口 
        private static MessageHistoryContainer inits = null;
        /// <summary>
        /// 历史列表
        /// </summary>
        private List<MessageHistory> historyList { get; set; }
        /// <summary>
        /// 消息总线配置
        /// </summary>
        private Protein.Enzyme.Layout.Configuration.Msg msgconfig { get; set; }
        /// <summary>
        /// 当前历史记录数量
        /// </summary>
        public int HistoryCount {
            get {
                return this.historyList.Count;
            }
        }
        /// <summary>
        /// 消息存储
        /// </summary>
        private MessageHistoryContainer()
        {  
            this.historyList = new List<MessageHistory>(); 
            this.msgconfig = Protein.Enzyme.Layout.Configuration.ProteinConfig.GetInstance().MsgConfig; 
        }

        /// <summary>
        /// 获取消息历史容器实例
        /// </summary>
        /// <returns></returns>
        public static MessageHistoryContainer GetInstance()
        {
            if (inits == null)
            {
                inits = new MessageHistoryContainer(); 
            }
            return inits; 
        }
         
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Content"></param>
        public void ProcessMessage(MessageObject Content)
        {
            if (this.msgconfig.UseHistory && this.msgconfig.HistoryMaxCount>0)
            {
                this.RecordMessage(Content);
            }
        }
        /// <summary>
        /// 记录消息
        /// </summary>
        protected virtual void RecordMessage(MessageObject Content)
        {
            //如果超出了最大值则先删除第一个
            if (this.historyList.Count + 1>this.msgconfig.HistoryMaxCount)
            {
                this.historyList.RemoveAt(0);
            }
            MessageHistory msgh = new MessageHistory();
            msgh.MsgObject = Content;
            msgh.RecordTime = DateTime.Now;
            this.historyList.Add(msgh); 
        }
        /// <summary>
        /// 清空所有历史和记录
        /// </summary>
        public virtual void ClearHistory()
        {
            this.historyList.Clear();
        }
        /// <summary>
        /// 获取历史消息
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public MessageHistory this[int Index]
        { 
            get{
                if (this.historyList.Count > Index)
                {
                    return this.historyList[Index];
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 根据消息类型查找历史消息
        /// </summary>
        /// <param name="MsgType"></param>
        /// <returns></returns>
        public List<MessageHistory> FindHistory(MessageType MsgType)
        {
            var result = this.historyList.FindAll(delegate(MessageHistory mh) { return mh.MsgObject.Type == MsgType; });
            if (result != null)
            {
                return  result;
            }
            else
            {
                return null;
            }
        }


    }
}
