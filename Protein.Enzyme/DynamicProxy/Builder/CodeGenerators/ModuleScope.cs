using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace Protein.Enzyme.DynamicProxy
{
   

    [CLSCompliant(false)]
    public class ModuleScope
    {
        private AssemblyBuilder _assemblyBuilder;
        private object _lockobj = new object();
        private ModuleBuilder _moduleBuilder = null;
        private ModuleBuilder _moduleBuilderWithStrongName = null;
        private Hashtable _typeCache = Hashtable.Synchronized(new Hashtable());
        public static readonly string ASSEMBLY_NAME = "DynamicAssemblyProxyGen";
        public static readonly string FILE_NAME = "GeneratedAssembly.dll";
        private ReaderWriterLock readerWriterLock = new ReaderWriterLock();

        private ModuleBuilder CreateModule(bool signStrongName)
        {
            AssemblyName name = new AssemblyName();
            name.Name = ASSEMBLY_NAME;
            if (signStrongName)
            {
                name.KeyPair = new StrongNameKeyPair(GetKeyPair());
            }
            this._assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(name, AssemblyBuilderAccess.Run);
            return this._assemblyBuilder.DefineDynamicModule(name.Name, true);
        }

        private static byte[] GetKeyPair()
        {
            byte[] buffer;
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Protein.Enzyme.DynamicProxy.DynProxy.snk"))
            {
                int length = (int) stream.Length;
                buffer = new byte[length];
                stream.Read(buffer, 0, length);
            }
            return buffer;
        }

        public ModuleBuilder ObtainDynamicModule()
        {
            return this.ObtainDynamicModule(false);
        }

        public ModuleBuilder ObtainDynamicModule(bool signStrongName)
        {
            lock (this._lockobj)
            {
                if (signStrongName && (this._moduleBuilderWithStrongName == null))
                {
                    this._moduleBuilderWithStrongName = this.CreateModule(signStrongName);
                }
                else if (!signStrongName && (this._moduleBuilder == null))
                {
                    this._moduleBuilder = this.CreateModule(signStrongName);
                }
            }
            if (!signStrongName)
            {
                return this._moduleBuilder;
            }
            return this._moduleBuilderWithStrongName;
        }

        public void SaveAssembly()
        {
        }

        public Type this[string name]
        {
            get
            {
                return (this._typeCache[name] as Type);
            }
            set
            {
                this._typeCache[name] = value;
                this.SaveAssembly();
            }
        }

        public ReaderWriterLock RWLock
        {
            get
            {
                return this.readerWriterLock;
            }
        }
    }
}

