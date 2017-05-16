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

namespace ListBox
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

        private void listBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<Person> list = new List<Person>();
            Person p1 = new Person();
            p1.Name = "safasf";
            p1.Age = "23";
            list.Add(p1);

            list.Add(new Person() {Name = "qeqwe",Age = "12"});
            list.Add(new Person() {Name = "niiovlck",Age = "43"});

            listBox.ItemsSource = list;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            object selectItem = listBox.SelectedItem;
            object selectValue = listBox.SelectedValue;
            button.Content = string.Format("{0}+{1}", selectItem, selectValue);
        }
    }
}
