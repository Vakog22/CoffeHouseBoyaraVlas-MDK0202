using CoffeHouseBoyaraVlas.DB;
using CoffeHouseBoyaraVlas.Windows.AccessLevel3;
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
using static CoffeHouseBoyaraVlas.ClassHelper.EFHelper;

namespace CoffeHouseBoyaraVlas.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();
            UpdateData();

            if ((ClassHelper.EFHelper.Context.Employee.ToList().Where(i => i.IdAccount == ClassHelper.CurentUserData.account.IdAccount && i.IdRole == 1)).FirstOrDefault() != null)
            {

            }
            else
            {
                btn_addProd.Visibility = Visibility.Collapsed;
                btn_Change.Visibility = Visibility.Collapsed;
                btn_Delete.Visibility = Visibility.Collapsed;
            }

        }
        private void btn_addProd_Click(object sender, RoutedEventArgs e)
        {
            WorkerChangeWindow productChangeWindow = new WorkerChangeWindow(0);
            productChangeWindow.Show();
            UpdateData();

        }

        private void btn_Change_Click(object sender, RoutedEventArgs e)
        {
            if (LvEmployeeList.SelectedItem != null)
            {
                WorkerChangeWindow productChangeWindow = new WorkerChangeWindow((LvEmployeeList.SelectedItem as Employee).IdEmployee);
                productChangeWindow.Show();
                UpdateData();
            }
        }
        private void UpdateData()
        {
            List<Employee> EmployeeList = new List<Employee>();
            EmployeeList = Context.Employee.ToList();
            LvEmployeeList.ItemsSource = EmployeeList;
        }
    }
}
