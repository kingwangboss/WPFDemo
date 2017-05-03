using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace INotifyPropertyChangedInterface
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public Person personobj { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            personobj = new Person()
            {
                FirstName = "123",
                LastName = "sasfa"
            };
            this.DataContext = personobj;
        }
    }

    public class Person:INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private string fullName;

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged("FiestName");
                    OnPropertyChanged("FullName");
                }
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                    OnPropertyChanged("FullName");
                }
            }
        }

        public string FullName
        {
            get
            {
                return fullName = firstName + " " + lastName;
            }

            set
            {
                if (fullName != value)
                {
                    fullName = value;
                    OnPropertyChanged("FullName");
                }
            }
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
