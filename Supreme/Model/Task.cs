using static Supreme.Core.Enums;

namespace Supreme.Model
{
    public class Task: BaseItem
    {

        private string _ProductName;
        public string ProductName { get { return _ProductName; } set { if (_ProductName != value) { _ProductName = value; NotifyPropertyChanged(); } } }

        private string _Color;
        public string Color { get { return _Color; } set { if (_Color != value) { _Color = value; NotifyPropertyChanged(); } } }

        private Category _ProductCategory;
        public Category ProductCategory { get { return _ProductCategory; } set { if (_ProductCategory != value) { _ProductCategory = value; NotifyPropertyChanged(); } } }

        private WEARSIZES _ProductSize;
        public WEARSIZES ProductSize { get { return _ProductSize; } set { if (_ProductSize != value) { _ProductSize = value; NotifyPropertyChanged(); } } }


    }


}
