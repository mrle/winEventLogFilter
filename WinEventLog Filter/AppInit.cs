using System;
using System.Windows.Forms;

namespace WinEventLog_Filter
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
