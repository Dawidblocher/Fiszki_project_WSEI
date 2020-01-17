using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fiszki
{
    /// <summary>
    /// Logika interakcji dla klasy FiszkiHome.xaml
    /// </summary>
    public partial class FiszkiHome : Page
    {
        public List<Category> Categories = new List<Category>();
        
        public FiszkiHome()
        {
            InitializeComponent();
            LoadCategory();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FiszkiPackPage packPage = new FiszkiPackPage(this.CategoryListBox.SelectedItem as ListBoxItem);
            this.NavigationService.Navigate(packPage);

        }

        private void LoadCategory()
        {
            Categories = DatabaseAccess.LoadCategorys();
            foreach(var cat in Categories)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = cat.nazwa;
                CategoryListBox.Items.Add(item);
                
            }
            

        }
    }
}
