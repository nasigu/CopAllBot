using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Supreme.Core
{
    [DataContract]
    public class NotifyModel: INotifyPropertyChanged
    {
        #region Event

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, e);
            }
        }

        protected void NotifyPropertyChangedAll()
        {
            var props = GetType().GetProperties();
            foreach (var prop in props)
            {
                NotifyPropertyChanged(prop.Name);
            }
        }

        #endregion Event
    }
}
