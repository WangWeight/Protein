using Protein.Enzyme.DynamicProxy; 
using System;
using System.Reflection.Emit;
namespace Protein.Enzyme.DynamicProxy
{
     
    /// <summary>
    /// 
    /// </summary>
    [CLSCompliant(false)]
    public class ReferenceExpression : Expression
    {
        private Reference _reference;

        public ReferenceExpression(Reference reference)
        {
            this._reference = reference;
        }

        public override void Emit(IEasyMember member, ILGenerator gen)
        {
            ArgumentsUtil.EmitLoadOwnerAndReference(this._reference, gen);
        }
    }
}

