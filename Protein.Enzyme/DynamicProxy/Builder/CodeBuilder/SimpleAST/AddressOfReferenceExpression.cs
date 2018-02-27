using Protein.Enzyme.DynamicProxy; 
using System;
using System.Reflection.Emit;

namespace Protein.Enzyme.DynamicProxy
{
    

    [CLSCompliant(false)]
    public class AddressOfReferenceExpression : Expression
    {
        private Reference _reference;

        public AddressOfReferenceExpression(Reference reference)
        {
            this._reference = reference;
        }

        public override void Emit(IEasyMember member, ILGenerator gen)
        {
            ArgumentsUtil.EmitLoadOwnerAndReference(this._reference.OwnerReference, gen);
            this._reference.LoadAddressOfReference(gen);
        }
    }
}

