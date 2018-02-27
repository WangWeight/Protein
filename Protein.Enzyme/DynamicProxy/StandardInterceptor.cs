using System;
namespace Protein.Enzyme.DynamicProxy
{ 
    /// <summary>
    /// 
    /// </summary>
    [Serializable, CLSCompliant(true)]
    public class StandardInterceptor : IInterceptor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="invocation"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public virtual object Intercept(IInvocation invocation, params object[] args)
        {
            this.PreProceed(invocation, args);
            object returnValue = invocation.Proceed(args);
            this.PostProceed(invocation, ref returnValue, args);
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="invocation"></param>
        /// <param name="returnValue"></param>
        /// <param name="args"></param>
        protected virtual void PostProceed(IInvocation invocation, ref object returnValue, params object[] args)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="invocation"></param>
        /// <param name="args"></param>
        protected virtual void PreProceed(IInvocation invocation, params object[] args)
        {
        }
    }
}

