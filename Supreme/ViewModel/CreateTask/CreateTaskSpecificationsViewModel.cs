
using Supreme.Core;
using Supreme.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Supreme.ViewModel
{
    public class CreateTaskSpecificationsViewModel : BaseStepViewModel, ICreateTaskState
    {
        public TaskDashboard Task { get; set; }

        public CreateTaskSpecificationsViewModel()
        {
            Task = new TaskDashboard("Supreme","prof1","","","","","Add");
        }  

        public override void NextStep(CreateTaskViewModel createTaskVM)
        {
            createTaskVM.Current = new CreateTaskFinalizeViewModel();
        }
    }
}
