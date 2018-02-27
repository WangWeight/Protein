using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections.Generic;

namespace Protein.Enzyme.IO
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="param"></param>
    /// <param name="handle"></param>
    public delegate void ProcessKeyHandle(HookStruct param, out bool handle); //接收SetWindowsHookEx返回值
    /// <summary>
    /// 热键注册
    /// </summary>  
    public  class KeyHook
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;

        //设置钩子
        [DllImport("user32.dll")]
        private static extern int SetWindowsHookEx(int idHook, HookHandle lpfn, IntPtr hInstance, int threadId);

        //取消钩子
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern bool UnhookWindowsHookEx(int idHook);

        //调用下一个钩子
        [DllImport("user32.dll")]
        private static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr Param);

        //获取当前线程ID
        [DllImport("kernel32.dll")]
        private static extern int GetCurrentThreadId();

        //Gets the main module for the associated process.
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string name);
        //键盘
        //键盘处理事件委托 当捕获键盘输入时调用定义该委托的方法
        private delegate int HookHandle(int nCode, int wParam, IntPtr lParam); //客户端键盘处理事件

        /// <summary>
        /// 钩子句柄
        /// </summary>
        private  int hHookValue = 0;

        /// <summary>
        /// 键盘钩子句柄
        /// </summary>
        public int HookHandler {
            get {
                return  hHookValue;
            }
        }
        static KeyHook hook = null;
        /// <summary>
        /// 勾子程序处理事件
        /// </summary>
        private HookHandle keyBoardHookProcedure;  
         
        /// <summary>
        /// 外部调用的键盘处理事件
        /// </summary>
        private    List<ProcessKeyHandle> handles = new List<ProcessKeyHandle>();

        /// <summary>
        ///  
        /// </summary>
        /// <param name="hookWindowPtr"></param>
        private KeyHook()
        {
            RegistHook();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hookWindowPtr"></param>
        /// <returns></returns>
        public static KeyHook GetHook()
        {
            if (hook == null)
            {
                hook = new KeyHook();
            }
            return hook;
        }

        /// <summary>
        /// 
        /// </summary>
        public IntPtr HokWindowPtr { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IntPtr GetWindowPtr()
        {
            return GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);
        }
        /// <summary>
        /// 注册钩子
        /// </summary>
        protected void RegistHook()
        {
            if (hHookValue == 0 || this.HokWindowPtr!=this.GetWindowPtr())
            { 
                this.keyBoardHookProcedure = new HookHandle(OnHookProc);
                GCHandle.Alloc(this.keyBoardHookProcedure, GCHandleType.Normal);
                HokWindowPtr = GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);
                hHookValue = SetWindowsHookEx(WH_KEYBOARD_LL, this.keyBoardHookProcedure, HokWindowPtr, 0);
            }
        }

        /// <summary>
        /// 安装钩子处理方法
        /// </summary>
        /// <param name="keyhandle"></param>
        public void InstallHook(ProcessKeyHandle keyhandle)
        {
           
            if (!handles.Contains(keyhandle))
            {
                handles.Add(keyhandle);
            }
            //this.clientMethod = keyhandle;
            //GCHandle.Alloc(this.clientMethod, GCHandleType.Normal); 
           
        }

        /// <summary>
        /// 卸载钩子
        /// </summary>
        public void UninstallHook(ProcessKeyHandle keyhandle)
        {
            handles.Remove(keyhandle);
        }
        /// <summary>
        /// 卸载钩子
        /// </summary>
        public void EscHook()
        {
            if (hHookValue != 0)
            {
                bool ret = UnhookWindowsHookEx(hHookValue);
                if (ret)
                {
                    hHookValue = 0;
                }
            }
        }
        /// <summary>
        /// 钩子事件内部调用,调用_clientMethod方法转发到客户端应用。
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        protected    int OnHookProc(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                if (wParam == WM_KEYDOWN)
                {
                    //转换结构
                    HookStruct hookStruct = (HookStruct)Marshal.PtrToStructure(lParam, typeof(HookStruct)); 
                    if (handles != null)
                    { 
                        //调用客户提供的事件处理程序。
                        foreach (ProcessKeyHandle pkh in handles)
                        {
                            bool handle = false;
                            pkh(hookStruct, out handle);
                            if (handle)
                            {
                                return 0;
                            }
                        }  
                    }
                }
            }
            return 0;
            //try
            //{
            //    return CallNextHookEx(this.hHookValue, nCode, wParam, lParam);
            //}
            //catch
            //{
            //    return 0;
            //}
        }
    }

     
}
