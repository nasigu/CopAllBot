using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supreme.Model
{
    public class Test: BaseItem
    {
        private string _UrlAddress;
        public string UrlAddress { get { return _UrlAddress; } set { if (_UrlAddress != value) { _UrlAddress = value; NotifyPropertyChanged(); } } }
    }
}
