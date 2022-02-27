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
/// INotifyPropertyChanged 인터페이스, PropertyChanged 이벤트를
/// 이용한 데이터 바인딩
/// 
/// 데이터바인딩에서 소스 객체를 UI 컨트롤 일수도 있지만 C#의 일반
/// 클래스가 될 수도 있는데 이 경우 프로퍼티(속성)의 값이 변경되는
/// 경우 이를 타켓 객체에 알릴 수 있는 매커니즘이 필요
/// 
/// WPF 데이터 바인딩은 이벤트가 INotifyPropertyChanged 인터페이스를
/// 구현한 클래스안에 정의되어 있으면 이벤트를 찾는데
/// 소스 객체의 속성값의 변경을 UI객체에 통지하기 위해서는 이 인터페이스를 
/// 상속받아 구현하고 PropertyChangedEventHandler 델리게이트를 기본으로 
/// 하는 PropertyChanged 이벤트를 정의해야 한다.
/// 
/// PropertyChanged 이벤트를 발생시킬 때의 첫 인자는 this이며 두번째 인자는
/// PropertyChangedEventArgs 타입의 객치이다. PropertyChangedEventArgs는 
/// String타입의 PropertyName이라는 프로퍼티가 정의되어 있는데 프로퍼티를
/// 구별하기 위해 사용한다. 그래서 new 프로퍼티 이름을 넣어준다.
/// 
/// CallerMemberName특성을 통해 어느 프로퍼티에서 PropertyChanged이벤트가
/// 발생했는지 확인 가능 하다. 만약 CallerMemberName 특성이 없으면 프로퍼티
/// 이름을 문자열로 지정해야 한다.
/// PropertyChanged?.invoke(this, new PropertyChangedEventArgs(propertyname));
/// 
/// 이 방법은 다수의 프로퍼티를 다루는 좋은 방법이다. 하나의 PropertyChanged 이벤트가
/// 모든 프로퍼티(속성)에 대한 변경을 처리할 수 있기 때문이다.
/// </summary>
 
namespace WpfDataBindingBasic3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UserViewModel v = new UserViewModel();
            this.DataContext = v;
        }

        // MessageBox에 현재 Model값 출력
        private void button_Show(object sender, RoutedEventArgs e)
        {
            // 현재 DataContext값을 읽어오기
            UserViewModel v = this.DataContext as UserViewModel;
            MessageBox.Show(v.FirstName + "," + v.LastName);
        }

        // ViewModel값을 변경
        private void button_Change(object sender, RoutedEventArgs e)
        {
            UserViewModel v = this.DataContext as UserViewModel;
            v.FirstName = "홍";
            v.LastName = "길동";
        }
    }
}
