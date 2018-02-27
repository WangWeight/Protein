using Protein.Enzyme.DynamicProxy;
using System;
using System.Reflection.Emit;

namespace Protein.Enzyme.DynamicProxy
{
   
    [CLSCompliant(false)]
    public class NullExpression : Expression
    {
        public static readonly NullExpression Instance = new NullExpression();

        protected NullExpression()
        {
        }

        public override void Emit(IEasyMember member, ILGenerator gen)
        {
            gen.Emit(OpCodes.Ldnull);
        }
    }
}

