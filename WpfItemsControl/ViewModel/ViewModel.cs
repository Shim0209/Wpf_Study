using System.Collections.ObjectModel;
using System.Linq;
using WpfItemsControl.Models;

namespace WpfItemsControl.ViewModel
{
    class ViewModel : ModelBase
    {
        public ObservableCollection<ModelBase> MODEL { get; set; }
        public ViewModel()
        {
            this.MODEL = new ObservableCollection<ModelBase>();
            foreach (uint i in Enumerable.Range(0, (int)1000))
            {
                this.MODEL.Add(new Model() { NAME = "TEST" + i });
            }
        }
    }
}
