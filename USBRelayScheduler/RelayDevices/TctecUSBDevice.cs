using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TctecUSB4;
using USBRelayScheduler.Resources;

namespace USBRelayScheduler.RelayDevices
{
    public class TctecUSBDevice : RelayDeviceBase
    {
        private string serialNumber;
        private bool[] currentRelayStates = new bool[] { false, false, false, false };

        private readonly byte[] RELAYBYTES = { 0x01, 0x02, 0x04, 0x08 };

        public TctecUSBDevice() : base()
        {
            try
            {
                serialNumber = TctecUSB4.TctecUSB4.getSerialNumbers()[0].ToString();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Unable to find a Tctec USB Relay device, please reconnect and try again.", "No Devices", MessageBoxButtons.OK);
            }
        }

        public TctecUSBDevice(string serialNum) : base()
        {
            serialNumber = serialNum;
        }

        public override bool GetRelayState(int relay)
        {
            return currentRelayStates[relay];
        }

        public override string GetSerialNumber()
        {
            return serialNumber;
        }

        public override bool SetRelay(int relay, bool on)
        {
            int success = 0;
            if (on)
            {
                success = TctecUSB4.TctecUSB4.setBits(serialNumber, RELAYBYTES[relay], true);
                if (success == 1)
                {
                    MessageBox.Show("Unable to set relay, please check connection.", "Unable to connect", MessageBoxButtons.OK);
                    return false;
                }
                currentRelayStates[relay] = true;
            }
            else
            {
                success = TctecUSB4.TctecUSB4.setBits(serialNumber, RELAYBYTES[relay], false);
                if (success == 1)
                {
                    MessageBox.Show("Unable to set relay, please check connection.", "Unable to connect", MessageBoxButtons.OK);
                    return false;
                }
                currentRelayStates[relay] = false;
            }
            return true;
        }
    }
}
