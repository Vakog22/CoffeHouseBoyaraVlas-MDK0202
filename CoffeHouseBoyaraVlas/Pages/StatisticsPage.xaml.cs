using CoffeHouseBoyaraVlas.Pages.StatisticsPages;
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

namespace CoffeHouseBoyaraVlas.Pages
{
    /// <summary>
    /// Логика взаимодействия для StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        public StatisticsPage()
        {
            InitializeComponent();
        }

        private void btn_addProd_Click(object sender, RoutedEventArgs e)
        {
            SaleStatsPage saleStatsPage = new SaleStatsPage();
            StatsMainFrame.Navigate(saleStatsPage);

        }
    }
}
