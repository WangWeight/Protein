// File:    LHTDZS_ManagerUser.cs
// Author:  Administrator
// Created: 2012年9月18日 9:59:49
// Purpose: Definition of Class LHTDZS_ManagerUser

using System;
using System.Reflection;
using Protein.Enzyme.DAL;

/// 管理员用户信息
public class LHTDZS_ManagerUser :EntityBase, Test.LHTDZS.ILHTDZS_ManagerUser
{
   private long _USER_ID;
   /// <summary>
   /// 用户编码
   /// </summary>
   /// <value>The 用户编码. </value>
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
   /// 用户名
   /// </summary>
   /// <value>The 用户名. </value>
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
   /// 密码
   /// </summary>
   /// <value>The 密码. </value>
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