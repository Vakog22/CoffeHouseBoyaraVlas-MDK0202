using CoffeHouseBoyaraVlas.Windows;
using CoffeHouseBoyaraVlas.Windows.Director;
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

namespace CoffeHouseBoyaraVlas
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int IDAccount;
        public MainWindow(int a)
        {
            IDAccount = a;
            InitializeComponent();
            IdShow.Text = a.ToString();
        }

        private void btn_changeProd_Click(object sender, RoutedEventArgs e)
        {
            ProductChangeWindow productChangeWindow = new ProductChangeWindow();
            productChangeWindow.Show();
            this.Close();
        }

        private void btn_editAccount_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow(IDAccount);
            profileWindow.Show();
            this.Close();
        }
    }
}
