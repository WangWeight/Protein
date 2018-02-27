using System;
using System.Runtime.Serialization;

namespace Protein.Enzyme.DynamicProxy
{
   
    /// <summary>
    /// 
    /// </summary>
    [Serializable, CLSCompliant(false)]
    public class ProxyGenerationException : Exception
    {
        public ProxyGenerationException(string message) : base(message)
        {
        }

        public ProxyGenerationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

