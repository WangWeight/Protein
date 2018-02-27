using System;
using System.Reflection.Emit;
namespace Protein.Enzyme.DynamicProxy
{
   

    [CLSCompliant(false)]
    public class FieldReference : Protein.Enzyme.DynamicProxy.Reference
    {
        private FieldBuilder _fieldbuilder;

        public FieldReference(FieldBuilder fieldbuilder)
        {
            this._fieldbuilder = fieldbuilder;
        }

        public override void LoadAddressOfReference(ILGenerator gen)
        {
            throw new NotSupportedException();
        }

        public override void LoadReference(ILGenerator gen)
        {
            gen.Emit(OpCodes.Ldfld, this.Reference);
        }

        public override void StoreReference(ILGenerator gen)
        {
            gen.Emit(OpCodes.Stfld, this.Reference);
        }

        public FieldBuilder Reference
        {
            get
            {
                return this._fieldbuilder;
            }
        }
    }
}

