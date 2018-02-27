﻿using Protein.Enzyme.DynamicProxy;
using System;
using System.Reflection.Emit;

namespace Protein.Enzyme.DynamicProxy
{
  
    [CLSCompliant(false)]
    public abstract class Statement : IEmitter
    {
        public abstract void Emit(IEasyMember member, ILGenerator gen);
    }
}

