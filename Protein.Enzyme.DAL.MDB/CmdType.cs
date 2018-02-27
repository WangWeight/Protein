using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Protein.Enzyme.DAL.MDB.Command
{
    /// <summary>
    /// 命令类型
    /// </summary>
    public enum CmdType : int
    {
        /// <summary>
        /// Select
        /// </summary>
        [Description("Select")]
        Select = 0,
        /// <summary>
        /// Insert
        /// </summary>
        [Description("Insert")]
        Insert = 1,
        /// <summary>
        /// Delete
        /// </summary>
        [Description("Delete")]
        Delete = 2,
        /// <summary>
        /// Update
        /// </summary>
        [Description("Update")]
        Update = 3,
    }
}
