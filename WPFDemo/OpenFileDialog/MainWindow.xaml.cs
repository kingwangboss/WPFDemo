using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

namespace OpenFileDialog
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
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "文本文件|*.txt|PNG图片|*.png";
            if (ofd.ShowDialog() == true)
            {
                string file = ofd.FileName;
                MessageBox.Show("打开文件"+ file);
            }
            else
            {
                MessageBox.Show("取消");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog sfd = new Microsoft.Win32.SaveFileDialog();
            sfd.Filter = "文档文件|*.doc";
            if (sfd.ShowDialog() == true)
            {
                MessageBox.Show(sfd.FileName);
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.Filter = "JPEG图片|*.jpg|PNG图片|*.png";
            if (ofd.ShowDialog() == true)
            {
                string picFileName = ofd.FileName;
                image.Source = new BitmapImage(new Uri(picFileName));
            }
        }
    }
}
