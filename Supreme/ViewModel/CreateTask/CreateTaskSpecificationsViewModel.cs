using Supreme.Model;

namespace Supreme.ViewModel
{
    public class CreateTaskSpecificationsViewModel : BaseStepViewModel
    {

        public CreateTaskViewModel Parent { get; set; }


        public CreateTaskSpecificationsViewModel()
        {
        }

        public CreateTaskSpecificationsViewModel(CreateTaskViewModel parent)
        {
            Parent = parent;
        }




        public override void NextStep(CreateTaskViewModel CreateTaskVM)
        {
            Parent.CanCreate = true;

            CreateTaskVM.Current = CreateTaskVM.finalize;

        }
    }
}
