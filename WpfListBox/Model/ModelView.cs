using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace WpfListBox.Model
{
    class ModelView : INotifyPropertyChanged
    {
        public RelayCommand AddCommand { get; set; }

        private ObservableCollection<Model> ROOT_;
        public ObservableCollection<Model> ROOT
        {
            get
            {
                return this.ROOT_;
            }
            set
            {
                this.ROOT_ = value;
                this.OnPropertyChanged("RCP");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ModelView()
        {
            this.ROOT = new ObservableCollection<Model>();
            this.AddCommand = new RelayCommand(AddExecuted, AddCanExecuted);
        }

        private bool AddCanExecuted(object param)
        {
            return true;
        }

        private void AddExecuted(object param)
        {
            this.ROOT.Add(new Model() { NAME = "TEST" });
        }
    }
}
