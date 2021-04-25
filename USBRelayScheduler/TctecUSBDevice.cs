using System;
using System.Collections.Generic;
using System.Text;
using TctecUSB4;

namespace USBRelayScheduler
{
    public class TctecUSBDevice
    {
        private string serialNumber;
        private bool[] currentRelayStates = new bool[] {false, false, false, false };

        private readonly byte[] RELAYBYTES = { 0x01, 0x02, 0x04, 0x08 };

        public TctecUSBDevice()
        {
            serialNumber = TctecUSB4.TctecUSB4.getSerialNumbers()[0].ToString();
        }

        public TctecUSBDevice(string serialNum)
        {
            serialNumber = serialNum;
        }

        // TODO Add timer to check schedule and state

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
    }
}
