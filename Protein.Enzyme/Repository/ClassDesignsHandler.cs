using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.Design;


namespace Protein.Enzyme.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public static class ClassDesignsHandler
    {
        /// <summary>
        /// 从代理对象获取对象的类型
        /// </summary>
        /// <param name="Obj"></param>
        /// <returns></returns>
        public static Type GetObjTypeFromProxy(this object Obj)
        { 
            Type t = null;
            if (Obj != null)
            {
                if (Obj.GetType().FullName.Substring(0, 11).ToUpper() ==  Protein.Enzyme.DynamicProxy.DefProxy.ProxyMark.ToUpper())
                {
                    t = Obj.GetType().BaseType;
                }
                else
                {
                    t = Obj.GetType();
                }
            }
            return t;
        }
    }
}
