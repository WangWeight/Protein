using Protein.Enzyme.DynamicProxy;
using System;
using System.Reflection;
namespace Protein.Enzyme.DynamicProxy
{
    
    /// <summary>
    /// 
    /// </summary>
    [CLSCompliant(true)]
    public class InterfaceInvocation : AbstractInvocation
    {
        public InterfaceInvocation(ICallable callable, object proxy, MethodInfo method, object newtarget) : base(callable, proxy, method, newtarget)
        {
        }
    }
}

