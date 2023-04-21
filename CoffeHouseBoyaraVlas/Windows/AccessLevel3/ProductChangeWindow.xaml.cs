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
using CoffeHouseBoyaraVlas.DB;

namespace CoffeHouseBoyaraVlas.Windows.Director
{
    /// <summary>
    /// Логика взаимодействия для ProductChangeWindow.xaml
    /// </summary>
    public partial class ProductChangeWindow : Window
    {
        int ind;
        string filePath = string.Empty;
        public ProductChangeWindow(int a)
        {
            ind = a;
            if (a == 0)
            {
                InitializeComponent();
            }
            else {
                InitializeComponent();
                Product product = new Product();
                product = EFHelper.Context.Product.ToList().Where(i => i.IdProduct == a).FirstOrDefault();
                TB_ProdName.Text = product.Name;
                TB_ProdDesc.Text = product.Description;
                TB_ProdPrice.Text = product.Price.ToString();
                if (product.PhotoPath != null)
                {
                    MemoryStream stream = new MemoryStream(product.PhotoPath);
                    I_Photo.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.None);
                }
                else 
                { 
                    BitmapImage bim = new BitmapImage();
                    bim.BeginInit();
                    bim.UriSource = new Uri(@"\Res\logo.png", UriKind.Relative);
                    bim.EndInit();
                    I_Photo.Source = bim;
                }
            }
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
            if (ind == 0)
            {
                DB.Product product = new DB.Product();
                product.Name = TB_ProdName.Text;
                product.Price = d;
                product.Description = TB_ProdDesc.Text;
                product.PhotoPath = File.ReadAllBytes(filePath);

                EFHelper.Context.Product.Add(product);
                EFHelper.Context.SaveChanges();
                MessageBox.Show("Вы успешно добавили товаръ");
            }
            else {
                DB.Product product = EFHelper.Context.Product.ToList().Where(i => i.IdProduct == ind).FirstOrDefault();
                product.Name = TB_ProdName.Text;
                product.Price = d;
                product.Description = TB_ProdDesc.Text;
                EFHelper.Context.SaveChanges();
                MessageBox.Show("Вы успешно изменили товаръ");
            }

            
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
