using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace WpfListBox.Model
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

        private ObservableCollection<clsRCP> RCP_;
        public ObservableCollection<clsRCP> RCP
        {
            get
            {
                return this.RCP_;
            }
            set
            {
                this.RCP_ = value;
                this.OnPropertyChanged("RCP");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Model()
        {
            this.RCP = new ObservableCollection<clsRCP>();
            this.RCP.Add(new clsRCP() { NAME = "RCP1" });
            this.RCP.Add(new clsRCP() { NAME = "RCP2" });
            this.RCP.Add(new clsRCP() { NAME = "RCP3" });
            this.RCP.Add(new clsRCP() { NAME = "RCP4" });
        }
    }
}
