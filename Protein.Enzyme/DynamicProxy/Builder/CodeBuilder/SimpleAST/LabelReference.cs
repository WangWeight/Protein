using System;
using System.Reflection.Emit;

namespace Protein.Enzyme.DynamicProxy
{
   
    [CLSCompliant(false)]
    public class LabelReference : Protein.Enzyme.DynamicProxy.Reference
    {
        private Label _label;

        public override void Generate(ILGenerator gen)
        {
            this._label = gen.DefineLabel();
        }

        public override void LoadAddressOfReference(ILGenerator gen)
        {
            throw new NotSupportedException();
        }

        public override void LoadReference(ILGenerator gen)
        {
            gen.MarkLabel(this._label);
        }

        public override void StoreReference(ILGenerator gen)
        {
            throw new NotImplementedException();
        }

        public override Expression ToExpression()
        {
            throw new NotImplementedException();
        }

        public Label Reference
        {
            get
            {
                return this._label;
            }
        }
    }
}

