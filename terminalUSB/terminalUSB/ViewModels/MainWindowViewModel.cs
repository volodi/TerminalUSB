using System;
using System.Collections.Generic;
using System.Text;
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

    }
}
