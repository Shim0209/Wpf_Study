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
using System.Data.SqlClient;

namespace Wpf_MSSQLTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            
            try
            {
                string conString = "server=.;database=TestDB;Integrated Security=true;";
                con.ConnectionString = conString;
                con.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = con;
                sqlCommand.CommandText = "SELECT * FROM people";
                SqlDataReader sqlData = sqlCommand.ExecuteReader();
                {
                    while (sqlData.Read())
                    {
                        Console.WriteLine($"No : {sqlData[0].ToString()}");
                        Console.WriteLine($"Name : {sqlData[1].ToString()}");
                        Console.WriteLine($"Age : {sqlData[2].ToString()}");
                        Console.WriteLine();
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
