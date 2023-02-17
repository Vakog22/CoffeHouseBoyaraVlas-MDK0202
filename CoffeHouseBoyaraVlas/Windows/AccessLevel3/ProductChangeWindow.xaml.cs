using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Microsoft.Win32.OpenFileDialog;
using CoffeHouseBoyaraVlas.ClassHelper;
using Microsoft.Win32;
using static CoffeHouseBoyaraVlas.ClassHelper.EFHelper;



namespace CoffeHouseBoyaraVlas.Windows.Director
{
    /// <summary>
    /// Логика взаимодействия для ProductChangeWindow.xaml
    /// </summary>
    public partial class ProductChangeWindow : Window
    {
        string filePath = string.Empty;
        public ProductChangeWindow()
        {
            InitializeComponent();
        }

        private void BTN_Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_ProdName.Text) || string.IsNullOrWhiteSpace(TB_ProdPrice.Text) || string.IsNullOrWhiteSpace(TB_ProdDesc.Text))
            {
                MessageBox.Show("Поле пустое");
                return;
            }
            decimal d;
            if (Decimal.TryParse(TB_ProdPrice.Text, out d))
            {

            }
            else
            {
                MessageBox.Show("Цена не число или типа того");
                return;
            }

            DB.Product product = new DB.Product();
            product.Name = TB_ProdName.Text;
            product.Price = d;
            product.Description = TB_ProdDesc.Text;
            product.PhotoPath = filePath;

            EFHelper.Context.Product.Add(product);
            EFHelper.Context.SaveChanges();
            MessageBox.Show("Вы успешно добавили товаръ");
        }

        private void BTN_SelectPhoto_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            {
                openFileDialog.InitialDirectory = "c:\\";

                if (openFileDialog.ShowDialog()==true)
                {
                    filePath = openFileDialog.FileName;

                    I_Photo.Source = new BitmapImage(new Uri(filePath));
                }
            }

           
        }
    }
}
