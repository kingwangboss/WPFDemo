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

namespace RoutedEvent
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

        private void ButtonClick_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("I am the outer button");
        }

        private void OuterEllipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("I am the green ellipse");
        }

        private void InnerButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("I am the Inner ellipse");
        }
    }
}
