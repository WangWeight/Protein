using System;
using System.Collections.Generic;
using System.Text;

namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// ��ѯ������� �����ۺϺ���
    /// </summary>
    public interface  IFilter
    {
        /// <summary>
        /// ɸѡ���ֶ�
        /// </summary>
        System.Reflection.PropertyInfo Usefield { get;set;}
        /// <summary>
        /// �ֶ����
        /// </summary>
        string OutPutFieldChar { get;}
        /// <summary>
        /// ��������
        /// </summary>
        Operator OperatorSign { get;set;}

        /// <summary>
        /// ���ù��� �������� �����ֶ�
        /// </summary>
        void SetFilter(System.Reflection.PropertyInfo Field, Operator Oprt);


    }
}
