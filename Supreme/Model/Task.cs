
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Documents;
using Newtonsoft.Json;

namespace Supreme.Model
{
    [DataContract]
    public class Task: BaseItem
    {
        public Task(string store, string profile, string size, string product,string style, string log, string action)
        {
            Store = store;
            Profile = profile;
            Size = size;
            Product = product;
            Style = style;
            Log = log;
            Action = action;
        }

        public Task()
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

        [DataMember(Name = "Category")]
        private string _Category;
        public string Category { get { return _Category; } set { if (_Category != value) { _Category = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "Mode")]
        private string _Mode;
        public string Mode { get { return _Mode; } set { if (_Mode != value) { _Mode = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "Date")]
        private string _Date;
        public string Date { get { return _Date; } set { if (_Date != value) { _Date = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "Log")]
        private string _Log;
        public string Log { get { return _Log; } set { if (_Log != value) { _Log = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "Action")]
        private string _Action;
        public string Action { get { return _Action; } set { if (_Action != value) { _Action = value; NotifyPropertyChanged(); } } }

        public Task ShallowCopy()
        {
            return (Task)this.MemberwiseClone();
        }

        public static List<Task> GetTaskList()
        {
            var Items = new List<Task>();
            using (StreamReader r = new StreamReader("tasks.json"))
            {
                var json = r.ReadToEnd();
                var tasks = JsonConvert.DeserializeObject<ListTask>(json) ?? new ListTask();
                var i = 0;
                foreach (var task in tasks.Tasks)
                {
                    Items.Add(task);
                }

                return Items;
            }
        }


    }
}
