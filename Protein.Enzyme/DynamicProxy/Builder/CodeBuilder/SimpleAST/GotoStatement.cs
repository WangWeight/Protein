using Protein.Enzyme.DynamicProxy;
using System;
using System.Reflection.Emit;
namespace Protein.Enzyme.DynamicProxy
{
   

    [CLSCompliant(false)]
    public class GotoStatement : Statement
    {
        private LabelReference _label;

        public GotoStatement(LabelReference label)
        {
            this._label = label;
        }

        public override void Emit(IEasyMember member, ILGenerator gen)
        {
            gen.Emit(OpCodes.Br_S, this._label.Reference);
        }
    }
}

