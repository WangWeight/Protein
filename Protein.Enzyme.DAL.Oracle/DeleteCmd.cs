using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Protein.Enzyme.DAL;
namespace Protein.Enzyme.DAL.Oracle.Command
{
    /// <summary>
    /// ɾ�����
    /// and or ˳����ȥ 
    /// </summary>
    public class DeleteCmd :SelectCmd
    { 
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="Table"></param> 
        public override void CreateCmd(IDvTable Table) 
        { 
            string cmd = "DELETE  FROM " + Table.Entity.GetType().Name + "  ";
            if (Table.Wherelist.Count > 0)
            {
                this.Cmd = SetWhere(Table,cmd); 
            }
            else
            {
                this.Cmd = cmd;
            }
            
        }

        


    }
}
