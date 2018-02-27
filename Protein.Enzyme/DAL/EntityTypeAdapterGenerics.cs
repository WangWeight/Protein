using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.DAL;
using System.Reflection; 

namespace Protein.Enzyme.DAL
{ 
    /// <summary>
    /// 实体类型泛型适配器
    /// </summary>
    public class EntityTypeAdapterGenerics<T,TC> : EntityTypeAdapter
        where T : IEntityBase
    {
        /// <summary>
        /// 判断类型
        /// </summary>
        /// <param name="EntityType"></param>
        /// <returns></returns>
        protected override bool IsType(Type EntityType)
        {
            //获取接口
            if (EntityType == typeof(T))
            {
                this.TargetType = typeof(TC);
                return true;
            }
            return false;
        }
    }
}
