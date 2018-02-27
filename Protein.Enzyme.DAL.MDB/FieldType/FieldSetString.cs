using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Protein.Enzyme.DAL;

namespace Protein.Enzyme.DAL.MDB.FieldType
{
    /// <summary>
    /// 
    /// </summary>
    class FieldSetString : FieldSetBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Pi"></param>
        /// <param name="Entity"></param>
        /// <param name="ParKey"></param>
        /// <returns></returns>
        protected override OleDbParameter SetVale(  string ParKey, object Value)
        {
            OleDbParameter result = null;
            result = new OleDbParameter(ParKey, OleDbType.VarChar);
            result.Value = NullValue(Value);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Pi"></param>
        /// <returns></returns>
        protected override bool IsType(System.Reflection.PropertyInfo Pi)
        {
            if (Pi.PropertyType == typeof(String))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        protected override object NullValue(  object Value)
        {
            object result = Value;
            if (result == null)
            {
                result = "";
            }
            return result;
        }
    }
}
