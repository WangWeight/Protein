using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using Protein.Enzyme.Repository;

namespace Protein.Enzyme.Log
{
    /// <summary>
    /// 记录器管理
    /// </summary>
    public sealed class LoggerManager
    {
        private static TxtHelper gloubHellLog = null;

        /// <summary>
        /// 获取灾难日志记录
        /// </summary>
        public TxtHelper getHellLog
        {
            get {
                if (LoggerManager.gloubHellLog == null)
                {
                    string filename = typeof(LoggerManager).Assembly.GetAssemblyPath();
                    if (filename == null)
                    {
                        filename = "c:\\";
                    }
                    filename = filename + "\\ProteinLog.txt";
                    LoggerManager.gloubHellLog = new TxtHelper(filename);  
                }
                return LoggerManager.gloubHellLog;
            }
        }
        /// <summary>
        /// 创建日志记录器对象
        /// </summary>
        /// <param name="AssemblyPath">程序集全路径 带扩展名</param>
        /// <param name="FullClassName">要实例化类名称</param>
        /// <returns></returns>
        public static ILogger CreateLogger(string AssemblyPath, string FullClassName)
        {
            ILogger result=null; 
            if (File.Exists(AssemblyPath))
            {
                Assembly ably = Assembly.LoadFile(AssemblyPath);
                System.Type[] types = ably.GetTypes();
                foreach (System.Type type in types)
                {
                    if (type.GetInterface("ILogger") != null && type.FullName.ToLower() == FullClassName.ToLower())
                    {
                        result = (ILogger)Activator.CreateInstance(type);
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 记录灾难日志，全局使用统一的方法来记录灾难日志
        /// </summary>
        /// <param name="content"></param>
        public  void recordHellLog(string content)
        {
            this.getHellLog.Write(content);
            
        }

    }
}


