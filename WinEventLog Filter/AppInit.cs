using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WinEventLog_Browser
{
    static class AppInit
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
