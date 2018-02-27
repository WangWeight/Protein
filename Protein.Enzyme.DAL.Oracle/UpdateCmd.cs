using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Protein.Enzyme.DAL;
namespace Protein.Enzyme.DAL.Oracle.Command
{
    /// <summary>
    /// ������� 
    /// </summary>
    public class UpdateCmd : SelectCmd
    {
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="Table"></param> 
        public override void CreateCmd(IDvTable Table)
        { 
            this.Cmd = "UPDATE   " + Table.Entity.GetType().Name + "  ";
            UpdateValue(Table);
            if (Table.Wherelist.Count > 0)
            {
                this.Cmd = SetWhere(Table, this.Cmd);
            } 
        }

        /// <summary>
        /// ���ø���ֵ
        /// </summary>
        protected void UpdateValue(IDvTable Table)
        {
            string cmd = "";
            foreach (PropertyInfo pi in Table.Entity.GetFields())
            {
                base.AddPar(pi, Table.Entity);
                if (cmd == "")
                {
                    cmd = " SET " + pi.Name + "=:" + pi.Name;
                }
                else
                {
                    cmd = cmd + "," + pi.Name + "=:" + pi.Name;
                }
            }
            this.Cmd = this.Cmd + cmd;

        }

    }
}
