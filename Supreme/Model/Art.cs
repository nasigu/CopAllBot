
using Supreme.Core;

namespace Supreme.Model
{
    public class Art: BaseItem
    {
        #region Property

        private string _Name;
        public string Name { get { return _Name; } set { if (_Name != value) { _Name = value; NotifyPropertyChanged(); } } }

        private string _Color;
        public string Color { get { return _Color; } set { if (_Color != value) { _Color = value; NotifyPropertyChanged(); } } }

        private string _Description;
        public string Description { get { return _Description; } set { if (_Description != value) { _Description = value; NotifyPropertyChanged(); } } }

        private int _Size;
        public int Size { get { return _Size; } set { if (_Size != value) { _Size = value; NotifyPropertyChanged(); } } }

        private decimal _Price;
        public decimal Price { get { return _Price; } set { if (_Price != value) { _Price = value; NotifyPropertyChanged(); } } }

        private string _Reference;
        public string Reference { get { return _Reference; } set { if (_Reference != value) { _Reference = value; NotifyPropertyChanged(); } } }

        private string _Image;
        public string Image { get { return _Image; } set { if (_Image != value) { _Image = value; NotifyPropertyChanged(); } } }

        #endregion Property

    }
}
