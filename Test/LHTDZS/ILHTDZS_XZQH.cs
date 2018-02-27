using System;
using Protein.Enzyme.DAL;
namespace Test.LHTDZS
{
    public interface ILHTDZS_XZQH : IEntityBase
    {
        /// <summary>
        /// 城镇分类
        /// </summary>
        string ChengXiangFenLei { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        double JiBie { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        string MingCheng { get; set; }
        /// <summary>
        /// 上级代码
        /// </summary>
        string ShangJiDaiMa { get; set; }
        /// <summary>
        /// 行政区代码
        /// </summary>
        string XingZhengQuDaiMa { get; set; }
    }
}
