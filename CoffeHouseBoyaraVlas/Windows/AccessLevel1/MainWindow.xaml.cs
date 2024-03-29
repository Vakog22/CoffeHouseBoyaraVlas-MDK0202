﻿using CoffeHouseBoyaraVlas.DB;
using CoffeHouseBoyaraVlas.Pages;
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
        bool isMenuShow = true;
        public MainWindow()
        {
            InitializeComponent();
            btnAvalibaleChek();
            
            ProductShow PS = new ProductShow();
            F_MainFrame.Navigate(PS);
        }

        private void btn_editAccount_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Show();
            this.Close();
        }

        private void btn_clients_Click(object sender, RoutedEventArgs e)
        {
            ClientPage EP = new ClientPage();
            F_MainFrame.Navigate(EP);
        }

        private void btn_employees_Click(object sender, RoutedEventArgs e)
        {
            EmployeePage EP = new EmployeePage();
            F_MainFrame.Navigate(EP);
        }

        private void btnAvalibaleChek()
        {
            if ((ClassHelper.EFHelper.Context.Employee.ToList().Where(i => i.IdAccount == ClassHelper.CurentUserData.account.IdAccount && i.IdRole == 1)).FirstOrDefault() != null)
            {

            }
            else
            {
                btn_statistics.Visibility = Visibility.Collapsed;
                btn_clients.Visibility = Visibility.Collapsed;
                btn_employees.Visibility = Visibility.Collapsed;
            }
        }

        private void btn_products_Click(object sender, RoutedEventArgs e)
        {
            ProductShow PS = new ProductShow();
            F_MainFrame.Navigate(PS);
        }

        private void btn_busket_Click(object sender, RoutedEventArgs e)
        {
            Basket basket = new Basket();
            F_MainFrame.Navigate(basket);
        }

        private void btn_statistics_Click(object sender, RoutedEventArgs e)
        {
            StatisticsPage statisticsPage = new StatisticsPage();
            F_MainFrame.Navigate(statisticsPage);
        }

        private void btn_menu_Click(object sender, RoutedEventArgs e)
        {
            
            if (isMenuShow)
            {stk_MenuStakPAnnel.Visibility = Visibility.Hidden;
                grd_Main.ColumnDefinitions.Clear();
                btn_menu.Content = "→";
            }
            else
            {
                for (int i = 0; i < 6; i++)
                {
                    grd_Main.ColumnDefinitions.Add(new ColumnDefinition());
                }
                stk_MenuStakPAnnel.Visibility = Visibility.Visible;
                btn_menu.Content = "←";
            }
            isMenuShow = !isMenuShow;
        }
    }
}
