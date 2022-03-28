using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HomeCheckList.ViewModels
{
    public class ViewModelBase : ReactiveObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
