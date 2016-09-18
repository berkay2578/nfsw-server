using System;
using System.Windows.Forms;

namespace AddonManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form targetForm;
            if (Properties.Settings.Default.hasRunManagerBefore)
                targetForm = new MainForm();
            else
                targetForm = new FirstRunForm();
            Application.Run(targetForm);
        }
    }
}
