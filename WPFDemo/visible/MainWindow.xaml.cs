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

namespace visible
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
            if (textBlock.Visibility == Visibility.Visible)
            {
                textBlock.Visibility = Visibility.Collapsed;
                button.Content = "显示";
            }
            else if (textBlock.Visibility == Visibility.Collapsed)
            {
                textBlock.Visibility = Visibility.Visible;
                button.Content = "隐藏";
            }
        }
    }
}
