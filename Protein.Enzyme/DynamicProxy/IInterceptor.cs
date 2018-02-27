using System;
namespace Protein.Enzyme.DynamicProxy
{
    

    public interface IInterceptor
    {
        object Intercept(IInvocation invocation, params object[] args);
    }
}

