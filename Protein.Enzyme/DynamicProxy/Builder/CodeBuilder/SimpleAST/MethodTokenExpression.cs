using Protein.Enzyme.DynamicProxy;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Protein.Enzyme.DynamicProxy
{
   
    [CLSCompliant(false)]
    public class MethodTokenExpression : Expression
    {
        private MethodInfo _method;

        public MethodTokenExpression(MethodInfo method)
        {
            this._method = method;
        }

        public override void Emit(IEasyMember member, ILGenerator gen)
        {
            gen.Emit(OpCodes.Ldtoken, this._method);
            MethodInfo meth = typeof(MethodBase).GetMethod("GetMethodFromHandle", BindingFlags.Public | BindingFlags.Static, null, new Type[] { typeof(RuntimeMethodHandle) }, null);
            gen.Emit(OpCodes.Call, meth);
            gen.Emit(OpCodes.Castclass, typeof(MethodInfo));
        }
    }
}

