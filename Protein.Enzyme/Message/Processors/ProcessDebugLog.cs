using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.Message;
using Protein.Enzyme.Log;
using System.Diagnostics;

namespace Protein.Enzyme.Message.Processors
{
    /// <summary>
    /// 调试消息处理 
    /// </summary>
    public class ProcessDebugLog:IProcessor
    {
        private ILogger logger; 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Logger"></param>
        public ProcessDebugLog(ILogger Logger)
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
            if (Content.Type > Protein.Enzyme.Layout.Configuration.ProteinConfig.GetInstance().LogConfig.RecordLevel)
            {
                return;
            } 
            if (Content.Type == MessageType.Debug
                || Content.Type == MessageType.PtDebug)
            {
                this.logger.Debug(Content.Message); 
            }
        }

         
         

        #endregion
    }
}
