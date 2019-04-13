using System;
using System.Windows.Input;

namespace Supreme.Core
{
    public class ActCommand : ICommand
    {
        #region Constructor

        public ActCommand(Action execute)
            : this(execute, null)
        {
        }

        public ActCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region Field

        private readonly Action _execute = null;
        private readonly Func<bool> _canExecute = null;

        #endregion Field

        #region ICommand Member

        public bool CanExecute(object parameter)
        {
            return (_canExecute == null ? true : _canExecute());
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        #endregion Field
    }
}
