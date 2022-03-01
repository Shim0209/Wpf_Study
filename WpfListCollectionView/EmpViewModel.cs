using System.Collections.ObjectModel;

/// <summary>
/// 
/// </summary>
namespace WpfListCollectionView
{
    class EmpViewModel : ObservableCollection<Emp>
    {
        public EmpViewModel()
        {
            Add(new Emp() { Empno = 1, Ename = "망고", Job = "과일" });
            Add(new Emp() { Empno = 2, Ename = "가지", Job = "채소" });
            Add(new Emp() { Empno = 3, Ename = "오이", Job = "채소" });
            Add(new Emp() { Empno = 4, Ename = "토마토", Job = "채소" });
            Add(new Emp() { Empno = 5, Ename = "소고기", Job = "정육" });
            Add(new Emp() { Empno = 6, Ename = "갈치", Job = "수산" });
            Add(new Emp() { Empno = 7, Ename = "연성", Job = "매니저" });
        }
    }
}
