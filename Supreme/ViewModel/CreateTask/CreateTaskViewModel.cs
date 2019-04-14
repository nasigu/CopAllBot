using Supreme.Core;
using System.Windows.Input;

namespace Supreme.ViewModel
{
    public class CreateTaskViewModel : BaseViewModel
    {
        #region Constructor

        public CreateTaskViewModel()
        {
            Current = new CreateTaskTypeViewModel();
        }

        #endregion Constructor

        #region Property

        private BaseViewModel _Current;
        public BaseViewModel Current { get { return _Current; } set { if (_Current != value) { _Current = value; NotifyPropertyChanged(); } } }

        #endregion Property

        #region Command

        private ICommand _ViewTypeCommand;
        public ICommand ViewTypeCommand
        {
            get { return _ViewTypeCommand ?? (_ViewTypeCommand = new ActCommand(ViewType)); }
        }

        private ICommand _ViewSpecificationsCommand;
        public ICommand ViewSpecificationsCommand
        {
            get { return _ViewSpecificationsCommand ?? (_ViewSpecificationsCommand = new ActCommand(ViewSpecifications)); }
        }

        private ICommand _ViewFinalizeCommand;
        public ICommand ViewFinalizeCommand
        {
            get { return _ViewFinalizeCommand ?? (_ViewFinalizeCommand = new ActCommand(ViewFinalize)); }
        }

        #endregion Command


        #region Method

        private void ViewType()
        {
            Current = new CreateTaskTypeViewModel();
        }

        private void ViewSpecifications()
        {
            Current = new CreateTaskSpecificationsViewModel();
        }

        private void ViewFinalize()
        {
            Current = new CreateTaskFinalizeViewModel();
        }

        #endregion Method

    }
}
