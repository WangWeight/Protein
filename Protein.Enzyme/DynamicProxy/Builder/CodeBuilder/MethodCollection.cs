using System;
using System.Collections;

namespace Protein.Enzyme.DynamicProxy
{
  
    [CLSCompliant(false)]
    public class MethodCollection : CollectionBase
    {
        public void Add(EasyMethod method)
        {
            base.InnerList.Add(method);
        }
    }
}

