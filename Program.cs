using ManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagementSystem.Model;
using ManagementSystem.Presenter;
using ManagementSystem.Repositories;


namespace ManagementSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string connectionString = @"Data Source=./Databases/Sacco.db;Version=3;New=True;Compress=True;";
            IMainView view = new Main();
            new MainPresenter(view, connectionString);
            Application.Run((Form)view);
        }
    }
}
