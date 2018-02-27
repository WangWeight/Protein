using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.Design;
using Protein.Enzyme.Layout.Configuration;
using Protein.Enzyme.Message;
using Protein.Enzyme.Message.Processors;
using Protein.Enzyme.Layout.Mechanisms;
using Protein.Enzyme.Layout.ProxyAdapter;
namespace Protein.Enzyme.Layout
{
    /// <summary>
    /// 代理结构体
    /// 1、异常处理机制不变，通过消息总线来处理
    /// 2、拦截方法的前后记录入口，也就是运行日志记录的入口
    /// 这些入口的处理都是通过配置文件来修改
    /// </summary>
    internal class ProxyAntipod
    {
        public ProxyAntipod()
        { 
        
        }

        public virtual ProxyInterceptor Antipod()
        {
            //类库配置
            ProteinConfig pconfig= ProteinConfig.GetInstance();
            //代理拦截器
            ProxyInterceptor pri = new ProxyInterceptor();
            ProxyDefaul pd = new ProxyDefaul();
            //对拦截器的机制进行初始化
            pd.SetProxy(pri); 
            return pri;
        }

        

       
    }
}
