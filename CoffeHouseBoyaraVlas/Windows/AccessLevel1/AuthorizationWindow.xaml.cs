using CoffeHouseBoyaraVlas.Windows.AccessLevel1;
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
using System.Windows.Shapes;

using CoffeHouseBoyaraVlas.ClassHelper;
using static CoffeHouseBoyaraVlas.ClassHelper.EFHelper;

namespace CoffeHouseBoyaraVlas.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void TbRegistration_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }

        private void TbRegistration_MouseEnter(object sender, MouseEventArgs e)
        {
            TbRegistration.Foreground = Brushes.Blue;
        }

        private void TbRegistration_MouseLeave(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            TbRegistration.Foreground = (Brush)bc.ConvertFrom("#FF634919");
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var AuthUser = Context.Account.ToList().Where(i => i.Login == TbLogin.Text && i.Password == PbPassword.Password).FirstOrDefault();

            if (AuthUser != null)
            {
                //MainWindow mainWindow = new MainWindow();
                //mainWindow.Show();
                //this.Close();\
                ProfileWindow profile = new ProfileWindow();
                profile.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Такого аккаунта нет");
            }

        }
    }
}
