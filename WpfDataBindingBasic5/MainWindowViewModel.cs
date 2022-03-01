using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace WpfDataBindingBasic5
{
    class MainWindowViewModel
    {
        private ICommand m_ButtonCommand;
        public ICommand ButtonCommand
        {
            get
            {
                return m_ButtonCommand;
            }
            set
            {
                m_ButtonCommand = value;
            }
        }

        public MainWindowViewModel()
        {
            ButtonCommand = new RelayCommand(new Action<object>(ShowMessage));
        }

        private void ShowMessage(object param)
        {
            MessageBox.Show("Hi~ " + param.ToString());
        }
    }
}
