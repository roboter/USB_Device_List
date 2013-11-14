using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USB.Helpers;

namespace USB.Models
{
    public class USBDeviceInfo : NotificationObject
    {
        public USBDeviceInfo(string deviceID, string pnpDeviceID, string description)
        {
            this.DeviceID = deviceID;
            this.PnpDeviceID = pnpDeviceID;
            this.Description = description;
        }
        private string _deviceID;
        public string DeviceID
        {
            get { return _deviceID; }
            private set
            {
                if (_deviceID != value)
                {
                    _deviceID = value;
                    RaisePropertyChanged(() => DeviceID);
                }
            }
        }
        private string _pnpDeviceID;
        public string PnpDeviceID
        {
            get { return _pnpDeviceID; }
            private set
            {
                if (_pnpDeviceID != value)
                {
                    _pnpDeviceID = value;
                    RaisePropertyChanged(() => PnpDeviceID);
                }
            }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            private set
            {
                if (_description != value)
                {
                    _description = value;
                    RaisePropertyChanged(() => Description);
                }
            }
        }
    }

}
