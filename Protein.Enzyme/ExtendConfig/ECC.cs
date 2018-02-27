using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protein.Enzyme.ExtendConfig;
using Protein.Enzyme.Layout.Configuration;
using System.IO;
using System.Reflection;
using Protein.Enzyme.Repository;
using System.Xml.Serialization;

namespace Protein.Enzyme.ExtendConfig
{
    /// <summary>
    ///  扩展配置类接口
    /// </summary> 
    internal class ECC : IECContainer
    {
 
        protected  List<object> Container{get;set;}

        public ECC()
        {
            this.Container = new List<object>(); 
        }

        
        #region IECContainer 成员
        /// <summary>
        /// 扩展配置对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetExtendConfig<T>()
        {
            Type tagT = typeof(T);
            foreach (object obj in this.Container)
            {
                if (obj == null)
                {
                    continue;
                    //throw new Exception("扩展配置类型获取失败，原因是实例化失败：" + tagT.FullName);
                }
                if (tagT.IsInterface)
                {
                    if (obj.GetType().GetInterface(tagT.Name) == tagT)
                    {
                        return (T)obj;
                    }

                }
                else
                {
                    if (obj.GetType() == tagT)
                    {
                        return (T)obj;
                    }
                    else if (obj.GetType().FullName == tagT.FullName)
                    {
                        return (T)obj;
                    }
                }
               
            }
            return default(T);
        }

        
        /// <summary>
        /// 
        /// </summary> 
        /// <param name="NewObject"></param>
        public void AddExtendConfig(object NewObject)
        {
            this.Container.Add(NewObject);
        }

        public void AddExtendConfig(string XmlFile,string DllFile,ExConfig ExConfig)
        {
            object obj = Deserialize(XmlFile, DllFile,ExConfig);
            if (obj != null)
            {
                AddExtendConfig(obj);
            }
            else
            {
                Message.MessageObject ms = new Message.MessageObject(Message.MessageType.Error);
                ms.Message = "扩展配置加载失败。 xml:" + XmlFile + " file:" + DllFile;
                Message.MessageFactory.GetMegBus().Send(ms);
            }
        }

        public void SaveExtendConfig<T>(string XmlFile,T Obj)
        {
            bool hassave=SaveConfig<T>(XmlFile, Obj);
            int i = -1;  
            while (!hassave)
            {
                i++;
                hassave = SaveConfig<T>(XmlFile, Obj);
                if (i > 5)
                {
                    break;
                }
            }  
        }
        /// <summary>
        /// 保存配置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="XmlFile"></param>
        /// <param name="Obj"></param>
        protected bool SaveConfig<T>(string XmlFile, T Obj)
        {
            try
            {
                using (FileStream fs = new FileStream(XmlFile, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    xs.Serialize(fs, Obj);

                }
                return true;
            }
            catch(Exception ex) {
                Protein.Enzyme.Message.MessageFactory.GetMegBus().Send(Protein.Enzyme.Message.MessageFactory.CreateMessage(ex));
                return false;
            }
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        protected virtual object Deserialize(string XmlFile, string DllFile, ExConfig Config)
        {
            string asfile = DllFile;
            object result = null;
            if (File.Exists(XmlFile))
            {
                Type tartype = GetTypeFromFlag(asfile, Config.Name);
                if (tartype == null)
                {
                    return result;
                }
                XmlSerializer xs = new XmlSerializer(tartype);
                //result = xs.Deserialize(File.OpenRead(XmlFile));
                FileStream fs = File.OpenRead(XmlFile); 
                result = xs.Deserialize(fs);
                fs.Close();
                fs.Dispose();


            }
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="AssemblyPath"></param>
        /// <param name="FullClassName"></param>
        /// <returns></returns>
        protected virtual  Type GetTypeFromFlag(string AssemblyPath, string FullClassName)
        {
            if (File.Exists(AssemblyPath))
            {
                Assembly ably = Assembly.LoadFrom(AssemblyPath);
                System.Type[] types = ably.GetTypes();
                foreach (System.Type type in types)
                {
                    if (type.FullName.ToLower() == FullClassName.ToLower())
                    {
                        return type;
                    }
                }
            }
            return null;
        }
        #endregion
    }

     
}
