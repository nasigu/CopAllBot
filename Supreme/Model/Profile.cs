using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supreme.Model
{
    public class Profile: BaseItem
    {
        #region Property

        private string _ProfileName;
        public string ProfileName { get { return _ProfileName; } set { if (_ProfileName != value) { _ProfileName = value; NotifyPropertyChanged(); } } }

        private string _ProfileFullName;
        public string ProfileFullName { get { return _ProfileFullName; } set { if (_ProfileFullName != value) { _ProfileFullName = value; NotifyPropertyChanged(); } } }

        private string _ProfileEmail;
        public string ProfileEmail { get { return _ProfileEmail; } set { if (_ProfileEmail != value) { _ProfileEmail = value; NotifyPropertyChanged(); } } }

        private string _ProfileTel;
        public string ProfileTel { get { return _ProfileTel; } set { if (_ProfileTel != value) { _ProfileTel = value; NotifyPropertyChanged(); } } }

        private string _ProfileAddress;
        public string ProfileAddress { get { return _ProfileAddress; } set { if (_ProfileAddress != value) { _ProfileAddress = value; NotifyPropertyChanged(); } } }

        private string _ProfileAddress2;
        public string ProfileAddress2 { get { return _ProfileAddress2; } set { if (_ProfileAddress2 != value) { _ProfileAddress2 = value; NotifyPropertyChanged(); } } }

        private string _ProfileAddress3;
        public string ProfileAddress3 { get { return _ProfileAddress3; } set { if (_ProfileAddress3 != value) { _ProfileAddress3 = value; NotifyPropertyChanged(); } } }

        private string _ProfileCountry;
        public string ProfileCountry { get { return _ProfileCountry; } set { if (_ProfileCountry != value) { _ProfileCountry = value; NotifyPropertyChanged(); } } }

        private string _ProfileCity;
        public string ProfileCity { get { return _ProfileCity; } set { if (_ProfileCity != value) { _ProfileCity = value; NotifyPropertyChanged(); } } }

        private string _ProfilePostCode;
        public string ProfilePostCode { get { return _ProfilePostCode; } set { if (_ProfilePostCode != value) { _ProfilePostCode = value; NotifyPropertyChanged(); } } }

        private string _ProfileCreditCardType;
        public string ProfileCreditCardType { get { return _ProfileCreditCardType; } set { if (_ProfileCreditCardType != value) { _ProfileCreditCardType = value; NotifyPropertyChanged(); } } }

        private string _ProfileCreditCardNumber;
        public string ProfileCreditCardNumber { get { return _ProfileCreditCardNumber; } set { if (_ProfileCreditCardNumber != value) { _ProfileCreditCardNumber = value; NotifyPropertyChanged(); } } }

        private int _ProfileExpiryMonth;
        public int ProfileExpiryMonth { get { return _ProfileExpiryMonth; } set { if (_ProfileExpiryMonth != value) { _ProfileExpiryMonth = value; NotifyPropertyChanged(); } } }

        private int _ProfileExpiryYear;
        public int ProfileExpiryYear { get { return _ProfileExpiryYear; } set { if (_ProfileExpiryYear != value) { _ProfileExpiryYear = value; NotifyPropertyChanged(); } } }

        private int _ProfileCardCVV;
        public int ProfileCardCVV { get { return _ProfileCardCVV; } set { if (_ProfileCardCVV != value) { _ProfileCardCVV = value; NotifyPropertyChanged(); } } }

        #endregion Property
    }

    public class CreditCardType
    {
        public string CardType { get; set; }

        private static ObservableCollection<string> _CardTypes = new ObservableCollection<string>()
        {
            "Visa",
            "American Express",
            "Mastercard",
            "Solo",
            "PayPal"
        };

        public ObservableCollection<string> CardTypes = _CardTypes;

    }

    public class ExpiryMonth
    {
        private static ObservableCollection<string> _ExpiryMonthList = new ObservableCollection<string>()
        {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"

        };

        public ObservableCollection<string> ExpiryMonthList = _ExpiryMonthList;

    }

    public class ExpiryYear
    {
        private static ObservableCollection<string> _ExpiryYearList = new ObservableCollection<string>()
        {
             DateTime.Now.Year.ToString(),
            (DateTime.Now.Year + 1).ToString() ,
            (DateTime.Now.Year + 2).ToString() ,
            (DateTime.Now.Year + 3).ToString() ,
            (DateTime.Now.Year + 4).ToString() ,
            (DateTime.Now.Year + 5).ToString() ,
            (DateTime.Now.Year + 6).ToString() ,
            (DateTime.Now.Year + 7).ToString() ,
            (DateTime.Now.Year + 8).ToString() ,
            (DateTime.Now.Year + 9).ToString() ,
            (DateTime.Now.Year + 10).ToString()

        };

        public ObservableCollection<string> ExpiryYearList = _ExpiryYearList;

    }
}
