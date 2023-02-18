using CoffeHouseBoyaraVlas.ClassHelper;
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

namespace CoffeHouseBoyaraVlas.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        int IdAccount;
        public ProfileWindow(int a)
        {
            IdAccount = a;
            InitializeComponent();
            IdAcc.Text = a.ToString();

            CMBGender.ItemsSource = new List<bool>() { true, false};
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                if (string.IsNullOrWhiteSpace(TbName.Text) || string.IsNullOrWhiteSpace(TbSurename.Text) || string.IsNullOrWhiteSpace(TbEmail.Text))
                {
                    MessageBox.Show("Поле пустое");
                    return;
                }

            DB.Client client = new DB.Client();
            client.IdAccount = IdAccount;
            client.Surename = TbSurename.Text;
            client.Name = TbName.Text;
            client.Email = TbEmail.Text;
            client.DateOfBirth = Convert.ToDateTime(DpDateOfBirth.Text);
            //client.IsMale = CMBGender.SelectedItem as bool;

            EFHelper.Context.Client.Add(client);
            EFHelper.Context.SaveChanges();
            MessageBox.Show("Ништяк");
        }
    }
}
