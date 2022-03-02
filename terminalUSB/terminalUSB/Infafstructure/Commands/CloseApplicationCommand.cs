using System;
using System.Windows;
using terminalUSB.Infafstructure.Commands.Base;

namespace terminalUSB.Infafstructure.Commands
{
    internal class CloseApplicationCommand : Command
    {

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}
