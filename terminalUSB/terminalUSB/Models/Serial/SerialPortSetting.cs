using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Text;
using terminalUSB.Infafstructure.Commands;
using terminalUSB.ViewModels.Base;

namespace terminalUSB.Models.Serial
{
    sealed class SerialPortSetting : ViewModel
    {
        private string _selectedComPort;
        public string SelectedCOMPort
        {
            get => _selectedComPort;
            set => RaisePropertyChanged(ref _selectedComPort, value);
        }

        

        // one of the most common baud rate
        public int BaudRate { get; set; } //= 9600;

        // i think determinds how many bits are in 1 byte. so 8. could also use 5.. if you wanted to
        public int DataBits { get; set; } //= 8;

        // I think the serialport only supports none, probably
        public StopBits StopBits { get; set; } //= StopBits.None;

        // The serialport doesn't support all of the parity options, i think such as mark/even
        public Parity Parity { get; set; } //= Parity.None;

        // not using a handshake
        public Handshake Handshake { get; set; } //= Handshake.None;
    }
}
