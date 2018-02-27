using System;
using System.Collections.Generic; 
using System.Text;
using System.ComponentModel;


namespace Protein.Enzyme.DAL.Oracle.Command
{
    /// <summary>
    /// √¸¡Ó¿‡–Õ
    /// </summary>
    public enum CmdType:int
    {
        /// <summary>
        /// select
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
