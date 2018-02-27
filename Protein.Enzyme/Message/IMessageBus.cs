using System;
namespace Protein.Enzyme.Message
{
    /// <summary>
    /// 消息总线接口
    /// </summary>
    public interface IMessageBus
    {
        /// <summary>
        /// 添加消息处理器
        /// </summary>
        /// <param name="Processor"></param>
        void AddProcessor(IProcessor Processor); 
        /// <summary>
        /// 消息处理器集合
        /// </summary>
        System.Collections.Generic.List<IProcessor> Pcslist { get; set; } 
        /// <summary>
        /// 移除消息处理器
        /// </summary>
        /// <param name="Processor"></param>
        void RemoveProcessor(IProcessor Processor);
        /// <summary>
        /// 移除消息处理器根据类型
        /// </summary>
        /// <param name="ProcessorType"></param>
        void RemoveProcessorByType(Type ProcessorType);
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="Msg"></param>
        void Send(MessageObject Msg);
        /// <summary>
        /// 判断在消息总线的处理器集合中是否存在指定类型的处理器
        /// </summary>
        /// <param name="ProcessorType"></param>
        /// <returns></returns>
        bool Contains(Type ProcessorType);
         
    }
}
