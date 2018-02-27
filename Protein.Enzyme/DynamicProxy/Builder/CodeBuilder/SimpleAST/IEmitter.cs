using Protein.Enzyme.DynamicProxy;
using System;
using System.Reflection.Emit;
namespace Protein.Enzyme.DynamicProxy
{
   

    public interface IEmitter
    {
        void Emit(IEasyMember member, ILGenerator gen);
    }
}

