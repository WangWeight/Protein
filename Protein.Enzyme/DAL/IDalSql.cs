using System; 
using System.Collections.Generic;
namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// 数据库表格操作接口
    /// </summary>
    public interface IDalSql
    {
        /// <summary>
        /// 
        /// </summary>
        IDBInfo DbHelper { get;set;}
        /// <summary>
        /// 将表对象插入数据库
        /// </summary>
        /// <param name="Table"></param>
        /// <returns></returns>
        int Insert(IDvTable Table);
        /// <summary>
        /// 根据表对象数据查询数据
        /// </summary>
        /// <param name="Table"></param>
        /// <returns></returns>
        System.Data.DataSet SelectSingle(IDvTable Table) ;
        /// <summary>
        /// 删除表中的该对象
        /// </summary>
        /// <param name="Table"></param>
        /// <returns></returns>
        int Delete(IDvTable Table);
        /// <summary>
        /// 修改表中的对象数据
        /// </summary>
        /// <returns></returns>
        int Update(IDvTable Table);

         

        /// <summary>
        /// 批量插入数据库记录
        /// </summary>
        /// <param name="Tables"></param>
        /// <param name="IsRollBack">是否允许在操作异常时回滚，true为发生异常是回滚所有操作，false忽略异常记录</param>
        /// <returns>影响的记录数量</returns>
        int InsertTran(List<IDvTable> Tables,bool IsRollBack);
        /// <summary>
        /// 批量更新数据库记录
        /// </summary>
        /// <param name="Tables"></param>
        /// <param name="IsRollBack">是否允许在操作异常时回滚，true为发生异常是回滚所有操作，false忽略异常记录</param>
        /// <returns>影响的记录数量</returns>
        int UpdateTran(List<IDvTable> Tables, bool IsRollBack);

        /// <summary>
        /// 批量删除数据库记录
        /// </summary>
        /// <param name="Tables"></param>
        /// <param name="IsRollBack">是否允许在操作异常时回滚，true为发生异常是回滚所有操作，false忽略异常记录</param>
        /// <returns>影响的记录数量</returns>
        int DeleteTran(List<IDvTable> Tables, bool IsRollBack);

        
         
    }
}
