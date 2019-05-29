using Newtonsoft.Json;
using Supreme.Core;
using Supreme.Model;
using System.Collections.ObjectModel;
using System.IO;

namespace Supreme.ViewModel
{
    public class CreateTaskSpecificationsViewModel : BaseStepViewModel
    {

        public CreateTaskViewModel Parent { get; set; }

        public ObservableCollection<string> Mode { get; set; }

        public ObservableCollection<Profile> Profiles { get; set; }

        public ObservableCollection<Enums.Size> Sizes { get; set; }

        public CreateTaskSpecificationsViewModel()
        {
        }

        public CreateTaskSpecificationsViewModel(CreateTaskViewModel parent)
        {
            Mode = new ObservableCollection<string>()
            {
                "keywords",
                "url"
            };

            Parent = parent;
            Profiles = GetProfiles();
            Sizes = new ObservableCollection<Enums.Size>() { Enums.Size.Small, Enums.Size.Medium, Enums.Size.Large, Enums.Size.XLarge };
        }

        


        public override void NextStep(CreateTaskViewModel CreateTaskVM)
        {
            Parent.CanCreate = true;

            CreateTaskVM.Current = CreateTaskVM.finalize;

        }

        private ObservableCollection<Profile> GetProfiles()
        {
            var profiles = new ObservableCollection<Profile>();

            using (StreamReader r = new StreamReader("profiles.json"))
            {
                string json = r.ReadToEnd();
                var tasks = JsonConvert.DeserializeObject<ListProfiles>(json);
                foreach (var task in tasks.Profiles)
                {
                    profiles.Add(task);
                }
                return profiles;
            }
        }
    }
}
