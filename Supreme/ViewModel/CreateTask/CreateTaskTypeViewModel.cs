using Supreme.Core;
using Supreme.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<string> Images { get; set; }


        public CreateTaskTypeViewModel()
        {
            //CurrentTask = new TaskDashboard();

        }

        public CreateTaskTypeViewModel(CreateTaskViewModel parent)
        {
            Parent = parent;

        }

        public override void NextStep(CreateTaskViewModel CreateTaskVM)
        {
            CreateTaskVM.CurrentTask.Store = "Supreme";
            CreateTaskVM.Current = CreateTaskVM.spec;

        }
    }
}
