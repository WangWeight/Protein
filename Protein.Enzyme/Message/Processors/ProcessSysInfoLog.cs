using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.Message;
using Protein.Enzyme.Log;
using System.Diagnostics;

namespace Protein.Enzyme.Message.Processors
{
    /// <summary> 
    /// 系统内部消息处理
    /// </summary>
    public class ProcessSysInfo: IProcessor
    {
        private ILogger logger; 
         /// <summary>
        /// 系统内部消息处理
        /// </summary>
        /// <param name="Logger"></param>
        public ProcessSysInfo(ILogger Logger)
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
            if (Content.Type == MessageType.InsideInfo
                || Content.Type == MessageType.Note)
            {
                this.logger.Info(Content.Message); 
            }
             
        }
         

        #endregion
    }
}
