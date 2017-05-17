using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace ADO.Net
{ 
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        string sqlStr = ConfigurationManager.ConnectionStrings["dbConnStr"].ConnectionString;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SqlHelper.ExecuteNonQuery("insert into Student(Stu_name,Stu_desc) values('vxcvxcv','rteye');");
            MessageBox.Show("执行完成");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(sqlStr))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "select * from Student";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int stu_id = reader.GetInt32(0);
                            string stu_name = reader.GetString(1);
                            string stu_desc = reader.GetString(2);
                            MessageBox.Show("stu_id:"+stu_id+","+ "stu_name:" + stu_name + ","+ "stu_desc:" + stu_desc);
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(sqlStr))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    //cmd.CommandText = "select Stu_id from Student where Stu_name='" + textBox.Text + "';";
                    cmd.CommandText = "select Stu_id from Student where Stu_name=@Name";
                    cmd.Parameters.Add(new SqlParameter("@Name", textBox.Text));
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MessageBox.Show(reader.GetInt32(0).ToString());
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            
            using (SqlConnection connection = new SqlConnection(sqlStr))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "select * from Student where Stu_name=@Name";
                    cmd.Parameters.Add(new SqlParameter("@Name", textBox.Text));
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    
                    DataTable table = dataSet.Tables[0];
                    DataRowCollection rows = table.Rows;
                    for (int i = 0; i < rows.Count; i++)
                    {
                        DataRow row = rows[i];
                        int stu_id = (int)row["Stu_id"];
                        string stu_name = (string) row["Stu_name"];
                        string stu_desc = (string)row["Stu_desc"];
                        MessageBox.Show(stu_id + stu_name + stu_desc);
                    }

                }
            }
        }
    }
}
