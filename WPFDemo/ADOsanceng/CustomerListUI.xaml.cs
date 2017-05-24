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
using ADOsanceng.DAL;
using ADOsanceng.Model;

namespace ADOsanceng
{
    /// <summary>
    /// CustomerListUI.xaml 的交互逻辑
    /// </summary>
    public partial class CustomerListUI : Window
    {
        public CustomerListUI()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gridCustomers.ItemsSource = CustomerDAL.GetAll();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            CustomerEditUI editUi = new CustomerEditUI();
            editUi.IsInsert = true;
            if (editUi.ShowDialog() == true)
            {
                gridCustomers.ItemsSource = CustomerDAL.GetAll();
            }

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = (Customer)gridCustomers.SelectedItem;
            if (customer == null)
            {
                MessageBox.Show("请选择要编辑的数据!");
                return;
            }
            CustomerEditUI editUi = new CustomerEditUI();
            editUi.IsInsert = false;
            editUi.EditId = customer.Id;
            if (editUi.ShowDialog() == true)
            {
                gridCustomers.ItemsSource = CustomerDAL.GetAll();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = (Customer)gridCustomers.SelectedItem;
            if (customer == null)
            {
                MessageBox.Show("请选择要删除的行！");
                return;
            }
            if (MessageBox.Show("确定删除这条数据？", "提醒", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CustomerDAL.DeleteById(customer.Id);
                gridCustomers.ItemsSource = CustomerDAL.GetAll();
            }
        }
    }
}
