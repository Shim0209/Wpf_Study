using System;
using System.Collections.Generic;
using System.Windows;
using System.Data.SqlClient;

/**
 * 1. 데이터베이스 사용하기 위해서 참조추가
 * 2. 프로젝트 우클릭 - 속성 - 빌드 - 플랫폼타켓 x64 설정
 */
namespace Wpf_OracleTest
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

        SqlConnection con = new SqlConnection();

        private void DB_Connect(object sender, RoutedEventArgs e)
        {
            try
            {
                string conString = "server=.;database=TestDB;Integrated Security=true;";
                con.ConnectionString = conString;
                con.Open();

                MessageBox.Show("DB Connection OK!");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void Select_Emp(object sender, RoutedEventArgs e)
        {
            string getPeopleAll = "SELECT * FROM people";

            SqlCommand sqlCommand = new SqlCommand();
            if (con == null) DB_Connect(this, null);
            sqlCommand.Connection = con;
            sqlCommand.CommandText = getPeopleAll;


            List<PeopleViewModel> emps = new List<PeopleViewModel>();

            SqlDataReader sqlData = sqlCommand.ExecuteReader();
            {
                while (sqlData.Read())
                {
                    emps.Add(new PeopleViewModel()
                    {
                        No = (int)sqlData[0],
                        Name = (string)sqlData[1],
                        Age = (int)sqlData[2]
                    });
                }
                listView.ItemsSource = emps;
            }
            con.Close();
        }
    }
}
