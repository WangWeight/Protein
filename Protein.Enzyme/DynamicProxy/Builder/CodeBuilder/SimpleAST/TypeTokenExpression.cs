using Protein.Enzyme.DynamicProxy;
using System;
using System.Reflection.Emit;
namespace Protein.Enzyme.DynamicProxy
{
   

    [CLSCompliant(false)]
    public class TypeTokenExpression : Expression
    {
        private Type _type;

        public TypeTokenExpression(Type type)
        {
            this._type = type;
        }

        public override void Emit(IEasyMember member, ILGenerator gen)
        {
            gen.Emit(OpCodes.Ldtoken, this._type);
            gen.Emit(OpCodes.Call, typeof(Type).GetMethod("GetTypeFromHandle"));
        }
    }
}

