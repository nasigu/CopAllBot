using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supreme.ViewModel
{
    public class BaseTestViewModel : BaseViewModel
    {
        // Паттерн State
        //private BaseTestViewModel _Current;
        //public BaseTestViewModel Current
        //{
        //    get { return _Current; }
        //    set { if (_Current != value) { _Current = value; NotifyPropertyChanged(); } }
        //}

        public virtual void NextStep(TestMainViewModel createTaskVM)
        {
            //Current = createTaskVM;
        }

    }
}
