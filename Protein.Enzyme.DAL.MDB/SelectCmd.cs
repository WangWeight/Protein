using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Protein.Enzyme.DAL;

namespace Protein.Enzyme.DAL.MDB.Command
{
    /// <summary>
    /// 查询语句配置类
    /// and or 顺加下去
    /// </summary>
    public class SelectCmd : StockCmd
    {


        /// <summary>
        /// 创建命令
        /// </summary>
        /// <param name="Table"></param> 
        public override void CreateCmd(IDvTable Table)
        {
            string cmd = "SELECT " + SetFilter(Table) + "  FROM " + SetEntity(Table) + " " + SetGroupByKey(Table) + SetGroupBy(Table);
            if (Table.Wherelist.Count > 0)
            {
                this.Cmd = SetWhere(Table, cmd);
            }
            else
            {
                this.Cmd = cmd;
            }

        }
         

        /// <summary>
        /// 设置实体字符串
        /// </summary>
        /// <param name="Table"></param>
        /// <returns></returns>
        protected string SetEntity(IDvTable Table)
        {
            //Table.Entity = "";
            string result = "[" + Table.Entity.GetType().Name + "]";
            //string result = "[table]";
            foreach (IEntityBase eb in Table.Join.Entitys)
            {
                result = result + "," + "[" + eb.GetType().Name + "]";
            }
            return result;
        }


       


        /// <summary>
        /// 设置语句的字段
        /// </summary>
        /// <param name="Table"></param>
        /// <returns></returns>
        protected string SetFilter(IDvTable Table)
        { 
            string result = "";
            foreach (IFilter fl in Table.Filterlist)
            {
                string tmp = Oprator(fl);
                if (result == "")
                {
                    result =  tmp  ;
                }
                else
                {
                    result = result + "," +  tmp  ;
                }
            }

            //加上聚合字段值
            if (result == "")
            {
                result = SetGroupBy(Table);

            }
            else if (Table.GetGroupBy!=null)
            {
                result = result + "," + SetGroupBy(Table);
            }

            //
            if (result == "")
            {
                result = "*";
            }
            
            return result;
        }

        protected string SetGroupByKey(IDvTable Table)
        {
            if (Table.GetGroupBy == null)
            {
                return "";
            }
            else
            {
                return Table.GetGroupBy.OutPutFieldChar;
            }
        }
        /// <summary>
        /// 设置分组字段
        /// </summary>
        /// <param name="Table"></param>
        /// <returns></returns>
        protected string SetGroupBy(IDvTable Table)
        {
            string result = "";
            if (Table.GetGroupBy == null)
            {
                return result;
            }
            for (int i = 0; i < Table.GetGroupBy.UseField.Count; i++)
            {
                if (i == 0)
                {
                    result = Table.GetGroupBy.UseField[i];
                }
                else
                {
                    result =result+","+ Table.GetGroupBy.UseField[i];
                }
            }
            return result;

        }

        /// <summary>
        /// 操作符号
        /// </summary>
        /// <param name="Fl"></param>
        /// <returns></returns>
        protected string Oprator(IFilter Fl)
        {
            string result = "";
            switch (Fl.OperatorSign)
            {
                case Operator.Fun_Max:
                    result = "MAX(" + Fl.OutPutFieldChar + ")";
                    break;
                case Operator.Count:
                    result = "COUNT(" + Fl.OutPutFieldChar + ") AS Count_" + Fl.OutPutFieldChar;
                    break;
                default:
                    break;
            }
            return result;
        }

        
        /// <summary>
        /// 这个方法应该用职责链或者策略来做 或者适配器
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="Cmd"></param>
        /// <returns></returns>
        protected string SetWhere(IDvTable Table, string Cmd)
        {
            Type t = Table.Entity.GetType();
            string lastopr = "";
            string cul = SetJoinChar(Table);
            if (cul != "")
            {
                cul = "WHERE " + cul + " AND ";
            }
            foreach (IDvWhere pw in Table.Wherelist)
            { 
                
                //添加重复的键值 主键无法update 或者说是无法根据自己更新自己
                if (pw.OperatorItem == Operator.In)
                {
                    base.AddParWhere(pw.Usefield, pw.Entity, pw.OperatorItem,Table);
                }
                else
                {
                    base.AddParWhere(pw.Usefield, pw.Entity, pw.OperatorItem);
                }
                if (cul == "")
                {
                    cul = "WHERE ";
                    if (pw.LinknextOperator != "null")
                    {
                        lastopr = pw.LinknextOperator;
                        cul = cul + pw.Clause + " " + pw.LinknextOperator;
                    }
                    else
                    {
                        cul = cul + pw.Clause;
                        break;
                    }
                }
                else
                {
                    if (pw.LinknextOperator != "null")
                    {
                        lastopr = pw.LinknextOperator;
                        cul = cul + " " + pw.Clause + " " + pw.LinknextOperator;
                    }
                    else
                    {
                        lastopr = pw.LinknextOperator;
                        cul = cul + " " + pw.Clause;
                        break;
                    }
                }
            }
            cul = Cmd + " " + cul;
            return cul;
        }





        /// <summary>
        /// 设置联立表外键关联字符串
        /// </summary>
        /// <param name="Table"></param>
        /// <returns></returns>
        protected string SetJoinChar(IDvTable Table)
        {
            string result = "";
            foreach (IEntityBase eb in Table.Join.Entitys)
            {
                if (result == "")
                {
                    result = Table.Join.JoinField(Table.Entity, eb);
                }
                else
                {
                    result = result + "AND" + Table.Join.JoinField(Table.Entity, eb);
                }
            }
            return result;
        }

       
        
    }
}
