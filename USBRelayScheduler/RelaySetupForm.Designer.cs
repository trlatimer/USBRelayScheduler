
namespace USBRelayScheduler
{
    partial class RelaySetupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelRelayName = new System.Windows.Forms.Label();
            this.checkBoxApplySchedule = new System.Windows.Forms.CheckBox();
            this.labelEnable = new System.Windows.Forms.Label();
            this.labelStart = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.labelMonday = new System.Windows.Forms.Label();
            this.checkBoxEnableMonday = new System.Windows.Forms.CheckBox();
            this.dateTimePickerMondayStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerMondayEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTuesdayEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTuesdayStart = new System.Windows.Forms.DateTimePicker();
            this.checkBoxEnableTuesday = new System.Windows.Forms.CheckBox();
            this.labelTuesday = new System.Windows.Forms.Label();
            this.dateTimePickerWednesdayEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerWednesdayStart = new System.Windows.Forms.DateTimePicker();
            this.checkBoxEnableWednesday = new System.Windows.Forms.CheckBox();
            this.labelWednesday = new System.Windows.Forms.Label();
            this.dateTimePickerThursdayEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerThursdayStart = new System.Windows.Forms.DateTimePicker();
            this.checkBoxEnableThursday = new System.Windows.Forms.CheckBox();
            this.labelThursday = new System.Windows.Forms.Label();
            this.dateTimePickerFridayEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFridayStart = new System.Windows.Forms.DateTimePicker();
            this.checkBoxEnableFriday = new System.Windows.Forms.CheckBox();
            this.labelFriday = new System.Windows.Forms.Label();
            this.dateTimePickerSaturdayEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerSaturdayStart = new System.Windows.Forms.DateTimePicker();
            this.checkBoxEnableSaturday = new System.Windows.Forms.CheckBox();
            this.labelSaturday = new System.Windows.Forms.Label();
            this.dateTimePickerSundayEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerSundayStart = new System.Windows.Forms.DateTimePicker();
            this.checkBoxEnableSunday = new System.Windows.Forms.CheckBox();
            this.labelSunday = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelRelayName
            // 
            this.labelRelayName.AutoSize = true;
            this.labelRelayName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRelayName.Location = new System.Drawing.Point(13, 13);
            this.labelRelayName.Name = "labelRelayName";
            this.labelRelayName.Size = new System.Drawing.Size(112, 41);
            this.labelRelayName.TabIndex = 0;
            this.labelRelayName.Text = "Relay 1";
            // 
            // checkBoxApplySchedule
            // 
            this.checkBoxApplySchedule.AutoSize = true;
            this.checkBoxApplySchedule.Location = new System.Drawing.Point(230, 25);
            this.checkBoxApplySchedule.Name = "checkBoxApplySchedule";
            this.checkBoxApplySchedule.Size = new System.Drawing.Size(212, 29);
            this.checkBoxApplySchedule.TabIndex = 1;
            this.checkBoxApplySchedule.Text = "Apply to All Schedules";
            this.checkBoxApplySchedule.UseVisualStyleBackColor = true;
            // 
            // labelEnable
            // 
            this.labelEnable.AutoSize = true;
            this.labelEnable.Location = new System.Drawing.Point(109, 65);
            this.labelEnable.Name = "labelEnable";
            this.labelEnable.Size = new System.Drawing.Size(64, 25);
            this.labelEnable.TabIndex = 3;
            this.labelEnable.Text = "Enable";
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(199, 65);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(91, 25);
            this.labelStart.TabIndex = 4;
            this.labelStart.Text = "Start Time";
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Location = new System.Drawing.Point(336, 65);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(85, 25);
            this.labelEnd.TabIndex = 5;
            this.labelEnd.Text = "End Time";
            // 
            // labelMonday
            // 
            this.labelMonday.AutoSize = true;
            this.labelMonday.Location = new System.Drawing.Point(32, 98);
            this.labelMonday.Name = "labelMonday";
            this.labelMonday.Size = new System.Drawing.Size(78, 25);
            this.labelMonday.TabIndex = 6;
            this.labelMonday.Text = "Monday";
            // 
            // checkBoxEnableMonday
            // 
            this.checkBoxEnableMonday.AutoSize = true;
            this.checkBoxEnableMonday.Location = new System.Drawing.Point(133, 101);
            this.checkBoxEnableMonday.Name = "checkBoxEnableMonday";
            this.checkBoxEnableMonday.Size = new System.Drawing.Size(18, 17);
            this.checkBoxEnableMonday.TabIndex = 7;
            this.checkBoxEnableMonday.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerMondayStart
            // 
            this.dateTimePickerMondayStart.CustomFormat = "hh:mm tt";
            this.dateTimePickerMondayStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerMondayStart.Location = new System.Drawing.Point(190, 92);
            this.dateTimePickerMondayStart.Name = "dateTimePickerMondayStart";
            this.dateTimePickerMondayStart.ShowUpDown = true;
            this.dateTimePickerMondayStart.Size = new System.Drawing.Size(117, 31);
            this.dateTimePickerMondayStart.TabIndex = 8;
            // 
            // dateTimePickerMondayEnd
            // 
            this.dateTimePickerMondayEnd.CustomFormat = "hh:mm tt";
            this.dateTimePickerMondayEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerMondayEnd.Location = new System.Drawing.Point(326, 92);
            this.dateTimePickerMondayEnd.Name = "dateTimePickerMondayEnd";
            this.dateTimePickerMondayEnd.ShowUpDown = true;
            this.dateTimePickerMondayEnd.Size = new System.Drawing.Size(116, 31);
            this.dateTimePickerMondayEnd.TabIndex = 9;
            // 
            // dateTimePickerTuesdayEnd
            // 
            this.dateTimePickerTuesdayEnd.CustomFormat = "hh:mm tt";
            this.dateTimePickerTuesdayEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTuesdayEnd.Location = new System.Drawing.Point(326, 125);
            this.dateTimePickerTuesdayEnd.Name = "dateTimePickerTuesdayEnd";
            this.dateTimePickerTuesdayEnd.ShowUpDown = true;
            this.dateTimePickerTuesdayEnd.Size = new System.Drawing.Size(116, 31);
            this.dateTimePickerTuesdayEnd.TabIndex = 13;
            // 
            // dateTimePickerTuesdayStart
            // 
            this.dateTimePickerTuesdayStart.CustomFormat = "hh:mm tt";
            this.dateTimePickerTuesdayStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTuesdayStart.Location = new System.Drawing.Point(190, 125);
            this.dateTimePickerTuesdayStart.Name = "dateTimePickerTuesdayStart";
            this.dateTimePickerTuesdayStart.ShowUpDown = true;
            this.dateTimePickerTuesdayStart.Size = new System.Drawing.Size(117, 31);
            this.dateTimePickerTuesdayStart.TabIndex = 12;
            // 
            // checkBoxEnableTuesday
            // 
            this.checkBoxEnableTuesday.AutoSize = true;
            this.checkBoxEnableTuesday.Location = new System.Drawing.Point(133, 134);
            this.checkBoxEnableTuesday.Name = "checkBoxEnableTuesday";
            this.checkBoxEnableTuesday.Size = new System.Drawing.Size(18, 17);
            this.checkBoxEnableTuesday.TabIndex = 11;
            this.checkBoxEnableTuesday.UseVisualStyleBackColor = true;
            // 
            // labelTuesday
            // 
            this.labelTuesday.AutoSize = true;
            this.labelTuesday.Location = new System.Drawing.Point(32, 131);
            this.labelTuesday.Name = "labelTuesday";
            this.labelTuesday.Size = new System.Drawing.Size(77, 25);
            this.labelTuesday.TabIndex = 10;
            this.labelTuesday.Text = "Tuesday";
            // 
            // dateTimePickerWednesdayEnd
            // 
            this.dateTimePickerWednesdayEnd.CustomFormat = "hh:mm tt";
            this.dateTimePickerWednesdayEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerWednesdayEnd.Location = new System.Drawing.Point(326, 158);
            this.dateTimePickerWednesdayEnd.Name = "dateTimePickerWednesdayEnd";
            this.dateTimePickerWednesdayEnd.ShowUpDown = true;
            this.dateTimePickerWednesdayEnd.Size = new System.Drawing.Size(116, 31);
            this.dateTimePickerWednesdayEnd.TabIndex = 17;
            // 
            // dateTimePickerWednesdayStart
            // 
            this.dateTimePickerWednesdayStart.CustomFormat = "hh:mm tt";
            this.dateTimePickerWednesdayStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerWednesdayStart.Location = new System.Drawing.Point(190, 158);
            this.dateTimePickerWednesdayStart.Name = "dateTimePickerWednesdayStart";
            this.dateTimePickerWednesdayStart.ShowUpDown = true;
            this.dateTimePickerWednesdayStart.Size = new System.Drawing.Size(117, 31);
            this.dateTimePickerWednesdayStart.TabIndex = 16;
            // 
            // checkBoxEnableWednesday
            // 
            this.checkBoxEnableWednesday.AutoSize = true;
            this.checkBoxEnableWednesday.Location = new System.Drawing.Point(133, 167);
            this.checkBoxEnableWednesday.Name = "checkBoxEnableWednesday";
            this.checkBoxEnableWednesday.Size = new System.Drawing.Size(18, 17);
            this.checkBoxEnableWednesday.TabIndex = 15;
            this.checkBoxEnableWednesday.UseVisualStyleBackColor = true;
            // 
            // labelWednesday
            // 
            this.labelWednesday.AutoSize = true;
            this.labelWednesday.Location = new System.Drawing.Point(10, 164);
            this.labelWednesday.Name = "labelWednesday";
            this.labelWednesday.Size = new System.Drawing.Size(104, 25);
            this.labelWednesday.TabIndex = 14;
            this.labelWednesday.Text = "Wednesday";
            // 
            // dateTimePickerThursdayEnd
            // 
            this.dateTimePickerThursdayEnd.CustomFormat = "hh:mm tt";
            this.dateTimePickerThursdayEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerThursdayEnd.Location = new System.Drawing.Point(326, 191);
            this.dateTimePickerThursdayEnd.Name = "dateTimePickerThursdayEnd";
            this.dateTimePickerThursdayEnd.ShowUpDown = true;
            this.dateTimePickerThursdayEnd.Size = new System.Drawing.Size(116, 31);
            this.dateTimePickerThursdayEnd.TabIndex = 21;
            // 
            // dateTimePickerThursdayStart
            // 
            this.dateTimePickerThursdayStart.CustomFormat = "hh:mm tt";
            this.dateTimePickerThursdayStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerThursdayStart.Location = new System.Drawing.Point(190, 191);
            this.dateTimePickerThursdayStart.Name = "dateTimePickerThursdayStart";
            this.dateTimePickerThursdayStart.ShowUpDown = true;
            this.dateTimePickerThursdayStart.Size = new System.Drawing.Size(117, 31);
            this.dateTimePickerThursdayStart.TabIndex = 20;
            // 
            // checkBoxEnableThursday
            // 
            this.checkBoxEnableThursday.AutoSize = true;
            this.checkBoxEnableThursday.Location = new System.Drawing.Point(133, 200);
            this.checkBoxEnableThursday.Name = "checkBoxEnableThursday";
            this.checkBoxEnableThursday.Size = new System.Drawing.Size(18, 17);
            this.checkBoxEnableThursday.TabIndex = 19;
            this.checkBoxEnableThursday.UseVisualStyleBackColor = true;
            // 
            // labelThursday
            // 
            this.labelThursday.AutoSize = true;
            this.labelThursday.Location = new System.Drawing.Point(27, 197);
            this.labelThursday.Name = "labelThursday";
            this.labelThursday.Size = new System.Drawing.Size(84, 25);
            this.labelThursday.TabIndex = 18;
            this.labelThursday.Text = "Thursday";
            // 
            // dateTimePickerFridayEnd
            // 
            this.dateTimePickerFridayEnd.CustomFormat = "hh:mm tt";
            this.dateTimePickerFridayEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFridayEnd.Location = new System.Drawing.Point(326, 224);
            this.dateTimePickerFridayEnd.Name = "dateTimePickerFridayEnd";
            this.dateTimePickerFridayEnd.ShowUpDown = true;
            this.dateTimePickerFridayEnd.Size = new System.Drawing.Size(116, 31);
            this.dateTimePickerFridayEnd.TabIndex = 25;
            // 
            // dateTimePickerFridayStart
            // 
            this.dateTimePickerFridayStart.CustomFormat = "hh:mm tt";
            this.dateTimePickerFridayStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFridayStart.Location = new System.Drawing.Point(190, 224);
            this.dateTimePickerFridayStart.Name = "dateTimePickerFridayStart";
            this.dateTimePickerFridayStart.ShowUpDown = true;
            this.dateTimePickerFridayStart.Size = new System.Drawing.Size(117, 31);
            this.dateTimePickerFridayStart.TabIndex = 24;
            // 
            // checkBoxEnableFriday
            // 
            this.checkBoxEnableFriday.AutoSize = true;
            this.checkBoxEnableFriday.Location = new System.Drawing.Point(133, 233);
            this.checkBoxEnableFriday.Name = "checkBoxEnableFriday";
            this.checkBoxEnableFriday.Size = new System.Drawing.Size(18, 17);
            this.checkBoxEnableFriday.TabIndex = 23;
            this.checkBoxEnableFriday.UseVisualStyleBackColor = true;
            // 
            // labelFriday
            // 
            this.labelFriday.AutoSize = true;
            this.labelFriday.Location = new System.Drawing.Point(46, 230);
            this.labelFriday.Name = "labelFriday";
            this.labelFriday.Size = new System.Drawing.Size(60, 25);
            this.labelFriday.TabIndex = 22;
            this.labelFriday.Text = "Friday";
            // 
            // dateTimePickerSaturdayEnd
            // 
            this.dateTimePickerSaturdayEnd.CustomFormat = "hh:mm tt";
            this.dateTimePickerSaturdayEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSaturdayEnd.Location = new System.Drawing.Point(326, 257);
            this.dateTimePickerSaturdayEnd.Name = "dateTimePickerSaturdayEnd";
            this.dateTimePickerSaturdayEnd.ShowUpDown = true;
            this.dateTimePickerSaturdayEnd.Size = new System.Drawing.Size(116, 31);
            this.dateTimePickerSaturdayEnd.TabIndex = 29;
            // 
            // dateTimePickerSaturdayStart
            // 
            this.dateTimePickerSaturdayStart.CustomFormat = "hh:mm tt";
            this.dateTimePickerSaturdayStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSaturdayStart.Location = new System.Drawing.Point(190, 257);
            this.dateTimePickerSaturdayStart.Name = "dateTimePickerSaturdayStart";
            this.dateTimePickerSaturdayStart.ShowUpDown = true;
            this.dateTimePickerSaturdayStart.Size = new System.Drawing.Size(117, 31);
            this.dateTimePickerSaturdayStart.TabIndex = 28;
            // 
            // checkBoxEnableSaturday
            // 
            this.checkBoxEnableSaturday.AutoSize = true;
            this.checkBoxEnableSaturday.Location = new System.Drawing.Point(133, 266);
            this.checkBoxEnableSaturday.Name = "checkBoxEnableSaturday";
            this.checkBoxEnableSaturday.Size = new System.Drawing.Size(18, 17);
            this.checkBoxEnableSaturday.TabIndex = 27;
            this.checkBoxEnableSaturday.UseVisualStyleBackColor = true;
            // 
            // labelSaturday
            // 
            this.labelSaturday.AutoSize = true;
            this.labelSaturday.Location = new System.Drawing.Point(28, 263);
            this.labelSaturday.Name = "labelSaturday";
            this.labelSaturday.Size = new System.Drawing.Size(82, 25);
            this.labelSaturday.TabIndex = 26;
            this.labelSaturday.Text = "Saturday";
            // 
            // dateTimePickerSundayEnd
            // 
            this.dateTimePickerSundayEnd.CustomFormat = "hh:mm tt";
            this.dateTimePickerSundayEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSundayEnd.Location = new System.Drawing.Point(326, 290);
            this.dateTimePickerSundayEnd.Name = "dateTimePickerSundayEnd";
            this.dateTimePickerSundayEnd.ShowUpDown = true;
            this.dateTimePickerSundayEnd.Size = new System.Drawing.Size(116, 31);
            this.dateTimePickerSundayEnd.TabIndex = 33;
            // 
            // dateTimePickerSundayStart
            // 
            this.dateTimePickerSundayStart.CustomFormat = "hh:mm tt";
            this.dateTimePickerSundayStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerSundayStart.Location = new System.Drawing.Point(190, 290);
            this.dateTimePickerSundayStart.Name = "dateTimePickerSundayStart";
            this.dateTimePickerSundayStart.ShowUpDown = true;
            this.dateTimePickerSundayStart.Size = new System.Drawing.Size(117, 31);
            this.dateTimePickerSundayStart.TabIndex = 32;
            // 
            // checkBoxEnableSunday
            // 
            this.checkBoxEnableSunday.AutoSize = true;
            this.checkBoxEnableSunday.Location = new System.Drawing.Point(133, 299);
            this.checkBoxEnableSunday.Name = "checkBoxEnableSunday";
            this.checkBoxEnableSunday.Size = new System.Drawing.Size(18, 17);
            this.checkBoxEnableSunday.TabIndex = 31;
            this.checkBoxEnableSunday.UseVisualStyleBackColor = true;
            // 
            // labelSunday
            // 
            this.labelSunday.AutoSize = true;
            this.labelSunday.Location = new System.Drawing.Point(28, 296);
            this.labelSunday.Name = "labelSunday";
            this.labelSunday.Size = new System.Drawing.Size(82, 25);
            this.labelSunday.TabIndex = 30;
            this.labelSunday.Text = "Saturday";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCancel.Location = new System.Drawing.Point(109, 352);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 28);
            this.buttonCancel.TabIndex = 34;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSave.Location = new System.Drawing.Point(278, 352);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 28);
            this.buttonSave.TabIndex = 35;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // RelaySetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 400);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.dateTimePickerSundayEnd);
            this.Controls.Add(this.dateTimePickerSundayStart);
            this.Controls.Add(this.checkBoxEnableSunday);
            this.Controls.Add(this.labelSunday);
            this.Controls.Add(this.dateTimePickerSaturdayEnd);
            this.Controls.Add(this.dateTimePickerSaturdayStart);
            this.Controls.Add(this.checkBoxEnableSaturday);
            this.Controls.Add(this.labelSaturday);
            this.Controls.Add(this.dateTimePickerFridayEnd);
            this.Controls.Add(this.dateTimePickerFridayStart);
            this.Controls.Add(this.checkBoxEnableFriday);
            this.Controls.Add(this.labelFriday);
            this.Controls.Add(this.dateTimePickerThursdayEnd);
            this.Controls.Add(this.dateTimePickerThursdayStart);
            this.Controls.Add(this.checkBoxEnableThursday);
            this.Controls.Add(this.labelThursday);
            this.Controls.Add(this.dateTimePickerWednesdayEnd);
            this.Controls.Add(this.dateTimePickerWednesdayStart);
            this.Controls.Add(this.checkBoxEnableWednesday);
            this.Controls.Add(this.labelWednesday);
            this.Controls.Add(this.dateTimePickerTuesdayEnd);
            this.Controls.Add(this.dateTimePickerTuesdayStart);
            this.Controls.Add(this.checkBoxEnableTuesday);
            this.Controls.Add(this.labelTuesday);
            this.Controls.Add(this.dateTimePickerMondayEnd);
            this.Controls.Add(this.dateTimePickerMondayStart);
            this.Controls.Add(this.checkBoxEnableMonday);
            this.Controls.Add(this.labelMonday);
            this.Controls.Add(this.labelEnd);
            this.Controls.Add(this.labelStart);
            this.Controls.Add(this.labelEnable);
            this.Controls.Add(this.checkBoxApplySchedule);
            this.Controls.Add(this.labelRelayName);
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "RelaySetupForm";
            this.ShowIcon = false;
            this.Text = "Relay Schedule";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRelayName;
        private System.Windows.Forms.CheckBox checkBoxApplySchedule;
        private System.Windows.Forms.Label labelEnable;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.Label labelMonday;
        private System.Windows.Forms.CheckBox checkBoxEnableMonday;
        private System.Windows.Forms.DateTimePicker dateTimePickerMondayStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerMondayEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerTuesdayEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerTuesdayStart;
        private System.Windows.Forms.CheckBox checkBoxEnableTuesday;
        private System.Windows.Forms.Label labelTuesday;
        private System.Windows.Forms.DateTimePicker dateTimePickerWednesdayEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerWednesdayStart;
        private System.Windows.Forms.CheckBox checkBoxEnableWednesday;
        private System.Windows.Forms.Label labelWednesday;
        private System.Windows.Forms.DateTimePicker dateTimePickerThursdayEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerThursdayStart;
        private System.Windows.Forms.CheckBox checkBoxEnableThursday;
        private System.Windows.Forms.Label labelThursday;
        private System.Windows.Forms.DateTimePicker dateTimePickerFridayEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerFridayStart;
        private System.Windows.Forms.CheckBox checkBoxEnableFriday;
        private System.Windows.Forms.Label labelFriday;
        private System.Windows.Forms.DateTimePicker dateTimePickerSaturdayEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerSaturdayStart;
        private System.Windows.Forms.CheckBox checkBoxEnableSaturday;
        private System.Windows.Forms.Label labelSaturday;
        private System.Windows.Forms.DateTimePicker dateTimePickerSundayEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerSundayStart;
        private System.Windows.Forms.CheckBox checkBoxEnableSunday;
        private System.Windows.Forms.Label labelSunday;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
    }
}