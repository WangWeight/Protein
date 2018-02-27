using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Reflection;
using Protein.Enzyme.DAL;
namespace Protein.Enzyme.DAL.Oracle.FieldType
{
    /// <summary>
    /// �ֶθ�ֵ���ʹ������
    /// </summary>
    public abstract class FieldSetBase
    {
        protected FieldSetBase nextFieldSet = null;

        /// <summary>
        /// ������һ���ֶδ���ʽ
        /// </summary>
        /// <param name="Successor"></param>
        public virtual void SetNextFieldSetType(FieldSetBase FieldSet)
        {
            this.nextFieldSet = FieldSet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual OracleParameter Definition(PropertyInfo Pi, IEntityBase Entity, string ParKey)
        {
            OracleParameter result = null;
            if (IsType(Pi))
            {
                result = SetVale(Pi, Entity, ParKey);
            }
            else if (this.nextFieldSet != null)
            {
                result = this.nextFieldSet.Definition(Pi, Entity, ParKey);
            }
            return result;
        }
        /// <summary>
        /// ����ֵ
        /// </summary>
        /// <param name="Pi"></param>
        /// <param name="Entity"></param>
        /// <param name="ParKey"></param>
        /// <returns></returns>
        protected abstract OracleParameter SetVale(PropertyInfo Pi, IEntityBase Entity, string ParKey);
        /// <summary>
        /// �жϴ�������
        /// </summary>
        /// <param name="NewModule"></param>
        /// <returns></returns>
        protected abstract bool IsType(PropertyInfo Pi);
        /// <summary>
        /// ���ÿ�ֵʱ������
        /// </summary>
        /// <param name="Pi"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        protected abstract object NullValue(PropertyInfo Pi, object Value);
    }
}
