using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;
using System.ComponentModel;
using Protein.Enzyme.DAL.MDB.Command;
using Protein.Enzyme.DAL;
using System.Collections;

namespace Protein.Enzyme.DAL.MDB
{
    /// <summary>
    /// 数据表基类
    /// </summary>
    public class DvTable : IDvTable
    {
        #region 实体基础操作

        List<IDvWhere> wherelist = new List<IDvWhere>();

        public List<IDvWhere> Wherelist
        {
            get { return wherelist; }
            set { wherelist = value; }
        }

        IDalSql setup = null;
        public DvTable(IDalSql Setup)
        {
            setup = Setup;
            this.InClause = new InClause();
        }

        IJoinEntity join = new JoinEntity();

        /// <summary>
        /// 联立的实体类包装接口
        /// </summary>
        public IJoinEntity Join
        {
            get
            {
                return join;
            }
            set
            {
                this.join = value;
            }
        }

        public IEntityBase entity = null;

        /// <summary>
        /// 操作的实体对象
        /// </summary>
        public IEntityBase Entity
        {
            get
            {
                return this.entity;
            }
            set
            {
                this.entity = value;
            }
        }


        #endregion

        #region 查询
        /// <summary>
        /// 检查字段是否存在 不存在直接抛出异常
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="FieldName"></param>
        protected virtual void CheckField(IEntityBase Entity, string FieldName)
        {
            if (Entity.GetField(FieldName) == null)
            {
                throw new Exception("驱动表格没找到实体的指定字段：" + this.entity.ToString() +　" " + FieldName);
            }
        }


        /// <summary>
        /// 创建语句
        /// </summary>
        /// <param name="JoinEntity"></param>
        /// <param name="FieldName"></param>
        /// <param name="OperatorType"></param>
        /// <param name="LinkNextOperator"></param>
        protected void CreateWhereClause(IEntityBase JoinEntity, string FieldName, Operator OperatorType, LinkOperator LinkNextOperator)
        {
            this.CheckField(JoinEntity, FieldName);
            IDvWhere newpw = new DvWhere();
            newpw.ClauseItem(JoinEntity, JoinEntity.GetType().GetProperty(FieldName)
                , GetDescription(OperatorType), GetDescription(LinkNextOperator));
            newpw.OperatorItem = OperatorType;
            this.wherelist.Add(newpw);
        }

        /// <summary>
        /// 创建查询条件子语句
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="OperatorType"></param>
        /// <param name="LinkNextOperator"></param>
        public void WhereClause(string FieldName, Operator OperatorType, LinkOperator LinkNextOperator)
        {
            CreateWhereClause(this.entity, FieldName, OperatorType, LinkNextOperator);
        }

        /// <summary>
        /// 创建条件子语句，指定要作为条件子语句的实体对象
        /// </summary>
        /// <param name="JoinEntity">在联立的实体对象中查找</param>
        /// <param name="FieldName">字段名</param>
        /// <param name="OperatorType">运算符</param>
        /// <param name="LinkNextOperator">其后的逻辑操作符，当存在多个条件时，确定他们之间的关系</param>
        public void WhereClause(IEntityBase JoinEntity, string FieldName, Operator OperatorType, LinkOperator LinkNextOperator)
        {
            if (this.join.Entitys.Contains(JoinEntity))
            {
                CreateWhereClause(JoinEntity, FieldName, OperatorType, LinkNextOperator);
            }
        }

        /// <summary>
        /// 配置select   查询条件子语句的匹配
        /// 实现单表 多条件查询
        /// </summary>
        /// <returns></returns>
        public DataSet Select()
        {
            return this.setup.SelectSingle(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Table"></param>
        /// <returns></returns>
        public DataSet Select(IDvTable Table)
        {
            return this.setup.SelectSingle(Table);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> SelectEntity<T>()
        {
            DataSet ds = Select();
            T obj = default(T);
            DataHelper dte = new DataHelper();
            return dte.ConvertToEntity<T>(ds);
        }

        #endregion

        #region 插入

        /// <summary>
        /// 把表对象的属性都作为字段和值添加到插入语句中
        /// 生成插入语句
        /// </summary>
        /// <returns>返回影响行数</returns>
        public int Insert()
        {
            int count = setup.Insert(this);
            return count;
        }

        
        #endregion

        #region 删除

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public int Delete()
        {
            int count = setup.Delete(this);
            return count;
        }

        public int Delete(IDvTable Table)
        {
            int count = setup.Delete(Table);
            return count;
        }

        #endregion

        #region 更新

        /// <summary>
        /// 
        /// 更新
        /// </summary>
        /// <returns></returns>
        public int Update()
        {
            int count = setup.Update(this);
            return count;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Table"></param>
        /// <returns></returns>
        public int Update(IDvTable Table)
        {
            int count = setup.Update(Table);
                return count;
        }
        #endregion

        #region 设置分组

        public IGroupBy GetGroupBy { get; set; }

        /// <summary>
        /// 设置分组字段
        /// </summary>
        /// <param name="FieldName"></param>
        public void SetGroupBy(string FieldName)
        {
            if (this.GetGroupBy == null)
            {
                this.GetGroupBy = new GroupBy();
            }
            
            this.GetGroupBy.SetField(FieldName);
        }

        #endregion 

        #region 筛选器

        System.Collections.Generic.List<IFilter> filterlist = new List<IFilter>();
        /// <summary>
        /// 筛选过滤器
        /// </summary>
        public System.Collections.Generic.List<IFilter> Filterlist
        {
            get { return this.filterlist; }
            set { this.filterlist = value; }
        }

        /// <summary>
        /// 设置字段筛选
        /// </summary>
        /// <param name="OperatorType"></param>
        /// <param name="FieldName"></param>
        public void SetFilter(Operator OperatorType, string FieldName)
        {
            IFilter flt = new Filter(this.entity.GetField(FieldName), OperatorType);
            this.filterlist.Add(flt);
        }
        #endregion 

        #region 获取枚举解释值
        /// <summary>
        /// 获取枚举变量值的 Description 属性
        /// </summary>
        /// <param name="obj">枚举变量</param>
        /// <returns>如果包含 Description 属性，则返回 Description 属性的值，否则返回枚举变量值的名称</returns>
        private string GetDescription(object obj)
        {
            return GetDescription(obj, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="isTop"></param>
        /// <returns></returns>
        private string GetDescription(object obj, bool isTop)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            Type _enumType = obj.GetType();
            DescriptionAttribute dna = null;
            if (isTop)
            {
                dna = (DescriptionAttribute)Attribute.GetCustomAttribute(_enumType, typeof(DescriptionAttribute));
            }
            else
            {
                FieldInfo fi = _enumType.GetField(Enum.GetName(_enumType, obj));
                dna = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
            }
            if (dna != null && string.IsNullOrEmpty(dna.Description) == false)
            {
                return dna.Description;
            }
            return obj.ToString();
        }

        #endregion

        #region 设置select条件语句

        //private string test1 = null;

        //public string Test1
        //{
        //    get
        //    {
        //        return this.test1;
        //    }
        //    set
        //    {
        //        this.test1 = value;
        //    }
        //}
        private List<string> setselect = new List<string>();
        public List<string> SetSelect
        {
            get
            {
                return this.setselect;
            }
            set
            {
                this.setselect = value;
            }
        }

        #endregion

        #region 设置from条件语句

        //private string []test2 = null;
        //private static int i = 0;

        //public string Test2[int t]
        //{
        //    get
        //    {
        //        return this.test2[t];
        //    }
        //    set
        //    {
        //        this.test2[i] = value;
        //        i++;
        //    }
        //}
        private List<string> setfrom = new List<string>();
        public List<string> SetFrom
        {
            get 
            {
                return this.setfrom;
            }
            set
            {
                this.setfrom = value;
            }
        }

        #endregion

        #region 设置where条件语句

        //private string test3 = null;

        //public string Test3
        //{
        //    get
        //    {
        //        return this.test3;
        //    }
        //    set
        //    {
        //        this.test3 = value;
        //    }
        //}
        private List<string> setwherefirst = new List<string>();
        public List<string> SetWhereFrist
        {
            get
            {
                return this.setwherefirst;
            }
            set
            {
                this.setwherefirst = value;
            }
        }

        private ArrayList setwherelast = new ArrayList();
        public ArrayList SetWhereLast
        {
            get
            {
                return this.setwherelast;
            }
            set
            {
                this.setwherelast = value;
            }
        }

        #endregion

        #region 设置delete语句

        private List<string> setdelete = new List<string>();
        public List<string> SetDelete
        {
            get
            {
                return this.setdelete;
            }
            set
            {
                this.setdelete = value;
            }
        }

        #endregion

        #region 设置insert语句

        private List<string> setinsertinto = new List<string>();
        public List<string> SetInsertInto
        {
            get
            {
                return this.setinsertinto;
            }
            set
            {
                this.setinsertinto = value;
            }
        }

        private List<string> setinsertvalue = new List<string>();
        public List<string> SetInsertValue
        {
            get
            {
                return this.setinsertvalue;
            }
            set
            {
                this.setinsertvalue = value;
            }
        }

        #endregion

        #region 设置update语句

        private List<string> setupdatesetfrist = new List<string>();
        public List<string> SetUpdateSetFrist
        {
            get
            {
                return this.setupdatesetfrist;
            }
            set
            {
                this.setupdatesetfrist = value;
            }
        }

        private List<string> setupdatesetlast = new List<string>();
        public List<string> SetUpdateSetLast
        {
            get
            {
                return this.setupdatesetlast;
            }
            set
            {
                this.setupdatesetlast = value;
            }
        }

        #endregion

        #region 设置table语句

        private string settablename = null;
        public string SetTableName
        {
            get
            {
                return this.settablename;
            }
            set
            {
                this.settablename = value;
            }
        }

        #endregion

        public InClauseOperator InClause { get; set; }
    }
}
