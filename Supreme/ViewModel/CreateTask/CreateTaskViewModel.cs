using Newtonsoft.Json;
using Supreme.Core;
using Supreme.Model;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows.Input;

namespace Supreme.ViewModel
{
    public class CreateTaskViewModel : BaseStepViewModel
    {

        #region Constructor

        public CreateTaskViewModel()
        {
            CanCreate = false;
            CurrentTask = new TaskDashboard("Supreme", "prof1", "ddd", "", "", "", "Add");
            typed = new CreateTaskTypeViewModel(this);
            spec = new CreateTaskSpecificationsViewModel(this);
            finalize = new CreateTaskFinalizeViewModel(this);
            Current = typed;      
        }

        public CreateTaskViewModel(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            CanCreate = false;
            CurrentTask = new TaskDashboard("Supreme", "prof1", "ddd", "", "", "", "Add");
            typed = new CreateTaskTypeViewModel(this);
            spec = new CreateTaskSpecificationsViewModel(this);
            finalize = new CreateTaskFinalizeViewModel(this);
            Current = typed;
        }

        #endregion Constructor

        #region Property

        public TaskDashboard TestTask = new TaskDashboard();
        //public bool CanCreate { get; set; }

        private bool _CanCreate;
        public bool CanCreate
        {
            get { return _CanCreate; }
            set { if (_CanCreate != value) { _CanCreate = value; NotifyPropertyChanged(); } }
        }

        public TaskDashboard CurrentTask { get; set; }

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
            //CreateTaskSpecificationsViewModel vm = (CreateTaskSpecificationsViewModel)Current;
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
           
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(TaskDashboard));
            //using (FileStream fileStream = new FileStream("tasks.json", FileMode.OpenOrCreate))
            //{
            //    jsonFormatter.WriteObject(fileStream, CurrentTask);
            //}
            ListTaskDashboard tasks;
            using (StreamReader r = new StreamReader("tasks.json"))
            {
                string json = r.ReadToEnd();
                tasks = JsonConvert.DeserializeObject<ListTaskDashboard>(json) ?? new ListTaskDashboard();
                tasks.List =  tasks.List ?? new List<TaskDashboard>();
                tasks.List.Add(CurrentTask);
                
            }

            using (StreamWriter file = File.CreateText("tasks.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, tasks);
                }

            MainViewModel.ViewTask();

        }

        #endregion Method

    }
}
