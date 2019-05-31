
using System;

namespace Supreme.ViewModel
{
    public class CreateTaskFinalizeViewModel : BaseStepViewModel
    {

        #region Property

        public CreateTaskViewModel Parent { get; set; }

        private DateTime _SelectedDate;
        public DateTime SelectedDate
        {
            get { return _SelectedDate; }
            set { if (_SelectedDate != value) { _SelectedDate = value;   Parent.TaskDate.Date = value; NotifyPropertyChanged(); } }
        }

        private DateTime _SelectedTime;
        public DateTime SelectedTime
        {
            get { return _SelectedTime; }
            set { if (_SelectedTime != value) { _SelectedTime = value; Parent.TaskDate.Time = value; NotifyPropertyChanged(); } }
        }

        #endregion Property

        #region Constructor

        public CreateTaskFinalizeViewModel()
        {

        }

        public CreateTaskFinalizeViewModel(CreateTaskViewModel parent)
        {
            Parent = parent;
            SelectedDate = DateTime.Today;
            //Parent.CanCreate = true;
        }

        #endregion Constructor


        #region Method

        public override void NextStep(CreateTaskViewModel createTaskVm)
        {
            createTaskVm.Current = new CreateTaskFinalizeViewModel();
        }

        #endregion Method
    }
}
