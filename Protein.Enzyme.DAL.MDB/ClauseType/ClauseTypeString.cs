using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using Protein.Enzyme.DAL;
using System.Diagnostics; 

namespace Protein.Enzyme.DAL.MDB.ClauseType
{
    /// <summary>
    ///  
    /// </summary>
    public   class ClauseTypeString:ClauseTypeBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Pi"></param>
        /// <returns></returns>
        protected override bool IsType(PropertyInfo Pi)
        {
            if (Pi.PropertyType == typeof(string))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override object SetVale(object value)
        {
            return "'" + value.ToString() + "'";
        }
 
    }
}
