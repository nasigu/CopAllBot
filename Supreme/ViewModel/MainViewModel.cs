using Supreme.Core;
using System.Windows.Input;

namespace Supreme.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {

        #region Constructor

        public MainViewModel()
        {
            Current = new ArtListViewModel();
        }

        #endregion Constructor

        #region Property

        private BaseViewModel _Current;
        public BaseViewModel Current { get { return _Current; } set { if (_Current != value) { _Current = value; NotifyPropertyChanged(); } } }

        #endregion Property

        #region Commands

        private ICommand _ViewArtsCommand;
        public ICommand ViewArtsCommand
        {
            get { return _ViewArtsCommand ?? (_ViewArtsCommand = new Core.ActCommand(ViewArts)); }
        }

        private ICommand _ViewDashboardCommand;
        public ICommand ViewDashboardCommand
        {
            get { return _ViewDashboardCommand ?? (_ViewDashboardCommand = new ActCommand(ViewTask)); }
        }

        private ICommand _ViewProfileSettingsCommand;
        public ICommand ViewProfileSettingsCommand
        {
            get { return _ViewProfileSettingsCommand ?? (_ViewProfileSettingsCommand = new ActCommand(ViewProfileSettings)); }
        }

        private ICommand _ViewComingSoonCommand;
        public ICommand ViewComingSoonCommand
        {
            get { return _ViewComingSoonCommand ?? (_ViewComingSoonCommand = new ActCommand(ViewComingSoon)); }
        }

        #endregion Commands

        #region Method

        public static void Start()
        {
            var mainVM = new MainViewModel();
            var v = new MainWindow
            {
                DataContext = mainVM
            };
            v.Show();
        }

        private void ViewArts()
        {
            Current = new ArtListViewModel();
        }

        private void ViewTask()
        {
            Current = new TaskDashboardViewModel();
        }

        private void ViewProfileSettings()
        {
            Current = new ProfileSettingsViewModel();
        }

        private void ViewComingSoon()
        {
            Current = new TaskListViewModel();
        }

        #endregion Method
    }
}
