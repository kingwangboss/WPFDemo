using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
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
        private Son s1 = new Son();
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            s1.Age += 1;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(s1.Age.ToString());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            s1.Age = 18;
            textBox.DataContext = s1;
        }
    }

    public class Son :INotifyPropertyChanged
    {
        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                this.age = value;
                //if (PropertyChanged != null)
                //{
                //    PropertyChanged(this,new PropertyChangedEventArgs("Age"));
                //}
                OnPropertyChanged("Age");
            }
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
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
