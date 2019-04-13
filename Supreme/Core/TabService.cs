using System;
using System.Collections.ObjectModel;

namespace Supreme.Core
{
    public static class TabService
    {
        #region Method

        public static void Add(ViewModel.BaseViewModel tab, bool isSelected = true)
        {
            Items.Add(tab);
            if (isSelected)
            {
                Current = tab;
            }
        }

        public static void Remove(ViewModel.BaseViewModel tab)
        {
            Items.Remove(tab);
        }

        #endregion Method

        #region Property

        private static ViewModel.BaseViewModel current;
        public static ViewModel.BaseViewModel Current
        {
            get { return current; }
            set { if (current != value) { current = value; NotifyCurrentChanged(); } }
        }

        private static ObservableCollection<ViewModel.BaseViewModel> items;
        public static ObservableCollection<ViewModel.BaseViewModel> Items
        {
            get { return items ?? (items = new ObservableCollection<ViewModel.BaseViewModel>()); }
        }

        #endregion Property

        #region Event

        public static event EventHandler CurrentChanged;
        private static void NotifyCurrentChanged()
        {
            CurrentChanged?.Invoke(null, EventArgs.Empty);
        }

        #endregion Event
    }
}
