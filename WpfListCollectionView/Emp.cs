using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfListCollectionView
{
    /// 모델의 값이 바뀌면 UI 컨트롤쪽(ViewModel)으로 값이 바꼈다는걸 통지하기 위해
    /// INotifyPropertyChanged를 구현
    public class Emp : INotifyPropertyChanged
    {
        private int _empno;
        private string _ename;
        private string _job;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Empno
        {
            get { return _empno; }
            set { _empno = value; OnPropertyChanged("Empno"); }
        }

        public string Ename
        {
            get { return _ename; }
            set { _ename = value; OnPropertyChanged("Ename"); }
        }

        public string Job
        {
            get { return _job; }
            set { _job = value; OnPropertyChanged("Job"); }
        }

        private void OnPropertyChanged(string PName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PName));
        }
    }
}
