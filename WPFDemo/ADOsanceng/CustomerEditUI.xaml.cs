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
    /// CustomerEditUI.xaml 的交互逻辑
    /// </summary>
    public partial class CustomerEditUI : Window
    {
        public bool IsInsert { get; set; }
        public long EditId { get; set; }
        public CustomerEditUI()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (IsInsert)
            {
                Customer customer = (Customer)Grid.DataContext;
                //customer.Address = textAddress.Text;
                //customer.BirthDay = textBirthDay.SelectedDate;
                //customer.CustomerLevel = Convert.ToInt32(textCustomerLevel.Text);
                //customer.Name = textName.Text;
                //customer.TelNum = textTelNum.Text;
                CustomerDAL.Insert(customer);
                CustomerDAL.GetAll();
            }
            else
            {
                Customer customer = (Customer)Grid.DataContext;
                //customer.Address = textAddress.Text;
                //customer.BirthDay = textBirthDay.SelectedDate;
                //customer.CustomerLevel = Convert.ToInt32(textCustomerLevel.Text);
                //customer.Name = textName.Text;
                //customer.TelNum = textTelNum.Text;
                CustomerDAL.Update(customer);
                //CustomerDAL.GetAll();
            }
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (IsInsert)
            {
                //textCustomerLevel.Text = "2";
                Customer customer = new Customer();
                customer.CustomerLevel = 2;
                Grid.DataContext = customer;
            }
            else
            {
                Customer customer = CustomerDAL.GetById(EditId);
                Grid.DataContext = customer;
                //textName.Text = customer.Name;
                //textAddress.Text = customer.Address;
                //textTelNum.Text = customer.TelNum;
                //textCustomerLevel.Text = customer.CustomerLevel.ToString();
                //textBirthDay.SelectedDate = customer.BirthDay;
            }
        }
    }
}
