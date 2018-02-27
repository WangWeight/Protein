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
    /// ���ط������
    /// </summary>
    /// <param name="invocation"></param>
    public delegate void InvokeHandler(IInvocation invocation);

    /// <summary>
    /// ����������
    /// </summary>
    public class ProxyInterceptor : IInterceptor
    { 
        /// <summary>
        /// ���ط�������ǰ�¼�
        /// </summary>
        public event InvokeHandler InvokeBefore;
        /// <summary>
        /// ���ط������к��¼�
        /// </summary>
        public event InvokeHandler InvokeAfter;
        /// <summary>
        /// ���ط����쳣�����¼�
        /// </summary>
        public event ExceptionHandler InvokeException;


        #region IInterceptor ��Ա
        /// <summary>
        /// ��д����������
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
        ///  �޷�������쳣�ڳ�������Ŀ¼����Log�ļ�
        /// </summary>
        /// <param name="se"></param>
        protected virtual void WelcomeToHell(Exception se)
        { 
            string erContent = Environment.NewLine + "[�޷�������쳣] -" + DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss")
                + Environment.NewLine + "-" + se.Message
                + Environment.NewLine + "-" + se.Source
                + Environment.NewLine + "-" + se.TargetSite
                + Environment.NewLine + "-" + se.StackTrace;
            LoggerManager lg = new LoggerManager();
            lg.recordHellLog(erContent);
            System.Windows.Forms.MessageBox.Show("�����޷���ȷ������쳣�������Զ��رգ���鿴������־��¼��"+Environment.NewLine+"-"+se.Message, "�����쳣");
            System.Windows.Forms.Application.Exit();
        }   
        #endregion

        /// <summary>
        /// �ضϷ����Ĵ���ǰ�÷���
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
        /// �ضϷ����Ĵ�����÷���
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
