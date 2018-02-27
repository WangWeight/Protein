// File:    LHTDZS_SZDBCJL.cs
// Author:  Administrator
// Created: 2012��9��18�� 9:59:49
// Purpose: Definition of Class LHTDZS_SZDBCJL

using System;
using System.Reflection;
using Protein.Enzyme.DAL;
/// ����ز�����¼��
public class LHTDZS_SZDBCJL :EntityBase, Test.LHTDZS.ILHTDZS_SZDBCJL 
{
   /// ��������+��ˮ
   private string _BuChangBianHao;
   /// <summary>
   /// �������
   /// </summary>
   /// <value>The �������. </value>
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
   /// ����������
   /// </summary>
   /// <value>The ����������. </value>
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
   /// ������
   /// </summary>
   /// <value>The ������. </value>
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
   /// �Ա�
   /// </summary>
   /// <value>The �Ա�. </value>
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
   /// ����
   /// </summary>
   /// <value>The ����. </value>
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
   /// ��ϵ�绰
   /// </summary>
   /// <value>The ��ϵ�绰. </value>
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
   /// ��������
   /// </summary>
   /// <value>The ��������. </value>
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
   /// ���п���
   /// </summary>
   /// <value>The ���п���. </value>
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
   /// ���֤
   /// </summary>
   /// <value>The ���֤. </value>
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
   /// ��ͥ��ַ
   /// </summary>
   /// <value>The ��ͥ��ַ. </value>
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
   /// �Ƿ���֧��
   /// </summary>
   /// <value>The �Ƿ���֧��. </value>
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
   /// ֧��ʱ��
   /// </summary>
   /// <value>The ֧��ʱ��. </value>
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
   /// ��ע
   /// </summary>
   /// <value>The ��ע. </value>
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
   /// ��������
   /// </summary>
   /// <value>The ��������. </value>
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
   /// ����ԭ��;
   /// </summary>
   /// <value>The ����ԭ��;. </value>
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
   /// ��������
   /// </summary>
   /// <value>The ��������. </value>
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
   /// ���صȼ�
   /// </summary>
   /// <value>The ���صȼ�. </value>
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
   /// �������
   /// </summary>
   /// <value>The �������. </value>
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
   /// ����Ȩ������
   /// </summary>
   /// <value>The ����Ȩ������. </value>
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
   /// ����Ȩ����λ
   /// </summary>
   /// <value>The ����Ȩ����λ. </value>
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
   /// ��״��������
   /// </summary>
   /// <value>The ��״��������. </value>
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
   /// �滮��������
   /// </summary>
   /// <value>The �滮��������. </value>
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
   /// ����_��
   /// </summary>
   /// <value>The ����_��. </value>
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
   /// ����_��
   /// </summary>
   /// <value>The ����_��. </value>
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
   /// ����_��
   /// </summary>
   /// <value>The ����_��. </value>
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
   /// ����_��
   /// </summary>
   /// <value>The ����_��. </value>
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
   /// ��ת���ޣ���
   /// </summary>
   /// <value>The ��ת���ޣ���. </value>
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
   /// ��ת���ޣ�ֹ��
   /// </summary>
   /// <value>The ��ת���ޣ�ֹ��. </value>
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
   /// ���ر��
   /// </summary>
   /// <value>The ���ر��. </value>
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
   /// ��������
   /// </summary>
   /// <value>The ��������. </value>
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
   /// ������
   /// </summary>
   /// <value>The ������. </value>
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
   /// �������
   /// </summary>
   /// <value>The �������. </value>
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
   /// �����ʽ���Դ
   /// </summary>
   /// <value>The �����ʽ���Դ. </value>
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
   /// ����������;
   /// </summary>
   /// <value>The ����������;. </value>
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
   /// �������
   /// </summary>
   /// <value>The �������. </value>
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
   /// ��ͬ�Ƿ���ǩ��
   /// </summary>
   /// <value>The ��ͬ�Ƿ���ǩ��. </value>
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
   /// ǩ��ʱ��
   /// </summary>
   /// <value>The ǩ��ʱ��. </value>
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
   /// ��ͥ��Ա��Ŀ
   /// </summary>
   /// <value>The ��ͥ��Ա��Ŀ. </value>
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
   /// �м�����
   /// </summary>
   /// <value>The �м�����. </value>
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
   /// �ͱ�����
   /// </summary>
   /// <value>The �ͱ�����. </value>
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
   /// �Ͷ�������
   /// </summary>
   /// <value>The �Ͷ�������. </value>
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
   /// ���
   /// </summary>
   /// <value>The ���. </value>
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
   /// ������
   /// </summary>
   /// <value>The ������. </value>
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
   /// �а����ޣ���
   /// </summary>
   /// <value>The �а����ޣ���. </value>
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
   /// �а����ޣ�ֹ��
   /// </summary>
   /// <value>The �а����ޣ�ֹ��. </value>
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
   /// ��������
   /// </summary>
   /// <value>The ��������. </value>
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
   /// �а���ʽ
   /// </summary>
   /// <value>The �а���ʽ. </value>
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
   /// ��ӪȨ֤���
   /// </summary>
   /// <value>The ��ӪȨ֤���. </value>
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
   /// �������
   /// </summary>
   /// <value>The �������. </value>
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
   /// �������ޣ���
   /// </summary>
   /// <value>The �������ޣ���. </value>
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
   /// �������ޣ�ֹ��
   /// </summary>
   /// <value>The �������ޣ�ֹ��. </value>
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
   /// ����Э���
   /// </summary>
   /// <value>The ����Э���. </value>
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
   /// ÿ��ÿĶ�������
   /// </summary>
   /// <value>The ÿ��ÿĶ�������. </value>
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
   /// ÿ�겹���ܶ�
   /// </summary>
   /// <value>The ÿ�겹���ܶ�. </value>
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
   /// �������
   /// </summary>
   /// <value>The �������. </value>
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
   /// ����������
   /// </summary>
   /// <value>The ����������. </value>
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