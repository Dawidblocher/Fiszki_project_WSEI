using System;
using System.Collections.Generic;
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
        public FiszkiHome()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // View Expense Report
            FiszkiPackPage packPage = new FiszkiPackPage();
            this.NavigationService.Navigate(packPage);

        }
    }
}
