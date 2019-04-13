using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supreme.ViewModel
{
    //public abstract class BaseItemViewModel<TItem> : BaseViewModel
    //   where TItem : Models.BaseItem
    //{
    //    #region Constructor

    //    public BaseItemViewModel(TItem item, string displayName, bool canEdit)
    //        : base(displayName, false)
    //    {
    //        CanEdit = canEdit;

    //        Item = item;
    //        Item.PropertyChanged += Item_PropertyChanged;
    //    }

    //    private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    //    {
    //        NotifyPropertyChanged(e.PropertyName);
    //    }

    //    #endregion Constructor

    //    #region Property

    //    public TItem Item { get; private set; }
    //    public bool HasChanges { get; private set; }
    //    public bool HasExtraTabs { get { return Item.ID != 0; } }
    //    public bool CanEdit { get; private set; }

    //    #endregion Property

    //    #region Command

    //    private ICommand _saveCommand;
    //    public ICommand SaveCommand { get { return _saveCommand ?? (_saveCommand = new FuncCommand<bool>(Save, CanSave)); } }

    //    private ICommand _removeCommand;
    //    public ICommand RemoveCommand { get { return _removeCommand ?? (_removeCommand = new FuncCommand<bool>(Remove, CanRemove)); } }

    //    #endregion Command

    //    #region Method

    //    public bool Save()
    //    {
    //        var isSaved = Item.Save();
    //        if (isSaved)
    //        {
    //            HasChanges = true;
    //            NotifyPropertyChanged("HasExtraTabs");
    //            RefreshExtraTabs();
    //        }
    //        return isSaved;
    //    }

    //    public virtual bool CanSave()
    //    {
    //        return CanEdit;
    //    }

    //    public bool Remove()
    //    {
    //        var isRemoved = false;
    //        if (DialogService.ShowDialog("Удалить объект?", "Удаление") == true)
    //        {
    //            isRemoved = Item.Remove();
    //            if (isRemoved)
    //            {
    //                if (Item.ID != 0)
    //                {
    //                    HasChanges = true;
    //                }
    //                NotifyCloseRequested();
    //            }
    //        }
    //        return isRemoved;
    //    }

    //    public virtual bool CanRemove()
    //    {
    //        return CanEdit;
    //    }

    //    public virtual void RefreshExtraTabs()
    //    {
    //    }

    //    #endregion Method
    //}
}
