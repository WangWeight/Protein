using System;
using Protein.Enzyme.DAL;
namespace Test.LHTDZS
{
    public interface ILHTDZS_SZDBCJL : IEntityBase
    {
        string BuChangBianHao { get; set; }
        float BuChangJinE { get; set; }
        int CanJiRenShu { get; set; }
        string ChengBaoFangShi { get; set; }
        DateTime ChengBaoNianXianQ { get; set; }
        DateTime ChengBaoNianXianZ { get; set; }
        int CunMinZu { get; set; }
        int DiBaoRenShu { get; set; }
        string GuiHuaLiYongLeiXing { get; set; }
        float HuiZuMianJi { get; set; }
        DateTime HuiZuNianXianQ { get; set; }
        DateTime HuiZuNianXianZ { get; set; }
        int HuiZuXieYiHao { get; set; }
        string HuZhuMing { get; set; }
        string JBXX_BeiZhu { get; set; }
        int JiaTIngChengYuanShu { get; set; }
        string JiaTingDiZhi { get; set; }
        int JingYingQuanZhengShuHao { get; set; }
        int LaoDongLiRenShu { get; set; }
        string LianXiDianHua { get; set; }
        DateTime LiuZhuanQiXianQ { get; set; }
        DateTime LiuZhuanQiXianZ { get; set; }
        string LiYongLeiXing { get; set; }
        float MeiNianBuZhuZongE { get; set; }
        float MeiNianMeiMuBuZhuJin { get; set; }
        float MianJiZengJian { get; set; }
        float MianJiZengJianJinE { get; set; }
        string MinZu { get; set; }
        DateTime QianDingShiJian { get; set; }
        string SFQianDingHeTong { get; set; }
        string SFZhiFu { get; set; }
        int ShenFenZheng { get; set; }
        string Si_Bei { get; set; }
        string Si_Dong { get; set; }
        string Si_Nan { get; set; }
        string Si_Xi { get; set; }
        string SuoShuCun { get; set; }
        int SuoShuXiangZhen { get; set; }
        int TuDiBianHao { get; set; }
        string TuDiDengJi { get; set; }
        string TuDiMianJi { get; set; }
        string TuDiMingCheng { get; set; }
        string TuDiQuanShuDanWei { get; set; }
        string TuDiQuanShuXingZhi { get; set; }
        string TuDiYuanYongTu { get; set; }
        string TuDiZhongLei { get; set; }
        string XianZhuangLiYongLeiXing { get; set; }
        string XingBie { get; set; }
        long XingZhengQuDaiMa { get; set; }
        int XuHao { get; set; }
        int YingHangKaHao { get; set; }
        string YingHangMingCheng { get; set; }
        string ZhengShouMianJi { get; set; }
        string ZhengShouTuDiYongTu { get; set; }
        string ZhengShouZiJinLaiYuan { get; set; }
        DateTime ZhiFuShiJian { get; set; }
    }
}
