using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Protein.Enzyme.DynamicProxy;
using Protein.Enzyme.Design;
namespace Test
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ClassDrive cdiv = new ClassDrive();
            Form1 frm = cdiv.ProxyInstance<Form1>(typeof(Form1));
            Application.Run(frm);
        }
    }
}
