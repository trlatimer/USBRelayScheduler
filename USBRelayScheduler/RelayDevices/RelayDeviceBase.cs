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

        public abstract bool GetRelayState(int relay);
        public abstract string GetSerialNumber();
        public abstract bool SetRelay(int relay, bool on);
        public abstract void Close();

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

        public void StartScheduleTimer()
        {
            relayScheduleTimer = new System.Windows.Forms.Timer();
            relayScheduleTimer.Interval = 5000; // Every 5 seconds
            relayScheduleTimer.Enabled = true;
            relayScheduleTimer.Tick += RelayScheduleTimer_Tick;
            relayScheduleTimer.Start();
        }

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

        private void RelayScheduleTimer_Tick(object sender, EventArgs e)
        {
            relayScheduleTimer.Tick -= RelayScheduleTimer_Tick;
            CheckRelaySchedules();
            if (relayScheduleTimer != null)
                relayScheduleTimer.Tick += RelayScheduleTimer_Tick;
        }
    }
}
