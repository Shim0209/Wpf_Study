using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfListBox2
{
    class Model : INotifyPropertyChanged
    {
        private string NAME_;
        public string NAME
        {
            get
            {
                return this.NAME_;
            }
            set
            {
                this.NAME_ = value;
                OnPropertyChanged("NAME");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Model() { }
    }
}
