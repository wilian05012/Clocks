using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DigiClock.Infrastructure {
    public abstract class PropertyChangedNotifier : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertiesChanged(params string[] properties) {
            if(PropertyChanged != null) {
                foreach(string propertyName in properties) {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
}
