using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using terminalUSB.Infafstructure.Commands;
using terminalUSB.ViewModels.Base;

namespace terminalUSB.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title = "Terminal";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }


        #region Status

        /// <summary>статутс підключення</summary>
        private string _StatusConnect = "Connect";

        /// <summary>статутс підключення</summary>
        public string StatusConnect
        {
            get => _StatusConnect;
            set => Set(ref _StatusConnect, value);
        }

        #endregion

        #region ClaseApplicationCommand 

        public ICommand ClaseApplicationCommand { get; }

        private bool CanClaseApplicationCommand(object p) => true;
        private void OnClaseApplicationCommand(object p)
        {
            Application.Current.Shutdown();
        }

        #endregion

        public MainWindowViewModel()
        {
            ClaseApplicationCommand = new LambdaCommand(OnClaseApplicationCommand, CanClaseApplicationCommand);
        }
    }
}
