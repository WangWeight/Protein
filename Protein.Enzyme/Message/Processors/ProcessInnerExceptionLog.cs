using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.Message;
using Protein.Enzyme.Log;
namespace Protein.Enzyme.Message.Processors
{
    /// <summary>
    /// 支撑类库内部异常消息处理器 记录日志
    /// </summary>
    public class ProcessInnerExceptionLog:IProcessor
    {

        private ILogger logger;
        /// <summary>
        /// 内部异常消息处理器
        /// </summary>
        /// <param name="Logger"></param>
        public ProcessInnerExceptionLog(ILogger Logger)
        {
            this.logger = Logger; 
        }

        #region IProcessor 成员
        /// <summary>
        /// 处理消息
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
