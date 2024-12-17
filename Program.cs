using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using test.Presenter;
using test.Presenter.Class;
using test.VIew.Class;

namespace test
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginWindow loginWindow = new LoginWindow();
            //Application.Run(loginWindow);
            MainWindow mainWindow = new MainWindow();
            AddWindow addWindow = new AddWindow();
            MainPresenter presenter = new MainPresenter(mainWindow, addWindow);
            Application.Run(mainWindow);
            //System.Windows.Forms.Application.Exit();
        }
    }
}
