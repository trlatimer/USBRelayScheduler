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
        public Timer relayScheduleTimer;

        private readonly byte[] RELAYBYTES = { 0x01, 0x02, 0x04, 0x08 };

        public TctecUSBDevice()
        {
            if (Settings.Default.RelaySchedules == null)
            {
                Settings.Default.RelaySchedules = new List<RelaySchedule>();
                for (int i = 0; i <= 3; i++)
                {
                    Settings.Default.RelaySchedules.Add(new RelaySchedule());
                }

                Settings.Default.Save();
            }

            try
            {
                serialNumber = TctecUSB4.TctecUSB4.getSerialNumbers()[0].ToString();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Unable to find a Tctec USB Relay device, please reconnect and try again.", "No Devices", MessageBoxButtons.OK);
                Console.WriteLine("Unable to locate device, ex: " + ex.Message);
                return;
            }
            StartScheduleTimer();
        }

        public TctecUSBDevice(string serialNum)
        {
            serialNumber = serialNum;
        }

        public bool GetRelayState(int relay)
        {
            return currentRelayStates[relay ];
        }
        
        public string GetSerialNumber()
        {
            return serialNumber;
        }

        public void SetRelay(int relay, bool on)
        {
            if (on)
            {
                TctecUSB4.TctecUSB4.setBits(serialNumber, RELAYBYTES[relay], true);
                currentRelayStates[relay] = true;
            }
            else
            {
                TctecUSB4.TctecUSB4.setBits(serialNumber, RELAYBYTES[relay], false);
                currentRelayStates[relay] = false;
            }
        }

        private void StartScheduleTimer()
        {
            relayScheduleTimer = new Timer();
            relayScheduleTimer.Interval = 5000; // Every 5 seconds
            relayScheduleTimer.Enabled = true;
            relayScheduleTimer.Tick += RelayScheduleTimer_Tick;
            relayScheduleTimer.Start();
        }

        private void CheckRelaySchedules()
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            int currentDay = (int)DateTime.Now.DayOfWeek;

            if (Settings.Default.RelaySchedules == null) return;
            List<RelaySchedule> relaySchedules = Settings.Default.RelaySchedules;

            for (int i = 0; i <= relaySchedules.Count - 1; i++)
            {
                if (relaySchedules[i] == null || relaySchedules[i].schedules[currentDay] == null) { continue; }

                if (relaySchedules[i].schedules[currentDay].Enabled)
                {
                    TimeSpan startTime = relaySchedules[i].schedules[currentDay].StartTime.TimeOfDay;
                    TimeSpan endTime = relaySchedules[i].schedules[currentDay].EndTime.TimeOfDay;
                    if (currentTime >= startTime && currentTime < endTime && !GetRelayState(i))
                    {
                        SetRelay(i, true);
                    }
                    else if (currentTime >= relaySchedules[i].schedules[currentDay].EndTime.TimeOfDay && GetRelayState(i))
                    {
                        SetRelay(i, false);
                    }
                }
            }
        }

        private void RelayScheduleTimer_Tick(object sender, EventArgs e)
        {
            relayScheduleTimer.Tick -= RelayScheduleTimer_Tick;
            CheckRelaySchedules();
            relayScheduleTimer.Tick += RelayScheduleTimer_Tick;
        }
    }
}
