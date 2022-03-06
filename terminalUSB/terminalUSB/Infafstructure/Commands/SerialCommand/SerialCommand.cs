using System;
using System.Windows;
using terminalUSB.Infafstructure.Commands.Base;

namespace terminalUSB.Infafstructure.Commands
{
    internal class SerialCommand : Command
    {

        private readonly Action _action;

        /// <summary>
        /// Creates a command that can always execute
        /// </summary>
        /// <param name="action">The method to be executed</param>
        public SerialCommand(Action action)
        {
            _action = action;
        }

        public override void Execute(object parameter)
        {
            _action?.Invoke();
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        //public override event EventHandler CanExecuteChanged { add { } remove { } }
    }
}
