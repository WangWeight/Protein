// File:    LHTDZS_SZDBCJL.cs
// Author:  Administrator
// Created: 2012年9月18日 9:59:49
// Purpose: Definition of Class LHTDZS_SZDBCJL

using System;
using System.Reflection;
using Protein.Enzyme.DAL;
/// 收租地补偿记录表
public class LHTDZS_SZDBCJL :EntityBase, Test.LHTDZS.ILHTDZS_SZDBCJL 
{
   /// 行政区划+流水
   private string _BuChangBianHao;
   /// <summary>
   /// 补偿编号
   /// </summary>
   /// <value>The 补偿编号. </value>
   public string BuChangBianHao
   {
          get
          {
                 return _BuChangBianHao;
          }
          set
          {
                 value = _BuChangBianHao;
          }
   }
   private long _XingZhengQuDaiMa;
   /// <summary>
   /// 行政区代码
   /// </summary>
   /// <value>The 行政区代码. </value>
   public long XingZhengQuDaiMa
   {
          get
          {
                 return _XingZhengQuDaiMa;
          }
          set
          {
                 value = _XingZhengQuDaiMa;
          }
   }
   private string _HuZhuMing;
   /// <summary>
   /// 户主名
   /// </summary>
   /// <value>The 户主名. </value>
   public string HuZhuMing
   {
          get
          {
                 return _HuZhuMing;
          }
          set
          {
                 value = _HuZhuMing;
          }
   }
   private string _XingBie;
   /// <summary>
   /// 性别
   /// </summary>
   /// <value>The 性别. </value>
   public string XingBie
   {
          get
          {
                 return _XingBie;
          }
          set
          {
                 value = _XingBie;
          }
   }
   private string _MinZu;
   /// <summary>
   /// 民族
   /// </summary>
   /// <value>The 民族. </value>
   public string MinZu
   {
          get
          {
                 return _MinZu;
          }
          set
          {
                 value = _MinZu;
          }
   }
   private string _LianXiDianHua;
   /// <summary>
   /// 联系电话
   /// </summary>
   /// <value>The 联系电话. </value>
   public string LianXiDianHua
   {
          get
          {
                 return _LianXiDianHua;
          }
          set
          {
                 value = _LianXiDianHua;
          }
   }
   private string _YingHangMingCheng;
   /// <summary>
   /// 银行名称
   /// </summary>
   /// <value>The 银行名称. </value>
   public string YingHangMingCheng
   {
          get
          {
                 return _YingHangMingCheng;
          }
          set
          {
                 value = _YingHangMingCheng;
          }
   }
   private int _YingHangKaHao;
   /// <summary>
   /// 银行卡号
   /// </summary>
   /// <value>The 银行卡号. </value>
   public int YingHangKaHao
   {
          get
          {
                 return _YingHangKaHao;
          }
          set
          {
                 value = _YingHangKaHao;
          }
   }
   private int _ShenFenZheng;
   /// <summary>
   /// 身份证
   /// </summary>
   /// <value>The 身份证. </value>
   public int ShenFenZheng
   {
          get
          {
                 return _ShenFenZheng;
          }
          set
          {
                 value = _ShenFenZheng;
          }
   }
   private string _JiaTingDiZhi;
   /// <summary>
   /// 家庭地址
   /// </summary>
   /// <value>The 家庭地址. </value>
   public string JiaTingDiZhi
   {
          get
          {
                 return _JiaTingDiZhi;
          }
          set
          {
                 value = _JiaTingDiZhi;
          }
   }
   private string _SFZhiFu;
   /// <summary>
   /// 是否已支付
   /// </summary>
   /// <value>The 是否已支付. </value>
   public string SFZhiFu
   {
          get
          {
                 return _SFZhiFu;
          }
          set
          {
                 value = _SFZhiFu;
          }
   }
   private DateTime _ZhiFuShiJian;
   /// <summary>
   /// 支付时间
   /// </summary>
   /// <value>The 支付时间. </value>
   public DateTime ZhiFuShiJian
   {
          get
          {
                 return _ZhiFuShiJian;
          }
          set
          {
                 value = _ZhiFuShiJian;
          }
   }
   private string _JBXX_BeiZhu;
   /// <summary>
   /// 备注
   /// </summary>
   /// <value>The 备注. </value>
   public string JBXX_BeiZhu
   {
          get
          {
                 return _JBXX_BeiZhu;
          }
          set
          {
                 value = _JBXX_BeiZhu;
          }
   }
   private string _TuDiMingCheng;
   /// <summary>
   /// 土地名称
   /// </summary>
   /// <value>The 土地名称. </value>
   public string TuDiMingCheng
   {
          get
          {
                 return _TuDiMingCheng;
          }
          set
          {
                 value = _TuDiMingCheng;
          }
   }
   private string _TuDiYuanYongTu;
   /// <summary>
   /// 土地原用途
   /// </summary>
   /// <value>The 土地原用途. </value>
   public string TuDiYuanYongTu
   {
          get
          {
                 return _TuDiYuanYongTu;
          }
          set
          {
                 value = _TuDiYuanYongTu;
          }
   }
   private string _TuDiZhongLei;
   /// <summary>
   /// 土地种类
   /// </summary>
   /// <value>The 土地种类. </value>
   public string TuDiZhongLei
   {
          get
          {
                 return _TuDiZhongLei;
          }
          set
          {
                 value = _TuDiZhongLei;
          }
   }
   private string _TuDiDengJi;
   /// <summary>
   /// 土地等级
   /// </summary>
   /// <value>The 土地等级. </value>
   public string TuDiDengJi
   {
          get
          {
                 return _TuDiDengJi;
          }
          set
          {
                 value = _TuDiDengJi;
          }
   }
   private string _TuDiMianJi;
   /// <summary>
   /// 土地面积
   /// </summary>
   /// <value>The 土地面积. </value>
   public string TuDiMianJi
   {
          get
          {
                 return _TuDiMianJi;
          }
          set
          {
                 value = _TuDiMianJi;
          }
   }
   private string _TuDiQuanShuXingZhi;
   /// <summary>
   /// 土地权属性质
   /// </summary>
   /// <value>The 土地权属性质. </value>
   public string TuDiQuanShuXingZhi
   {
          get
          {
                 return _TuDiQuanShuXingZhi;
          }
          set
          {
                 value = _TuDiQuanShuXingZhi;
          }
   }
   private string _TuDiQuanShuDanWei;
   /// <summary>
   /// 土地权属单位
   /// </summary>
   /// <value>The 土地权属单位. </value>
   public string TuDiQuanShuDanWei
   {
          get
          {
                 return _TuDiQuanShuDanWei;
          }
          set
          {
                 value = _TuDiQuanShuDanWei;
          }
   }
   private string _XianZhuangLiYongLeiXing;
   /// <summary>
   /// 现状利用类型
   /// </summary>
   /// <value>The 现状利用类型. </value>
   public string XianZhuangLiYongLeiXing
   {
          get
          {
                 return _XianZhuangLiYongLeiXing;
          }
          set
          {
                 value = _XianZhuangLiYongLeiXing;
          }
   }
   private string _GuiHuaLiYongLeiXing;
   /// <summary>
   /// 规划利用类型
   /// </summary>
   /// <value>The 规划利用类型. </value>
   public string GuiHuaLiYongLeiXing
   {
          get
          {
                 return _GuiHuaLiYongLeiXing;
          }
          set
          {
                 value = _GuiHuaLiYongLeiXing;
          }
   }
   private string _Si_Dong;
   /// <summary>
   /// 四至_东
   /// </summary>
   /// <value>The 四至_东. </value>
   public string Si_Dong
   {
          get
          {
                 return _Si_Dong;
          }
          set
          {
                 value = _Si_Dong;
          }
   }
   private string _Si_Nan;
   /// <summary>
   /// 四至_南
   /// </summary>
   /// <value>The 四至_南. </value>
   public string Si_Nan
   {
          get
          {
                 return _Si_Nan;
          }
          set
          {
                 value = _Si_Nan;
          }
   }
   private string _Si_Xi;
   /// <summary>
   /// 四至_西
   /// </summary>
   /// <value>The 四至_西. </value>
   public string Si_Xi
   {
          get
          {
                 return _Si_Xi;
          }
          set
          {
                 value = _Si_Xi;
          }
   }
   private string _Si_Bei;
   /// <summary>
   /// 四至_北
   /// </summary>
   /// <value>The 四至_北. </value>
   public string Si_Bei
   {
          get
          {
                 return _Si_Bei;
          }
          set
          {
                 value = _Si_Bei;
          }
   }
   private DateTime _LiuZhuanQiXianQ;
   /// <summary>
   /// 流转期限（起）
   /// </summary>
   /// <value>The 流转期限（起）. </value>
   public DateTime LiuZhuanQiXianQ
   {
          get
          {
                 return _LiuZhuanQiXianQ;
          }
          set
          {
                 value = _LiuZhuanQiXianQ;
          }
   }
   private DateTime _LiuZhuanQiXianZ;
   /// <summary>
   /// 流转期限（止）
   /// </summary>
   /// <value>The 流转期限（止）. </value>
   public DateTime LiuZhuanQiXianZ
   {
          get
          {
                 return _LiuZhuanQiXianZ;
          }
          set
          {
                 value = _LiuZhuanQiXianZ;
          }
   }
   private int _TuDiBianHao;
   /// <summary>
   /// 土地编号
   /// </summary>
   /// <value>The 土地编号. </value>
   public int TuDiBianHao
   {
          get
          {
                 return _TuDiBianHao;
          }
          set
          {
                 value = _TuDiBianHao;
          }
   }
   private int _SuoShuXiangZhen;
   /// <summary>
   /// 所属乡镇
   /// </summary>
   /// <value>The 所属乡镇. </value>
   public int SuoShuXiangZhen
   {
          get
          {
                 return _SuoShuXiangZhen;
          }
          set
          {
                 value = _SuoShuXiangZhen;
          }
   }
   private string _SuoShuCun;
   /// <summary>
   /// 所属村
   /// </summary>
   /// <value>The 所属村. </value>
   public string SuoShuCun
   {
          get
          {
                 return _SuoShuCun;
          }
          set
          {
                 value = _SuoShuCun;
          }
   }
   private string _ZhengShouMianJi;
   /// <summary>
   /// 征收面积
   /// </summary>
   /// <value>The 征收面积. </value>
   public string ZhengShouMianJi
   {
          get
          {
                 return _ZhengShouMianJi;
          }
          set
          {
                 value = _ZhengShouMianJi;
          }
   }
   private string _ZhengShouZiJinLaiYuan;
   /// <summary>
   /// 征收资金来源
   /// </summary>
   /// <value>The 征收资金来源. </value>
   public string ZhengShouZiJinLaiYuan
   {
          get
          {
                 return _ZhengShouZiJinLaiYuan;
          }
          set
          {
                 value = _ZhengShouZiJinLaiYuan;
          }
   }
   private string _ZhengShouTuDiYongTu;
   /// <summary>
   /// 征收土地用途
   /// </summary>
   /// <value>The 征收土地用途. </value>
   public string ZhengShouTuDiYongTu
   {
          get
          {
                 return _ZhengShouTuDiYongTu;
          }
          set
          {
                 value = _ZhengShouTuDiYongTu;
          }
   }
   private float _BuChangJinE;
   /// <summary>
   /// 补偿金额
   /// </summary>
   /// <value>The 补偿金额. </value>
   public float BuChangJinE
   {
          get
          {
                 return _BuChangJinE;
          }
          set
          {
                 value = _BuChangJinE;
          }
   }
   private string _SFQianDingHeTong;
   /// <summary>
   /// 合同是否已签订
   /// </summary>
   /// <value>The 合同是否已签订. </value>
   public string SFQianDingHeTong
   {
          get
          {
                 return _SFQianDingHeTong;
          }
          set
          {
                 value = _SFQianDingHeTong;
          }
   }
   private DateTime _QianDingShiJian;
   /// <summary>
   /// 签订时间
   /// </summary>
   /// <value>The 签订时间. </value>
   public DateTime QianDingShiJian
   {
          get
          {
                 return _QianDingShiJian;
          }
          set
          {
                 value = _QianDingShiJian;
          }
   }
   private int _JiaTIngChengYuanShu;
   /// <summary>
   /// 家庭成员数目
   /// </summary>
   /// <value>The 家庭成员数目. </value>
   public int JiaTIngChengYuanShu
   {
          get
          {
                 return _JiaTIngChengYuanShu;
          }
          set
          {
                 value = _JiaTIngChengYuanShu;
          }
   }
   private int _CanJiRenShu;
   /// <summary>
   /// 残疾人数
   /// </summary>
   /// <value>The 残疾人数. </value>
   public int CanJiRenShu
   {
          get
          {
                 return _CanJiRenShu;
          }
          set
          {
                 value = _CanJiRenShu;
          }
   }
   private int _DiBaoRenShu;
   /// <summary>
   /// 低保人数
   /// </summary>
   /// <value>The 低保人数. </value>
   public int DiBaoRenShu
   {
          get
          {
                 return _DiBaoRenShu;
          }
          set
          {
                 value = _DiBaoRenShu;
          }
   }
   private int _LaoDongLiRenShu;
   /// <summary>
   /// 劳动力人数
   /// </summary>
   /// <value>The 劳动力人数. </value>
   public int LaoDongLiRenShu
   {
          get
          {
                 return _LaoDongLiRenShu;
          }
          set
          {
                 value = _LaoDongLiRenShu;
          }
   }
   private int _XuHao;
   /// <summary>
   /// 序号
   /// </summary>
   /// <value>The 序号. </value>
   public int XuHao
   {
          get
          {
                 return _XuHao;
          }
          set
          {
                 value = _XuHao;
          }
   }
   private int _CunMinZu;
   /// <summary>
   /// 村民组
   /// </summary>
   /// <value>The 村民组. </value>
   public int CunMinZu
   {
          get
          {
                 return _CunMinZu;
          }
          set
          {
                 value = _CunMinZu;
          }
   }
   private DateTime _ChengBaoNianXianQ;
   /// <summary>
   /// 承包年限（起）
   /// </summary>
   /// <value>The 承包年限（起）. </value>
   public DateTime ChengBaoNianXianQ
   {
          get
          {
                 return _ChengBaoNianXianQ;
          }
          set
          {
                 value = _ChengBaoNianXianQ;
          }
   }
   private DateTime _ChengBaoNianXianZ;
   /// <summary>
   /// 承包年限（止）
   /// </summary>
   /// <value>The 承包年限（止）. </value>
   public DateTime ChengBaoNianXianZ
   {
          get
          {
                 return _ChengBaoNianXianZ;
          }
          set
          {
                 value = _ChengBaoNianXianZ;
          }
   }
   private string _LiYongLeiXing;
   /// <summary>
   /// 利用类型
   /// </summary>
   /// <value>The 利用类型. </value>
   public string LiYongLeiXing
   {
          get
          {
                 return _LiYongLeiXing;
          }
          set
          {
                 value = _LiYongLeiXing;
          }
   }
   private string _ChengBaoFangShi;
   /// <summary>
   /// 承包方式
   /// </summary>
   /// <value>The 承包方式. </value>
   public string ChengBaoFangShi
   {
          get
          {
                 return _ChengBaoFangShi;
          }
          set
          {
                 value = _ChengBaoFangShi;
          }
   }
   private int _JingYingQuanZhengShuHao;
   /// <summary>
   /// 经营权证书号
   /// </summary>
   /// <value>The 经营权证书号. </value>
   public int JingYingQuanZhengShuHao
   {
          get
          {
                 return _JingYingQuanZhengShuHao;
          }
          set
          {
                 value = _JingYingQuanZhengShuHao;
          }
   }
   private float _HuiZuMianJi;
   /// <summary>
   /// 回租面积
   /// </summary>
   /// <value>The 回租面积. </value>
   public float HuiZuMianJi
   {
          get
          {
                 return _HuiZuMianJi;
          }
          set
          {
                 value = _HuiZuMianJi;
          }
   }
   private DateTime _HuiZuNianXianQ;
   /// <summary>
   /// 回租年限（起）
   /// </summary>
   /// <value>The 回租年限（起）. </value>
   public DateTime HuiZuNianXianQ
   {
          get
          {
                 return _HuiZuNianXianQ;
          }
          set
          {
                 value = _HuiZuNianXianQ;
          }
   }
   private DateTime _HuiZuNianXianZ;
   /// <summary>
   /// 回租年限（止）
   /// </summary>
   /// <value>The 回租年限（止）. </value>
   public DateTime HuiZuNianXianZ
   {
          get
          {
                 return _HuiZuNianXianZ;
          }
          set
          {
                 value = _HuiZuNianXianZ;
          }
   }
   private int _HuiZuXieYiHao;
   /// <summary>
   /// 回租协议号
   /// </summary>
   /// <value>The 回租协议号. </value>
   public int HuiZuXieYiHao
   {
          get
          {
                 return _HuiZuXieYiHao;
          }
          set
          {
                 value = _HuiZuXieYiHao;
          }
   }
   private float _MeiNianMeiMuBuZhuJin;
   /// <summary>
   /// 每年每亩补助金额
   /// </summary>
   /// <value>The 每年每亩补助金额. </value>
   public float MeiNianMeiMuBuZhuJin
   {
          get
          {
                 return _MeiNianMeiMuBuZhuJin;
          }
          set
          {
                 value = _MeiNianMeiMuBuZhuJin;
          }
   }
   private float _MeiNianBuZhuZongE;
   /// <summary>
   /// 每年补助总额
   /// </summary>
   /// <value>The 每年补助总额. </value>
   public float MeiNianBuZhuZongE
   {
          get
          {
                 return _MeiNianBuZhuZongE;
          }
          set
          {
                 value = _MeiNianBuZhuZongE;
          }
   }
   private float _MianJiZengJian;
   /// <summary>
   /// 面积增减
   /// </summary>
   /// <value>The 面积增减. </value>
   public float MianJiZengJian
   {
          get
          {
                 return _MianJiZengJian;
          }
          set
          {
                 value = _MianJiZengJian;
          }
   }
   private float _MianJiZengJianJinE;
   /// <summary>
   /// 面积增减金额
   /// </summary>
   /// <value>The 面积增减金额. </value>
   public float MianJiZengJianJinE
   {
          get
          {
                 return _MianJiZengJianJinE;
          }
          set
          {
                 value = _MianJiZengJianJinE;
          }
   }


   public override System.Reflection.PropertyInfo PrimaryKey()
   {
       return this.GetType().GetProperty("BuChangBianHao", BindingFlags.Public
                    | BindingFlags.Instance | BindingFlags.IgnoreCase);
   }
}