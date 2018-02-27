﻿using System;
using System.Reflection.Emit;
namespace Protein.Enzyme.DynamicProxy
{
    
    /// <summary>
    /// 
    /// </summary>
    [CLSCompliant(false)]
    public class ReturnReferenceExpression : TypeReference
    {
        public ReturnReferenceExpression(Type argumentType) : base(argumentType)
        {
        }

        public override void LoadAddressOfReference(ILGenerator gen)
        {
            throw new NotSupportedException();
        }

        public override void LoadReference(ILGenerator gen)
        {
        }

        public override void StoreReference(ILGenerator gen)
        {
        }
    }
}

