using System;
using System.Collections.Generic;
using System.Text;

namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// ������������������ί��
    /// </summary>
    /// <param name="Entity"></param>
    /// <param name="DalSql"></param>
    /// <returns></returns>
    public delegate IDvTable DlgCreateDvTableIns(Protein.Enzyme.DAL.IEntityBase Entity, IDalSql DalSql);
 

    /// <summary>
    /// ����������������ӿڣ�������ӡ����¡�ɾ����¼
    /// </summary>
    public interface IDvTableBatch
    {
        /// <summary>
        /// ���ݿ����
        /// </summary>
        IDalSql DalSql { get;set;}
        /// <summary>
        /// ��������������ʵ����ί��ʵ��
        /// </summary>
        DlgCreateDvTableIns DlgCreateDriveTableIns {  set;}
        /// <summary>
        /// ��������������IDalSql����Ͳ��������ʵ����󴴽���������������ʵ�� 
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        IDvTable CreateDriveTable(Protein.Enzyme.DAL.IEntityBase Entity);
        
        /// <summary>
        /// ��Ӳ������,�Ա�����ִ��
        /// </summary>
        /// <param name="Entity"></param>
        void AddInsert(IEntityBase Entity);
        /// <summary>
        /// ��Ӹ��²���,�Ա�����ִ��
        /// </summary>
        /// <param name="Table"></param>
        void AddUpdate(IDvTable Table);
        /// <summary>
        /// ���ɾ������,�Ա�����ִ��
        /// </summary>
        /// <param name="Table"></param>
        void AddDelete(IDvTable Table);
        /// <summary>
        /// ִ�в��� ����ִ�����еĲ��롢���¡�ɾ����������ʱ����ϸ���Ĳ������ ֻ����Ӱ�������
        /// ��֧�ֻع�����
        /// </summary>
        int  Execute();
        /// <summary>
        /// ִ�в��� ����ִ�� ���� ���� 
        /// <param name="TableList">����б�</param>
        /// <param name="IsRollBack">�Ƿ�ع�����������ع�������ֵΪ-1</param>
        /// </summary>
        int ExecuteUpdate(List<IDvTable> TableList, bool IsRollBack);

        /// <summary>
        /// ִ�в��� ����ִ�� ���� ���� 
        /// <param name="Entity">ʵ��</param>
        /// <param name="IsRollBack">�Ƿ�ع�����������ع�������ֵΪ-1</param>
        /// </summary>
        int ExecuteInsert(List<IEntityBase> Entity, bool IsRollBack);

        /// <summary>
        /// ִ�в��� ����ִ�� ���� ���� 
        /// <param name="TableList">����б�</param>
        /// <param name="IsRollBack">�Ƿ�ع�����������ع�������ֵΪ-1</param>
        /// </summary>
        int ExecuteDelete(List<IDvTable> TableList, bool IsRollBack);
         
    }
}
