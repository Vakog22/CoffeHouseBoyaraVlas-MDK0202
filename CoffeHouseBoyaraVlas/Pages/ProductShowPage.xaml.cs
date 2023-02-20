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

            List<Product> ProductList = new List<Product>();
            ProductList = Context.Product.ToList();
            LvProductList.ItemsSource = ProductList;
        }
    }
}
