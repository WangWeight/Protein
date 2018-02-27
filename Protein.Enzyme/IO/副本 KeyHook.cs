//using System;
//using System.Runtime.InteropServices;
//using System.Diagnostics;

//namespace Protein.Enzyme.IO
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    /// <param name="param"></param>
//    /// <param name="handle"></param>
//    public delegate void ProcessKeyHandle(HookStruct param, out bool handle); //接收SetWindowsHookEx返回值
//    /// <summary>
//    /// 热键注册
//    /// </summary>  
//    public  class KeyHook
//    {
//        private const int WH_KEYBOARD_LL = 13;
//        private const int WM_KEYDOWN = 0x100;
//        private const int WM_KEYUP = 0x101;

//        //键盘
//        //键盘处理事件委托 当捕获键盘输入时调用定义该委托的方法
//        private delegate int HookHandle(int nCode, int wParam, IntPtr lParam); //客户端键盘处理事件

//        /// <summary>
//        /// 钩子句柄
//        /// </summary>
//        private int _hHookValue = 0;

//        /// <summary>
//        /// 键盘钩子句柄
//        /// </summary>
//        public int HookHandler {
//            get {
//                return this._hHookValue;
//            }
//        }

//        /// <summary>
//        /// 勾子程序处理事件
//        /// </summary>
//        private HookHandle _KeyBoardHookProcedure; //Hook结构
        
//        //设置钩子
//        [DllImport("user32.dll")]
//        private static extern int SetWindowsHookEx(int idHook, HookHandle lpfn, IntPtr hInstance, int threadId);

//        //取消钩子
//        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
//        private static extern bool UnhookWindowsHookEx(int idHook);

//        //调用下一个钩子
//        [DllImport("user32.dll")]
//        private static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr Param);

//        //获取当前线程ID
//        [DllImport("kernel32.dll")]
//        private static extern int GetCurrentThreadId();

//        //Gets the main module for the associated process.
//        [DllImport("kernel32.dll")]
//        private static extern IntPtr GetModuleHandle(string name);
         
//        //外部调用的键盘处理事件
//        private   ProcessKeyHandle clientMethod = null;

//        /// <summary>
//        ///  
//        /// </summary>
//        /// <param name="keyhandle"></param>
//        public KeyHook()
//        {
//            //InstallHook(keyhandle);
//        }
//        /// <summary>
//        ///  
//        /// </summary>
//        /// <param name="keyhandle"></param>
//        public   KeyHook(ProcessKeyHandle keyhandle)
//        {
//            InstallHook(keyhandle);
//        }

//        /// <summary>
//        /// 安装钩子
//        /// </summary>
//        /// <param name="keyhandle"></param>
//        public void InstallHook(ProcessKeyHandle keyhandle)
//        {
//            if (this.clientMethod == null)
//            {
//                this.clientMethod = keyhandle;
//                GCHandle.Alloc(this.clientMethod, GCHandleType.Normal);
//                this._KeyBoardHookProcedure = new HookHandle(OnHookProc);
//                GCHandle.Alloc(this._KeyBoardHookProcedure, GCHandleType.Normal);
//                IntPtr hookWindowPtr = GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);
//                this._hHookValue = SetWindowsHookEx(WH_KEYBOARD_LL, this._KeyBoardHookProcedure, hookWindowPtr, 0);
//            }
//        }

//        /// <summary>
//        /// 卸载钩子
//        /// </summary>
//        public  void UninstallHook()
//        {
//            if (this._hHookValue != 0)
//            {
//                bool ret = UnhookWindowsHookEx(this._hHookValue);
//                if (ret)
//                {
//                    this.clientMethod = null;
//                    this._hHookValue = 0;
//                }
//            }
//        }

//        /// <summary>
//        /// 钩子事件内部调用,调用_clientMethod方法转发到客户端应用。
//        /// </summary>
//        /// <param name="nCode"></param>
//        /// <param name="wParam"></param>
//        /// <param name="lParam"></param>
//        /// <returns></returns>
//        private   int OnHookProc(int nCode, int wParam, IntPtr lParam)
//        {
//            if (nCode >= 0)
//            {
//                if (wParam == WM_KEYDOWN)
//                {
//                    //转换结构
//                    HookStruct hookStruct = (HookStruct)Marshal.PtrToStructure(lParam, typeof(HookStruct));

//                    if (this.clientMethod != null)
//                    {
//                        bool handle = false;
//                        //调用客户提供的事件处理程序。
//                        this.clientMethod(hookStruct, out handle);

//                        if (handle) return 1; //1:表示拦截键盘,return 退出
//                    }
//                }
//            }
//            try
//            {
//                return CallNextHookEx(this._hHookValue, nCode, wParam, lParam);
//            }
//            catch
//            {
//                return 0;
//            }
//        }
//    }

     
//}
