using System;
using System.Reflection;
namespace Protein.Enzyme.DynamicProxy
{
 

    public interface IEasyMember
    {
        void EnsureValidCodeBlock();
        void Generate();

        MethodBase Member { get; }

        Type ReturnType { get; }
    }
}

