using Protein.Enzyme.DynamicProxy;
using System;
using System.Reflection;
namespace Protein.Enzyme.DynamicProxy
{
   

    [CLSCompliant(false)]
    public class EasyNested : AbstractEasyType
    {
        public EasyNested(AbstractEasyType maintype, string name, Type baseType, Type[] interfaces, ReturnReferenceExpression returnType, params ArgumentReference[] args)
        {
            base._typebuilder = maintype.TypeBuilder.DefineNestedType(name, TypeAttributes.Sealed | TypeAttributes.NestedPublic, baseType, interfaces);
        }
    }
}

