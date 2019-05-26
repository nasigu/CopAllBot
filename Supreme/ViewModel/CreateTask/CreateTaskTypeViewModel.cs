using Supreme.Core;
using Supreme.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supreme.ViewModel
{
    public class CreateTaskTypeViewModel : BaseStepViewModel
    {
        public TaskDashboard CurrentTask;

        public CreateTaskViewModel Parent { get; set; }


        public CreateTaskTypeViewModel()
        {
            //CurrentTask = new TaskDashboard();
            CurrentTask = new TaskDashboard("Supreme", "prof1", "ddd", "", "", "", "Add");

        }

        public CreateTaskTypeViewModel(CreateTaskViewModel parent)
        {
            Parent = parent;

        }

        public override void NextStep(CreateTaskViewModel CreateTaskVM)
        {

            CreateTaskVM.Current = CreateTaskVM.spec;

        }
    }
}
