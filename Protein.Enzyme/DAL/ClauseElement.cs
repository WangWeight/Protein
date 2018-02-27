using System;
using System.Collections.Generic; 
using System.Text;
using System.ComponentModel;

namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// ���������Ҫ����
    /// ��ʱ�� ���￼����IDvTable�ӿ��������ƹ��ܵĳ���
    /// ������ѯ�����ڿͻ���ֱ����
    /// </summary>
    public sealed class ClauseElement
    {
        /// <summary>
        /// ʵ��������
        /// </summary>
        public Type EntityType { get; set; }
        /// <summary>
        /// �����������ֶ�����
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public Operator Opr { get; set; }
        /// <summary>
        /// ���Ӳ�����
        /// </summary>
        public LinkOperator LinkOpr { get; set; }
    }
}
