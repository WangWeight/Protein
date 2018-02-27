using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.ComponentModel;
using Protein.Enzyme.DAL;
using Protein.Enzyme.DAL.MDB.FieldType;

namespace Protein.Enzyme.DAL.MDB.FieldType
{
    /// <summary>
    /// 实体类类型转换到Access参数类型
    /// </summary>
    class TypeToAccessPar
    {

        public virtual OleDbParameter ParType(PropertyInfo Pi, IEntityBase Entity, string ParKey)
        {
            OleDbParameter result = null;
            FieldSetBase fsbString = new FieldSetString();
            FieldSetBase fsblong = new FieldSetLong();
            FieldSetBase fsbDateTime = new FieldSetDateTime();
            FieldSetBase fsbInt = new FieldSetInt();
            FieldSetBase fsbDouble = new FieldSetDouble();

            fsbString.SetNextFieldSetType(fsblong);
            fsblong.SetNextFieldSetType(fsbDateTime);
            fsbDateTime.SetNextFieldSetType(fsbInt);
            result = fsbString.Definition(Pi, Entity, ParKey);

            return result;
        }
    }
}
