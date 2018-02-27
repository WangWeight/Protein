using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Protein.Enzyme.DAL;
namespace Protein.Enzyme.DAL.Oracle.Command
{
    /// <summary>
    /// ≤Â»Î”Ôæ‰≈‰÷√¿‡
    /// </summary>
    public class InsertCmd:StockCmd
    {
        /// <summary>
        /// ¥¥Ω®√¸¡Ó
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
                if (!IsNotNull(pi,Table.Entity))
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
                base.AddPar(pi,Table.Entity);
            }
            fields = "(" + fields + ")";
            values = "(" + values + ")";
            cmd = cmd + fields + " VALUES " + values;
            this.Cmd = cmd;
        }

        /// <summary>
        /// ºÏ≤È◊÷∂Œ «∑ÒŒ™ø’
        /// </summary>
        /// <param name="Pi"></param>
        /// <returns></returns>
        protected bool IsNotNull(PropertyInfo Pi,IEntityBase Entity)
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
