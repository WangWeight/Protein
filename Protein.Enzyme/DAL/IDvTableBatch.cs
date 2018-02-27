using System;
using System.Collections.Generic;
using System.Text;

namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// 创建表格操作驱动对象委托
    /// </summary>
    /// <param name="Entity"></param>
    /// <param name="DalSql"></param>
    /// <returns></returns>
    public delegate IDvTable DlgCreateDvTableIns(Protein.Enzyme.DAL.IEntityBase Entity, IDalSql DalSql);
 

    /// <summary>
    /// 驱动表格批量操作接口，批量添加、更新、删除纪录
    /// </summary>
    public interface IDvTableBatch
    {
        /// <summary>
        /// 数据库操作
        /// </summary>
        IDalSql DalSql { get;set;}
        /// <summary>
        /// 创建表格操作驱动实例的委托实例
        /// </summary>
        DlgCreateDvTableIns DlgCreateDriveTableIns {  set;}
        /// <summary>
        /// 根据批量操作的IDalSql对象和参数传入的实体对象创建表格操作驱动对象实例 
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        IDvTable CreateDriveTable(Protein.Enzyme.DAL.IEntityBase Entity);
        
        /// <summary>
        /// 添加插入操作,以备批量执行
        /// </summary>
        /// <param name="Entity"></param>
        void AddInsert(IEntityBase Entity);
        /// <summary>
        /// 添加更新操作,以备批量执行
        /// </summary>
        /// <param name="Table"></param>
        void AddUpdate(IDvTable Table);
        /// <summary>
        /// 添加删除操作,以备批量执行
        /// </summary>
        /// <param name="Table"></param>
        void AddDelete(IDvTable Table);
        /// <summary>
        /// 执行操作 批量执行所有的插入、更新、删除操作，暂时不做细化的操作结果 只返回影响的数量
        /// 不支持回滚操作
        /// </summary>
        int  Execute();
        /// <summary>
        /// 执行操作 批量执行 更新 操作 
        /// <param name="TableList">表格列表</param>
        /// <param name="IsRollBack">是否回滚，如果发生回滚，返回值为-1</param>
        /// </summary>
        int ExecuteUpdate(List<IDvTable> TableList, bool IsRollBack);

        /// <summary>
        /// 执行操作 批量执行 更新 操作 
        /// <param name="Entity">实体</param>
        /// <param name="IsRollBack">是否回滚，如果发生回滚，返回值为-1</param>
        /// </summary>
        int ExecuteInsert(List<IEntityBase> Entity, bool IsRollBack);

        /// <summary>
        /// 执行操作 批量执行 更新 操作 
        /// <param name="TableList">表格列表</param>
        /// <param name="IsRollBack">是否回滚，如果发生回滚，返回值为-1</param>
        /// </summary>
        int ExecuteDelete(List<IDvTable> TableList, bool IsRollBack);
         
    }
}
