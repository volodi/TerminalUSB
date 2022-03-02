﻿using System;
using System.Windows.Input;

namespace terminalUSB.Infafstructure.Commands.Base
{
    internal abstract class Commands : ICommand

    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested += value;
        }

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }
}
