using Supreme.Core;
using Supreme.Model;
using System.Windows.Input;

namespace Supreme.ViewModel
{
    public class MainViewModel : BaseViewModel
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

        private ICommand _ViewNewTaskCommand;
        public ICommand ViewNewTaskCommand
        {
            get { return _ViewNewTaskCommand ?? (_ViewNewTaskCommand = new ActCommand(ViewNewTask)); }
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

        private ICommand _ViewTestCommand;
        public ICommand ViewTestCommand
        {
            get { return _ViewTestCommand ?? (_ViewTestCommand = new ActCommand(ViewTest)); }
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

        public void ViewArts()
        {
            Current = new ArtListViewModel();
        }

        public void ViewTask()
        {
            Current = new TaskDashboardViewModel();
        }

        public void ViewNewTask()
        {
            Current = new CreateTaskViewModel(this);
        }

        public void ViewProfileSettings()
        {
            Current = new ProfileSettingsViewModel();
        }

        public void ViewComingSoon()
        {
            Current = new TaskListViewModel();
        }

        public void ViewTest()
        {
            Current = new TestViewModel(new Test());
        }

        #endregion Method
    }
}
