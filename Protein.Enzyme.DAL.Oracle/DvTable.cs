using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection; 
using System.Data; 
using System.ComponentModel;
using Protein.Enzyme.DAL.Oracle.Command; 
using Protein.Enzyme.DAL;

namespace Protein.Enzyme.DAL.Oracle
{
    /// <summary>
    /// 数据表基类
    /// </summary>
    public class DvTable : IDvTable
    {
        #region 实体基础操作

        List<IDvWhere> wherelist = new List<IDvWhere>();
        /// <summary>
        /// 查询条件列表
        /// </summary>
        public List<IDvWhere> Wherelist
        {
            get { return wherelist; }
            set { wherelist = value; }
        }

        IDalSql setup = null;
        public DvTable(IDalSql Setup)
        {
            setup = Setup;
        }

        IJoinEntity join = new JoinEntity();
        /// <summary>
        /// 联立的实体类包装接口
        /// </summary>
        public IJoinEntity Join
        {
            get
            {
                return join;
            }
            set
            {
                this.join = value;
            }
        }


        private IEntityBase entity = null;
        /// <summary>
        /// 操作的实体对象
        /// </summary>
        public IEntityBase Entity
        {
            get
            {
                return this.entity;
            }
            set
            {
                this.entity = value; ;
            }
        }
        #endregion

        #region 查询

        /// <summary>
        /// 检查字段是否存在 不存在直接抛出异常
        /// </summary>
        protected virtual void CheckField(IEntityBase Entity,string FieldName)
        {
            if (Entity.GetField(FieldName) == null)
            {
                throw new Exception("驱动表格没找到实体的指定字段："+this.entity.ToString()+"  "+FieldName);
            }

        }

        /// <summary>
        /// 创建查询条件子语句
        /// </summary>
        /// <param name="FieldName">字段名</param>
        /// <param name="OperatorType">操作符</param>
        /// <param name="Value">值</param>
        /// <param name="LinkNextOperator">链接下一个条件子语句的操作符</param>
        public void  WhereClause(string FieldName, Operator OperatorType
           ,LinkOperator LinkNextOperator)
        { 
            CreateWhereClause(this.entity, FieldName, OperatorType
           , LinkNextOperator);
        }

        /// <summary>
        /// 创建条件子语句，指定要作为条件子语句的实体对象
        /// </summary>
        /// <param name="JoinEntity">在联立的实体对象中查找</param>
        /// <param name="FieldName">字段名</param>
        /// <param name="OperatorType">运算符</param>
        /// <param name="LinkNextOperator">其后的逻辑操作符，当存在多个条件时，确定他们之间的关系</param>
        public void WhereClause(IEntityBase JoinEntity, string FieldName, Operator OperatorType, LinkOperator LinkNextOperator)
        {
            if (this.join.Entitys.Contains(JoinEntity))
            {
                CreateWhereClause(JoinEntity, FieldName, OperatorType
          , LinkNextOperator);
            } 
        }

        /// <summary>
        /// 创建语句
        /// </summary>
        protected void CreateWhereClause(IEntityBase JoinEntity
            , string FieldName, Operator OperatorType
           , LinkOperator LinkNextOperator)
        {
            this.CheckField(JoinEntity,FieldName);
            IDvWhere newpw = new DvWhere();
            newpw.ClauseItem(JoinEntity,JoinEntity.GetType().GetProperty(FieldName)
                , GetDescription(OperatorType), GetDescription(LinkNextOperator));
            this.wherelist.Add(newpw);
        }

        /// <summary>
        /// 配置select   查询条件子语句的匹配
        /// 实现单表 多条件查询 
        /// </summary>
        /// <returns></returns>
        public DataSet Select()
        {
            return  this.setup.SelectSingle(this);  
        }


        public List<T> SelectEntity<T>()
        {
            DataSet ds = Select();
            //T obj = default(T);
            DataHelper dte = new DataHelper();
            return  dte.ConvertToEntity<T>(ds);
        }


        #endregion

        #region 插入
        /// <summary>
        /// 把表对象的属性都作为字段和值添加到插入语句中
        /// 生成插入语句
        /// </summary> 
        /// <returns>返回影响行数</returns>
        public int Insert()
        { 
            int count = setup.Insert(this); 
            return count; 
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public int Delete()
        {
            int count = setup.Delete(this);
            return count;
        }

        #endregion

        #region 更新

        /// <summary>
        /// 更新
        /// </summary>
        /// <returns></returns>
        public int Update()
        {
            int count = setup.Update(this);
            return count;
        }

        #endregion

        #region 筛选器
        System.Collections.Generic.List<IFilter> filterlist = new List<IFilter>(); 
        /// <summary>
        /// 筛选过滤器
        /// </summary>
        public System.Collections.Generic.List<IFilter> Filterlist 
        { 
            get{
                return this.filterlist;
            }
            set {
                this.filterlist = value;
            }
        }

        public IGroupBy GetGroupBy
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

        public InClauseOperator InClause
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

        /// <summary>
        /// 查询过滤器
        /// </summary>
        public void SetFilter(Operator OperatorType, string FieldName)
        { 
            IFilter flt = new Filter(this.entity.GetField(FieldName), OperatorType);
            this.filterlist.Add(flt);
        }

        #endregion 

        #region 获取枚举解释值
        /// <summary>  
        /// 获取枚举变量值的 Description 属性  
        /// </summary>  
        /// <param name="obj">枚举变量</param>  
        /// <returns>如果包含 Description 属性，则返回 Description 属性的值，否则返回枚举变量值的名称</returns>  
        private   string GetDescription(object obj)
        {
            return GetDescription(obj, false);

        }

       /// <summary>  
        /// 获取枚举变量值的 Description 属性  
        /// </summary>  
        /// <param name="obj">枚举变量</param>  
        /// <param name="isTop">是否改变为返回该类、枚举类型的头 Description 属性，而不是当前的属性或枚举变量值的 Description 属性</param>  
        /// <returns>如果包含 Description 属性，则返回 Description 属性的值，否则返回枚举变量值的名称</returns> 
        private  string GetDescription(object obj, bool isTop)
        { 
            if (obj == null)
            {
                return string.Empty; 
            }  
            Type _enumType = obj.GetType(); 
            DescriptionAttribute dna = null; 
            if (isTop)
            { 
                dna = (DescriptionAttribute)Attribute.GetCustomAttribute(_enumType, typeof(DescriptionAttribute)); 
            }

            else
            {

                FieldInfo fi = _enumType.GetField(Enum.GetName(_enumType, obj));
                dna = (DescriptionAttribute)Attribute.GetCustomAttribute(
                fi, typeof(DescriptionAttribute));

            }

            if (dna != null && string.IsNullOrEmpty(dna.Description) == false)
            {
                return dna.Description;
            }
             

            return obj.ToString();

        }

        public void SetGroupBy(string FieldName)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
