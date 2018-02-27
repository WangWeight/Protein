using Protein.Enzyme.DynamicProxy; 
using System;
using System.Collections;
using System.Reflection;
namespace Protein.Enzyme.DynamicProxy
{
   

    [CLSCompliant(false)]
    public class EasyType : AbstractEasyType
    {
        private static IDictionary signedAssemblyCache = new Hashtable();

        protected EasyType()
        {
        }

        public EasyType(ModuleScope modulescope, string name) : this(modulescope, name, typeof(object), new Type[0])
        {
        }

        public EasyType(ModuleScope modulescope, string name, Type baseType, Type[] interfaces) : this(modulescope, name, baseType, interfaces, false)
        {
        }

        public EasyType(ModuleScope modulescope, string name, Type baseType, Type[] interfaces, bool serializable) : this()
        {
            TypeAttributes attr = TypeAttributes.Serializable | TypeAttributes.Public;
            if (serializable)
            {
                attr |= TypeAttributes.Serializable;
            }
            bool signStrongName = this.IsAssemblySigned(baseType);
            base._typebuilder = modulescope.ObtainDynamicModule(signStrongName).DefineType(name, attr, baseType, interfaces);
        }

        public EasyCallable CreateCallable(ReturnReferenceExpression returnType, params ArgumentReference[] args)
        {
            EasyCallable nested = new EasyCallable(this, base.IncrementAndGetCounterValue, returnType, args);
            base._nested.Add(nested);
            return nested;
        }

        public EasyCallable CreateCallable(Type returnType, params ParameterInfo[] args)
        {
            EasyCallable nested = new EasyCallable(this, base.IncrementAndGetCounterValue, new ReturnReferenceExpression(returnType), ArgumentsUtil.ConvertToArgumentReference(args));
            base._nested.Add(nested);
            return nested;
        }

        private bool IsAssemblySigned(Type baseType)
        {
            lock (signedAssemblyCache)
            {
                if (!signedAssemblyCache.Contains(baseType.Assembly))
                {
                    AssemblyName name = baseType.Assembly.GetName();
                    bool flag = false;
                    byte[] publicKey = name.GetPublicKey();
                    flag = (publicKey != null) && (publicKey.Length != 0);
                    signedAssemblyCache.Add(baseType.Assembly, flag);
                }
                return (bool) signedAssemblyCache[baseType.Assembly];
            }
        }
    }
}

