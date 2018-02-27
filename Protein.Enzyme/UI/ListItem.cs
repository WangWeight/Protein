using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protein.Enzyme.UI
{
    /// <summary>
    /// 选择项类，用于ComboBox或者ListBox添加项
    /// </summary>
    public class ListItem
    {
        private string id = string.Empty;
        private string name = string.Empty;
        private object value = null;
        ////可以根据自己的需求继续添加,如：private Int32 m_Index；
        /// <summary>
        /// 
        /// </summary>
        public ListItem()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sid"></param>
        /// <param name="sname"></param>
        public ListItem(string sid, string sname)
        {
            id = sid;
            name = sname;
        }
        /// <summary>
        /// 显示在控件上的值
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.name;
        }
        /// <summary>
        /// id
        /// </summary>
        public string ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        /// <summary>
        /// 值
        /// </summary>
        public object Value
        {
            get {
                return this.value;
            }
            set {
                this.value = value;
            }
        }
    }



}
