using System;
using System.Collections.Generic;
using System.Text;
using USBRelayScheduler.Resources;
using System.Windows.Forms;

namespace USBRelayScheduler.RelayDevices
{
    public abstract class RelayDeviceBase
    {
        public System.Windows.Forms.Timer relayScheduleTimer;

        public RelayDeviceBase()
        {
            InitializeSettings();
        }

        /// <summary>
        /// Returns the current state of an individual relay
        /// </summary>
        /// <param name="relay"></param>
        public abstract bool GetRelayState(int relay);
        /// <summary>
        /// Returns the serial number of the current device
        /// </summary>
        public abstract string GetSerialNumber();
        /// <summary>
        /// Attempts to set a specific relay on or off
        /// </summary>
        /// <param name="relay"></param>
        /// <param name="on"></param>
        /// <returns></returns>
        public abstract bool SetRelay(int relay, bool on);
        /// <summary>
        /// Closed the port for the current device
        /// </summary>
        public abstract void Close();

        /// <summary>
        /// Checks the schedule for each relay and sets the relay on/off accordingly
        /// </summary>
        public void CheckRelaySchedules()
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            int currentDay = (int)DateTime.Now.DayOfWeek;

            if (Settings.Default.RelaySchedules == null) return;
            List<RelaySchedule> relaySchedules = Settings.Default.RelaySchedules;

            // Iterate through each schedule
            for (int i = 0; i <= relaySchedules.Count - 1; i++)
            {
                if (relaySchedules[i] == null || relaySchedules[i].schedules[currentDay] == null) continue;
                if (!relaySchedules[i].enabled) continue;

                // If we are within the scheduled time and the state doesn't match, attempt to set the relay
                if (relaySchedules[i].schedules[currentDay].Enabled)
                {
                    TimeSpan startTime = relaySchedules[i].schedules[currentDay].StartTime.TimeOfDay;
                    TimeSpan endTime = relaySchedules[i].schedules[currentDay].EndTime.TimeOfDay;
                    if (currentTime >= startTime && currentTime < endTime && !GetRelayState(i))
                    {
                        if (!SetRelay(i, true)) break;
                    }
                    else if (currentTime >= relaySchedules[i].schedules[currentDay].EndTime.TimeOfDay && GetRelayState(i))
                    {
                        if (!SetRelay(i, false)) break;
                    }
                }
                else // Not a scheduled day
                {
                    if (!GetRelayState(i)) continue; // Already off, move to next relay
                    if (!SetRelay(i, false)) break;  // We are not scheduled to be on, need to turn off
                }
            }
        }

        /// <summary>
        /// Creates default values for settings if they don't yet exist
        /// </summary>
        private static void InitializeSettings()
        {
            if (Settings.Default.RelaySchedules == null)
            {
                Settings.Default.RelaySchedules = new List<RelaySchedule>();
                for (int i = 0; i <= 3; i++)
                {
                    Settings.Default.RelaySchedules.Add(new RelaySchedule());
                }
            }

            if (Settings.Default.RelayForcedStates == null)
            {
                Settings.Default.RelayForcedStates = new List<CheckState>() { CheckState.Unchecked, CheckState.Unchecked, CheckState.Unchecked, CheckState.Unchecked };
            }

            Settings.Default.Save();
        }

        /// <summary>
        /// Instantiates and starts the timer to check if we need to turn relays on or off
        /// </summary>
        public void StartScheduleTimer()
        {
            relayScheduleTimer = new System.Windows.Forms.Timer();
            relayScheduleTimer.Interval = 5000; // Every 5 seconds
            relayScheduleTimer.Enabled = true;
            relayScheduleTimer.Tick += RelayScheduleTimer_Tick;
            relayScheduleTimer.Start();
        }

        /// <summary>
        /// Stops the timer that checks relay schedules and disposes of it
        /// </summary>
        public void StopScheduleTimer()
        {   
            if (relayScheduleTimer != null)
            {
                relayScheduleTimer.Tick -= RelayScheduleTimer_Tick;
                relayScheduleTimer.Stop();
                relayScheduleTimer.Enabled = false;
                relayScheduleTimer = null;
            }
        }

        /// <summary>
        /// Checks the current state of relays and if the relay should be on/off and sets it accordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RelayScheduleTimer_Tick(object sender, EventArgs e)
        {
            relayScheduleTimer.Tick -= RelayScheduleTimer_Tick;
            CheckRelaySchedules();
            if (relayScheduleTimer != null)
                relayScheduleTimer.Tick += RelayScheduleTimer_Tick;
        }
    }
}
