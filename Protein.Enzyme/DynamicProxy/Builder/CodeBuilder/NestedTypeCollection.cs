using System;
using System.Collections;
namespace Protein.Enzyme.DynamicProxy
{
    

    [CLSCompliant(false)]
    public class NestedTypeCollection : CollectionBase
    {
        public void Add(EasyNested nested)
        {
            base.InnerList.Add(nested);
        }
    }
}

