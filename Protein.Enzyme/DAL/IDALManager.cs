using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// 数据层管理接口
    /// </summary>
    public  interface  IDALManager
    { 
        /// <summary>
        /// 实体是否存在
        /// </summary>
        /// <returns></returns>
        bool IsEntityExist(IEntityBase Entity);
        /// <summary>
        /// 创建实体
        /// </summary>
        bool CreateEntity(IEntityBase Entity);

    }
}
