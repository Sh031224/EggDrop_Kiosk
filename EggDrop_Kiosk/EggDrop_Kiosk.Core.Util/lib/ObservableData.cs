using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop_Kiosk.Core.Util.lib
{
    public class ObservableData<T> : INotifyPropertyChanged
    {
        private T _value;
        public T Value
        {
            get { return _value; }
            set { _value = value; NotifyPropertyChanged("Value"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
