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
using static CoffeHouseBoyaraVlas.ClassHelper.EFHelper;
using CoffeHouseBoyaraVlas.DB;


namespace CoffeHouseBoyaraVlas.Windows.AccessLevel1
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
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

        private void TbRegistration_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLogin.Text) || string.IsNullOrWhiteSpace(PbPassword.Password))
            {
                MessageBox.Show("Логин или пароль пустые");
                return;
            }
            if (PbPassword.Password != PbPasswordConfirm.Password)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            var AuthUser = Context.Account.ToList().
                Where(i => i.Login == TbLogin.Text).FirstOrDefault();

            if (AuthUser != null)
            {
                MessageBox.Show("Логин занят");
                return;
            }

            
            DB.Account account = new DB.Account();
            account.Login = TbLogin.Text;
            account.Password = PbPassword.Password;
            account.DateCreated = DateTime.Now;

            Context.Account.Add(account);
            Context.SaveChanges();
            MessageBox.Show("Вы успешно зарегестрировались");
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Close();

        }
    }
}
