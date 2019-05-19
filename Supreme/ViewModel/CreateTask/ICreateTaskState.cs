using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supreme.ViewModel
{
    public interface ICreateTaskState
    {
        void NextStep(CreateTaskViewModel createTaskVM);
    }
}
