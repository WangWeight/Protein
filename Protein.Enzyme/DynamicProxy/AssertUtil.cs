using System;
using System.Reflection;
namespace Protein.Enzyme.DynamicProxy
{
   

    internal abstract class AssertUtil
    {
        protected AssertUtil()
        {
        }

        public static void IsClass(Type type, string argumentName, bool checkAbstract)
        {
            NotNull(type, argumentName);
            if (!type.IsClass || (type.IsAbstract && checkAbstract))
            {
                bool flag = false;
                if (type.IsAbstract)
                {
                    foreach (MethodInfo info in type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
                    {
                        if (info.IsAbstract)
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                if (flag)
                {
                    throw new ArgumentException(string.Format("Argument '{0}' must be a concrete class", argumentName));
                }
            }
        }

        public static void IsInterface(Type type, string argumentName)
        {
            NotNull(type, argumentName);
            if (!type.IsInterface)
            {
                throw new ArgumentException(string.Format("Argument '{0}' must be an interface", argumentName));
            }
        }

        public static void IsInterface(Type[] types, string argumentName)
        {
            NotNull(types, argumentName);
            foreach (Type type in types)
            {
                IsInterface(type, argumentName);
            }
        }

        public static void NotNull(object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(string.Format("Argument '{0}' 要实例化的类在程序集中未找到", argumentName));
            }
        }
    }
}

