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
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();
            List<Employee> EmployeeList = new List<Employee>();
            EmployeeList = Context.Employee.ToList();
            LvEmployeeList.ItemsSource = EmployeeList;
        }
    }
}
