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

namespace WpfBasics
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

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The description is {this.DescriptionText.Text}");
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            this.WeldCheckBox.IsChecked 
            = this.AssemblyCheckBox.IsChecked 
            = this.PlasmaCheckBox.IsChecked 
            = this.LaserCheckBox.IsChecked 
            = this.PurchaseCheckBox.IsChecked
            = this.LatheCheckBox.IsChecked 
            = this.DrillCheckBox.IsChecked 
            = this.FoldCheckBox.IsChecked 
            = this.RollCheckBox.IsChecked 
            = this.SawCheckBox.IsChecked 
            = false;

            this.LengthText.Text = "";
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.LengthText.Text += (string)((CheckBox)sender).Content;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.LengthText.Text = this.LengthText.Text.Replace((string)((CheckBox)sender).Content,"");
        }

        private void FinishComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // NoteText 객체가 만들어지기 전에 실행되는 문제를 해결하기 위함
            if (this.NoteText == null)
                return;
   
            var combo = (ComboBox)sender;
            var comboItem = (ComboBoxItem)combo.SelectedValue;
            this.NoteText.Text = (string)comboItem.Content;
        }

        /**
         * XAML의 Window에 Loaded 이벤트를 만들면
         * UI가 전부 로드된 후에 정의된 로직을 수행한다.
         */
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FinishComboBox_SelectionChanged(this.FinishDropdown, null);
        }

        private void SupplierNameText_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.MassText.Text = this.SupplierNameText.Text;
        }
    }
}
