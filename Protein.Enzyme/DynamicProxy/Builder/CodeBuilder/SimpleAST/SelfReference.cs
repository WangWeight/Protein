using System;
using System.Reflection.Emit;
namespace Protein.Enzyme.DynamicProxy
{
   
    /// <summary>
    /// 
    /// </summary>
    [CLSCompliant(false)]
    public class SelfReference : Reference
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly SelfReference Self = new SelfReference();
        /// <summary>
        /// 
        /// </summary>
        protected SelfReference() : base(null)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gen"></param>
        public override void LoadAddressOfReference(ILGenerator gen)
        {
            throw new NotSupportedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gen"></param>
        public override void LoadReference(ILGenerator gen)
        {
            gen.Emit(OpCodes.Ldarg_0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gen"></param>
        public override void StoreReference(ILGenerator gen)
        {
            gen.Emit(OpCodes.Ldarg_0);
        }
    }
}

