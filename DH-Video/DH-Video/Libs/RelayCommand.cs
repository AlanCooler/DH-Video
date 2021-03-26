using System;
using System.Windows.Input;

namespace DH_Video.Libs
{
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// We can always execute this command
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>true</returns>
        public bool CanExecute(object parameter) => true;

        /// <summary>
        /// Action that stores information about the methods to be executed in the Execute method
        /// </summary>
        private Action mAction;
        
        /// <summary>
        /// The main realization of the command object. Start working.
        /// </summary>
        /// <param name="parameter"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Execute(object parameter)
        {
            if (mAction == null) throw new NotImplementedException("The action of the command is not implemented");
            
            mAction.Invoke();
        }

        /// <summary>
        /// Basic constructor commands
        /// </summary>
        /// <param name="action">What to do</param>
        public RelayCommand(Action action)
        {
            mAction = action;
        }
        
        public event EventHandler CanExecuteChanged;
    }
}