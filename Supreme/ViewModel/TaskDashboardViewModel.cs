using Newtonsoft.Json;
using Supreme.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Supreme.ViewModel
{

    public class TaskDashboardViewModel : BaseListViewModel<Task>
    {

        #region Property

        public ObservableCollection<Task> TasksList { get; set; }

        #endregion Property

        #region Method

        public TaskDashboardViewModel()
        {
            //WriteTask();
            GetTaskdfsList();
        }

        public void WriteTask()
        {
            Task task1 = new Task("Supreme", "prof1", "M", "Box Logo Tee", "Red", "Idle", "Running");
            Task task2 = new Task("Supreme", "prof1", "S", "Box Logo Tee", "White", "Idle", "Running");
            Task[] tasks = new Task[] { task1, task2 };

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Task[]));
            using (FileStream fileStream = new FileStream("tasks.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fileStream, tasks);
            }
        }

        public void WriteTdsfask(Task task)
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
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Task));
            var Items = new ObservableCollection<Task>();

            using (FileStream fileStream = new FileStream("tasks.json", FileMode.OpenOrCreate))
            {
                Task[] tasks = (Task[])jsonFormatter.ReadObject(fileStream);

                foreach (Task task in tasks)
                {
                    Items.Add(task);
                }
                TasksList = Items;
            }
        }

        public void GetTaskdfsList()
        {
            var Items = new ObservableCollection<Task>();
            using (StreamReader r = new StreamReader("tasks.json"))
            {
                string json = r.ReadToEnd();
                var tasks = JsonConvert.DeserializeObject<ListTask>(json) ?? new ListTask();
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
