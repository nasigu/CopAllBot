using Newtonsoft.Json;
using Supreme.Core;
using Supreme.Model;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Supreme.ViewModel
{
    public class CreateTaskSpecificationsViewModel : BaseStepViewModel
    {

        public CreateTaskViewModel Parent { get; set; }

        public ObservableCollection<string> Mode { get; set; }

        public ObservableCollection<Profile> Profiles { get; set; }

        public ObservableCollection<Enums.Size> Sizes { get; set; }

        private string _SelectedMode;
        public string SelectedMode
        {
            get { return _SelectedMode; }
            set { if (_SelectedMode != value) { _SelectedMode = value; Parent.CurrentTask.Mode = value; NotifyPropertyChanged(); } }
        }

        private Enums.Size _SelectedSizes;
        public Enums.Size SelectedSizes
        {
            get { return _SelectedSizes; }
            set { if (_SelectedSizes != value) { _SelectedSizes = value; Parent.CurrentTask.Size = value.ToString(); NotifyPropertyChanged(); } }
        }

        private Profile _SelectedProfile;
        public Profile SelectedProfile
        {
            get { return _SelectedProfile; }
            set { if (_SelectedProfile != value) { _SelectedProfile = value; Parent.CurrentTask.Profile = value.ProfileName; NotifyPropertyChanged(); } }
        }

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
            SelectedMode = "keywords";
            SelectedSizes = Enums.Size.Medium;
            SelectedProfile = Profiles.FirstOrDefault();
        }

        


        public override void NextStep(CreateTaskViewModel createTaskVm)
        {
            Parent.CanCreate = true;
            //Parent.CurrentTask.Size = SelectedSizes.ToString();
            //Parent.CurrentTask.Profile = SelectedProfile.ProfileName;
            //Parent.CurrentTask.Mode = SelectedMode;
            createTaskVm.Current = createTaskVm.finalize;

        }

        private ObservableCollection<Profile> GetProfiles()
        {
            var profiles = new ObservableCollection<Profile>();

            using (var r = new StreamReader("profiles.json"))
            {
                var json = r.ReadToEnd();
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
