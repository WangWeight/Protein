using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.Message;
using Protein.Enzyme.Message.Processors;
using Protein.Enzyme.Design;
using Protein.Enzyme.Layout.Mechanisms;
using Protein.Enzyme.DynamicProxy;
namespace Protein.Enzyme.Layout.ProxyAdapter
{
    /// <summary>
    /// 代理的默认初始化机制
    /// 1、	异常处理机制不变，默认通过消息总线来处理，但是可以通过配置文件扩展处理的事件
    /// </summary>
    internal class ProxyDefaul
    {
        /// <summary>
        /// 设置代理拦截器
        /// </summary>
        /// <param name="ProxyInter"></param>
        public virtual void SetProxy(ProxyInterceptor ProxyInter)
        { 
            ProxyInter.InvokeException += new ExceptionHandler(ExceptionProxy);
            ProxyInter.InvokeAfter+=new InvokeHandler(ProxyInter_InvokeAfter);
        }
        /// <summary>
        /// 异常代理
        /// </summary>
        /// <param name="Ex"></param>
        protected virtual void ExceptionProxy(Exception Ex)
        {
            MessageFactory.GetMegBus().Send(MessageFactory.CreateMessage(Ex)); 
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Invocation"></param>
        protected virtual void ProxyInter_InvokeAfter(IInvocation Invocation)
        {
            Type tclass = Invocation.Method.DeclaringType; 
            string str = "Intercept {TIME}  Class:{CLASS}  Method:{METHOD} ";
            str = str.Replace("{CLASS}", tclass.Name);
            str = str.Replace("{METHOD}", Invocation.Method.Name);
            str = str.Replace("{TIME}", "Before");
            //MessageFactory.GetMegBus().Send(MessageFactory.CreateMessageDebug(str));
            MessageFactory.GetMegBus().Send(MessageFactory.CreateMessagePtDebug(str)); 
        }
        ///// <summary>
        ///// 初始化消息处理机构
        ///// </summary>
        //protected virtual void SetMessageBus()
        //{
        //    IMessageBus msgbus = MessageFactory.GetMegBus();
        //    // 异常处理  调试处理
        //    IProcessor error = new ProcessException(MachineLog.GetLogger());
        //    msgbus.AddProcessor(error);
        //    //调试处理
        //    IProcessor dbug = new ProcessDebug(MachineLog.GetLogger());
        //    msgbus.AddProcessor(dbug);
        //    //Pt调试处理
        //    IProcessor ptdbug = new ProcessPtDebug(MachineLog.GetLogger());
        //    msgbus.AddProcessor(ptdbug);
        //    //警告提示处理
        //    IProcessor remind = new ProcessWarning();
        //    msgbus.AddProcessor(remind);
        //    //系统内部消息处理
        //    IProcessor sysinfo = new ProcessSysInfo(MachineLog.GetLogger());
        //    msgbus.AddProcessor(sysinfo);
        //    //普通提示消息处理
        //    IProcessor noteinfo = new ProcessNote();
        //    msgbus.AddProcessor(noteinfo); 
        //}
    }
}
