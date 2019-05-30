using Newtonsoft.Json;
using Supreme.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Supreme.ViewModel
{

    public class TaskDashboardViewModel : BaseListViewModel<TaskDashboard>
    {

        #region Property

        public ObservableCollection<TaskDashboard> TasksList { get; set; }

        #endregion Property

        #region Method

        public TaskDashboardViewModel()
        {
            //WriteTask();
            GetTaskdfsList();
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

        public void WriteTdsfask(TaskDashboard task)
        {
            using (StreamWriter file = File.CreateText("tasks.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, task);
            }
        }


        public void GetTasksList()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(TaskDashboard));
            var Items = new ObservableCollection<TaskDashboard>();

            using (FileStream fileStream = new FileStream("tasks.json", FileMode.OpenOrCreate))
            {
                TaskDashboard[] tasks = (TaskDashboard[])jsonFormatter.ReadObject(fileStream);

                foreach (TaskDashboard task in tasks)
                {
                    Items.Add(task);
                }
                TasksList = Items;
            }
        }

        public void GetTaskdfsList()
        {
            var Items = new ObservableCollection<TaskDashboard>();
            using (StreamReader r = new StreamReader("tasks.json"))
            {
                string json = r.ReadToEnd();
                var tasks = JsonConvert.DeserializeObject<ListTaskDashboard>(json) ?? new ListTaskDashboard();
                var i = 0;
                foreach (var task in tasks.Tasks)
                {
                    Items.Add(task);
                }
                TasksList = Items;
            }
        }

        #endregion Method

    }
}
