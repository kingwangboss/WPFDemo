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

namespace MoreWindows
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            InputWindow inputWindow = new InputWindow();
            bool? b = inputWindow.ShowDialog();
            if (b == null)
            {
                MessageBox.Show("没设置");
            }else if (b == true)
            {
                MessageBox.Show("确定" + inputWindow.InputValue);
            }
            else
            {
                MessageBox.Show("取消");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ffff","提示",MessageBoxButton.OK);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r1 = MessageBox.Show("确定还是取消？", "提示", MessageBoxButton.OKCancel);
            if (r1 == MessageBoxResult.OK)
            {
                MessageBox.Show("确定");
            }else if (r1 == MessageBoxResult.Cancel)
            {
                MessageBox.Show("取消");
            }
            else
            {
                
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r1 = MessageBox.Show("真的要删除？", "警告", MessageBoxButton.YesNo);
            if (r1 == MessageBoxResult.Yes)
            {
                MessageBox.Show("删除");
            }else if (r1 == MessageBoxResult.No)
            {
                MessageBox.Show("取消删除");
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult r1 = MessageBox.Show("删除吗？", "提示", MessageBoxButton.YesNoCancel);
            if (r1 == MessageBoxResult.Yes)
            {
                MessageBox.Show("执行删除");
            }else if (r1 == MessageBoxResult.No)
            {
                MessageBox.Show("不执行删除");
            }else if (r1 == MessageBoxResult.Cancel)
            {
                MessageBox.Show("取消");
            }
            else
            {
                
            }
        }
    }
}
