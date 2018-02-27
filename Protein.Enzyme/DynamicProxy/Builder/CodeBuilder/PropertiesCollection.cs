using System;
using System.Collections;


namespace Protein.Enzyme.DynamicProxy
{
   
    [CLSCompliant(false)]
    public class PropertiesCollection : CollectionBase
    {
        public void Add(EasyProperty property)
        {
            base.InnerList.Add(property);
        }
    }
}

