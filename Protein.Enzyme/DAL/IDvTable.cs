 

using System; 
using System.Collections.Generic;
namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// 驱动表格接口，抽象表格对象的操作
    /// </summary>
    public interface IDvTable 
    {
        /// <summary>
        /// 操作的实体对象
        /// </summary>
        IEntityBase Entity { get;set; }
        /// <summary> 
        /// 联立实体类包装对象
        /// </summary>
        IJoinEntity Join { get;set;}
        /// <summary>
        /// 创建条件子语句，只用于主实体对象
        /// </summary>
        /// <param name="FieldName">字段名</param>
        /// <param name="OperatorType">运算符</param>
        /// <param name="LinkNextOperator">其后的逻辑操作符，当存在多个条件时，确定他们之间的关系</param>
        void WhereClause(string FieldName, Operator OperatorType, LinkOperator LinkNextOperator);
        /// <summary>
        /// 创建条件子语句，指定要作为条件子语句的实体对象
        /// </summary>
        /// <param name="JoinEntity">在联立的实体对象中查找</param>
        /// <param name="FieldName">字段名</param>
        /// <param name="OperatorType">运算符</param>
        /// <param name="LinkNextOperator">其后的逻辑操作符，当存在多个条件时，确定他们之间的关系</param>
        void WhereClause(IEntityBase JoinEntity, string FieldName, Operator OperatorType, LinkOperator LinkNextOperator);
        /// <summary>
        /// 将该表格对象插入数据库中
        /// </summary>
        /// <returns></returns>
        int Insert();
        /// <summary>
        /// 根据存在的条件子语句查询该单位
        /// </summary>
        /// <returns></returns>
        System.Data.DataSet Select();　
        /// <summary>
        /// 条件子语句
        /// </summary>
        System.Collections.Generic.List<IDvWhere> Wherelist { get; set; }
        /// <summary>
        /// 根据条件语句删除数据
        /// </summary>
        /// <returns></returns>
        int Delete();
        /// <summary>
        /// 根据条件语句更新对象的所有值
        /// </summary>
        /// <returns></returns>
        int Update();
        /// <summary>
        /// 筛选过滤器
        /// </summary>
        System.Collections.Generic.List<IFilter> Filterlist { get; set; }
        /// <summary>
        /// 查询过滤器
        /// </summary>
        void SetFilter(Operator OperatorType,string FieldName);
        /// <summary>
        /// 分组对象
        /// </summary>
        IGroupBy GetGroupBy { get; set; }
        /// <summary>
        /// 设置分组字段
        /// </summary>
        /// <param name="FieldName"></param>
        void SetGroupBy(string FieldName);

        /// <summary>
        /// in子语句设置 该方法欠考虑 暂时用
        /// </summary>
        InClauseOperator InClause { get; set; }
    }
}
