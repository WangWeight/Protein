using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Protein.Enzyme.DAL;
namespace Protein.Enzyme.DAL.Oracle
{
    /// <summary>
    /// 查询条件，条件子语句的查询条件对象
    /// </summary>
    public class DvWhere : IDvWhere
    {
        private PropertyInfo usefield;

        /// <summary>
        /// 使用的字段
        /// </summary>
        public PropertyInfo Usefield
        {
            get { return usefield; }
            set { usefield = value; }
        }
        private string clause = "";

        /// <summary>
        /// 查询条件子句
        /// </summary>
        public string Clause
        {
            get { return clause; }
            set { clause = value; }
        }

        private string linknextOperator = ""; 
        /// <summary>
        /// 链接下一个查询条件的操作符号
        /// </summary>
        public string LinknextOperator
        {
            get { return linknextOperator; }
            set { linknextOperator = value; }
        }

        IEntityBase entity = null;
        /// <summary>
        /// 实体对象
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
        /// 获取查询子语句项
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
        /// 获取项值的添加格式
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
