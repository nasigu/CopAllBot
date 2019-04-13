
namespace Supreme.Model
{
    public class ProfileSettings: BaseItem
    {
        private string _ProfileName;
        public string ProfileName { get { return _ProfileName; } set { if (_ProfileName != value) { _ProfileName = value; NotifyPropertyChanged(); } } }

        private string _FullName;
        public string FullName { get { return _FullName; } set { if (_FullName != value) { _FullName = value; NotifyPropertyChanged(); } } }

        private string _Email;
        public string Email { get { return _Email; } set { if (_Email != value) { _Email = value; NotifyPropertyChanged(); } } }

        private string _Address;
        public string Address { get { return _Address; } set { if (_Address != value) { _Address = value; NotifyPropertyChanged(); } } }

        private string _Address2;
        public string Address2 { get { return _Address2; } set { if (_Address2 != value) { _Address2 = value; NotifyPropertyChanged(); } } }

        private string _Address3;
        public string Address3 { get { return _Address3; } set { if (_Address3 != value) { _Address3 = value; NotifyPropertyChanged(); } } }

        private Country _CountryName;
        public Country CountryName { get { return _CountryName; } set { if (_CountryName != value) { _CountryName = value; NotifyPropertyChanged(); } } }


        private string _City;
        public string City { get { return _City; } set { if (_City != value) { _City = value; NotifyPropertyChanged(); } } }

        private string _CreditCardNumber;
        public string CreditCardNumber { get { return _CreditCardNumber; } set { if (_CreditCardNumber != value) { _CreditCardNumber = value; NotifyPropertyChanged(); } } }

        private string _CCV;
        public string CCV { get { return _CCV; } set { if (_CCV != value) { _CCV = value; NotifyPropertyChanged(); } } }

    }
}
