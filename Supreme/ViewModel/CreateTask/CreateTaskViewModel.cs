using Supreme.Core;
using Supreme.Model;
using System.Windows.Input;

namespace Supreme.ViewModel
{
    public class CreateTaskViewModel : BaseStepViewModel
    {
        #region Constructor

        public CreateTaskViewModel()
        {
            Current = new CreateTaskTypeViewModel();
        }



        #endregion Constructor

        #region Property

        TaskDashboard Task;

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

        private ICommand _NextStepCommand;
        public ICommand NextStepCommand
        {
            get { return _NextStepCommand ?? (_NextStepCommand = new ActCommand(NextStep)); }
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
            CreateTaskSpecificationsViewModel vm = (CreateTaskSpecificationsViewModel)Current;
            Task = vm.Task;
        }

        private void ViewFinalize()
        {
            Current = new CreateTaskFinalizeViewModel();
        }

        private void NextStep()
        {
            Current.NextStep(this);
        }

        #endregion Method

    }
}
