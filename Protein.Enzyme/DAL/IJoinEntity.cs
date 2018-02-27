using System;
using System.Collections.Generic;
using System.Text;

namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// ������ʵ�����װ�ӿ�
    /// </summary>
    public  interface  IJoinEntity
    {
        /// <summary>
        /// ������ʵ����
        /// </summary>
        List<IEntityBase> Entitys { get;set;}


        /// <summary>
        /// ����Ҫ���ϵ�ʵ�� �ڵ��õ�ʵ���ڼ�¼�����ϵ��ֶ����
        /// ���������ϵ���÷�����ʾ 
        /// <param name="JionEntity">������ʵ�������</param>
        /// <param name="SourceEntity">������ʵ�������</param>
        /// </summary>
        string JoinField(IEntityBase SourceEntity, IEntityBase JionEntity);

        //�������ʵ���ͬʱ ���ù����ֶ� 
        //ʵ���Լ�ά���ֶι������ ��ѯֻ��Ҫ������������
        //
    }
}
