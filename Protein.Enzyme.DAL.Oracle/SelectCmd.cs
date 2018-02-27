using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Protein.Enzyme.DAL;

namespace Protein.Enzyme.DAL.Oracle.Command
{
    /// <summary>
    /// ��ѯ���������
    /// and or ˳����ȥ 
    /// </summary>
    public class SelectCmd:StockCmd
    { 
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="Table"></param> 
        public override void CreateCmd(IDvTable Table) 
        {
            string cmd = "SELECT " + SetFilter(Table) + "  FROM " + SetEntity(Table) + " ";//Table.Entity.GetType().Name
            if (Table.Wherelist.Count > 0)
            {
                this.Cmd = SetWhere(Table,cmd); 
            }
            else
            {
                this.Cmd = cmd;
            }
            
        }
        /// <summary>
        /// ����ʵ���ַ���
        /// </summary>
        /// <returns></returns>
        protected string SetEntity(IDvTable Table)
        {
            string result = Table.Entity.GetType().Name;
            foreach (IEntityBase eb in Table.Join.Entitys)
            { 
                result =result+","+ eb.GetType().Name; 
            }
            return result;
        }


        /// <summary>
        /// ���������ֶ�
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="Cmd"></param>
        /// <returns></returns>
        protected string SetFilter(IDvTable Table)
        { 
            string result="";
            foreach (IFilter fl in Table.Filterlist)
            {
               string tmp= Oprator(fl);
               if (result == "")
               {
                   result = tmp;
               }
               else
               {
                   result = result + "," + tmp;
               }
            }
            if (result == "")
            {
                result = "*";
            }
            return result;
                
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        protected string Oprator(IFilter Fl)
        {
            string result = "";
            switch (Fl.OperatorSign)
            {
                case Operator.Fun_Max:
                    //result = "MAX(" + Fl.Usefield.Name+ ")";
                    result = "MAX(" + Fl.OutPutFieldChar + ")";
                    break;
                case Operator.Count:
                    result = "COUNT(" + Fl.OutPutFieldChar + ")";
                    break;
                default:
                    break;
            } 
            return result;
        }

        /// <summary>
        /// �������������
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="Cmd"></param>
        /// <returns></returns>
        protected string SetWhere(IDvTable Table, string Cmd)
        {   
            Type t = Table.Entity.GetType();
            string lastopr="";
            string cul = SetJoinChar(Table);
            if (cul != "")
            {
                cul = "WHERE " + cul +" AND ";
            }
            foreach (IDvWhere pw in Table.Wherelist)
            {
                //����ظ��ļ�ֵ �����޷�update ����˵���޷������Լ������Լ�
                base.AddParWhere(pw.Usefield, pw.Entity);
                if (cul == "")
                {
                    cul = "WHERE ";
                    if (pw.LinknextOperator != "null")
                    {
                        lastopr = pw.LinknextOperator;
                        cul =cul+ pw.Clause + " " + pw.LinknextOperator;
                    }
                    else
                    { 
                        cul =cul+ pw.Clause;
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
                        cul = cul + " " + pw.Clause ;
                        break;
                    } 
                }
            }
            cul = Cmd + " " + cul;
            return cul;
             

        }

        /// <summary>
        /// ������������������ַ���
        /// </summary>
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
