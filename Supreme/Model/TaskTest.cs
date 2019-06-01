using static Supreme.Core.Enums;

namespace Supreme.Model
{
    public class TaskTest: BaseItem
    {

        private string _ProductName;
        public string ProductName { get { return _ProductName; } set { if (_ProductName != value) { _ProductName = value; NotifyPropertyChanged(); } } }

        //Style in Supreme
        private string _Color;
        public string Color { get { return _Color; } set { if (_Color != value) { _Color = value; NotifyPropertyChanged(); } } }

        private string _ProductCategory;
        public string ProductCategory { get { return _ProductCategory; } set { if (_ProductCategory != value) { _ProductCategory = value; NotifyPropertyChanged(); } } }

        //Size in Supreme
        private Size _ProductSize;
        public Size ProductSize { get { return _ProductSize; } set { if (_ProductSize != value) { _ProductSize = value; NotifyPropertyChanged(); } } }

       
    }


}
