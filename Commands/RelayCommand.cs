using System;
using System.Windows.Input;

namespace QuizGenerator.Core.Helpers.Commands
{
    public class RelayCommand : ICommand
    {

        //private Action mAction;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //public RelayCommand(Action action, Predicate<object> predicate)
        //{
        //    mAction = action;
        //}

        //public bool CanExecute(object parameter)
        //{
        //    return true; //zawsze da sie odpalic dana funkcje
        //}

        //public void Execute(object parameter)
        //{
        //    mAction();
        //}

        private Action<object> execute;
        private Predicate<object> canExecute;

        public RelayCommand(Action<object> execute)
        {
            this.execute = execute;
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }


        public bool CanExecute(object parameter)
        {

            return canExecute == null ? true : canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}