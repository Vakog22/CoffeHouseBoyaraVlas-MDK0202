using CoffeHouseBoyaraVlas.ClassHelper;
using CoffeHouseBoyaraVlas.DB;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace CoffeHouseBoyaraVlas.Windows.AccessLevel3
{
    /// <summary>
    /// Логика взаимодействия для WorkerChangeWindow.xaml
    /// </summary>
    public partial class WorkerChangeWindow : Window
    {
        int ind;
        public WorkerChangeWindow(int a)
        {
            InitializeComponent();
            ind = a;
            CB_IdRole.ItemsSource = Context.Role.ToList();
            CB_IdRole.SelectedIndex = 0;
            CB_IdRole.DisplayMemberPath = "Name";

            CB_IsMale.ItemsSource = new List<bool>() { true, false };
            CB_IsMale.SelectedIndex = 0;
            if (a == 0)
            {
                InitializeComponent();
            }
            else
            {
                InitializeComponent();
                Employee employee = new Employee();
                employee = EFHelper.Context.Employee.ToList().Where(i => i.IdEmployee == a).FirstOrDefault();
                TB_Name.Text = employee.Name;
                TB_Surename.Text = employee.Surename;
                TB_Patronimic.Text = employee.Patronimyc;
                CB_IdRole.SelectedItem = employee.Role;
                DpDateOfBirth.Text = employee.DateOfBirth.ToString();
                DpDateOfEmploy.Text = employee.DateOfEmployment.ToString();
                TbEmail.Text = employee.Email;

                TbLogin.Text = employee.Account.Login.ToString();
                TbPassword.Text= employee.Account.Password.ToString();
            }
        }

        private void BTN_Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (ind == 0)
            {
                try
                {

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                Account account = new Account();
                account.Login = TbLogin.Text;
                account.Password = TbPassword.Text;
                Context.Account.Add(account);
                Context.SaveChanges();

                Employee employee = new Employee();
                employee.Name = TB_Name.Text;
                employee.Surename = TB_Surename.Text;
                employee.Patronimyc = TB_Patronimic.Text;
                employee.IdRole = (CB_IdRole.SelectedItem as Role).IdRole;
                employee.DateOfBirth = Convert.ToDateTime(DpDateOfBirth.Text);
                employee.DateOfEmployment = Convert.ToDateTime(DpDateOfEmploy.Text);
                employee.Email = TbEmail.Text;
                employee.IsMale = Convert.ToBoolean(CB_IsMale.SelectedItem);
                employee.IdAccount = Context.Account.ToList().Where(i => i.Login == TbLogin.Text).FirstOrDefault().IdAccount;
                Context.Employee.Add(employee);
                Context.SaveChanges();
            }
            else
            {
                Employee employee = new Employee();
                employee = EFHelper.Context.Employee.ToList().Where(i => i.IdEmployee == ind).FirstOrDefault();
                employee.Name = TB_Name.Text;
                employee.Surename = TB_Surename.Text;
                employee.Patronimyc = TB_Patronimic.Text;
                employee.IdRole = (CB_IdRole.SelectedItem as Role).IdRole;
                employee.DateOfBirth= Convert.ToDateTime(DpDateOfBirth.Text);
                employee.DateOfEmployment = Convert.ToDateTime(DpDateOfEmploy.Text);
                employee.Email = TbEmail.Text;
                employee.IsMale = Convert.ToBoolean(CB_IsMale.SelectedItem);

                employee.Account.Login = TbLogin.Text;
                employee.Account.Password = TbPassword.Text;
                Context.SaveChanges();
            }
        }
    }
}
