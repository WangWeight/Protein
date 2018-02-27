using Protein.Enzyme.DynamicProxy;
using System;
using System.Reflection;
using System.Reflection.Emit;
namespace Protein.Enzyme.DynamicProxy
{
  

    [CLSCompliant(false)]
    public class MethodPointerExpression : Expression
    {
        private MethodInfo _method;
        private Reference _owner;

        public MethodPointerExpression(MethodInfo method) : this(SelfReference.Self, method)
        {
        }

        public MethodPointerExpression(Reference owner, MethodInfo method)
        {
            this._owner = owner;
            this._method = method;
        }

        public override void Emit(IEasyMember member, ILGenerator gen)
        {
            bool isAbstract = this._method.IsAbstract;
            gen.Emit(OpCodes.Ldftn, this._method);
        }
    }
}

