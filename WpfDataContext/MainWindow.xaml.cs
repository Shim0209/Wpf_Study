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

namespace WpfDataContext
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Emp emp = new Emp()
            {
                Ename = "심연성",
                City = "용인"
            };

            this.DataContext = emp;
        }

        private void OnClicked(object sender, RoutedEventArgs args)
        {
            Emp e = this.DataContext as Emp;
            System.Console.WriteLine(e.Ename);
            System.Console.WriteLine(e.City);
        }
    }
}
