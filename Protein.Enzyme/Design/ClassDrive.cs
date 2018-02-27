using System;
using System.Collections.Generic;
using System.Text; 
using System.IO; 
using System.Linq; 
using System.Reflection;
using Protein.Enzyme.DynamicProxy;
using Protein.Enzyme.Design;
using Protein.Enzyme.Layout;
using Protein.Enzyme.Repository;
using Protein.Enzyme.Message;

namespace Protein.Enzyme.Design
{
    /// <summary>
    /// 类实例操作驱动类
    /// </summary>
    public sealed  class ClassDrive
    {

        ///// <summary>
        ///// 根据指定接口实例化程序集的指定类 
        ///// </summary>
        ///// <param name="FullClassName">要实例化的，包括命名空间的类名</param>
        ///// <param name="AssemblyPath">程序集绝对路径</param>
        ///// <returns></returns>
        //public  object Instance(string FullClassName, string AssemblyPath, string Interface)
        //{
        //    object result = null; 
        //    result = Instance(FullClassName,AssemblyPath);
        //    if (result != null && result.GetType().GetInterface(Interface) != null)
        //    {
                 
        //    }
        //    else
        //    {
        //        result = null;
        //    }
        //    return result;
            
        //}

        

        /// <summary>
        /// 设置指定对象事件方法委托
        /// </summary>
        /// <param name="DlgtObj">委托对象</param>
        /// <param name="DlgtEvent">委托对象事件</param>
        /// <param name="InvokeObj">调用对象</param>
        /// <param name="InvokeMethod">调用对象方法</param>
        public  void MethodDelegate(object DlgtObj,string DlgtEvent,object InvokeObj ,string InvokeMethod )
        {
            EventInfo eventinfo = DlgtObj.GetType().GetEvent(DlgtEvent);
            Type tDelegate = eventinfo.EventHandlerType;
            Delegate dlgt = Delegate.CreateDelegate(tDelegate,InvokeObj,InvokeMethod,true);
            MethodInfo miAddHandler = eventinfo.GetAddMethod();
            object[] addHandlerArgs = { dlgt };
            miAddHandler.Invoke(DlgtObj, addHandlerArgs); 
        }

        /// <summary>
        /// 通过代理实例化指定类型
        /// </summary>
        /// <param name="ClassType">要实例化的类的类型</param>
        /// <param name="Parameters">实例化类型构造函数的参数</param> 
        public T ProxyInstance<T>(Type ClassType, params object[] Parameters)
        {
            ProxyGenerator generator = new ProxyGenerator();
            ProxyAntipod pa = new ProxyAntipod(); 
            T newobj = (T)generator.CreateClassProxy(ClassType,pa.Antipod(), Parameters);
            return newobj;
        }


        /// <summary>
        /// 通过代理实例化程序集
        /// </summary>
        /// <param name="FullClassName">要实例化的，包括命名空间的类名</param>
        /// <param name="AssemblyPath">程序集绝对路径</param> 
        /// <param name="Parameters">参数</param> 
        /// <returns></returns>
        public T ProxyInstance<T>(string FullClassName, string AssemblyPath, params object[] Parameters)
        {
           
            T result = default(T);
            if (File.Exists(AssemblyPath))
            {
                Assembly asm = Assembly.LoadFile(AssemblyPath);
                result = ProxyInstance<T>(asm.GetType(FullClassName), Parameters);  
            }
            return result;

        }
        /// <summary>
        /// (过时的)创建对象实例，不使用动态代理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="AssemblyPath"></param>
        /// <param name="FullClassName"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public T InstanceFromPath<T>(string AssemblyPath, string FullClassName, params object[] Parameters)
        {
            return this.Instance<T>(AssemblyPath, FullClassName, Parameters);
        } 

        /// <summary>
        /// 创建对象实例，不使用动态代理
        /// </summary>
        /// <param name="AssemblyPath">程序集全路径 带扩展名</param>
        /// <param name="FullClassName">要实例化类名称</param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public T Instance<T>(string AssemblyPath, string FullClassName, params object[] Parameters)
        {
            T result = default(T);
            if (File.Exists(AssemblyPath))
            {
                Assembly ably = null;
                int index = AssemblyPath.LastIndexOf(@"\"); 
                if (index > 0) 
                {
                    string fname = AssemblyPath.Substring(index + 1, AssemblyPath.Length - index - 5);
                    ably = Assembly.Load(fname);
                }

                if (ably == null)
                {
                    ably = Assembly.LoadFile(AssemblyPath);
                } 
                //Assembly ably = Assembly.LoadFile(AssemblyPath);
                System.Type[] types = ably.GetTypes();
                foreach (System.Type type in types)
                {
                    if (type.FullName.ToLower() == FullClassName.ToLower())
                    {
                        result = (T)Activator.CreateInstance(type, Parameters);
                        break;
                    }
                }
            }
            else
            { 
                //这里有空弄个枚举
                //int c = 0x1000;
                throw new Exception(ProteinErrorType.e0.GetEnumDescription()
                    + Environment.NewLine
                    + AssemblyPath);
            }
            return result;
        }

        /// <summary>
        /// 创建对象实例
        /// </summary>
        /// <param name="ClassType">类型</param> 
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public T Instance<T>(Type ClassType, params object[] Parameters)
        {
            T result = default(T); 
            result = (T)Activator.CreateInstance(ClassType, Parameters); 
            return result;
        }
        //foreach(System.Reflection.PropertyInfo pi in serverNavBar.GetType().GetProperties())
        //{
        //    //如果属性名 == 列名
        //    if( pi.Name == ColumnName )
        //    {
        //        //获得当前属性的数据类型
        //        string propertyType = pi.PropertyType.Name;
        //            switch(propertyType)
        //        {
        //            case "Unit":
        //                //根据属性的数据类型,赋予相应的值
        //                pi.SetValue(serverNavBar,Unit.Parse(property),null);
        //                break;
        //            case "String":
        //                //根据属性的数据类型,赋予相应的值
        //                pi.SetValue(serverNavBar,property,null);
        //                break;
        //        }
        //    }
        //}


        /// <summary>
        /// 加载程序集
        /// </summary>
        public Dictionary<string, object> GetInterfaceListFormAssemblys<T>(string Path, List<string> ExcludeNameList=null)
        {
            DirectoryInfo di = new DirectoryInfo(Path);
            if (!di.Exists)
            {
                return null;
            }
            Dictionary<string, object> result = new Dictionary<string, object>(); 
            List<string> files = Directory.GetFiles(Path).ToList(); 
            foreach (string f in files)
            {
                FileInfo fi = new FileInfo(f);
                if (fi.Extension.ToUpper() == ".dll".ToUpper())
                {
                    if (ExcludeNameList != null)
                    {
                        if (ExcludeNameList.Contains(fi.Name))
                        {
                            continue;
                        }
                    }
                    try
                    {
                        Assembly ably = Assembly.LoadFile(f);
                        System.Type[] types = ably.GetTypes();
                        foreach (System.Type type in types)
                        {
                            if (type.GetInterface(typeof(T).Name) != null)
                            {
                                if (!type.IsAbstract)
                                {
                                    object g = Activator.CreateInstance(type, null);
                                    string key = g.GetType().FullName;
                                    result.Add(key, g);
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        Protein.Enzyme.Message.MessageFactory.GetMegBus().Send(Protein.Enzyme.Message.MessageFactory.CreateMessage(ex));
                        //throw new Exception(ProteinErrorType.e1.GetEnumDescription()
                        //+ Environment.NewLine
                        //+ Path
                        //+ ex.Message);
                    }

                }
            } 
            return result;
        }


        /// <summary>
        /// 搜索指定路径下指定接口类型的Type对象，不是实例
        /// </summary>
        public Dictionary<string, Type> GetTypeListForInterface<T>(string Path)
        { 
            Dictionary<string, Type> result = new Dictionary<string, Type>(); 
            FileInfo fi = new FileInfo(Path);
            try
            {
                Assembly ably = Assembly.LoadFile(fi.FullName);
                System.Type[] types = ably.GetTypes();
                foreach (System.Type type in types)
                {
                    if (type.GetInterface(typeof(T).Name) != null)
                    {
                        if (!type.IsAbstract)
                        {
                            string key = type.FullName;
                            if (!result.ContainsKey(key))
                            {
                                result.Add(key, type);
                            }

                        }
                    }
                }
                ably = null;
            }
            catch (BadImageFormatException badformat)
            {  
                //MessageObject mso = new MessageObject(MessageType.Debug);
                //mso.Message = "无效的程序集加载： " + Path;
                //MessageFactory.GetMegBus().Send(mso);
            }
            catch (FileLoadException fileloadex)
            {
                //MessageObject mso = new MessageObject(MessageType.Debug);
                //mso.Message = "无效的程序集加载： " + Path;
                //MessageFactory.GetMegBus().Send(mso);
            }
            catch (Exception ex)
            {
                string debugmsg = ex.Message + " ---" + Path;
                MessageFactory.GetMegBus().Send(MessageFactory.CreateMessageDebug(debugmsg));
                ////为了便于定位异常加入提示
                //MessageObject mso = new MessageObject(MessageType.Error);
                //mso.Message = "程序集加载失败： " + Path;
                //MessageFactory.GetMegBus().Send(mso);

            }
                  
            return result;
        }


    }
}
