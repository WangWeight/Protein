using Protein.Enzyme.DynamicProxy; 
using System;
using System.Collections;
using System.Reflection.Emit;
using System.Threading;
namespace Protein.Enzyme.DynamicProxy
{
    

    [CLSCompliant(false)]
    public class LockBlockExpression : Expression
    {
        private ArrayList _stmts;
        private Reference _syncLockSource;

        public LockBlockExpression(Reference syncLockSource)
        {
            this._syncLockSource = syncLockSource;
            this._stmts = new ArrayList();
        }

        public void AddStatement(Statement stmt)
        {
            this._stmts.Add(stmt);
        }

        public override void Emit(IEasyMember member, ILGenerator gen)
        {
            ArgumentsUtil.EmitLoadOwnerAndReference(this._syncLockSource, gen);
            //gen.Emit(OpCodes.Call, typeof(Monitor).GetMethod("Enter"));
            //在2.0中没问题 vs2010 2.0中修改该处
            gen.Emit(OpCodes.Call, typeof(Monitor).GetMethod("Enter",new Type[] { typeof(object) }));
            gen.BeginExceptionBlock();
            foreach (Statement statement in this._stmts)
            {
                statement.Emit(member, gen);
            }
            gen.BeginFinallyBlock();
            ArgumentsUtil.EmitLoadOwnerAndReference(this._syncLockSource, gen);
            gen.Emit(OpCodes.Call, typeof(Monitor).GetMethod("Exit"));
            gen.EndExceptionBlock();
        }
    }
}

