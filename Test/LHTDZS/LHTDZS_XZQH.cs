// File:    LHTDZS_XZQH.cs
// Author:  Administrator
// Created: 2012��9��18�� 9:59:49
// Purpose: Definition of Class LHTDZS_XZQH

using System;
using System.Reflection;
using Protein.Enzyme.DAL;

public class LHTDZS_XZQH : EntityBase, Test.LHTDZS.ILHTDZS_XZQH
{
    private string _XingZhengQuDaiMa = "";
    /// <summary>
    /// ����������
    /// </summary>
    /// <value>The ����������. </value>
    public string XingZhengQuDaiMa
    {
        get
        {
            return _XingZhengQuDaiMa;
        }
        set
        {
            _XingZhengQuDaiMa = value;
        }
    }
    private string _ShangJiDaiMa;
    /// <summary>
    /// �ϼ�����
    /// </summary>
    /// <value>The �ϼ�����. </value>
    public string ShangJiDaiMa
    {
        get
        {
            return _ShangJiDaiMa;
        }
        set
        {
            _ShangJiDaiMa = value;
        }
    }
    private double _JiBie;
    /// <summary>
    /// ����
    /// </summary>
    /// <value>The ����. </value>
    public double JiBie
    {
        get
        {
            return _JiBie;
        }
        set
        {
            _JiBie = value;
        }
    }
    private string _MingCheng;
    /// <summary>
    /// ����
    /// </summary>
    /// <value>The ����. </value>
    public string MingCheng
    {
        get
        {
            return _MingCheng;
        }
        set
        {
            _MingCheng = value;
        }
    }
    private string _ChengXiangFenLei;
    /// <summary>
    /// �������
    /// </summary>
    /// <value>The �������. </value>
    public string ChengXiangFenLei
    {
        get
        {
            return _ChengXiangFenLei;
        }
        set
        {
            _ChengXiangFenLei = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override System.Reflection.PropertyInfo PrimaryKey()
    {
        return this.GetType().GetProperty("XingZhengQuDaiMa", BindingFlags.Public
                     | BindingFlags.Instance | BindingFlags.IgnoreCase);
    }

}