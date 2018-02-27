using System;
using System.Reflection;
namespace Protein.Enzyme.DynamicProxy
{
    

    [CLSCompliant(false)]
    public class EasyDefaultConstructor : EasyConstructor
    {
        internal EasyDefaultConstructor(AbstractEasyType maintype)
        {
            maintype.TypeBuilder.DefineDefaultConstructor(MethodAttributes.Public);
        }

        public override void EnsureValidCodeBlock()
        {
        }

        public override void Generate()
        {
        }
    }
}

