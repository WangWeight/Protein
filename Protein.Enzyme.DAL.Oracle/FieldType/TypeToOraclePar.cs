using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Reflection;
using System.ComponentModel;
using Protein.Enzyme.DAL;
using Protein.Enzyme.DAL.Oracle.FieldType;

namespace Protein.Enzyme.DAL.Oracle.FieldType
{
    /// <summary>
    /// 实体类类型转换到oracle参数类型
    /// </summary>
    public class TypeToOraclePar
    {
        /// <summary>
        /// 参数类型 这里还没做完 
        /// </summary>
        public  virtual OracleParameter ParType(PropertyInfo Pi
            , IEntityBase Entity
            , string ParKey)
        {
            OracleParameter result = null;
            FieldSetBase fsbString = new FieldSetString();
            FieldSetBase fsblong = new FieldSetLong();
            FieldSetBase fsbDateTime = new FieldSetDateTime();
            FieldSetBase fsbInt = new FieldSetInt();
            fsbString.SetNextFieldSetType(fsblong);
            fsblong.SetNextFieldSetType(fsbDateTime);
            fsbDateTime.SetNextFieldSetType(fsbInt);
            result = fsbString.Definition(Pi, Entity, ParKey);

            return result;
        }
    }
}
