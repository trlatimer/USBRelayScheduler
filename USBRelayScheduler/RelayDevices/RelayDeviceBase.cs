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
            try
            {
                InitializeSettings();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Unable to initialize settings and start timers, please reconnect and try again.", "Failed to Initialize", MessageBoxButtons.OK);
            }
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

            for (int i = 0; i <= relaySchedules.Count - 1; i++)
            {
                if (relaySchedules[i] == null || relaySchedules[i].schedules[currentDay] == null) continue;
                if (!relaySchedules[i].enabled) continue;

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
                else
                {
                    if (!SetRelay(i, false)) break;
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
