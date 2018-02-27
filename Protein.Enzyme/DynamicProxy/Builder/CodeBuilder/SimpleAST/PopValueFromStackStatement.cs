using Protein.Enzyme.DynamicProxy;
using System;
using System.Reflection.Emit;
namespace Protein.Enzyme.DynamicProxy
{
   

    [CLSCompliant(false)]
    public class PopValueFromStackStatement : Statement
    {
        public override void Emit(IEasyMember member, ILGenerator gen)
        {
            gen.Emit(OpCodes.Pop);
        }
    }
}

