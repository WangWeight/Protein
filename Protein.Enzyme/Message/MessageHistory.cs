using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protein.Enzyme.Message
{
    /// <summary>
    /// 历史
    /// </summary>
    public class MessageHistory
    {
        /// <summary>
        /// 消息对象
        /// </summary>
        public MessageObject MsgObject { get; set; }
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime RecordTime { get; set; }

    }
}
