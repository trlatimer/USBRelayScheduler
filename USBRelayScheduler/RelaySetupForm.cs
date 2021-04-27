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
        int currentRealy = 0;

        public RelaySetupForm()
        {
            InitializeComponent();
        }

        public RelaySetupForm(int relay)
        {
            InitializeComponent();
            currentRealy = relay;
            PopulateFields(relay);
        }

        private void PopulateFields(int relay)
        {
            RelaySchedule selectedSchedule = null;

            switch (relay)
            {
                case 0:
                    selectedSchedule = Settings.Default.Relay1Schedule;
                    break;
                case 1:
                    selectedSchedule = Settings.Default.Relay2Schedule;
                    break;
                case 2:
                    selectedSchedule = Settings.Default.Relay3Schedule;
                    break;
                case 4:
                    selectedSchedule = Settings.Default.Relay4Schedule;
                    break;
            }

            checkBoxEnableMonday.Checked = selectedSchedule.schedules[0].Enabled;
            checkBoxEnableTuesday.Checked = selectedSchedule.schedules[1].Enabled;
            checkBoxEnableWednesday.Checked = selectedSchedule.schedules[2].Enabled;
            checkBoxEnableThursday.Checked = selectedSchedule.schedules[3].Enabled;
            checkBoxEnableFriday.Checked = selectedSchedule.schedules[4].Enabled;
            checkBoxEnableSaturday.Checked = selectedSchedule.schedules[5].Enabled;
            checkBoxEnableSunday.Checked = selectedSchedule.schedules[6].Enabled;

            dateTimePickerMondayStart.Value = selectedSchedule.schedules[0].StartTime;
            dateTimePickerMondayEnd.Value = selectedSchedule.schedules[0].EndTime;
            dateTimePickerTuesdayStart.Value = selectedSchedule.schedules[1].StartTime;
            dateTimePickerTuesdayEnd.Value = selectedSchedule.schedules[1].EndTime;
            dateTimePickerWednesdayStart.Value = selectedSchedule.schedules[2].StartTime;
            dateTimePickerWednesdayEnd.Value = selectedSchedule.schedules[2].EndTime;
            dateTimePickerThursdayStart.Value = selectedSchedule.schedules[3].StartTime;
            dateTimePickerThursdayEnd.Value = selectedSchedule.schedules[3].EndTime;
            dateTimePickerFridayStart.Value = selectedSchedule.schedules[4].StartTime;
            dateTimePickerFridayEnd.Value = selectedSchedule.schedules[4].EndTime;
            dateTimePickerSaturdayStart.Value = selectedSchedule.schedules[5].StartTime;
            dateTimePickerSaturdayEnd.Value = selectedSchedule.schedules[5].EndTime;
            dateTimePickerSundayStart.Value = selectedSchedule.schedules[6].StartTime;
            dateTimePickerSundayEnd.Value = selectedSchedule.schedules[6].EndTime;
        }

        private bool ValidateForm()
        {
            if (dateTimePickerMondayStart.Value.TimeOfDay >= dateTimePickerMondayEnd.Value.TimeOfDay)
            {
                MessageBox.Show("Monday end time must be after start time");
                return false;
            }
            if (dateTimePickerTuesdayStart.Value.TimeOfDay >= dateTimePickerTuesdayEnd.Value.TimeOfDay)
            {
                MessageBox.Show("Tuesday end time must be after start time");
                return false;
            }
            if (dateTimePickerWednesdayStart.Value.TimeOfDay >= dateTimePickerWednesdayEnd.Value.TimeOfDay)
            {
                MessageBox.Show("Wednesday end time must be after start time");
                return false;
            }
            if (dateTimePickerThursdayStart.Value.TimeOfDay >= dateTimePickerThursdayEnd.Value.TimeOfDay)
            {
                MessageBox.Show("Thursday end time must be after start time");
                return false;
            }
            if (dateTimePickerFridayStart.Value.TimeOfDay >= dateTimePickerFridayEnd.Value.TimeOfDay)
            {
                MessageBox.Show("Friday end time must be after start time");
                return false;
            }
            if (dateTimePickerSaturdayStart.Value.TimeOfDay >= dateTimePickerSaturdayEnd.Value.TimeOfDay)
            {
                MessageBox.Show("Saturday end time must be after start time");
                return false;
            }
            if (dateTimePickerSundayStart.Value.TimeOfDay >= dateTimePickerSundayEnd.Value.TimeOfDay)
            {
                MessageBox.Show("Sunday end time must be after start time");
                return false;
            }

            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ValidateForm();
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
