using System;
using System.Collections;

namespace Protein.Enzyme.DynamicProxy
{
   
    [CLSCompliant(false)]
    public class EventsCollection : CollectionBase
    {
        public void Add(EasyEvent easyEvent)
        {
            base.InnerList.Add(easyEvent);
        }
    }
}

