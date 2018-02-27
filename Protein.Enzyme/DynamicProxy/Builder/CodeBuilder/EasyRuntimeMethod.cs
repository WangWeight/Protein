﻿using Protein.Enzyme.DynamicProxy; 
using System;
using System.Reflection;
namespace Protein.Enzyme.DynamicProxy
{
   

    [CLSCompliant(false)]
    public class EasyRuntimeMethod : EasyMethod
    {
        public EasyRuntimeMethod(AbstractEasyType maintype, string name, ReturnReferenceExpression returnRef, ArgumentReference[] arguments)
        {
            MethodAttributes attributes = MethodAttributes.HideBySig | MethodAttributes.Virtual | MethodAttributes.Public;
            Type[] parameterTypes = ArgumentsUtil.InitializeAndConvert(arguments);
            base._builder = maintype.TypeBuilder.DefineMethod(name, attributes, returnRef.Type, parameterTypes);
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

