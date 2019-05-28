using Newtonsoft.Json;
using Supreme.Core;
using Supreme.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Json;
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
        public ExpiryMonth SelectedExpiryMonth
        {
            get { return _SelectedExpityMonth; }
            set { if (_SelectedExpityMonth != value) { _SelectedExpityMonth = value; NotifyPropertyChanged(); } }
        }

        private ExpiryYear _SelectedExpityYear;
        public ExpiryYear SelectedExpiryYear
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
            SelectedExpiryMonth = new ExpiryMonth() { Id = 1, Month = "01" };
            SelectedExpiryYear = new ExpiryYear() { Id = 1, Year = DateTime.Now.Year.ToString() };
            

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
            Profile.ProfileExpiryMonth = Convert.ToInt32(SelectedExpiryMonth.Month);
            Profile.ProfileExpiryYear = Convert.ToInt32(SelectedExpiryYear.Year);

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Profile));
            //using (FileStream fileStream = new FileStream("tasks.json", FileMode.OpenOrCreate))
            //{
            //    jsonFormatter.WriteObject(fileStream, CurrentTask);
            //}
            ListProfiles profiles;
            using (StreamReader r = new StreamReader("profiles.json"))
            {
                string json = r.ReadToEnd();
                profiles = JsonConvert.DeserializeObject<ListProfiles>(json) ?? new ListProfiles();
                profiles.Profiles = profiles.Profiles ?? new List<Profile>();
                profiles.Profiles.Add(Profile);

            }

            using (StreamWriter file = File.CreateText("profiles.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, profiles);
            }

            //MainViewModel.ViewTask();
        }

        

        #endregion Method

    }
}
