using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supreme.ViewModel
{
    public class BaseStepViewModel: BaseViewModel
    {
        // Паттерн State
        private BaseStepViewModel _Current;
        public BaseStepViewModel Current
        {
            get { return _Current; }
            set { if (_Current != value) { _Current = value; NotifyPropertyChanged(); } }
        }

        public virtual void NextStep(CreateTaskViewModel createTaskVM)
        {
            Current = createTaskVM;
        }

    }
}
