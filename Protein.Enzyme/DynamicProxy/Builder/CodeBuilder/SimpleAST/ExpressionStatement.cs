﻿using Protein.Enzyme.DynamicProxy;
using System;
using System.Reflection.Emit;
namespace Protein.Enzyme.DynamicProxy
{
   

    [CLSCompliant(false)]
    public class ExpressionStatement : Statement
    {
        private Expression _expression;

        public ExpressionStatement(Expression expression)
        {
            this._expression = expression;
        }

        public override void Emit(IEasyMember member, ILGenerator gen)
        {
            this._expression.Emit(member, gen);
        }
    }
}

