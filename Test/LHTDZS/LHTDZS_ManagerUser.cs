// File:    LHTDZS_ManagerUser.cs
// Author:  Administrator
// Created: 2012��9��18�� 9:59:49
// Purpose: Definition of Class LHTDZS_ManagerUser

using System;
using System.Reflection;
using Protein.Enzyme.DAL;

/// ����Ա�û���Ϣ
public class LHTDZS_ManagerUser :EntityBase, Test.LHTDZS.ILHTDZS_ManagerUser
{
   private long _USER_ID;
   /// <summary>
   /// �û�����
   /// </summary>
   /// <value>The �û�����. </value>
   public long USER_ID
   {
          get
          {
                 return _USER_ID;
          }
          set
          {
                 value = _USER_ID;
          }
   }
   private string _YongHuMing;
   /// <summary>
   /// �û���
   /// </summary>
   /// <value>The �û���. </value>
   public string YongHuMing
   {
          get
          {
                 return _YongHuMing;
          }
          set
          {
                 value = _YongHuMing;
          }
   }
   private string _YongHuMiMa;
   /// <summary>
   /// ����
   /// </summary>
   /// <value>The ����. </value>
   public string YongHuMiMa
   {
          get
          {
                 return _YongHuMiMa;
          }
          set
          {
                 value = _YongHuMiMa;
          }
   }


   public override System.Reflection.PropertyInfo PrimaryKey()
   {
       return this.GetType().GetProperty("USER_ID", BindingFlags.Public
                    | BindingFlags.Instance | BindingFlags.IgnoreCase);
   }
}