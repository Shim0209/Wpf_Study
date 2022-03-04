using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfListBox.Model
{
    class clsRCP : INotifyPropertyChanged
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
                this.OnPropertyChanged("NAME");
            }
        }

        private bool USE_;
        public bool USE
        {
            get
            {
                return this.USE_;
            }
            set
            {
                this.USE_ = value;
                this.OnPropertyChanged("USE");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public clsRCP()
        {

        }
    }
}
