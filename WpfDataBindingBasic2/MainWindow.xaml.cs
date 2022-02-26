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

/// <summary>
/// TextBox의 Text 속성과 Label의 Content 속성을 바인딩 하는 예제
/// TextBox의 값을 수정하면 Text 속성의 값을 Label의 Content 속성에 바인딩
/// 
/// C#코드에서 TextBox의 TextChanged 이벤트 핸들러를 이용하거나 XAML파일로 바인딩
/// 
/// 바인딩 자체는 언제나 타겟에 설정한다.
/// </summary>

namespace WpfDataBindingBasic2
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
    }
}
