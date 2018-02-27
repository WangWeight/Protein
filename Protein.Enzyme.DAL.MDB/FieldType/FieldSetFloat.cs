using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Protein.Enzyme.DAL;
namespace Protein.Enzyme.DAL.MDB.FieldType
{
    class FieldSetFloat:FieldSetBase
    {
        protected override bool IsType(System.Reflection.PropertyInfo Pi)
        {
            if (Pi.PropertyType == typeof(float))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override OleDbParameter SetVale( string ParKey, object Value)
        {
            OleDbParameter result = null;
            result = new OleDbParameter(ParKey, OleDbType.Single);
            result.Value = NullValue(Value);
            return result;
        }

        protected override object NullValue(  object Value)
        {
            object result = Value;
            if (result == null)
            {
                result = 0;
            }
            return result;
        }
    }
}
