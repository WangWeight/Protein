using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.DAL;
using System.Reflection;
using System.Data.OracleClient;

namespace Protein.Enzyme.DAL.Oracle.FieldType
{
    /// <summary>
    /// 
    /// </summary>
    public class FieldSetInt : FieldSetBase
    {
         
        protected override System.Data.OracleClient.OracleParameter SetVale(PropertyInfo Pi, IEntityBase Entity, string ParKey)
        {
            OracleParameter result = null; 
            result = new OracleParameter(ParKey
               , OracleType.Number);
            result.Value = NullValue(Pi, Pi.GetValue(Entity, null));  
            return result;
            
        }

        
        protected override bool IsType(PropertyInfo Pi)
        {
            if (Pi.PropertyType == typeof(int))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override object NullValue(PropertyInfo Pi, object Value)
        {
            object result = Value;
            if (result == null)
            {
                 
                    result = -1;
                 
            }
            return result;
        }
    }
}
