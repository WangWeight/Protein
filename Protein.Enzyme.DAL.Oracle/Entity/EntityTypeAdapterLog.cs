using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.DAL;
namespace Protein.Enzyme.DAL.Oracle.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class EntityTypeAdapterLog : EntityTypeAdapter
    {
        protected override bool IsType(Type EntityType)
        {
            if (EntityType == typeof(Protein.Enzyme.Log.ILog))
           {
               this.TargetType = typeof(ProteinLog);
               return true;
           }
            return false;
        }
 
    }
}
