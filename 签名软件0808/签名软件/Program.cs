using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 签名软件
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
            //Application.SetCompatibleTextRenderingDefault(false);
            MDIParent1 Frm_MainMid = new MDIParent1();
            staticMain.MainMDI = Frm_MainMid;
            Application.Run(staticMain.MainMDI);
            //Application.Run(new Form1());
        }
    }
}
