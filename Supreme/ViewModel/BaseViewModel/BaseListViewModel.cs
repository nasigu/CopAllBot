using System;
using System.Windows.Input;

namespace Supreme.ViewModel
{
    public abstract class BaseListViewModel<TItem> : BaseViewModel
        where TItem : Model.BaseItem
    {
        #region Constructor

        #endregion Constructor

        #region Property

        public bool CanEdit { get; private set; }

        private TItem _Current;
        public TItem Current
        {
            get
            {
                return _Current;
            }
            set
            {
                if (_Current != value)
                {
                    if (_Current != null)
                    {
                        _Current.Saved -= Current_Changed;
                        _Current.Removed -= Current_Changed;
                    }

                    _Current = value;
                    NotifyPropertyChanged();
                    NotifyCurrentChanged();

                    if (_Current != null)
                    {
                        _Current.Saved += Current_Changed;
                        _Current.Removed += Current_Changed;
                    }
                }
            }
        }

        private void Current_Changed(object sender, EventArgs e)
        {
            NotifyItemsChanged();
        }


        #endregion Property

        #region Command


        #endregion Command

        #region Event

        public event EventHandler CurrentChanged;
        private void NotifyCurrentChanged()
        {
            CurrentChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler ItemsChanged;
        private void NotifyItemsChanged()
        {
            ItemsChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion Event

        #region Method

        //protected virtual void Tab_CloseRequested(object sender, EventArgs e)
        //{
        //    var baseVM = sender as BaseViewModel;
        //    baseVM.Dispose();
        //    Core.TabService.Remove(baseVM);
        //    if (sender is BaseItemViewModel<TItem> baseItemVM && baseItemVM.HasChanges)
        //    {
        //        Refresh();
        //    }
        //}

        //public void Refresh()
        //{
        //    var curID = Current == null ? 0 : Current.ID;
        //    Refresh(curID);
        //}

        //public abstract void Refresh(long curID);

        //public virtual bool CanRefresh()
        //{
        //    return true;
        //}

        //public override bool CanOkDialog()
        //{
        //    return Current != null;
        //}

        #endregion Method
    }
}
