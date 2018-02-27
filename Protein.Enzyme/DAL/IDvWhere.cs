using System;
namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// 查询条件，条件子语句的查询条件对象
    /// </summary>
    public interface IDvWhere
    {
        /// <summary>
        /// 实体实例
        /// </summary>
        IEntityBase Entity { get;set;}
        /// <summary>
        /// 条件子语句字符
        /// </summary>
        string Clause { get; set; }
        /// <summary>
        /// 操作条件
        /// </summary>
        Operator OperatorItem { get; set; }
        /// <summary>
        /// 创建对象实体数据项  这个方法的参数有问题 需要使用Operator
        /// </summary>
        /// <param name="Entity">条件字段</param>
        /// <param name="Field">条件字段</param>
        /// <param name="Operator">操作符</param>
        /// <param name="LinkNextOperator">子语句连接操作符</param>
        void ClauseItem(IEntityBase Entity,System.Reflection.PropertyInfo Field, string Operator, string LinkNextOperator);
        /// <summary>
        /// 连接下一个条件子语句的运算操作符
        /// </summary>
        string LinknextOperator { get; set; }
        /// <summary>
        /// 该条件子语句使用的字段
        /// </summary>
        System.Reflection.PropertyInfo Usefield { get; set; }
        
    }
}
