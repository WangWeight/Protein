using System;
namespace Protein.Enzyme.DAL 
{
    /// <summary>
    /// 数据操作实体工厂
    /// </summary>
    public interface IEntityFactory
    { 
        /// <summary>
        /// 创建实体对象实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T CreateEntityInstance<T>();
        /// <summary>
        /// 数据库信息
        /// </summary>
        Protein.Enzyme.DAL.IDBInfo DbHelper { get; set; }
        /// <summary>
        /// 创建表格操作驱动对象
        /// </summary>
        /// <returns></returns>
        Protein.Enzyme.DAL.IDvTable CreateDriveTable(Protein.Enzyme.DAL.IEntityBase Entity);
        /// <summary>
        /// 创建表格批量操作驱动对象
        /// </summary>
        /// <returns></returns>
        Protein.Enzyme.DAL.IDvTableBatch CreateDriveTableBatch();
        /// <summary>
        /// 管理接口
        /// </summary>
        /// <returns></returns>
        IDALManager CreateDALmanager();
        /// <summary>
        /// 实体类型适配器
        /// </summary>
        EntityTypeAdapter TypeAdapter { get; set; }
        /// <summary>
        ///  添加新的实体类型处理适配器
        /// </summary>
        /// <param name="NewAdapter"></param>
        void AddAdapter(EntityTypeAdapter NewAdapter);
        /// <summary>
        /// 关闭工厂
        /// </summary>
        void CloseFactory();
    }
}
