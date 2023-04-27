using CoffeHouseBoyaraVlas.ClassHelper;
using CoffeHouseBoyaraVlas.DB;
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

namespace CoffeHouseBoyaraVlas.Pages.StatisticsPages
{
    /// <summary>
    /// Логика взаимодействия для SaleStatsPage.xaml
    /// </summary>
    public partial class SaleStatsPage : Page
    {
        bool IsReverseSort = false;
        public SaleStatsPage()
        {
            InitializeComponent();
            cmbSortBy.SelectedIndex = 0;
            cmbSortBy.ItemsSource = new List<string>() { "ID", "Employee", "Client", "Date", "FullCost"};


            DG.ItemsSource = ClassHelper.EFHelper.Context.VW_SaleStats.ToList();
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            Sort(IsReverseSort);
            IsReverseSort = !IsReverseSort;
            tbxSearch.Text = "";
        }

        private void Sort(bool sortType) {
            if (sortType)
            {
                switch (cmbSortBy.SelectedIndex)
                {
                    default:
                        break;
                    case 0:
                        DG.ItemsSource = EFHelper.Context.VW_SaleStats.ToList().OrderByDescending(i => i.IdSale);
                        break;
                    case 1:
                        DG.ItemsSource = EFHelper.Context.VW_SaleStats.ToList().OrderByDescending(i => i.employee);
                        break;
                    case 2:
                        DG.ItemsSource = EFHelper.Context.VW_SaleStats.ToList().OrderByDescending(i => i.customer);
                        break;
                    case 3:
                        DG.ItemsSource = EFHelper.Context.VW_SaleStats.ToList().OrderByDescending(i => i.dateOfSale);
                        break;
                    case 4:
                        DG.ItemsSource = EFHelper.Context.VW_SaleStats.ToList().OrderByDescending(i => i.FullCost);
                        break;
                }
                btnSort.Content = "Сортировать ↑";
            }
            else {
                switch (cmbSortBy.SelectedIndex)
                {
                    default:
                        break;
                    case 0:
                        DG.ItemsSource = EFHelper.Context.VW_SaleStats.ToList().OrderBy(i => i.IdSale);
                        break;
                    case 1:
                        DG.ItemsSource = EFHelper.Context.VW_SaleStats.ToList().OrderBy(i => i.employee);
                        break;
                    case 2:
                        DG.ItemsSource = EFHelper.Context.VW_SaleStats.ToList().OrderBy(i => i.customer);
                        break;
                    case 3:
                        DG.ItemsSource = EFHelper.Context.VW_SaleStats.ToList().OrderBy(i => i.dateOfSale);
                        break;
                    case 4:
                        DG.ItemsSource = EFHelper.Context.VW_SaleStats.ToList().OrderBy(i => i.FullCost);
                        break;
                }
                btnSort.Content = "Сортировать ↓";
            }
           
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            tbxSearch.Text = "";
            cmbSortBy.SelectedIndex = 0;
            DG.ItemsSource = ClassHelper.EFHelper.Context.VW_SaleStats.ToList();
        }

        private void tbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (cmbSortBy.SelectedIndex)
            {
                default:
                    break;
                case 0:
                    DG.ItemsSource = EFHelper.Context.VW_SaleStats.ToList().Where(i => i.IdSale.ToString().Contains(tbxSearch.Text));
                    break;                                                  
                case 1:                                                     
                    DG.ItemsSource = EFHelper.Context.VW_SaleStats.ToList().Where(i => i.employee.ToString().Contains(tbxSearch.Text));
                    break;                                                  
                case 2:                                                     
                    DG.ItemsSource = EFHelper.Context.VW_SaleStats.ToList().Where(i => i.customer.ToString().Contains(tbxSearch.Text));
                    break;                                                  
                case 3:                                                     
                    DG.ItemsSource = EFHelper.Context.VW_SaleStats.ToList().Where(i => i.dateOfSale.ToString().Contains(tbxSearch.Text));
                    break;                                                  
                case 4:                                                     
                    DG.ItemsSource = EFHelper.Context.VW_SaleStats.ToList().Where(i => i.FullCost.ToString().Contains(tbxSearch.Text));
                    break;
            }
        }
    }
}
