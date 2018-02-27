using System;

namespace Protein.Enzyme.DynamicProxy
{
    
    /// <summary>
    /// 
    /// </summary>
    [CLSCompliant(true)]
    public interface ICallable
    {
        object Call(params object[] args);

        object Target { get; }
    }
}

