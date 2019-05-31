using System;
using Newtonsoft.Json;
using Supreme.Core;
using Supreme.Model;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;

namespace Supreme.ViewModel
{
    public class CreateTaskViewModel : BaseStepViewModel
    {

        #region Constructor

        public CreateTaskViewModel()
        {
            CanCreate = false;
            CurrentTask = new TaskDashboard();
            typed = new CreateTaskTypeViewModel(this);
            spec = new CreateTaskSpecificationsViewModel(this);
            finalize = new CreateTaskFinalizeViewModel(this);
            Current = typed;      
        }

        public CreateTaskViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            CanCreate = false;
            CurrentTask = new TaskDashboard {Store = "Supreme"};
            TaskDate = new TaskTime();
            TaskCount = 1;
            typed = new CreateTaskTypeViewModel(this);
            spec = new CreateTaskSpecificationsViewModel(this);
            finalize = new CreateTaskFinalizeViewModel(this);
            
            Current = typed;
        }

        #endregion Constructor

        #region Property

        //public bool CanCreate { get; set; }

        private bool _CanCreate;
        public bool CanCreate
        {
            get { return _CanCreate; }
            set { if (_CanCreate != value) { _CanCreate = value; NotifyPropertyChanged(); } }
        }



        public TaskDashboard CurrentTask { get; set; }

        public TaskTime TaskDate { get; set; }

        public int TaskCount { get; set; }

        public MainViewModel MainViewModel { get; set; }

        public CreateTaskTypeViewModel typed { get; set; }
        public CreateTaskSpecificationsViewModel spec { get; set; }
        public CreateTaskFinalizeViewModel finalize { get; set; }

    #endregion Property

    #region Command

    private ICommand _ViewTypeCommand;
        public ICommand ViewTypeCommand
        {
            get { return _ViewTypeCommand ?? (_ViewTypeCommand = new ActCommand(ViewType)); }
        }

        private ICommand _ViewSpecificationsCommand;
        public ICommand ViewSpecificationsCommand
        {
            get { return _ViewSpecificationsCommand ?? (_ViewSpecificationsCommand = new ActCommand(ViewSpecifications)); }
        }

        private ICommand _ViewFinalizeCommand;
        public ICommand ViewFinalizeCommand
        {
            get { return _ViewFinalizeCommand ?? (_ViewFinalizeCommand = new ActCommand(ViewFinalize)); }
        }

        private ICommand _NextStepCommand;
        public ICommand NextStepCommand
        {
            get { return _NextStepCommand ?? (_NextStepCommand = new ActCommand(NextStep)); }
        }

        private ICommand _CreateTaskCommand;
        public ICommand CreateTaskCommand
        {
            get { return _CreateTaskCommand ?? (_CreateTaskCommand = new ActCommand(CreateTask)); }
        }

        #endregion Command


        #region Method



        private void ViewType()
        {
            Current = typed;
        }

        private void ViewSpecifications()
        {
            Current = spec;
        }

        private void ViewFinalize()
        {
            Current = finalize;
        }

        private void NextStep()
        {
            Current.NextStep(this);
        }

        private void CreateTask()
        {
            ListTaskDashboard tasks;
            CurrentTask.Date = TaskDate.Date.ToString("dd/MM/yyyy") + " " +  TaskDate.Time.ToString("hh:mm:ss");
            using (var r = new StreamReader("tasks.json"))
            {
                var json = r.ReadToEnd();
                tasks = JsonConvert.DeserializeObject<ListTaskDashboard>(json) ?? new ListTaskDashboard();
                tasks.Tasks =  tasks.Tasks ?? new List<TaskDashboard>();
                for (var i = 0; i < TaskCount; i++)
                {
                    var task = CurrentTask.ShallowCopy();
                    task.Id = tasks.Tasks.Count + 1;
                    tasks.Tasks.Add(task);
                }

            }

            using (var file = File.CreateText("tasks.json"))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, tasks);
            }

            MainViewModel.ViewTask();

        }

        #endregion Method

    }
}
