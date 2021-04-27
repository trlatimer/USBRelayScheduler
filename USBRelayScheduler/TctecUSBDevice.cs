using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TctecUSB4;
using USBRelayScheduler.Resources;

namespace USBRelayScheduler
{
    public class TctecUSBDevice
    {
        private string serialNumber;
        private bool[] currentRelayStates = new bool[] {false, false, false, false };
        private RelaySchedule[] relaySchedules;

        private readonly byte[] RELAYBYTES = { 0x01, 0x02, 0x04, 0x08 };

        public TctecUSBDevice()
        {
            relaySchedules = new RelaySchedule[4]
            {
                new RelaySchedule(),
                new RelaySchedule(),
                new RelaySchedule(),
                new RelaySchedule()
            };

            try
            {
                serialNumber = TctecUSB4.TctecUSB4.getSerialNumbers()[0].ToString();
            } catch(ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Unable to find a Tctec USB Relay device, please reconnect and try again.", "No Devices", MessageBoxButtons.OK);
                Console.WriteLine("Unable to locate device, ex: " + ex.Message);
                return;
            }

            LoadSchedules();
        }

        public TctecUSBDevice(string serialNum)
        {
            serialNumber = serialNum;
        }

        // TODO Add timer to check schedule

        public bool GetRelayState(int relay)
        {
            return currentRelayStates[relay ];
        }
        
        public string GetSerialNumber()
        {
            return serialNumber;
        }

        public void SetRelayOn(int relay)
        {
            TctecUSB4.TctecUSB4.setBits(serialNumber, RELAYBYTES[relay], true);
            currentRelayStates[relay] = true;
        }

        public void SetRelayOff(int relay)
        {
            TctecUSB4.TctecUSB4.setBits(serialNumber, RELAYBYTES[relay], false);
            currentRelayStates[relay] = false;
        }

        public void LoadSchedules()
        {
            if (Settings.Default.Relay1Schedule != null)
            {
                relaySchedules[0] = Settings.Default.Relay1Schedule;
            }
            if (Settings.Default.Relay2Schedule != null)
            {
                relaySchedules[1] = Settings.Default.Relay2Schedule;
            }
            if (Settings.Default.Relay3Schedule != null)
            {
                relaySchedules[2] = Settings.Default.Relay3Schedule;
            }
            if (Settings.Default.Relay4Schedule != null)
            {
                relaySchedules[3] = Settings.Default.Relay4Schedule;
            }
        }
    }
}
