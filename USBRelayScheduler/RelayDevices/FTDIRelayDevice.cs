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
            try
            {
                InitializeDevice();
                FTDI.FT_STATUS connected = FTDIDevice.GetSerialNumber(out serialNumber);
                if (connected != FTDI.FT_STATUS.FT_OK)
                {
                    MessageBox.Show("Unable to find a FTDI USB Relay device, please reconnect and try again.", "No Devices", MessageBoxButtons.OK);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Unable to find a FTDI USB Relay device, please reconnect and try again.", "No Devices", MessageBoxButtons.OK);
            }
        }

        public FTDIRelayDevice(string serialNum) : base()
        {
            serialNumber = serialNum;
        }

        private bool InitializeDevice()
        {
            // Grab the first FTDI device found
            FTDI.FT_STATUS deviceStatus = FTDIDevice.OpenByIndex(0);
            if (deviceStatus != FTDI.FT_STATUS.FT_OK) return false;

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
            return serialNumber;
        }

        public override bool SetRelay(int relay, bool on)
        {
            FTDI.FT_STATUS setStatus;
            uint receivedBytes = 0;

            if (on)
            {
                sentBytes[0] = (byte)(sentBytes[0] | RELAYBYTES[0, relay]);
                setStatus = FTDIDevice.Write(sentBytes, 1, ref receivedBytes);
                if (setStatus != FTDI.FT_STATUS.FT_OK)
                {
                    MessageBox.Show("Unable to set relay, please check connection.", "Unable to connect", MessageBoxButtons.OK);
                    return false;
                }
                currentRelayStates[relay] = true;
            }
            else
            {
                sentBytes[0] = (byte)(sentBytes[0] & RELAYBYTES[1, relay]);
                setStatus = FTDIDevice.Write(sentBytes, 1, ref receivedBytes);
                if (setStatus != FTDI.FT_STATUS.FT_OK)
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
