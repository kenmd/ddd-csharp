using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Views;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // this is basic sample from https://anderson02.com/winforms-menu/
            // Application.Run(new MenuForm());

            // this is DDD sample from https://anderson02.com/ddd-menu/
            Application.Run(new MenuView());
        }
    }
}
