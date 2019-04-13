using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Supreme.Model
{
    public class ArtList: BaseItem
    {
        #region Property

        private string _Image;
        public string Image { get { return _Image; } set { if (_Image != value) { _Image = value; NotifyPropertyChanged(); } } }

        private string _Reference;
        public string Reference { get { return _Reference; } set { if (_Reference != value) { _Reference = value; NotifyPropertyChanged(); } } }

        private bool _SoldOut;
        public bool SoldOut { get { return _SoldOut; } set { if (_SoldOut != value) { _SoldOut = value; NotifyPropertyChanged(); } } }

        private Visibility _SoldOutVisibility;
        public Visibility SoldOutVisibility { get { return _SoldOutVisibility; } set { if (_SoldOutVisibility != value) { _SoldOutVisibility = value; NotifyPropertyChanged(); } } }

        #endregion Property
    }


}
