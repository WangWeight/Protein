using System;
using System.Collections.Generic;
using System.Text;
using Protein.Enzyme.DAL;
namespace Protein.Enzyme.Log
{
    /// <summary>
    /// 日志记录器接口
    /// </summary>
    public interface ILogger
    {
        void Info(object Message);
        void Debug(object Message);
        void Debug(object Message,Exception Exp);
        void Error(Exception Exp);
        void Error(object Message, Exception Exp);
        IEntityFactory EntityFactory { get; set; } 
        LogType ReadinLogLevel { get; set; }
        
    }
}
