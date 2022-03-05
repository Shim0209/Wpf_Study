using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WpfListBox2
{
    class RelayCommand : ICommand
    {
        // Fileds
        private Action<object> execute;
        private Predicate<object> canExecute;
        //private event EventHandler CanExecuteChangedInternal;

        // Constructor
        public RelayCommand(Action<object> execute) : this(execute, DefaultCanExecute)
        {

        }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if(execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }
            this.execute = execute;
            this.canExecute = canExecute;
        }
        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }

        // ICommand Interface

        /// <summary>
        /// CanExecute는 Command가 호출될 때만 사용이 된다.
        /// 그런데 CommandManager.RequerySuggested에 이벤트 핸들러를 추가하면 WPF 측에서 
        /// 알아서 해당 이벤트 핸들러를 호출해준다. (윈도우 이벤트 발생시) 
        /// 장점으로는 아무런 추가 작업 없이 버튼의 활성화 비활성화를 알아서 처리해준다는 것.
        /// 하지만 CanExecute는 알고리즘적으로 부하를 발생시킬 수도 있기에 융통성 있게 사용할것.
        /// </summary>
        public event EventHandler CanExecuteChanged;
        /*{
            add
            {
                CommandManager.RequerySuggested += value;
                //this.CanExecuteChangedInternal += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                //this.CanExecuteChangedInternal -= value;
            }
        }*/

        public bool CanExecute(object parameter)
        {
            return this.canExecute != null && this.canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        //
        /*public void OnCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChangedInternal;
            if (handler != null)
            {
                // DispatcherHelper.BeginInvokeOnUIThread(() => handler.Invoke(this, EventArgs.Empty));
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        public void Destroy()
        {
            this.canExecute = _ => false;
            this.execute = _ => { return; };
        }*/
    }
}
