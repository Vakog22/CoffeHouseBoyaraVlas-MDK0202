using CoffeHouseBoyaraVlas.DB;
using CoffeHouseBoyaraVlas.Windows.Director;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static CoffeHouseBoyaraVlas.ClassHelper.EFHelper;

namespace CoffeHouseBoyaraVlas.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductShow.xaml
    /// </summary>
    public partial class ProductShow : Page
    {
        public ProductShow()
        {
            InitializeComponent();
            UpdateData();
            
            if ((ClassHelper.EFHelper.Context.Employee.ToList().Where(i => i.IdAccount == ClassHelper.CurentUserData.account.IdAccount && i.IdRole == 1)).FirstOrDefault() != null)
            {

            }
            else 
            {
                btn_addProd.Visibility = Visibility.Collapsed;
                btn_Change.Visibility = Visibility.Collapsed;
                btn_Delete.Visibility = Visibility.Collapsed;
            }
        }

        private void btn_addProd_Click(object sender, RoutedEventArgs e)
        {
                ProductChangeWindow productChangeWindow = new ProductChangeWindow(0);
                productChangeWindow.Show();
                UpdateData();
            
        }

        private void btn_Change_Click(object sender, RoutedEventArgs e)
        {
            if (LvProductList.SelectedItem != null)
            {
                ProductChangeWindow productChangeWindow = new ProductChangeWindow((LvProductList.SelectedItem as Product).IdProduct);
                productChangeWindow.Show();
                UpdateData();
            }
        }

        private void UpdateData()
        {
            List<Product> ProductList = new List<Product>();
            ProductList = Context.Product.ToList();
            LvProductList.ItemsSource = ProductList;
        }

        private void btn_AddToBasket_Click(object sender, RoutedEventArgs e)
        {
Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            var selectedProduct = button.DataContext as DB.Product;

            if (selectedProduct != null)
            {
                if (ClassHelper.BasketHelper.products.Contains(selectedProduct))
                {
                    selectedProduct.Quantity++;
                }
                else
                {
                    selectedProduct.Quantity++;
                    ClassHelper.BasketHelper.products.Add(selectedProduct);
                }
            }
        }
    }
}
