using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.Message.Processors;
using Protein.Enzyme.Layout.Mechanisms;
using System.Linq;

namespace Protein.Enzyme.Message
{
    /// <summary>
    /// 消息总线
    /// </summary>
    internal class MessageBus :  IMessageBus
    {
        private static IMessageBus msgbus = null;

        /// <summary>
        /// 消息总线
        /// </summary>
        private MessageBus()
        { 
        }
         
        /// <summary>
        /// 获取消息总线实例
        /// </summary>
        /// <returns></returns>
        public static IMessageBus GetInstance()
        {
            if (msgbus == null)
            {
                msgbus = new MessageBus();
                SetMessageBus();
            }
            return msgbus;

        }

        /// <summary>
        /// 初始化消息处理机构 添加支撑类库内置的日志系统消息处理器
        /// </summary>
        protected static void SetMessageBus()
        {
            //IMessageBus msgbus = MessageFactory.GetMegBus();
            // 异常处理  调试处理
            IProcessor error = new ProcessExceptionLog(MachineLog.GetLogger());
            msgbus.AddProcessor(error);
            //调试处理
            IProcessor dbug = new ProcessDebugLog(MachineLog.GetLogger());
            msgbus.AddProcessor(dbug);
            ////Pt调试处理
            //IProcessor ptdbug = new ProcessPtDebug(MachineLog.GetLogger());
            //msgbus.AddProcessor(ptdbug);
            ////警告提示处理
            //IProcessor remind = new ProcessWarning();
            //msgbus.AddProcessor(remind);
            //系统内部消息处理
            IProcessor sysinfo = new ProcessSysInfo(MachineLog.GetLogger());
            msgbus.AddProcessor(sysinfo);
            //历史记录
            IProcessor history =   MessageHistoryContainer.GetInstance();
            msgbus.AddProcessor(history);
            ////普通提示消息处理
            //IProcessor noteinfo = new ProcessNote();
            //msgbus.AddProcessor(noteinfo);
        }
        private List<IProcessor> pcslist = new List<IProcessor>();
        /// <summary>
        /// 消息处理器列表
        /// </summary>
        public List<IProcessor> Pcslist
        {
            get { 
                    return this.pcslist; 
            }
            set { 
                    this.pcslist = value; 
            }
        }

        /// <summary>
        /// 发送消息 
        /// 这里需要将消息和日志的级别处理区分开
        /// 日志记录级别来源于消息
        /// 消息提示可以通过内置界面和可扩展的自定义界面来显示，显示也区分级别，目前消息提示是框架中的功能
        /// </summary>
        public virtual void Send(MessageObject Msg)
        { 
            if (Msg.Type > Protein.Enzyme.Layout.Configuration.ProteinConfig.GetInstance().MsgConfig.MessageLevel)
            {
                return;
            }
            if (this.Pcslist.Count == 0)
            {
                IProcessor pcs = new Processors.ProcessInnerExceptionLog(MachineLog.GetLogger());
                pcs.ProcessMessage(Msg);
            }
            ///
            int count = this.Pcslist.Count;
            for (int i = 0; i < count; i++)
            {
                if (i < this.Pcslist.Count)
                {
                    if (this.Pcslist[i] != null)
                    {
                        this.Pcslist[i].ProcessMessage(Msg);
                    }
                }
            }
            //foreach (IProcessor pcs in this.Pcslist)
            //{
            //    if (pcs != null)
            //    {
            //        pcs.ProcessMessage(Msg);
            //    }
            //}
             
        }

        
        /// <summary>
        /// 添加消息处理器
        /// </summary>
        /// <param name="Processor"></param>
        public virtual void AddProcessor(IProcessor Processor)
        {
            this.pcslist.Add(Processor);
        }

        /// <summary>
        /// 移除消息处理器
        /// </summary>
        /// <param name="Processor"></param>
        public virtual void RemoveProcessor(IProcessor Processor)
        {
            this.pcslist.Remove(Processor);

        }

        /// <summary>
        /// 判断在消息总线的处理器集合中是否存在指定类型的处理器
        /// </summary>
        /// <param name="ProcessorType"></param>
        /// <returns></returns>
        public bool Contains(Type ProcessorType)
        {
            bool isContains = false;
            foreach (IProcessor p in this.pcslist)
            {
                if (ProcessorType == p.GetType())
                {
                    isContains = true;
                }
            }
            return isContains;
        }


        /// <summary>
        /// 移除消息处理器根据类型
        /// </summary>
        /// <param name="ProcessorType"></param>
        public void RemoveProcessorByType(Type ProcessorType)
        {
            IProcessor removeobj = null;
            foreach (IProcessor p in this.pcslist)
            {
                if (ProcessorType == p.GetType())
                {
                    removeobj = p;
                }
            }
            this.RemoveProcessor(removeobj);
        }

    }


   

}
