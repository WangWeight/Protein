using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.DAL;

namespace Protein.Enzyme.DAL.Oracle
{
    /// <summary>
    /// ¹ýÂËÆ÷
    /// </summary>
    public class Filter:IFilter
    {

        private System.Reflection.PropertyInfo usefield ;
        private Operator oprator ;
        private string outchar = "";
        /// <summary>
        /// ¹ýÂËÆ÷
        /// </summary>
        /// <param name="Field"></param>
        /// <param name="Oprt"></param>
        public Filter(System.Reflection.PropertyInfo Field, Operator Oprt)
        {
            SetFilter(Field, Oprt);
        }

        #region IFilter ³ÉÔ±
        /// <summary>
        /// ÉèÖÃ¹ýÂË
        /// </summary>
        /// <param name="Field"></param>
        /// <param name="Oprt"></param>
        public void SetFilter(System.Reflection.PropertyInfo Field, Operator Oprt)
        {
            this.usefield = Field;
            this.oprator = Oprt;
            SetOutChar();
        }
        /// <summary>
        /// ÉèÖÃÊä³ö×Ö·û´®
        /// </summary>
       protected virtual void  SetOutChar()
       {
           if (this.OperatorSign== Operator.Fun_Max)
           {
               if (this.Usefield.PropertyType != typeof(int) || this.Usefield.PropertyType != typeof(long))
               {
                   this.outchar = "to_number(" + this.Usefield.Name + ")";
               }
               else
               {
                   this.outchar =this.Usefield.Name;
               }
           }
       }

        /// <summary>
        /// É¸Ñ¡µÄ×Ö¶Î
        /// </summary>
        public System.Reflection.PropertyInfo Usefield
        {
            get
            {
                return this.usefield;
            }
            set
            {
                this.usefield = value;
            }
        }

        /// <summary>
        /// ²Ù×÷·ûºÅ
        /// </summary>
        public Operator OperatorSign
        {
            get
            {
                return this.oprator;
            }
            set
            {
                this.oprator = value;
            }
        }

          
        /// <summary>
        /// Êä³ö×Ö¶Î×Ö·û
        /// </summary>
        public string OutPutFieldChar
        {
            get
            {
                return this.outchar;
            
            }
        }

        #endregion
    }
}
