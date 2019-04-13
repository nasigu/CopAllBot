using Supreme.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supreme.ViewModel
{
    public class PageViewModel: BaseListViewModel<ArtList>
    {
        public ObservableCollection<ArtList> arts { get; set; }

        public PageViewModel()
        {
            ObservableCollection<ArtList> arts = new ObservableCollection<ArtList>();
            arts.Add(new ArtList { Reference = "dhfjsoaijsd;fasdfoaisdjfd;ofij" }); 
        }
    } 
}
