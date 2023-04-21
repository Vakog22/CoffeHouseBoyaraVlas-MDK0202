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

namespace CoffeHouseBoyaraVlas.Pages
{
    /// <summary>
    /// Логика взаимодействия для Basket.xaml
    /// </summary>
    public partial class Basket : Page
    {
        public Basket()
        {
            InitializeComponent();
            GetListProduct();
        }

        private void GetListProduct()
        {
            ObservableCollection<DB.Product> stuffs = new ObservableCollection<DB.Product>(ClassHelper.BasketHelper.products);

             LvProductList.ItemsSource = stuffs;
             
             
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
                if (ClassHelper.BasketHelper.products.Contains(selectedProduct) && selectedProduct.Quantity>1)
                {
                    selectedProduct.Quantity--;
                }
                else
                {
                    ClassHelper.BasketHelper.products.Remove(selectedProduct);
                }
                
            }
            GetListProduct();
        }
    }
}
