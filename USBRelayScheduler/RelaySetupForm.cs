using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using USBRelayScheduler.Resources;

namespace USBRelayScheduler
{
    public partial class RelaySetupForm : Form
    {
        int currentRelay = 0;

        public RelaySetupForm()
        {
            InitializeComponent();
        }

        public RelaySetupForm(int relay)
        {
            InitializeComponent();
            currentRelay = relay;
            PopulateFields(relay);
        }

        private void PopulateFields(int relay)
        {
            if (Settings.Default.RelaySchedules == null) return;
            if (Settings.Default.RelaySchedules != null && relay >= Settings.Default.RelaySchedules.Count - 1) return;
            if (Settings.Default.RelaySchedules[relay] == null) { Settings.Default.RelaySchedules[relay] = new RelaySchedule(); }

            RelaySchedule selectedSchedule = Settings.Default.RelaySchedules[relay];

            if (selectedSchedule == null) { selectedSchedule = new RelaySchedule(); }

            checkBoxEnableMonday.Checked = selectedSchedule.schedules[(int)DayOfWeek.Monday].Enabled;
            checkBoxEnableTuesday.Checked = selectedSchedule.schedules[(int)DayOfWeek.Tuesday].Enabled;
            checkBoxEnableWednesday.Checked = selectedSchedule.schedules[(int)DayOfWeek.Wednesday].Enabled;
            checkBoxEnableThursday.Checked = selectedSchedule.schedules[(int)DayOfWeek.Thursday].Enabled;
            checkBoxEnableFriday.Checked = selectedSchedule.schedules[(int)DayOfWeek.Friday].Enabled;
            checkBoxEnableSaturday.Checked = selectedSchedule.schedules[(int)DayOfWeek.Saturday].Enabled;
            checkBoxEnableSunday.Checked = selectedSchedule.schedules[(int)DayOfWeek.Sunday].Enabled;

            dateTimePickerMondayStart.Value = selectedSchedule.schedules[(int)DayOfWeek.Monday].StartTime;
            dateTimePickerMondayEnd.Value = selectedSchedule.schedules[(int)DayOfWeek.Monday].EndTime;
            dateTimePickerTuesdayStart.Value = selectedSchedule.schedules[(int)DayOfWeek.Tuesday].StartTime;
            dateTimePickerTuesdayEnd.Value = selectedSchedule.schedules[(int)DayOfWeek.Tuesday].EndTime;
            dateTimePickerWednesdayStart.Value = selectedSchedule.schedules[(int)DayOfWeek.Wednesday].StartTime;
            dateTimePickerWednesdayEnd.Value = selectedSchedule.schedules[(int)DayOfWeek.Wednesday].EndTime;
            dateTimePickerThursdayStart.Value = selectedSchedule.schedules[(int)DayOfWeek.Thursday].StartTime;
            dateTimePickerThursdayEnd.Value = selectedSchedule.schedules[(int)DayOfWeek.Thursday].EndTime;
            dateTimePickerFridayStart.Value = selectedSchedule.schedules[(int)DayOfWeek.Friday].StartTime;
            dateTimePickerFridayEnd.Value = selectedSchedule.schedules[(int)DayOfWeek.Friday].EndTime;
            dateTimePickerSaturdayStart.Value = selectedSchedule.schedules[(int)DayOfWeek.Saturday].StartTime;
            dateTimePickerSaturdayEnd.Value = selectedSchedule.schedules[(int)DayOfWeek.Saturday].EndTime;
            dateTimePickerSundayStart.Value = selectedSchedule.schedules[(int)DayOfWeek.Sunday].StartTime;
            dateTimePickerSundayEnd.Value = selectedSchedule.schedules[(int)DayOfWeek.Sunday].EndTime;
        }

        private bool ValidateForm()
        {
            if (checkBoxEnableMonday.Checked && dateTimePickerMondayStart.Value.TimeOfDay >= dateTimePickerMondayEnd.Value.TimeOfDay)
            {
                MessageBox.Show("Monday end time must be after start time");
                return false;
            }
            if (checkBoxEnableTuesday.Checked && dateTimePickerTuesdayStart.Value.TimeOfDay >= dateTimePickerTuesdayEnd.Value.TimeOfDay)
            {
                MessageBox.Show("Tuesday end time must be after start time");
                return false;
            }
            if (checkBoxEnableWednesday.Checked && dateTimePickerWednesdayStart.Value.TimeOfDay >= dateTimePickerWednesdayEnd.Value.TimeOfDay)
            {
                MessageBox.Show("Wednesday end time must be after start time");
                return false;
            }
            if (checkBoxEnableThursday.Checked && dateTimePickerThursdayStart.Value.TimeOfDay >= dateTimePickerThursdayEnd.Value.TimeOfDay)
            {
                MessageBox.Show("Thursday end time must be after start time");
                return false;
            }
            if (checkBoxEnableFriday.Checked && dateTimePickerFridayStart.Value.TimeOfDay >= dateTimePickerFridayEnd.Value.TimeOfDay)
            {
                MessageBox.Show("Friday end time must be after start time");
                return false;
            }
            if (checkBoxEnableSaturday.Checked && dateTimePickerSaturdayStart.Value.TimeOfDay >= dateTimePickerSaturdayEnd.Value.TimeOfDay)
            {
                MessageBox.Show("Saturday end time must be after start time");
                return false;
            }
            if (checkBoxEnableSunday.Checked && dateTimePickerSundayStart.Value.TimeOfDay >= dateTimePickerSundayEnd.Value.TimeOfDay)
            {
                MessageBox.Show("Sunday end time must be after start time");
                return false;
            }

            return true;
        }

        private void SaveSchedule()
        {
            RelaySchedule tempSchedule = new RelaySchedule();
            tempSchedule.SetSchedule(DayOfWeek.Monday, checkBoxEnableMonday.Checked, dateTimePickerMondayStart.Value, dateTimePickerMondayEnd.Value);
            tempSchedule.SetSchedule(DayOfWeek.Tuesday, checkBoxEnableTuesday.Checked, dateTimePickerTuesdayStart.Value, dateTimePickerTuesdayEnd.Value);
            tempSchedule.SetSchedule(DayOfWeek.Wednesday, checkBoxEnableWednesday.Checked, dateTimePickerWednesdayStart.Value, dateTimePickerWednesdayEnd.Value);
            tempSchedule.SetSchedule(DayOfWeek.Thursday, checkBoxEnableThursday.Checked, dateTimePickerThursdayStart.Value, dateTimePickerThursdayEnd.Value);
            tempSchedule.SetSchedule(DayOfWeek.Friday, checkBoxEnableFriday.Checked, dateTimePickerFridayStart.Value, dateTimePickerFridayEnd.Value);
            tempSchedule.SetSchedule(DayOfWeek.Saturday, checkBoxEnableSaturday.Checked, dateTimePickerSaturdayStart.Value, dateTimePickerSaturdayEnd.Value);
            tempSchedule.SetSchedule(DayOfWeek.Sunday, checkBoxEnableSunday.Checked, dateTimePickerSundayStart.Value, dateTimePickerSundayEnd.Value);

            if (checkBoxApplySchedule.Checked)
            {
                for (int i = 0; i < Settings.Default.RelaySchedules.Count; i++)
                {
                    bool tempEnabled = Settings.Default.RelaySchedules[i].enabled;
                    Settings.Default.RelaySchedules[i] = tempSchedule;
                    Settings.Default.RelaySchedules[i].enabled = tempEnabled;
                }
            }
            else
            {
                tempSchedule.enabled = Settings.Default.RelaySchedules[currentRelay].enabled;
                Settings.Default.RelaySchedules[currentRelay] = tempSchedule;
            }
            Settings.Default.Save();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SaveSchedule();
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
