using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FTD2XX_NET;

namespace USBRelayScheduler.RelayDevices
{
    public class FTDIRelayDevice : RelayDeviceBase
    {
        private string serialNumber;
        private bool[] currentRelayStates = new bool[4] { false, false, false, false };
        private FTDI FTDIDevice = new FTDI();
        private byte[] sentBytes = new byte[2];

        private readonly int[,] RELAYBYTES = new int[2, 4] { { 2, 8, 32, 128 }, { 253, 247, 223, 127 } };

        public FTDIRelayDevice() : base()
        {
            InitializeDevice();
        }

        public bool CheckDeviceStatus()
        {
            FTDI.FT_STATUS connected = FTDIDevice.GetSerialNumber(out serialNumber);
            if (connected != FTDI.FT_STATUS.FT_OK)
            {
                return false;
            }
            return true;
        }

        public override void Close()
        {
            FTDIDevice.Close();
        }

        private bool InitializeDevice(string serial = "")
        {
            FTDI.FT_STATUS deviceStatus;
            if (serial != "")
            {
                // Open the device based on serial number
                deviceStatus = FTDIDevice.OpenBySerialNumber(serial);
                if (deviceStatus != FTDI.FT_STATUS.FT_OK) return false;
            }
            else
            {
                // Grab the first FTDI device found
                deviceStatus = FTDIDevice.OpenByIndex(0);
                if (deviceStatus != FTDI.FT_STATUS.FT_OK) return false;
            }

            // Reset the device and check status again
            deviceStatus = FTDIDevice.ResetDevice();
            if (deviceStatus != FTDI.FT_STATUS.FT_OK) return false;

            // Set Baud Rate
            deviceStatus = FTDIDevice.SetBaudRate(921600);
            if (deviceStatus != FTDI.FT_STATUS.FT_OK) return false;

            // Set Bit Bang
            deviceStatus = FTDIDevice.SetBitMode(255, FTDI.FT_BIT_MODES.FT_BIT_MODE_SYNC_BITBANG);
            if (deviceStatus != FTDI.FT_STATUS.FT_OK) return false;

            //Read Relays Status
            deviceStatus = FTDIDevice.GetPinStates(ref sentBytes[0]);
            if ((sentBytes[0] & 2) == 0) currentRelayStates[0] = true;
            if ((sentBytes[0] & 8) == 0) currentRelayStates[1] = true;
            if ((sentBytes[0] & 32) == 0) currentRelayStates[2] = true;
            if ((sentBytes[0] & 128) == 0) currentRelayStates[3] = true;

            return true;
        }

        public override bool GetRelayState(int relay)
        {
            return currentRelayStates[relay];
        }

        public override string GetSerialNumber()
        {
            if (serialNumber != "")
            {
                return serialNumber;
            }
            return null;
        }

        public override bool SetRelay(int relay, bool on)
        {
            FTDI.FT_STATUS setStatus;
            uint receivedBytes = 0;

            if (on)
            {   // Write the respective bytes to turn on the appropriate relay
                sentBytes[0] = (byte)(sentBytes[0] | RELAYBYTES[0, relay]);
                setStatus = FTDIDevice.Write(sentBytes, 1, ref receivedBytes);
                if (setStatus != FTDI.FT_STATUS.FT_OK)
                {
                    MessageBox.Show("Unable to set relay, please check connection.", "Unable to connect", MessageBoxButtons.OK);
                    // Stop the timer if we are checking schedules
                    if (relayScheduleTimer != null)
                        StopScheduleTimer();
                    return false;
                }
                currentRelayStates[relay] = true;
            }
            else
            {
                // Write the respective bytes to turn off the appropriate relay
                sentBytes[0] = (byte)(sentBytes[0] & RELAYBYTES[1, relay]);
                setStatus = FTDIDevice.Write(sentBytes, 1, ref receivedBytes);
                if (setStatus != FTDI.FT_STATUS.FT_OK)
                {
                    MessageBox.Show("Unable to set relay, please check connection.", "Unable to connect", MessageBoxButtons.OK);
                    // Stop the timer if we are checking schedules0
                    if (relayScheduleTimer != null)
                        StopScheduleTimer();
                    return false;   
                }
                currentRelayStates[relay] = false;
            }
            return true;
        }
    }
}
