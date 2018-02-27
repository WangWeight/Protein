using Protein.Enzyme.DynamicProxy; 
using System;
using System.Reflection.Emit;

namespace Protein.Enzyme.DynamicProxy
{
   

    [CLSCompliant(false)]
    public class AssignStatement : Statement
    {
        private Expression _expression;
        private Reference _target;

        public AssignStatement(Reference target, Expression expression)
        {
            this._target = target;
            this._expression = expression;
        }

        public override void Emit(IEasyMember member, ILGenerator gen)
        {
            ArgumentsUtil.EmitLoadOwnerAndReference(this._target.OwnerReference, gen);
            this._expression.Emit(member, gen);
            this._target.StoreReference(gen);
        }
    }
}

