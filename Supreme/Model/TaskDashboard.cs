
using System.Runtime.Serialization;

namespace Supreme.Model
{
    [DataContract]
    public class TaskDashboard: BaseItem
    {
        public TaskDashboard(string store, string profile, string size, string product,string style, string log, string action)
        {
            Store = store;
            Profile = profile;
            Size = size;
            Product = product;
            Style = style;
            Log = log;
            Action = action;
        }

        public TaskDashboard()
        {

        }

        [DataMember(Name = "Id")]
        private long _Id;
        public override long Id { get { return _Id; } set { if (_Id != value) { _Id = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "Store")]
        private string _Store;
        public string Store { get { return _Store; } set { if (_Store != value) { _Store = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "Profile")]
        private string _Profile;
        public string Profile { get { return _Profile; } set { if (_Profile != value) { _Profile = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "Size")]
        private string _Size;
        public string Size { get { return _Size; } set { if (_Size != value) { _Size = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "Product")]
        private string _Product;
        public string Product { get { return _Product; } set { if (_Product != value) { _Product = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "Style")]
        private string _Style;
        public string Style { get { return _Style; } set { if (_Style != value) { _Style = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "Log")]
        private string _Log;
        public string Log { get { return _Log; } set { if (_Log != value) { _Log = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "Action")]
        private string _Action;
        public string Action { get { return _Action; } set { if (_Action != value) { _Action = value; NotifyPropertyChanged(); } } }

    }
}
