using Protein.Enzyme.DynamicProxy;
using System;
using System.Collections;
using System.Reflection.Emit;

namespace Protein.Enzyme.DynamicProxy
{
    
    [CLSCompliant(false)]
    public abstract class AbstractCodeBuilder
    {
        private ILGenerator _generator;
        private ArrayList _ilmarkers = new ArrayList();
        private bool _isEmpty;
        private ArrayList _stmts = new ArrayList();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="generator"></param>
        protected AbstractCodeBuilder(ILGenerator generator)
        {
            this._generator = generator;
            this._isEmpty = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stmt"></param>
        public void AddStatement(Statement stmt)
        {
            this.SetNonEmpty();
            this._stmts.Add(stmt);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public LabelReference CreateLabel()
        {
            LabelReference reference = new LabelReference();
            this._ilmarkers.Add(reference);
            return reference;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public LocalReference DeclareLocal(Type type)
        {
            LocalReference reference = new LocalReference(type);
            this._ilmarkers.Add(reference);
            return reference;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <param name="il"></param>
        internal void Generate(IEasyMember member, ILGenerator il)
        {
            foreach (Reference reference in this._ilmarkers)
            {
                reference.Generate(il);
            }
            foreach (Statement statement in this._stmts)
            {
                statement.Emit(member, il);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected internal void SetNonEmpty()
        {
            this._isEmpty = false;
        }
        /// <summary>
        /// 
        /// </summary>
        protected ILGenerator Generator
        {
            get
            {
                return this._generator;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        internal bool IsEmpty
        {
            get
            {
                return this._isEmpty;
            }
        }
    }
}

