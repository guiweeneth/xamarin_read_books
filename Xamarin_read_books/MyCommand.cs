using System;
using System.Windows.Input;
namespace Xamarin_read_books
{
    public class MyCommand : ICommand
    {
        Action action;
        Func<bool> canExecute;
        public event EventHandler CanExecuteChanged;

        //Constructor calls 2 par. constructor below 
        public MyCommand(Action action) : this(action, ()=> true)
        {

        }

        public MyCommand(Action action, Func<bool> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public void ReevaluateCanExecute() 
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {
            return canExecute();
        }

        void ICommand.Execute(object parameter)
        {
            action();
        }
    }
}
