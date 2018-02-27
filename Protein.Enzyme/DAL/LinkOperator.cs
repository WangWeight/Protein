using System;
using System.Collections.Generic; 
using System.Text;
using System.ComponentModel;

namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// ×ÓÓï¾äÂß¼­ÔËËã·¨
    /// </summary>
    public enum LinkOperator:int
    {
        /// <summary>
        /// and
        /// </summary>
        [Description("and")]
        and = 0,
        /// <summary>
        /// or
        /// </summary>
        [Description("or")]
        or = 1,
        /// <summary>
        /// null
        /// </summary>
        [Description("null")]
        nul = 2,
      

         
    }
}
