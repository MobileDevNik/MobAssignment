using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UIKit;
using Xamarin.Forms;

namespace Assignment.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected Page Page { get; }
        public BaseViewModel(Page page)
        {
            Page = page;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // PropertyChangedEventHandler handler = PropertyChanged;
            // if (handler != null)
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
