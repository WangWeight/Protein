using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Protein.Enzyme.Repository
{
    /// <summary>
    /// �ı��ļ���������
    /// </summary>
    public class TxtHelper
    {
        FileStream onStream = null;
        /// <summary>
        /// 
        /// </summary>
        public TxtHelper(string fileName)
        {
            this.onStream = new FileStream(fileName, FileMode.Append);
        }
        /// <summary>
        /// 
        /// </summary>
        ~TxtHelper()
        {
            if (this.onStream != null && this.onStream.CanWrite)
            {
                this.onStream.Flush();
                this.onStream.Close();
            }
        }
        /// <summary>
        /// ��ָ���ļ�д���ַ������ݣ��̲߳���ȫ��
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="Content"></param>
        public static void Write(string FileName,string Content)
        {
            FileStream fs = new FileStream(FileName, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.Write(Content);
            sw.Close();
            fs.Close();
        }
        /// <summary>
        /// д���ı�����
        /// </summary>
        /// <param name="Content"></param>
        public void Write(string Content)
        { 
            StreamWriter sw = new StreamWriter(this.onStream, Encoding.Default);
            sw.Write(Content);
            this.onStream.Flush();
            sw.Close(); 
        }
        /// <summary>
        /// ����ļ�����
        /// </summary>
        public void finish()
        {
            this.onStream.Flush();
            this.onStream.Close();
        }
    }
}
