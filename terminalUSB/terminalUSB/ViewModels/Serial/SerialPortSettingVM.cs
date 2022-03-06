using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Text;
using terminalUSB.Infafstructure.Commands;
using terminalUSB.Models.Serial;

namespace terminalUSB.ViewModels.Serial
{
    class SerialPortSettingVM
    {


        public SerialPortSetting serialPortSetting { get; set; }


        public ObservableCollection<string> AvaliablePorts { get; set; }

        public SerialCommand RefreshPortsCommand { get; }

        public ObservableCollection<int> baudRate { get; set; }//


        public SerialPortSettingVM()
        {
            serialPortSetting = new SerialPortSetting();
            baudRate = new ObservableCollection<int>() { 9600, 115200, 230400 };
            serialPortSetting.BaudRate = baudRate[0];


            AvaliablePorts = new ObservableCollection<string>();

            RefreshPortsCommand = new SerialCommand(RefreshPorts);

            RefreshPorts();
        }

        private void RefreshPorts()
        {
            AvaliablePorts.Clear();
            foreach (string port in SerialPort.GetPortNames())
            {
                AvaliablePorts.Add(port);
            }
        }
    }
}
