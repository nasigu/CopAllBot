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
    public class TestMainViewModel : BaseStepViewModel
    {
        public TaskDashboard TestObject { get; set; }

        public TestMainViewModel()
        {
            Current = new TestTypeViewModel();
        }

        private ICommand _NextStepCommand;
        public ICommand NextStepCommand
        {
            get { return _NextStepCommand ?? (_NextStepCommand = new ActCommand(NextStep)); }
        }

        private void NextStep()
        {
            //Current.NextStep(this);
        }
    }
}
