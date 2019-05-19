using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supreme.ViewModel
{
    public class CreateTaskTypeViewModel : BaseStepViewModel, ICreateTaskState
    {
        public override void NextStep(CreateTaskViewModel createTaskVM)
        {
            createTaskVM.Current = new CreateTaskSpecificationsViewModel();
        }
    }
}
