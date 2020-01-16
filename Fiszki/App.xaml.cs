using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Fiszki
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string databaseName = "fiszki.db";
        static string pathFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string databasePath = System.IO.Path.Combine(pathFolder, databaseName);

    }
}
