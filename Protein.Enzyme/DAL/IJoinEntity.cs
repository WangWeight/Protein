using System;
using System.Collections.Generic;
using System.Text;

namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// 联立的实体类包装接口
    /// </summary>
    public  interface  IJoinEntity
    {
        /// <summary>
        /// 联立的实体类
        /// </summary>
        List<IEntityBase> Entitys { get;set;}


        /// <summary>
        /// 传入要联合的实体 在调用的实体内记录可联合的字段组合
        /// 所有外键关系都用方法表示 
        /// <param name="JionEntity">联立的实体类对象</param>
        /// <param name="SourceEntity">联立的实体类对象</param>
        /// </summary>
        string JoinField(IEntityBase SourceEntity, IEntityBase JionEntity);

        //添加联立实体的同时 设置关联字段 
        //实体自己维护字段关联情况 查询只需要设置条件即可
        //
    }
}
