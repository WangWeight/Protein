using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.Message;
using Protein.Enzyme.Log;
namespace Protein.Enzyme.Message.Processors
{
    /// <summary>
    /// ֧������ڲ��쳣��Ϣ������ ��¼��־
    /// </summary>
    public class ProcessInnerExceptionLog:IProcessor
    {

        private ILogger logger;
        /// <summary>
        /// �ڲ��쳣��Ϣ������
        /// </summary>
        /// <param name="Logger"></param>
        public ProcessInnerExceptionLog(ILogger Logger)
        {
            this.logger = Logger; 
        }

        #region IProcessor ��Ա
        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="Content"></param>
        public void ProcessMessage(MessageObject Content)
        {
            if (Content.Type == MessageType.Error)
            {
                this.logger.Error(((Exception)Content.Message));
            }
        }

        #endregion

       
    }
}
