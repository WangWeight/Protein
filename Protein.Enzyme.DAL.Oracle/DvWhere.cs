using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Protein.Enzyme.DAL;
namespace Protein.Enzyme.DAL.Oracle
{
    /// <summary>
    /// ��ѯ���������������Ĳ�ѯ��������
    /// </summary>
    public class DvWhere : IDvWhere
    {
        private PropertyInfo usefield;

        /// <summary>
        /// ʹ�õ��ֶ�
        /// </summary>
        public PropertyInfo Usefield
        {
            get { return usefield; }
            set { usefield = value; }
        }
        private string clause = "";

        /// <summary>
        /// ��ѯ�����Ӿ�
        /// </summary>
        public string Clause
        {
            get { return clause; }
            set { clause = value; }
        }

        private string linknextOperator = ""; 
        /// <summary>
        /// ������һ����ѯ�����Ĳ�������
        /// </summary>
        public string LinknextOperator
        {
            get { return linknextOperator; }
            set { linknextOperator = value; }
        }

        IEntityBase entity = null;
        /// <summary>
        /// ʵ�����
        /// </summary>
        public IEntityBase Entity
        {
            get
            {
                return this.entity;
            }
            set
            {
                this.entity = value;
            }
        }
 

        /// <summary>
        /// ��ȡ��ѯ�������
        /// </summary>
        /// <returns></returns>
        public virtual void ClauseItem(IEntityBase Entity, PropertyInfo Field
            , string Operator,string LinkNextOperator)
        {
            this.entity = Entity;
            this.clause = Field.Name + " " + Operator + " :" +"Where"+ Field.Name;
            this.LinknextOperator = LinkNextOperator;
            this.usefield = Field;
            
        }

    
        /// <summary>
        /// ��ȡ��ֵ����Ӹ�ʽ
        /// </summary>
        /// <param name="Field"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        protected virtual string GetValueItem(PropertyInfo Field
            , object Value)
        {
            string result="";
            if (Field.PropertyType == typeof(string))
            {
                result ="'" + Value.ToString() + "'";
            }
            return result;
        }







        public Operator OperatorItem
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
