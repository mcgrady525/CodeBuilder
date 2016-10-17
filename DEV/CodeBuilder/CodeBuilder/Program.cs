using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CodeBuilder
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

            FrmConnectDatabase frm = new FrmConnectDatabase();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //Application.Run(new FrmMain());
                Application.Run(new FrmMainNew());
            }
        }
    }
}
