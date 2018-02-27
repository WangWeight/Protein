using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Protein.Enzyme.DAL;
namespace Protein.Enzyme.DAL.Oracle.Command
{
    /// <summary>
    /// 删除语句
    /// and or 顺加下去 
    /// </summary>
    public class DeleteCmd :SelectCmd
    { 
        /// <summary>
        /// 创建命令
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
