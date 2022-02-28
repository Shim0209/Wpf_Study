using System.Windows;

/// <summary>
/// WPF Command 패턴의 이해 및 Command, 데이터바인딩 실습
/// 
/// MVVM에서는 Click 이벤트 핸들러를 이용하기 보다는 Command를 이용하기를 권장한다.
/// 여러 버튼에서 하나의 Command를 공유할 수 있으므로 모든 컨트롤마다 Click 이벤트를
/// 만드는 방법 보다는 효율적이기 때문이다.
/// 
/// WPF의 명령(Command)은 ICommand 인터페이스를 구현하여 만들며 ICommand는 Execute 및
/// CanExecute라는 두 가지 메서드와 CanExecuteChanged 이벤트를 제공한다.
/// 
/// Execute 메서드는 실제 처리해야 하는 작업을 기술하고 CanExecute 메소드에서는 Execute 
/// 메소드의 코드를 실행할지 여부를 결정하는 코드를 기술한다. CanExecute가 false를 리턴하면
/// Execute 메소드는 호출되지 않는다.
/// 
/// 즉, CanExecute 메소드는 명령을 사용 가능하게 하거나 불가능하게 할 때 사용되며, 명령을
/// 사용할 수 있는지 여부를 확인하기 위해 WPF에 의해 호출된다. 이 메소드는 키보드 GET포커스,
/// LOST포커스, 마우스 업 등과 같은 UI 상호 작용 중에 대부분 발생한다. 
/// 
/// 사용자 정의 명령의 경우 CanExecute 메서드가 대부분의 시나리오에서 호출되지는 않으므로 어떤 
/// 조건에 따라 버튼을 활성화, 비활성화 해야 할 수도 있는데 ICommand 구현체에서 CanExecuteChanged
/// 이벤트를 CommandManager의 RequerySuggested 이벤트에 연결하면 된다.
/// 
/// CanExecute 메소드가 호출되어 CanExecute의 상태가 변경되면 CanExecuteChanged 이벤트가
/// 발생해야 하며, WPF는 CanExecute를 호출하고 Command에 연결된 컨트롤의 상태를 변경한다.
/// 
/// CanExecuteChanged 이벤트는 해당 ICommand에 바인딩된 모든 명령 소스(버튼, 메뉴아이템)에
/// CanExecute에 의해 반환 된 값이 변경 되었음을 알린다.
/// 
/// Command 패턴에서는 몇가지 주체가 있는데, 서비스를 요청하는 클라이언트(손님), 명령을 서술
/// 하는 Command Object(주문서), 명령을 요청하는 Comamnd Invoker(웨이터), 특정 명령을 실제
/// 처리하는 Command Receiver(Target, 요리사)가 있다.
/// 
/// CommandManager.RequerySuggested 이벤트는 CommandManager가 명령 실행에 영향을 줄 수있는
/// 변경 사항이 있다고 생각할 때마다 발생하며 이때마다 CanExecute가 호출된다.
/// CanExecuteChanged이벤트는 CammandManager가 명령 실행 기능이 변경되었다고 생각할 때마다
/// 발생시킨다. 
/// 
/// 
/// </summary>
namespace WpfDataBindingBasic4
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
