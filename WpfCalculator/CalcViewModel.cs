using System.ComponentModel;
using System.Windows.Input;

namespace WpfCalculator
{
    class CalcViewModel : INotifyPropertyChanged
    {
        // 아래 두 필드는 속성으로 구현되어 있다.
        // 출력될 문자들을 담아둘 변수
        string inputString = "";

        // 계산기화면의 출력 텍스트박스에 대응되는 필드
        string displayText = "";

        // View와 바인딩된 속성값이 바뀔때 이를 WPF에게 알리기 위한 이벤트
        public event PropertyChangedEventHandler PropertyChanged;

        // 생성자, 명령객체들을 초기화
        // 명령객체들은 UI쪽 버튼의 Command에 바인딩 되어 있다.
        public CalcViewModel()
        {
            // 이벤트 핸들러 정의
            // 숫자 버튼을 클릭할 때 실행
            this.Append = new Append(this);

            // 백스페이스 버튼을 클릭할 때 실행, 한글자 삭제
            this.Backspace = new Backspace(this);

            // 출력화면 클리어
            this.Clear = new Clear(this);

            // +,-,*,/ 등 연산자 클릭할 때 실행
            this.Operator = new Operator(this);

            // '=' 버튼을 클릭할 때 실행
            this.Calculate = new Calculate(this);
        }

        public string InputString
        {
            get { return inputString; }
            internal set
            {
                if (inputString != value)
                {
                    inputString = value;
                    OnPropertyChanged("InputString");
                    if(value != "")
                    {
                        // 숫자를 여러개 입력하면 계속 화면에 출력하기 위해
                        DisplayText = value;
                    }
                }
            }
        }

        // 계산기의 출력창과 바인딩된 속성
        public string DisplayText
        {
            get { return displayText; }
            internal set
            {
                if(displayText != value)
                {
                    displayText = value;
                    OnPropertyChanged("DisplayText");
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Op { get; set; }      // Operator
        public double? Op1 { get; set; }    // Operand1

        // 명령객체
        public ICommand Append { protected set; get; }
        public ICommand Backspace { protected set; get; }
        public ICommand Clear { protected set; get; }   
        public ICommand Operator { protected set; get; }
        public ICommand Calculate { protected set; get; } 
    }
}
