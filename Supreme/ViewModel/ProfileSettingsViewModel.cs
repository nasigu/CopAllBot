using Supreme.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Supreme.ViewModel
{
    public class ProfileSettingsViewModel : BaseListViewModel<ProfileSettings>, INotifyPropertyChanged
    {
        //public ObservableCollection<Country> Countries = new CountryList().Countries;

        private ObservableCollection<Country> _Countries;

        public ObservableCollection<Country> Countries
        {
            get { return _Countries; }
            set { _Countries = value; }
        }
        private Country _SelectedCountry;

        public Country SelectedCountry
        {
            get { return _SelectedCountry; }
            set { if (_SelectedCountry != value) { _SelectedCountry = value; NotifyPropertyChanged(); } }
        }

        public ProfileSettingsViewModel()
        {
            Countries = new CountryList().Countries;
            SelectedCountry = new Country();
        }
    }
}
