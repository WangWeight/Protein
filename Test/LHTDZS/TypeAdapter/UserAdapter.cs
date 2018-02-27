using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.DAL;
using Test.LHTDZS;
namespace Test.LHTDZS.TypeAdapter
{
    /// <summary>
    /// 用户类型适配器
    /// </summary>
    public class UserAdapter : EntityTypeAdapter
    {
        protected override bool IsType(Type EntityType)
        {
            if (EntityType == typeof(ILHTDZS_ManagerUser))
            {
                this.TargetType = typeof(LHTDZS_ManagerUser);
                return true;
            }
            return false;
        }

    }

}
