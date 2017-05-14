using System;
using System.Windows.Input;

namespace ZeBoneGame.Model
{
    public class RelayCommand : ICommand
    {
        Action action;
        Func<bool> canExecute;

        public RelayCommand(Action action) : this(action, () => true) { }
        public RelayCommand(Action action, Func<bool> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecute();
        }

        public void Execute(object parameter)
        {
            action();
        }
    }

    public class RelayCommand<T> : ICommand
    {
        Action<T> action;
        Func<bool> canExecute;

        public RelayCommand(Action<T> action) : this(action, () => true) { }
        public RelayCommand(Action<T> action, Func<bool> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecute();
        }

        public void Execute(object parameter)
        {
            action((T) parameter);
        }
    }
}
