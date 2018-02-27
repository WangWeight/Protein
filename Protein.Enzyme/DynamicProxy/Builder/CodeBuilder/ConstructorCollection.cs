using System;
using System.Collections;
namespace Protein.Enzyme.DynamicProxy
{
   

    [CLSCompliant(false)]
    public class ConstructorCollection : CollectionBase
    {
        public void Add(EasyConstructor constructor)
        {
            base.InnerList.Add(constructor);
        }
    }
}

