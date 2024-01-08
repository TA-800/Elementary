using System;
using System.Windows.Input;

namespace Elementary.Core
{
    public class RelayCommand : ICommand
    {
        Action<object> _execute;
        Func<object, bool> _canExecute;

        // Add and Remove - part of event handling in C#.
        public event EventHandler CanExecuteChanged
        {
            add // what happens when event handler is added. 
            { CommandManager.RequerySuggested += value; }
            remove // what happens when event handler is removed.
            { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // If no canExecute is provided, then the command can always execute.
        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
