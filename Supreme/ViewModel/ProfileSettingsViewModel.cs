using Supreme.Core;
using Supreme.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Supreme.ViewModel
{
    //public class ProfileSettingsViewModel : BaseListViewModel<ProfileSettings>, INotifyPropertyChanged
    public class ProfileSettingsViewModel : BaseViewModel
    {

        #region Property
        public Profile Profile { get; set; }

        public ObservableCollection<Country> Countries { get; set; }
        public ObservableCollection<CreditCardType> CardTypes { get; set; }
        public ObservableCollection<ExpiryMonth> ExpiryMonth { get; set; }
        public ObservableCollection<ExpiryYear> ExpiryYears { get; set; }

        private Country _SelectedCountry;
        public Country SelectedCountry
        {
            get { return _SelectedCountry; }
            set { if (_SelectedCountry != value) { _SelectedCountry = value; NotifyPropertyChanged(); } }
        }

        private CreditCardType _SelectedCartType;
        public CreditCardType SelectedCardType
        {
            get { return _SelectedCartType; }
            set { if (_SelectedCartType != value) { _SelectedCartType = value; NotifyPropertyChanged(); } }
        }

        private ExpiryMonth _SelectedExpityMonth;
        public ExpiryMonth SelectedExpityMonth
        {
            get { return _SelectedExpityMonth; }
            set { if (_SelectedExpityMonth != value) { _SelectedExpityMonth = value; NotifyPropertyChanged(); } }
        }

        private ExpiryYear _SelectedExpityYear;
        public ExpiryYear SelectedExpityYear
        {
            get { return _SelectedExpityYear; }
            set { if (_SelectedExpityYear != value) { _SelectedExpityYear = value; NotifyPropertyChanged(); } }
        }

        #endregion Property

        public ProfileSettingsViewModel()
        {
            Profile = new Profile();
            Countries = new CountryList().Countries;
            CardTypes = new CreditCardType().CardTypes;
            ExpiryMonth = new ExpiryMonth().ExpiryMonthList;
            ExpiryYears = new ExpiryYear().ExpiryYearList;

            SelectedCountry = new Country() { Id = 1, CountryName = "UK" };
            SelectedCardType = new CreditCardType() { Id = 1, CardType = "Visa" };
            SelectedExpityMonth = new ExpiryMonth() { Id = 1, Month = "01" };
            SelectedExpityYear = new ExpiryYear() { Id = 1, Year = DateTime.Now.Year.ToString() };
            

        }

        private ICommand _CreateProfileCommand;
        public ICommand CreateProfileCommand
        {
            get { return _CreateProfileCommand ?? (_CreateProfileCommand = new ActCommand(CreateProfile)); }
        }

        #region Method

        public void CreateProfile()
        {
            Profile.ProfileCountry = SelectedCountry.CountryName;
            Profile.ProfileCreditCardType = SelectedCardType.CardType.ToString();
            Profile.ProfileExpiryMonth = Convert.ToInt32(SelectedExpityMonth.Month);
            Profile.ProfileExpiryYear = Convert.ToInt32(SelectedExpityYear.Year);

        }

        #endregion Method

    }
}
