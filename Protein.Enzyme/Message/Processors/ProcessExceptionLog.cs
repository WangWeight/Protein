using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.Message;
using Protein.Enzyme.Log;
namespace Protein.Enzyme.Message.Processors
{
    /// <summary>
    /// 异常处理器 记录日志
    /// </summary>
    public class ProcessExceptionLog:IProcessor
    {
        
        private ILogger logger;
        
        /// <summary>
        /// 日志处理器
        /// </summary>
        /// <param name="Logger"></param>
        public ProcessExceptionLog(ILogger Logger)
        {
            this.logger = Logger; 
        }


        #region IProcessor 成员
        /// <summary>
        /// 处理消息
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
                    Exception ex = new Exception("未定义的异常消息类型 ：" + Content.Message.ToString());
                    this.logger.Error(ex);
                }

            }
            
        }

        

        #endregion
    }
}
