using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using USB.Helpers;
using USB.Models;
using System.Collections.Generic;
using System.Management;

namespace USB.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Properties

        public ICommand RefreshDevicesCommand { get { return new DelegateCommand(GetUSBDevices); } }

        #region PersonsCollection

        private ObservableCollection<USBDeviceInfo> _USBDevicesCollection = new ObservableCollection<USBDeviceInfo>();
        public ObservableCollection<USBDeviceInfo> USBDevicesCollection
        {
            get { return _USBDevicesCollection; }
            set
            {
                if (_USBDevicesCollection != value)
                {
                    _USBDevicesCollection = value;
                    RaisePropertyChanged(() => USBDevicesCollection);
                }
            }
        }

        #endregion

        #endregion

        #region Commands

        public ICommand DoNothingCommand { get { return new DelegateCommand(OnDoNothing, CanExecuteDoNothing); } }

        #endregion

        #region Ctor
        public MainWindowViewModel()
        {
            GetUSBDevices();

        }
        #endregion

        #region Command Handlers





        private void OnDoNothing()
        {
        }

        private bool CanExecuteDoNothing()
        {
            return false;
        }

        #endregion


        void GetUSBDevices()
        {
            _USBDevicesCollection.Clear();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
                collection = searcher.Get();

            foreach (var device in collection)
            {
                _USBDevicesCollection.Add(new USBDeviceInfo(
                (string)device.GetPropertyValue("DeviceID"),
                (string)device.GetPropertyValue("PNPDeviceID"),
                (string)device.GetPropertyValue("Description")
                ));
            }

            collection.Dispose();

        }
    }
}
