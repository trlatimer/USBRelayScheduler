using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.Serialization;

namespace USBRelayScheduler
{
    [Serializable]
    public class RelaySchedule
    {
        private static DateTime MinDateValue = DateTime.Parse("01/01/1973 12:00:00 AM");
        private static DateTime MaxDateValue = DateTime.Parse("12/31/9997 11:59:59 PM");

        // Indices map to days - Monday = 0, Sunday = 6;
        public Schedule[] schedules;

        public RelaySchedule()
        {
            schedules = new Schedule[7]
            {
                new Schedule(false, MinDateValue, MaxDateValue),
                new Schedule(false, MinDateValue, MaxDateValue),
                new Schedule(false, MinDateValue, MaxDateValue),
                new Schedule(false, MinDateValue, MaxDateValue),
                new Schedule(false, MinDateValue, MaxDateValue),
                new Schedule(false, MinDateValue, MaxDateValue),
                new Schedule(false, MinDateValue,MaxDateValue)
            };
        }

        [Serializable]
        public class Schedule
        {
            public bool Enabled;
            public DateTime StartTime;
            public DateTime EndTime;

            public Schedule() { }

            public Schedule(bool enable, DateTime start, DateTime end)
            {
                Enabled = enable;
                StartTime = start;
                EndTime = end;
            }
        }

        public int Count => schedules.Length;

        public void SetSchedule(int day, bool enabled, DateTime start, DateTime end)
        {
            schedules[day].Enabled = enabled;
            schedules[day].StartTime = start;
            schedules[day].EndTime = end;
        }
    }
}
