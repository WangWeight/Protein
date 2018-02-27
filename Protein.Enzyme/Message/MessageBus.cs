using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.Message.Processors;
using Protein.Enzyme.Layout.Mechanisms;
using System.Linq;

namespace Protein.Enzyme.Message
{
    /// <summary>
    /// ��Ϣ����
    /// </summary>
    internal class MessageBus :  IMessageBus
    {
        private static IMessageBus msgbus = null;

        /// <summary>
        /// ��Ϣ����
        /// </summary>
        private MessageBus()
        { 
        }
         
        /// <summary>
        /// ��ȡ��Ϣ����ʵ��
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
        /// ��ʼ����Ϣ������� ���֧��������õ���־ϵͳ��Ϣ������
        /// </summary>
        protected static void SetMessageBus()
        {
            //IMessageBus msgbus = MessageFactory.GetMegBus();
            // �쳣����  ���Դ���
            IProcessor error = new ProcessExceptionLog(MachineLog.GetLogger());
            msgbus.AddProcessor(error);
            //���Դ���
            IProcessor dbug = new ProcessDebugLog(MachineLog.GetLogger());
            msgbus.AddProcessor(dbug);
            ////Pt���Դ���
            //IProcessor ptdbug = new ProcessPtDebug(MachineLog.GetLogger());
            //msgbus.AddProcessor(ptdbug);
            ////������ʾ����
            //IProcessor remind = new ProcessWarning();
            //msgbus.AddProcessor(remind);
            //ϵͳ�ڲ���Ϣ����
            IProcessor sysinfo = new ProcessSysInfo(MachineLog.GetLogger());
            msgbus.AddProcessor(sysinfo);
            //��ʷ��¼
            IProcessor history =   MessageHistoryContainer.GetInstance();
            msgbus.AddProcessor(history);
            ////��ͨ��ʾ��Ϣ����
            //IProcessor noteinfo = new ProcessNote();
            //msgbus.AddProcessor(noteinfo);
        }
        private List<IProcessor> pcslist = new List<IProcessor>();
        /// <summary>
        /// ��Ϣ�������б�
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
        /// ������Ϣ 
        /// ������Ҫ����Ϣ����־�ļ��������ֿ�
        /// ��־��¼������Դ����Ϣ
        /// ��Ϣ��ʾ����ͨ�����ý���Ϳ���չ���Զ����������ʾ����ʾҲ���ּ���Ŀǰ��Ϣ��ʾ�ǿ���еĹ���
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
        /// �����Ϣ������
        /// </summary>
        /// <param name="Processor"></param>
        public virtual void AddProcessor(IProcessor Processor)
        {
            this.pcslist.Add(Processor);
        }

        /// <summary>
        /// �Ƴ���Ϣ������
        /// </summary>
        /// <param name="Processor"></param>
        public virtual void RemoveProcessor(IProcessor Processor)
        {
            this.pcslist.Remove(Processor);

        }

        /// <summary>
        /// �ж�����Ϣ���ߵĴ������������Ƿ����ָ�����͵Ĵ�����
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
        /// �Ƴ���Ϣ��������������
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
