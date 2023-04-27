using CoffeHouseBoyaraVlas.ClassHelper;
using CoffeHouseBoyaraVlas.DB;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal fullCost=0;
            if (BasketHelper.products.Count > 0) {
                Sale sale = new Sale();
                sale.IdClient = 0;
                sale.IdEmployee = CurentUserData.SearchforId();
                sale.Date = DateTime.Now;
                EFHelper.Context.Sale.Add(sale);
                EFHelper.Context.SaveChanges();

                

                int saleID = EFHelper.Context.Sale.ToList().LastOrDefault().IdSale;
                foreach (var  prod in BasketHelper.products)
                {
                    SaleProduct saleProduct = new SaleProduct();
                    saleProduct.IdProduct = prod.IdProduct;
                    saleProduct.IdSale = saleID;
                    saleProduct.Quantity = prod.Quantity;
                    fullCost += (EFHelper.Context.Product.ToList().Where(i => i.IdProduct == prod.IdProduct).FirstOrDefault().Price) * prod.Quantity;
                    EFHelper.Context.SaleProduct.Add(saleProduct);
                     EFHelper.Context.SaveChanges();
                    prod.Quantity = 0;

                }
                 MessageBox.Show("Вы заплатили "+ fullCost.ToString() + " денег" );
          ClassHelper.BasketHelper.products.Clear();
            foreach (var prod in BasketHelper.products)
            {
                prod.Quantity = 0;
                BasketHelper.products.Remove(prod);
            }
            EFHelper.Context.SaveChanges();
            GetListProduct();
            }
          
            
        }
    }
}
