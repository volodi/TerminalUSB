using AdvSerialCommunicator.Messaging;
using AdvSerialCommunicator.Serial;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using terminalUSB.Infafstructure.Commands;
using terminalUSB.Models;
using terminalUSB.ViewModels.Base;
using terminalUSB.ViewModels.Serial;

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

        #region
        /// <summary>
        /// </summary>
        private IEnumerable<DataPoint> _DataPointUART;

        public IEnumerable<DataPoint> DataPointUART
        {
            get => _DataPointUART;
            set => Set(ref _DataPointUART, value);
        }

        #endregion

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


        public MessagesViewModel Messages { get; set; }

        public MessageReceiver Receiver { get; set; }

        public MessageSender Sender { get; set; }

        public SerialPortViewModel SerialPort { get; set; }

        public SerialPortSettingVM SerialPortSetting { get; set; }


        public MainWindowViewModel()
        {
            SerialPortSetting = new SerialPortSettingVM();
            SerialPort = new SerialPortViewModel();
            Receiver = new MessageReceiver();
            Sender = new MessageSender();
            Messages = new MessagesViewModel();

            // hmm
            Receiver.Messages = Messages;
            Messages.Sender = Sender;
            Sender.Messages = Messages;

            SerialPort.Receiver = Receiver;
            SerialPort.Sender = Sender;
            SerialPort.Messages = Messages;

            Receiver.Port = SerialPort.Port;
            Sender.Port = SerialPort.Port;

            #region Command
            ClaseApplicationCommand = new LambdaCommand(OnClaseApplicationCommand, CanClaseApplicationCommand);
            #endregion


            var data_points = new List<DataPoint>((int)(360 / 0.1));
            for (var x = 0d; x <= 360;x+=0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(x * to_rad);

                data_points.Add(new DataPoint { XValue = x, YValue = y });
            }

            DataPointUART = data_points;
        }
    }
}
