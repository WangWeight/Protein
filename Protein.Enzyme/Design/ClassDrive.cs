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
    /// ��ʵ������������
    /// </summary>
    public sealed  class ClassDrive
    {

        ///// <summary>
        ///// ����ָ���ӿ�ʵ�������򼯵�ָ���� 
        ///// </summary>
        ///// <param name="FullClassName">Ҫʵ�����ģ����������ռ������</param>
        ///// <param name="AssemblyPath">���򼯾���·��</param>
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
        /// ����ָ�������¼�����ί��
        /// </summary>
        /// <param name="DlgtObj">ί�ж���</param>
        /// <param name="DlgtEvent">ί�ж����¼�</param>
        /// <param name="InvokeObj">���ö���</param>
        /// <param name="InvokeMethod">���ö��󷽷�</param>
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
        /// ͨ������ʵ����ָ������
        /// </summary>
        /// <param name="ClassType">Ҫʵ�������������</param>
        /// <param name="Parameters">ʵ�������͹��캯���Ĳ���</param> 
        public T ProxyInstance<T>(Type ClassType, params object[] Parameters)
        {
            ProxyGenerator generator = new ProxyGenerator();
            ProxyAntipod pa = new ProxyAntipod(); 
            T newobj = (T)generator.CreateClassProxy(ClassType,pa.Antipod(), Parameters);
            return newobj;
        }


        /// <summary>
        /// ͨ������ʵ��������
        /// </summary>
        /// <param name="FullClassName">Ҫʵ�����ģ����������ռ������</param>
        /// <param name="AssemblyPath">���򼯾���·��</param> 
        /// <param name="Parameters">����</param> 
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
        /// (��ʱ��)��������ʵ������ʹ�ö�̬����
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
        /// ��������ʵ������ʹ�ö�̬����
        /// </summary>
        /// <param name="AssemblyPath">����ȫ·�� ����չ��</param>
        /// <param name="FullClassName">Ҫʵ����������</param>
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
                //�����п�Ū��ö��
                //int c = 0x1000;
                throw new Exception(ProteinErrorType.e0.GetEnumDescription()
                    + Environment.NewLine
                    + AssemblyPath);
            }
            return result;
        }

        /// <summary>
        /// ��������ʵ��
        /// </summary>
        /// <param name="ClassType">����</param> 
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
        //    //��������� == ����
        //    if( pi.Name == ColumnName )
        //    {
        //        //��õ�ǰ���Ե���������
        //        string propertyType = pi.PropertyType.Name;
        //            switch(propertyType)
        //        {
        //            case "Unit":
        //                //�������Ե���������,������Ӧ��ֵ
        //                pi.SetValue(serverNavBar,Unit.Parse(property),null);
        //                break;
        //            case "String":
        //                //�������Ե���������,������Ӧ��ֵ
        //                pi.SetValue(serverNavBar,property,null);
        //                break;
        //        }
        //    }
        //}


        /// <summary>
        /// ���س���
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
        /// ����ָ��·����ָ���ӿ����͵�Type���󣬲���ʵ��
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
                //mso.Message = "��Ч�ĳ��򼯼��أ� " + Path;
                //MessageFactory.GetMegBus().Send(mso);
            }
            catch (FileLoadException fileloadex)
            {
                //MessageObject mso = new MessageObject(MessageType.Debug);
                //mso.Message = "��Ч�ĳ��򼯼��أ� " + Path;
                //MessageFactory.GetMegBus().Send(mso);
            }
            catch (Exception ex)
            {
                string debugmsg = ex.Message + " ---" + Path;
                MessageFactory.GetMegBus().Send(MessageFactory.CreateMessageDebug(debugmsg));
                ////Ϊ�˱��ڶ�λ�쳣������ʾ
                //MessageObject mso = new MessageObject(MessageType.Error);
                //mso.Message = "���򼯼���ʧ�ܣ� " + Path;
                //MessageFactory.GetMegBus().Send(mso);

            }
                  
            return result;
        }


    }
}
