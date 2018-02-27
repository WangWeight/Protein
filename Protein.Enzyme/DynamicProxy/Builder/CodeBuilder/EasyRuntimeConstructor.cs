using Protein.Enzyme.DynamicProxy; 
using System;
using System.Reflection;

namespace Protein.Enzyme.DynamicProxy
{
   
    [CLSCompliant(false)]
    public class EasyRuntimeConstructor : EasyConstructor
    {
        public EasyRuntimeConstructor(AbstractEasyType maintype, params ArgumentReference[] arguments)
        {
            Type[] parameterTypes = ArgumentsUtil.InitializeAndConvert(arguments);
            base._builder = maintype.TypeBuilder.DefineConstructor(MethodAttributes.SpecialName | MethodAttributes.HideBySig | MethodAttributes.Public, CallingConventions.Standard, parameterTypes);
            base._builder.SetImplementationFlags(MethodImplAttributes.CodeTypeMask);
        }

        public override void EnsureValidCodeBlock()
        {
        }

        public override void Generate()
        {
        }
    }
}

