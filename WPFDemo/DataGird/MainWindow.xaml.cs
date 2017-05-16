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

namespace DataGird
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Person> list = new List<Person>();
            list.Add(new Person() {Name = "sadfa",Age = 3,Score = 100});
            list.Add(new Person() { Name = "wwrq", Age = 32, Score = 75.85f });
            list.Add(new Person() { Name = "jymw", Age = 23, Score = 43.65f });
            list.Add(new Person() { Name = "xcasda", Age = 54, Score = 87.9f });
            dataGrid.ItemsSource = list;
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public float Score { get; set; }
    }
}
