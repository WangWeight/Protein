using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.DynamicProxy;
using System.Diagnostics;
using Protein.Enzyme.Repository;
using Protein.Enzyme.Log;

namespace Protein.Enzyme.Design
{
    /// <summary>
    /// 拦截方法句柄
    /// </summary>
    /// <param name="invocation"></param>
    public delegate void InvokeHandler(IInvocation invocation);

    /// <summary>
    /// 代理拦截器
    /// </summary>
    public class ProxyInterceptor : IInterceptor
    { 
        /// <summary>
        /// 拦截方法运行前事件
        /// </summary>
        public event InvokeHandler InvokeBefore;
        /// <summary>
        /// 拦截方法运行后事件
        /// </summary>
        public event InvokeHandler InvokeAfter;
        /// <summary>
        /// 拦截方法异常处理事件
        /// </summary>
        public event ExceptionHandler InvokeException;


        #region IInterceptor 成员
        /// <summary>
        /// 重写拦截器方法
        /// </summary>
        /// <param name="invocation"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public object Intercept(IInvocation invocation, params object[] args)
        { 
            try 
            {
                BeforeInvoke(invocation);
                object ret = invocation.Proceed(args);
                AfterInvoke(invocation);
                return ret;
            }
            catch (Exception e)
            {
                //this.InvokeException(e); 
                //return null; 
                try 
                {
                    this.InvokeException(e); 
                }
                catch (Exception se)
                {
                    WelcomeToHell(se);
                    return null;
                }
                return null;
            }
        }

        /// <summary>
        ///  无法处理的异常在程序集所在目录生成Log文件
        /// </summary>
        /// <param name="se"></param>
        protected virtual void WelcomeToHell(Exception se)
        { 
            string erContent = Environment.NewLine + "[无法处理的异常] -" + DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss")
                + Environment.NewLine + "-" + se.Message
                + Environment.NewLine + "-" + se.Source
                + Environment.NewLine + "-" + se.TargetSite
                + Environment.NewLine + "-" + se.StackTrace;
            LoggerManager lg = new LoggerManager();
            lg.recordHellLog(erContent);
            System.Windows.Forms.MessageBox.Show("发生无法正确处理的异常，程序将自动关闭，请查看灾难日志记录。"+Environment.NewLine+"-"+se.Message, "严重异常");
            System.Windows.Forms.Application.Exit();
        }   
        #endregion

        /// <summary>
        /// 截断方法的代理前置方法
        /// </summary>
        /// <param name="Invocation"></param>
        protected virtual void BeforeInvoke(IInvocation Invocation)
        {
            if (this.InvokeBefore != null)
            {
                this.InvokeBefore(Invocation);
            }
            //Type tclass = invocation.Method.DeclaringType;
            //string str = this.invokeMode;
            //str = str.Replace("{CLASS}", tclass.Name);
            //str = str.Replace("{METHOD}", invocation.Method.Name);
            //str = str.Replace("{TIME}", "Before");
            //MessageFactory.GetMegBus().Send(MessageFactory.CreateMessageDebug(str));  
        }


        /// <summary>
        /// 截断方法的代理后置方法
        /// </summary>
        /// <param name="Invocation"></param>
        protected virtual void AfterInvoke(IInvocation Invocation)
        {
            if (this.InvokeAfter != null)
            {
                this.InvokeAfter(Invocation);
            }
            //Type tclass = invocation.Method.DeclaringType;
            //string str = this.invokeMode;
            //str = str.Replace("{CLASS}", tclass.Name);
            //str = str.Replace("{METHOD}", invocation.Method.Name);
            //str = str.Replace("{TIME}", "After");
            //MessageFactory.GetMegBus().Send(MessageFactory.CreateMessageDebug(str)); 
        }

 

    }
}
