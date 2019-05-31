using Supreme.Core;
using System;
using System.Runtime.Serialization;

namespace Supreme.Model
{

    [DataContract]
    public abstract class BaseItem : NotifyModel
    {

        private long _Id;
        public virtual long Id { get { return _Id; } set { if (_Id != value) { _Id = value; NotifyPropertyChanged(); } } }

        public event EventHandler Saved;
        protected void NotifySaved()
        {
            Saved?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler Removed;
        protected void NotifyRemoved()
        {
            Removed?.Invoke(this, EventArgs.Empty);
        }

    }
}
