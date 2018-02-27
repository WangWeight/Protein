using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.DAL;

namespace Protein.Enzyme.DAL.Oracle
{
    /// <summary>
    /// ������
    /// </summary>
    public class Filter:IFilter
    {

        private System.Reflection.PropertyInfo usefield ;
        private Operator oprator ;
        private string outchar = "";
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="Field"></param>
        /// <param name="Oprt"></param>
        public Filter(System.Reflection.PropertyInfo Field, Operator Oprt)
        {
            SetFilter(Field, Oprt);
        }

        #region IFilter ��Ա
        /// <summary>
        /// ���ù���
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
        /// ��������ַ���
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
        /// ɸѡ���ֶ�
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
        /// ��������
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
        /// ����ֶ��ַ�
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
