using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.DAL;

namespace Protein.Enzyme.DAL.MDB
{
    /// <summary>
    /// 过滤器
    /// </summary>
    public class Filter : IFilter
    {
        private System.Reflection.PropertyInfo usefield;
        private Operator oprator;
        private string outchar = "";

        public Filter(System.Reflection.PropertyInfo Field, Operator Oprt)
        {
            SetFilter(Field, Oprt);
        }

        #region IFilter 成员
        /// <summary>
        /// 设置过滤
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
        /// 设置输出字符串
        /// </summary>
        protected virtual void SetOutChar()
        {
            if (this.OperatorSign == Operator.Fun_Max)
            {
                //if (this.Usefield.PropertyType != typeof(int) || this.Usefield.PropertyType != typeof(long))
                //{
                //    this.outchar = "to_number(" + this.Usefield.Name + ")";
                //}
                //else
                //{
                    this.outchar = this.Usefield.Name;
                //}
            }
            else if (this.OperatorSign == Operator.Count)
            {
                this.outchar = this.Usefield.Name;
            }
        }

        /// <summary>
        /// 筛选的字段
        /// </summary>
        public System.Reflection.PropertyInfo Usefield
        {
            get { return this.usefield; }
            set { this.usefield = value; }
        }

        /// <summary>
        /// 操作符号
        /// </summary>
        public Operator OperatorSign
        {
            get { return this.oprator; }
            set { this.oprator = value; }
        }

        /// <summary>
        /// 输出字段字符
        /// </summary>
        public string OutPutFieldChar
        {
            get { return this.outchar; }
        }
        #endregion
    }
}
