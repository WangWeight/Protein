using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Protein.Enzyme.DAL;

namespace Protein.Enzyme.DAL.MDB
{
    /// <summary>
    /// 查询条件，条件子语句的查询条件对象
    /// 目前like没有封装 需要将条件语句的条件项抽象出来 可能会变化
    /// </summary>
    public  class DvWhere : IDvWhere
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

        public Operator OperatorItem
        {
            get;
            set;
        }


        /// <summary>
        /// 设置条件项 这里和SelectCmd.SetWhere 合起来考虑 做职责链、策略、适配器 要符合开闭原则
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Field"></param>
        /// <param name="Operator"></param>
        /// <param name="LinkNextOperator"></param>
        public virtual void ClauseItem(IEntityBase Entity, PropertyInfo Field, string Operator, string LinkNextOperator)
        {
            this.entity = Entity;
            if (Operator.ToUpper() == Protein.Enzyme.DAL.Operator.In.ToString().ToUpper())
            {
                this.clause = SetItemValueIn(Field, Operator, LinkNextOperator);
            }
            else
            {
                this.clause = SetItemValueDefault( Field,  Operator,  LinkNextOperator);// Field.Name + " " + Operator + " :" + "Where" + Field.Name;
            }
            this.LinknextOperator = LinkNextOperator;
            this.usefield = Field;
        }
        /// <summary>
        /// 
        /// </summary>
        protected virtual string SetItemValueDefault(PropertyInfo Field, string Operator, string LinkNextOperator)
        {
            return Field.Name + " " + Operator + " :" + "Where" + Field.Name; ;
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual string SetItemValueIn(PropertyInfo Field, string Operator, string LinkNextOperator)
        {
            return Field.Name + " " + Operator + " (:" + "Where" + Field.Name+" )" ;
        }
        ///// <summary>
        ///// 
        ///// </summary>
        //protected virtual void JudgeOperator(Operator OperatorObj)
        //{ 
        
        //}
        //public virtual void ClauseItem(IEntityBase Entity, PropertyInfo Field, Operator OperatorObj, string LinkNextOperator)
        //{
        //    this.entity = Entity;
        //    this.clause = Field.Name + " " + Operator + " :" + "Where" + Field.Name;
        //    this.LinknextOperator = LinknextOperator;
        //    this.usefield = Field;
        //}


       
    }
}