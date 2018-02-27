using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.Message;
using Protein.Enzyme.Log;
namespace Protein.Enzyme.Message.Processors
{
    /// <summary>
    /// �쳣������ ��¼��־
    /// </summary>
    public class ProcessExceptionLog:IProcessor
    {
        
        private ILogger logger;
        
        /// <summary>
        /// ��־������
        /// </summary>
        /// <param name="Logger"></param>
        public ProcessExceptionLog(ILogger Logger)
        {
            this.logger = Logger; 
        }


        #region IProcessor ��Ա
        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="Content"></param>
        public virtual void ProcessMessage(MessageObject Content)
        {
            if (Content.Type > Protein.Enzyme.Layout.Configuration.ProteinConfig.GetInstance().LogConfig.RecordLevel)
            {
                return;
            }
            if (Content.Type == MessageType.Error
                || Content.Type == MessageType.Warning)
            {
                if (Content.Message.GetType() == typeof(Exception)
                    || Content.Message.GetType().BaseType == typeof(Exception))
                {
                    this.logger.Error(((Exception)Content.Message));
                }
                else if(Content.Message.GetType() == typeof(string))
                {
                    Exception ex = new Exception((string)Content.Message);
                    this.logger.Error(ex);
                }
                else if (Content.Message.GetType() == typeof(FormatException))
                { 
                    this.logger.Error(((Exception)Content.Message));
                }
                else  
                { 
                    Exception ex = new Exception("δ������쳣��Ϣ���� ��" + Content.Message.ToString());
                    this.logger.Error(ex);
                }

            }
            
        }

        

        #endregion
    }
}
