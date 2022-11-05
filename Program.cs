using System;
using PManager.Models;
using PManager.Views;
using PManager.Database;

namespace PManager
{
    public delegate void Notify();
    public delegate void NotifyWithString(string s);
    class Program
    {

        [STAThread]
        public static void Main()
        {
            DbManager manager = new DbManager();

            App app = new App(manager);
            app.Run();
        }
    }
}