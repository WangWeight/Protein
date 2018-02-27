using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.DAL;
using Protein.Enzyme.Layout.Configuration;
using Protein.Enzyme.Layout.Mechanisms;
using Protein.Enzyme.ExtendConfig;
using System.Data;
namespace Protein.Enzyme.Repository
{
    /// <summary>
    /// 数据操作入口
    /// </summary>
    public class DalHandler
    {
        public IEntityFactory EntityFact { get; set; }

        DataHelper dh = new DataHelper();
        /// <summary>
        /// 数据操作入口
        /// </summary>
        public DalHandler()
        { 
            ProteinHandler ph=new ProteinHandler(); 
            this.EntityFact = ph.GetEntityFactory(); 
        }

        /// <summary>
        /// 创建实体类对象实例
        /// </summary>
        public virtual T DalCreateEntityInstance<T>()
        {
            T result = this.EntityFact.CreateEntityInstance<T>();
            return result; 
        }

        /// <summary>
        /// 创建实体表格驱动对象
        /// </summary>
        public virtual IDvTable DalCreateDriveTable(IEntityBase EntityInstance)
        { 
            IDvTable dvt = this.EntityFact.CreateDriveTable(EntityInstance);
            return dvt;
        }

        /// <summary>
        /// 查询指定实体对象的所有值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="EntityInstance"></param>
        /// <returns></returns>
        public virtual List<T> QueryAll<T>(IEntityBase EntityInstance)
        {
            IDvTable dvt = DalCreateDriveTable(EntityInstance);
            DataSet ds = dvt.Select();
            List<T> result= this.dh.Convert<T>(EntityInstance.GetType(), ds);
            return result;
        }

        /// <summary>
        /// 根据条件查询指定实体对象的所有值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="EntityInstance"></param>
        /// <param name="Field"></param>
        /// <param name="Opr"></param>
        /// <param name="LinkOpr"></param>
        /// <returns></returns>
        public virtual T QueryEntity<T>(IEntityBase EntityInstance, string Field,Operator Opr,LinkOperator LinkOpr)
        {
            T result = default(T);
            IDvTable dvt = DalCreateDriveTable(EntityInstance);
            dvt.WhereClause(Field, Opr, LinkOpr);
            DataSet ds = dvt.Select(); 
            result = this.dh.Convert<T>(EntityInstance.GetType(), ds, 0);
            return result;
        }

        /// <summary>
        /// 根据条件查询指定实体对象的所有值
        /// </summary>
        /// <typeparam name="T"></typeparam> 
        /// <param name="Field"></param>
        /// <param name="EntityInstance"></param>
        /// <param name="LinkOpr"></param>
        /// <param name="Opr"></param>
        /// <returns></returns>
        public virtual List<T> QueryEntityList<T>(IEntityBase EntityInstance, string Field, Operator Opr, LinkOperator LinkOpr)
        {
            List<T> result = new List<T>();
            IDvTable dvt = DalCreateDriveTable(EntityInstance);
            dvt.WhereClause(Field, Opr, LinkOpr);
            DataSet ds = dvt.Select();
            result = this.dh.Convert<T>(EntityInstance.GetType(),ds);
            return result;
        }

        /// <summary>
        /// 根据多个条件子语句查询指定实体对象的所有值 当条件子语句数量为0时返回值为空列表 此方法不考虑联立表查询情况
        /// </summary>
        /// <typeparam name="T"></typeparam> 
        /// <param name="EntityInstance"></param>
        /// <param name="Clauses"></param> 
        /// <returns></returns>
        public virtual List<T> QueryEntityList<T>(IEntityBase EntityInstance, List<ClauseElement> Clauses)
        { 
            List<T> result = new List<T>();
            if (Clauses.Count == 0)
            {
                return result;
            }
            IDvTable dvt = DalCreateDriveTable(EntityInstance);
            foreach (ClauseElement ce in Clauses)
            {
                dvt.WhereClause(ce.FieldName, ce.Opr, ce.LinkOpr);
            }
            DataSet ds = dvt.Select();
            result = this.dh.Convert<T>(EntityInstance.GetType(), ds);
            return result;
        }

        /// <summary>
        /// 联立查询获取实体对象列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual List<T> QueryEntityJoin<T>(List<ClauseElement> Clauses)
        {
            List<T> result = new List<T>();
            if (Clauses.Count == 0)
            {
                return result;
            }
            //IDvTable dvt = DalCreateDriveTable(EntityInstance);
            foreach (ClauseElement ce in Clauses)
            {
                //IEntityBase tmpEty = ce.EntityType.GetInterface(ce.EntityType.Name);
                //dvt.WhereClause(ce.FieldName, ce.Opr, ce.LinkOpr);
            }

            return result;
            //IMenu menu = entityfactory.CreateEntityInstance<IMenu>();
            //menu.MENUTYPE = MType.ToString();
            //IAuthControl actrl = entityfactory.CreateEntityInstance<IAuthControl>();
            //actrl.RoleCode = Role.RoleCode;
            //IDvTable dvt = entityfactory.CreateDriveTable(menu);
            //dvt.Join.Entitys.Add(actrl);
            //dvt.WhereClause("MENUTYPE", Operator.Deng, LinkOperator.and);
            //dvt.WhereClause(actrl, "RoleCode", Operator.Deng, LinkOperator.nul);
            //DataSet ds = dvt.Select();
            //List<IMenu> list = this.dh.Convert<IMenu>(menu.GetType(), ds);
            //List<IMenu> result = RefactoringMenu(list);
            //return result;
        }


        ///// <summary>
        ///// 模糊查找指定实体对象的所有值
        ///// </summary>
        ///// <typeparam name="T"></typeparam> 
        ///// <param name="Field"></param>
        ///// <param name="EntityInstance"></param>
        ///// <param name="LinkOpr"></param>
        ///// <param name="Opr"></param>
        ///// <returns></returns>
        //public virtual List<T> QueryEntityFuzzy<T>(IEntityBase EntityInstance, string Field, Operator Opr, LinkOperator LinkOpr)
        //{
        //    IDvTable dvt = DalCreateDriveTable(EntityInstance);
        //    dvt.WhereClause(Field, Opr, LinkOpr);
        //    DataSet ds = dvt.Select();
        //    List<T> result = this.dh.Convert<T>(EntityInstance.GetType(), ds);
        //    return result;
        //}

        /// <summary>
        /// 获取可用的新编号 流水最大值
        /// </summary>
        /// <returns></returns>
        public Int64 GetNewCode(IEntityBase Entity, string Field)
        {
            Int64 i = 0;
            DataHelper dh = new DataHelper();
            i = dh.GetMaxField(Entity, Field, this.EntityFact) + 1; 
            return i;
        }

        /// <summary>
        /// 添加实体记录
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        public virtual int AddEntityData(IEntityBase Entity)
        {
            IDvTable dvt = this.EntityFact.CreateDriveTable(Entity);
            int i = dvt.Insert();
            return i;
        }

 
        /// <summary>
        /// 移除实体数据
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Field"></param>
        /// <param name="LinkOpr"></param>
        /// <param name="Opr"></param>
        /// <returns></returns>
        public virtual int RemoveEntityData(IEntityBase Entity, string Field, Operator Opr, LinkOperator LinkOpr)
        {
            IDvTable dvt = this.EntityFact.CreateDriveTable(Entity);
            dvt.WhereClause(Field, Opr, LinkOpr);
            int i = dvt.Delete();
            return i;
        }
        /// <summary>
        /// 移除实体数据
        /// </summary> 
        /// <param name="Entity"></param>
        /// <param name="Clauses"></param>
        /// <returns></returns>
        public virtual int RemoveEntityData(IEntityBase Entity, List<ClauseElement> Clauses)
        {
            int result = 0;
            if (Clauses.Count == 0)
            {
                return result;
            }
            IDvTable dvt = DalCreateDriveTable(Entity);
            foreach (ClauseElement ce in Clauses)
            {
                dvt.WhereClause(ce.FieldName, ce.Opr, ce.LinkOpr);
            } 
            result = dvt.Delete();
            return result;
        }

        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Field"></param>
        /// <param name="Opr"></param>
        /// <param name="LinkOpr"></param>
        /// <returns></returns>
        public virtual int UpdateEntityData(IEntityBase Entity, string Field, Operator Opr, LinkOperator LinkOpr)
        {
            IDvTable dvt = this.EntityFact.CreateDriveTable(Entity);
            dvt.WhereClause(Field, Opr, LinkOpr);
            int i = dvt.Update();
            return i;
        }


        /// <summary>
        /// 更新实体数据
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Clauses"></param> 
        /// <returns></returns>
        public virtual int UpdateEntityData(IEntityBase Entity, List<ClauseElement> Clauses)
        {
            int result = 0;
            if (Clauses.Count == 0)
            {
                return result;
            }
            IDvTable dvt = DalCreateDriveTable(Entity);
            foreach (ClauseElement ce in Clauses)
            {
                dvt.WhereClause(ce.FieldName, ce.Opr, ce.LinkOpr);
            }
            result = dvt.Update();
            return result;  
        }

        

        /// <summary>
        /// 批量更新实体
        /// </summary>
        /// <param name="EntityClause">实体列表</param>
        /// <param name="IsRollBack">是否回滚</param>
        /// <returns></returns>
        public virtual int UpdateEntityDataTran<T>(Dictionary<T,List<ClauseElement>> EntityClause, bool IsRollBack)
        {  
            List<IDvTable> tableList = new List<IDvTable>();
            foreach (IEntityBase eb in EntityClause.Keys)
            {
                IDvTable dvt = this.EntityFact.CreateDriveTable(eb); 
                foreach (ClauseElement ce in EntityClause[(T)eb])
                {
                    dvt.WhereClause(ce.FieldName, ce.Opr, ce.LinkOpr);
                } 
                tableList.Add(dvt);
            }
            IDvTableBatch dvtb = this.EntityFact.CreateDriveTableBatch();
            int i = dvtb.ExecuteUpdate(tableList,IsRollBack); 
            return i;
        }

        /// <summary>
        /// 批量添加实体记录
        /// </summary>
        /// <param name="EntityList"></param>
        /// <param name="IsRollBack"></param>
        /// <returns></returns>
        public virtual int AddEntityDataTran<T>(List<T> EntityList, bool IsRollBack)
        { 
            List<IEntityBase> ibList=EntityList as List<IEntityBase>;
            IDvTableBatch dvtb = this.EntityFact.CreateDriveTableBatch();
            int i = dvtb.ExecuteInsert(ibList, IsRollBack); 
            return i;
        }

        /// <summary>
        /// 批量添加实体记录
        /// </summary>
        /// <param name="ListCell"></param>
        /// <param name="IsRollBack"></param>
        /// <returns></returns>
        public virtual int AddEntityDataTran(List<IEntityBase> ListCell, bool IsRollBack)
        {
            //List<IDvTable> tableList = new List<IDvTable>();
            //foreach (List<IEntityBase> entityList in ListCell)
            //{
            //    foreach (IEntityBase eb in entityList)
            //    {
            //        IDvTable dvt = this.EntityFact.CreateDriveTable(eb);
            //        tableList.Add(dvt);
            //    } 
            //} 
            IDvTableBatch dvtb = this.EntityFact.CreateDriveTableBatch();
            int i = dvtb.ExecuteInsert(ListCell, IsRollBack);
            return i;
        }
    }
}
