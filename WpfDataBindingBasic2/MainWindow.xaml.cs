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
/// 
/// 바인딩모드 4가지
/// 1. OneWay : Default 단방향 바인딩
/// 2. TwoWay : Target의 변화도 Source에 반영된다.
/// 3. OneTime : Target이 소스로 초기화 되자만 소스의변화가 계속 반영되지 않고 초기 한번만 반영
/// 4. OneWayToSource : 타켓이 소스를 갱신하는 모양
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

            Binding bind = new Binding();
            bind.Source = txt1;
            bind.Path = new PropertyPath(TextBox.TextProperty);

            // SetBinding의 첫 번째 인자는 DependencyProperty 타입이 되어야 한다.
            // 그러므로 타겟의 속성은 의존속성의 지원을 받는 속성이 되야 한다.
            label.SetBinding(Label.ContentProperty, bind);
        }
    }
}
