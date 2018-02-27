using Protein.Enzyme.DynamicProxy;
using System;
using System.Reflection.Emit;
namespace Protein.Enzyme.DynamicProxy
{
  
    /// <summary>
    /// 
    /// </summary>
    [CLSCompliant(false)]
    public class NopStatement : Statement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <param name="gen"></param>
        public override void Emit(IEasyMember member, ILGenerator gen)
        {
            gen.Emit(OpCodes.Nop);
        }
    }
}

