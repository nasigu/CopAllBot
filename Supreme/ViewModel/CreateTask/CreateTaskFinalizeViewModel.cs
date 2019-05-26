
namespace Supreme.ViewModel
{
    public class CreateTaskFinalizeViewModel : BaseStepViewModel
    {

        #region Property

        public CreateTaskViewModel Parent { get; set; }

        #endregion Property

        #region Constructor

        public CreateTaskFinalizeViewModel()
        {

        }

        public CreateTaskFinalizeViewModel(CreateTaskViewModel parent)
        {
            Parent = parent;
            //Parent.CanCreate = true;
        }

        #endregion Constructor


        #region Method

        public override void NextStep(CreateTaskViewModel CreateTaskVM)
        {
            CreateTaskVM.Current = new CreateTaskFinalizeViewModel();
        }

        #endregion Method
    }
}
