namespace Supreme.Model
{
    public class Country: BaseItem
    {
        public Country()
        {
            CountryName = "UK";
        }

        private string _CountryName;
        public string CountryName { get { return _CountryName; } set { if (_CountryName != value) { _CountryName = value; NotifyPropertyChanged(); } } }
    }
}
