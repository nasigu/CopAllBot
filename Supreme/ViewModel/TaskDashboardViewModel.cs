using Supreme.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Supreme.ViewModel
{
    
    public class TaskDashboardViewModel: BaseListViewModel<TaskDashboard>
    {

        #region Property

        public ObservableCollection<TaskDashboard> TasksList { get; set; }

        #endregion Property

        #region Method

        public TaskDashboardViewModel()
        {
            WriteTask();
            GetTasksList();
        }

        public void WriteTask()
        {
            TaskDashboard task1 = new TaskDashboard("Supreme", "prof1", "M", "Box Logo Tee", "Red", "Idle", "Running");
            TaskDashboard task2 = new TaskDashboard("Supreme", "prof1", "S", "Box Logo Tee", "White", "Idle", "Running");
            TaskDashboard[] tasks = new TaskDashboard[] { task1, task2 };

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(TaskDashboard[]));
            using (FileStream fileStream = new FileStream("tasks.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fileStream, tasks);
            }
        }

        public void GetTasksList()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(TaskDashboard[]));
            var Items = new ObservableCollection<TaskDashboard>();

            using (FileStream fileStream = new FileStream("tasks.json", FileMode.OpenOrCreate))
            {
                TaskDashboard[] tasks = (TaskDashboard[])jsonFormatter.ReadObject(fileStream);

                foreach (TaskDashboard task in tasks)
                {
                    Trace.WriteLine($"profile: {task.Profile} --- product: {task.Product} --- size: {task.Size} --- store: {task.Store} --- log: {task.Log} --- action: {task.Action} ---");
                    Items.Add(task);
                }
                TasksList = Items;
            }
        }

        #endregion Method

    }
}
