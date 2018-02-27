using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Protein.Enzyme.DAL;

namespace Protein.Enzyme.DAL.MDB.Command
{
    /// <summary>
    /// 插入语句配置类
    /// </summary>
    public class InsertCmd : StockCmd
    {
        /// <summary>
        /// 创建命令
        /// </summary>
        /// <param name="Table"></param>
        public override void CreateCmd(IDvTable Table)
        {
            string cmd = "INSERT INTO " + Table.Entity.GetType().Name + " ";
            string fields = "";
            string values = "";
            Type t = Table.Entity.GetType();
            foreach (PropertyInfo pi in Table.Entity.GetFields())
            {
                if (!IsNotNull(pi, Table.Entity))
                {
                    continue;
                }
                string f = pi.Name;
                string v = ":" + pi.Name;
                if (fields == "")
                {
                    fields = f;
                    values = v;
                }
                else
                {
                    fields = fields + "," + f;
                    values = values + "," + v;
                }
                base.AddPar(pi, Table.Entity);
            }
            fields = "(" + fields + ")";
            values = "(" + values + ")";
            cmd = cmd + fields + " VALUES " + values;
            this.Cmd = cmd;
        }

         


        //protected string SetInsertInto(string s, IDvTable Table)
        //{
        //    string result = "[" + s + "]";
        //    string row = null;
            
        //    foreach (string w in Table.SetInsertInto)
        //    {
        //        if (row == null)
        //        {
        //            row = "[" + w + "]";
        //        }
        //        else
        //        {
        //            row = row + ",[" + w + "]";
        //        }
        //    }
        //    result = result + "(" + row + ")";
        //    return result;
        //}

        //protected string SetInsertValue(IDvTable Table)
        //{
        //    string result = null;
        //    string row = null;
        //    foreach (string w in Table.SetInsertValue)
        //    {
        //        if (row == null)
        //        {
        //            row = "'" + w + "'";
        //        }
        //        else
        //        {
        //            row = row + ",'" + w + "'";
        //        }
        //    }
        //    result = "(" + row + ")";
        //    return result;
        //}

        protected bool IsNotNull(PropertyInfo Pi, IEntityBase Entity)
        {
            if (Pi.GetValue(Entity, null) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
