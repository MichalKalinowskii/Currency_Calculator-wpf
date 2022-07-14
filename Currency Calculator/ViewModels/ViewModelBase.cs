using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Calculator.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged, IDisposable
    {

        //INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //IDisposable
        public virtual void Dispose() { }
    }
}
