using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Supreme.Model
{
    [DataContract]
    public class Profile: BaseItem
    {
        #region Property

        [DataMember(Name = "Name")]
        private string _ProfileName;
        public string ProfileName { get { return _ProfileName; } set { if (_ProfileName != value) { _ProfileName = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "FullName")]
        private string _ProfileFullName;
        public string ProfileFullName { get { return _ProfileFullName; } set { if (_ProfileFullName != value) { _ProfileFullName = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "Email")]
        private string _ProfileEmail;
        public string ProfileEmail { get { return _ProfileEmail; } set { if (_ProfileEmail != value) { _ProfileEmail = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "Tel")]
        private string _ProfileTel;
        public string ProfileTel { get { return _ProfileTel; } set { if (_ProfileTel != value) { _ProfileTel = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "Address")]
        private string _ProfileAddress;
        public string ProfileAddress { get { return _ProfileAddress; } set { if (_ProfileAddress != value) { _ProfileAddress = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "Address2")]
        private string _ProfileAddress2;
        public string ProfileAddress2 { get { return _ProfileAddress2; } set { if (_ProfileAddress2 != value) { _ProfileAddress2 = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "Address3")]
        private string _ProfileAddress3;
        public string ProfileAddress3 { get { return _ProfileAddress3; } set { if (_ProfileAddress3 != value) { _ProfileAddress3 = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "Country")]
        private string _ProfileCountry;
        public string ProfileCountry { get { return _ProfileCountry; } set { if (_ProfileCountry != value) { _ProfileCountry = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "City")]
        private string _ProfileCity;
        public string ProfileCity { get { return _ProfileCity; } set { if (_ProfileCity != value) { _ProfileCity = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "PostCode")]
        private string _ProfilePostCode;
        public string ProfilePostCode { get { return _ProfilePostCode; } set { if (_ProfilePostCode != value) { _ProfilePostCode = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "CreditCardType")]
        private string _ProfileCreditCardType;
        public string ProfileCreditCardType { get { return _ProfileCreditCardType; } set { if (_ProfileCreditCardType != value) { _ProfileCreditCardType = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "CardNumber")]
        private string _ProfileCreditCardNumber;
        public string ProfileCreditCardNumber { get { return _ProfileCreditCardNumber; } set { if (_ProfileCreditCardNumber != value) { _ProfileCreditCardNumber = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "ExpiryMonth")]
        private int _ProfileExpiryMonth;
        public int ProfileExpiryMonth { get { return _ProfileExpiryMonth; } set { if (_ProfileExpiryMonth != value) { _ProfileExpiryMonth = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "ExpiryYear")]
        private int _ProfileExpiryYear;
        public int ProfileExpiryYear { get { return _ProfileExpiryYear; } set { if (_ProfileExpiryYear != value) { _ProfileExpiryYear = value; NotifyPropertyChanged(); } } }

        [DataMember(Name = "CardCVV")]
        private int _ProfileCardCVV;
        public int ProfileCardCVV { get { return _ProfileCardCVV; } set { if (_ProfileCardCVV != value) { _ProfileCardCVV = value; NotifyPropertyChanged(); } } }

        #endregion Property
    }

    public class CreditCardType: BaseItem
    {

        private string _CardType;
        public string CardType { get { return _CardType; } set { if (_CardType != value) { _CardType = value; NotifyPropertyChanged(); } } }

        private CreditCardType(string creditCard)
        {
            CardType = creditCard;
        }

        public CreditCardType()
        {
        }

        private static ObservableCollection<CreditCardType> _CardTypes = new ObservableCollection<CreditCardType>()
        {
            new CreditCardType("Visa"),
            new CreditCardType("American Express"),
            new CreditCardType("Mastercard"),
            new CreditCardType("Solo"),
            new CreditCardType("PayPal")
        };

        public ObservableCollection<CreditCardType> CardTypes = _CardTypes;

    }

    public class ExpiryMonth: BaseItem
    {
        private ExpiryMonth(string month)
        {
            Month = month;
        }

        public ExpiryMonth()
        {
        }

        private string _Month;
        public string Month { get { return _Month; } set { if (_Month != value) { _Month = value; NotifyPropertyChanged(); } } }

        private static ObservableCollection<ExpiryMonth> _ExpiryMonthList = new ObservableCollection<ExpiryMonth>()
        {
            new ExpiryMonth("01"),
            new ExpiryMonth("02"),
            new ExpiryMonth("03"),
            new ExpiryMonth("04"),
            new ExpiryMonth("05"),
            new ExpiryMonth("06"),
            new ExpiryMonth("07"),
            new ExpiryMonth("08"),
            new ExpiryMonth("09"),
            new ExpiryMonth("10"),
            new ExpiryMonth("11"),
            new ExpiryMonth("12"),

        };

        public  ObservableCollection<ExpiryMonth> ExpiryMonthList = _ExpiryMonthList;

    }

    public class ExpiryYear: BaseItem
    {

        private string _Year;
        public string Year { get { return _Year; } set { if (_Year != value) { _Year = value; NotifyPropertyChanged(); } } }

        public ExpiryYear()
        {
        }

        private ExpiryYear(string year)
        {
            Year = year;
        }

        private static ObservableCollection<ExpiryYear> _ExpiryYearList = new ObservableCollection<ExpiryYear>()
        {
             new ExpiryYear(DateTime.Now.Year.ToString()),
             new ExpiryYear((DateTime.Now.Year + 1).ToString()),
             new ExpiryYear((DateTime.Now.Year + 2).ToString()),
             new ExpiryYear((DateTime.Now.Year + 3).ToString()),
             new ExpiryYear((DateTime.Now.Year + 4).ToString()),
             new ExpiryYear((DateTime.Now.Year + 5).ToString()),
             new ExpiryYear((DateTime.Now.Year + 6).ToString()),
             new ExpiryYear((DateTime.Now.Year + 7).ToString()),
             new ExpiryYear((DateTime.Now.Year + 8).ToString()),
             new ExpiryYear((DateTime.Now.Year + 9).ToString()),
             new ExpiryYear((DateTime.Now.Year + 10).ToString())

        };

        public ObservableCollection<ExpiryYear> ExpiryYearList = _ExpiryYearList;

    }
}
