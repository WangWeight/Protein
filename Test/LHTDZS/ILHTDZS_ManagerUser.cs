using System;
using Protein.Enzyme.DAL;
namespace Test.LHTDZS
{
    public interface ILHTDZS_ManagerUser : IEntityBase
    {
        long USER_ID { get; set; }
        string YongHuMiMa { get; set; }
        string YongHuMing { get; set; }
    }
}
