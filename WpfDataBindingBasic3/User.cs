using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

// Model
namespace WpfDataBindingBasic3
{
    class User : INotifyPropertyChanged // 속성의 변경사항을 UI에 통보하기 위해 구현
    {
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                RaisePropertyChanged();
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // 호출쪽에서 인자를 넣어주지 않아도 CallerMemberName으로 자동으로 호출쪽의 인자값을 넣어준다.
        private void RaisePropertyChanged([CallerMemberName] string propertyname = null)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
            // if문을 한줄로 표현가능
            // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}
