using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfDataBindingBasic4
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private Emp _SelectedEmp;
        public Emp SelectedEmp
        {
            get
            {
                return _SelectedEmp;
            }
            set
            {
                _SelectedEmp = value;
                OnPropertyChanged();
            }
        }

        // 모델이 변경되었음을 알리기 위한 코드
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string Pname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Pname));
        }

        // 
        public RelayCommand AddEmpCommand { get; set; }

        // Emp객체 저장용
        public ObservableCollection<Emp> Emps { get; set; }
        
        // 생성자
        public MainWindowViewModel()
        {
            Emps = new ObservableCollection<Emp>();
            Emps.Add(new Emp { Ename = "망고", Job = "의류부서" });
            Emps.Add(new Emp { Ename = "애플", Job = "IT부서" });
            Emps.Add(new Emp { Ename = "포도", Job = "주류부서" });
            Emps.Add(new Emp { Ename = "사과", Job = "고객지원부서" });
            Emps.Add(new Emp { Ename = "바나나", Job = "웰빙부서" });

            AddEmpCommand = new RelayCommand(new Action<object>(AddEmp));
        }

        public void AddEmp(object param)
        {
            Emps.Add(new Emp { Ename = param.ToString(), Job = "발령대기" });
        }
    }
}
