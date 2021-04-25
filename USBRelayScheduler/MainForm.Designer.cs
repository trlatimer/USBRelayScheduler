
namespace USBRelayScheduler
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelFormTitle = new System.Windows.Forms.Label();
            this.labelDeviceAddress = new System.Windows.Forms.Label();
            this.textBoxDeviceAddress = new System.Windows.Forms.TextBox();
            this.buttonChangeDeviceAddress = new System.Windows.Forms.Button();
            this.labelForceOn = new System.Windows.Forms.Label();
            this.labelRelayOn = new System.Windows.Forms.Label();
            this.labelRelay1Name = new System.Windows.Forms.Label();
            this.labelRelay2Name = new System.Windows.Forms.Label();
            this.labelRelay3Name = new System.Windows.Forms.Label();
            this.relayLabel4Name = new System.Windows.Forms.Label();
            this.checkBoxRelay1ForceOn = new System.Windows.Forms.CheckBox();
            this.buttonRelay1Schedule = new System.Windows.Forms.Button();
            this.buttonRelay2Schedule = new System.Windows.Forms.Button();
            this.checkBoxRelay2ForceOn = new System.Windows.Forms.CheckBox();
            this.buttonRelay3Schedule = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.buttonRelay4Schedule = new System.Windows.Forms.Button();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonRelay1Status = new System.Windows.Forms.Button();
            this.buttonRelay2Status = new System.Windows.Forms.Button();
            this.buttonRelay3Status = new System.Windows.Forms.Button();
            this.buttonRelay4Status = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxLogo.Image = global::USBRelayScheduler.Resources.Resource.CTS_Logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(14, 39);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(228, 55);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // labelFormTitle
            // 
            this.labelFormTitle.AutoSize = true;
            this.labelFormTitle.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelFormTitle.Location = new System.Drawing.Point(257, 45);
            this.labelFormTitle.Name = "labelFormTitle";
            this.labelFormTitle.Size = new System.Drawing.Size(318, 45);
            this.labelFormTitle.TabIndex = 1;
            this.labelFormTitle.Text = "USB Relay Scheduler";
            // 
            // labelDeviceAddress
            // 
            this.labelDeviceAddress.AutoSize = true;
            this.labelDeviceAddress.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDeviceAddress.Location = new System.Drawing.Point(67, 116);
            this.labelDeviceAddress.Name = "labelDeviceAddress";
            this.labelDeviceAddress.Size = new System.Drawing.Size(138, 25);
            this.labelDeviceAddress.TabIndex = 2;
            this.labelDeviceAddress.Text = "Device Address:";
            // 
            // textBoxDeviceAddress
            // 
            this.textBoxDeviceAddress.Location = new System.Drawing.Point(224, 113);
            this.textBoxDeviceAddress.Name = "textBoxDeviceAddress";
            this.textBoxDeviceAddress.Size = new System.Drawing.Size(176, 31);
            this.textBoxDeviceAddress.TabIndex = 3;
            // 
            // buttonChangeDeviceAddress
            // 
            this.buttonChangeDeviceAddress.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonChangeDeviceAddress.Location = new System.Drawing.Point(416, 113);
            this.buttonChangeDeviceAddress.Name = "buttonChangeDeviceAddress";
            this.buttonChangeDeviceAddress.Size = new System.Drawing.Size(102, 35);
            this.buttonChangeDeviceAddress.TabIndex = 4;
            this.buttonChangeDeviceAddress.Text = "Change";
            this.buttonChangeDeviceAddress.UseVisualStyleBackColor = true;
            this.buttonChangeDeviceAddress.Click += new System.EventHandler(this.buttonChangeDeviceAddress_Click);
            // 
            // labelForceOn
            // 
            this.labelForceOn.AutoSize = true;
            this.labelForceOn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelForceOn.Location = new System.Drawing.Point(190, 154);
            this.labelForceOn.Name = "labelForceOn";
            this.labelForceOn.Size = new System.Drawing.Size(84, 25);
            this.labelForceOn.TabIndex = 5;
            this.labelForceOn.Text = "Force On";
            // 
            // labelRelayOn
            // 
            this.labelRelayOn.AutoSize = true;
            this.labelRelayOn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRelayOn.Location = new System.Drawing.Point(298, 154);
            this.labelRelayOn.Name = "labelRelayOn";
            this.labelRelayOn.Size = new System.Drawing.Size(60, 25);
            this.labelRelayOn.TabIndex = 6;
            this.labelRelayOn.Text = "Status";
            // 
            // labelRelay1Name
            // 
            this.labelRelay1Name.AutoSize = true;
            this.labelRelay1Name.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRelay1Name.Location = new System.Drawing.Point(114, 187);
            this.labelRelay1Name.Name = "labelRelay1Name";
            this.labelRelay1Name.Size = new System.Drawing.Size(72, 25);
            this.labelRelay1Name.TabIndex = 7;
            this.labelRelay1Name.Text = "Relay 1:";
            this.labelRelay1Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRelay2Name
            // 
            this.labelRelay2Name.AutoSize = true;
            this.labelRelay2Name.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRelay2Name.Location = new System.Drawing.Point(114, 229);
            this.labelRelay2Name.Name = "labelRelay2Name";
            this.labelRelay2Name.Size = new System.Drawing.Size(72, 25);
            this.labelRelay2Name.TabIndex = 8;
            this.labelRelay2Name.Text = "Relay 2:";
            this.labelRelay2Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRelay3Name
            // 
            this.labelRelay3Name.AutoSize = true;
            this.labelRelay3Name.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRelay3Name.Location = new System.Drawing.Point(114, 269);
            this.labelRelay3Name.Name = "labelRelay3Name";
            this.labelRelay3Name.Size = new System.Drawing.Size(72, 25);
            this.labelRelay3Name.TabIndex = 9;
            this.labelRelay3Name.Text = "Relay 3:";
            this.labelRelay3Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // relayLabel4Name
            // 
            this.relayLabel4Name.AutoSize = true;
            this.relayLabel4Name.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.relayLabel4Name.Location = new System.Drawing.Point(114, 309);
            this.relayLabel4Name.Name = "relayLabel4Name";
            this.relayLabel4Name.Size = new System.Drawing.Size(72, 25);
            this.relayLabel4Name.TabIndex = 10;
            this.relayLabel4Name.Text = "Relay 4:";
            this.relayLabel4Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxRelay1ForceOn
            // 
            this.checkBoxRelay1ForceOn.AutoSize = true;
            this.checkBoxRelay1ForceOn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxRelay1ForceOn.Location = new System.Drawing.Point(224, 192);
            this.checkBoxRelay1ForceOn.Name = "checkBoxRelay1ForceOn";
            this.checkBoxRelay1ForceOn.Size = new System.Drawing.Size(18, 17);
            this.checkBoxRelay1ForceOn.TabIndex = 11;
            this.checkBoxRelay1ForceOn.UseVisualStyleBackColor = true;
            this.checkBoxRelay1ForceOn.CheckedChanged += new System.EventHandler(this.checkBoxRelay1ForceOn_CheckedChanged);
            // 
            // buttonRelay1Schedule
            // 
            this.buttonRelay1Schedule.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRelay1Schedule.Location = new System.Drawing.Point(384, 184);
            this.buttonRelay1Schedule.Name = "buttonRelay1Schedule";
            this.buttonRelay1Schedule.Size = new System.Drawing.Size(121, 31);
            this.buttonRelay1Schedule.TabIndex = 13;
            this.buttonRelay1Schedule.Text = "Schedule...";
            this.buttonRelay1Schedule.UseVisualStyleBackColor = true;
            // 
            // buttonRelay2Schedule
            // 
            this.buttonRelay2Schedule.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRelay2Schedule.Location = new System.Drawing.Point(384, 226);
            this.buttonRelay2Schedule.Name = "buttonRelay2Schedule";
            this.buttonRelay2Schedule.Size = new System.Drawing.Size(121, 31);
            this.buttonRelay2Schedule.TabIndex = 16;
            this.buttonRelay2Schedule.Text = "Schedule...";
            this.buttonRelay2Schedule.UseVisualStyleBackColor = true;
            // 
            // checkBoxRelay2ForceOn
            // 
            this.checkBoxRelay2ForceOn.AutoSize = true;
            this.checkBoxRelay2ForceOn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxRelay2ForceOn.Location = new System.Drawing.Point(224, 234);
            this.checkBoxRelay2ForceOn.Name = "checkBoxRelay2ForceOn";
            this.checkBoxRelay2ForceOn.Size = new System.Drawing.Size(18, 17);
            this.checkBoxRelay2ForceOn.TabIndex = 14;
            this.checkBoxRelay2ForceOn.UseVisualStyleBackColor = true;
            this.checkBoxRelay2ForceOn.CheckedChanged += new System.EventHandler(this.checkBoxRelay2ForceOn_CheckedChanged);
            // 
            // buttonRelay3Schedule
            // 
            this.buttonRelay3Schedule.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRelay3Schedule.Location = new System.Drawing.Point(384, 266);
            this.buttonRelay3Schedule.Name = "buttonRelay3Schedule";
            this.buttonRelay3Schedule.Size = new System.Drawing.Size(121, 31);
            this.buttonRelay3Schedule.TabIndex = 19;
            this.buttonRelay3Schedule.Text = "Schedule...";
            this.buttonRelay3Schedule.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox2.Location = new System.Drawing.Point(224, 274);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(18, 17);
            this.checkBox2.TabIndex = 17;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // buttonRelay4Schedule
            // 
            this.buttonRelay4Schedule.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRelay4Schedule.Location = new System.Drawing.Point(384, 306);
            this.buttonRelay4Schedule.Name = "buttonRelay4Schedule";
            this.buttonRelay4Schedule.Size = new System.Drawing.Size(121, 31);
            this.buttonRelay4Schedule.TabIndex = 22;
            this.buttonRelay4Schedule.Text = "Schedule...";
            this.buttonRelay4Schedule.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox4.Location = new System.Drawing.Point(224, 314);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(18, 17);
            this.checkBox4.TabIndex = 20;
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemEdit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(593, 28);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemClose});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(46, 24);
            this.menuItemFile.Text = "File";
            // 
            // menuItemClose
            // 
            this.menuItemClose.Name = "menuItemClose";
            this.menuItemClose.Size = new System.Drawing.Size(128, 26);
            this.menuItemClose.Text = "Close";
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.Name = "menuItemEdit";
            this.menuItemEdit.Size = new System.Drawing.Size(49, 24);
            this.menuItemEdit.Text = "Edit";
            // 
            // buttonRelay1Status
            // 
            this.buttonRelay1Status.Enabled = false;
            this.buttonRelay1Status.Location = new System.Drawing.Point(300, 184);
            this.buttonRelay1Status.Name = "buttonRelay1Status";
            this.buttonRelay1Status.Size = new System.Drawing.Size(56, 31);
            this.buttonRelay1Status.TabIndex = 24;
            this.buttonRelay1Status.Text = "OFF";
            this.buttonRelay1Status.UseVisualStyleBackColor = true;
            // 
            // buttonRelay2Status
            // 
            this.buttonRelay2Status.Enabled = false;
            this.buttonRelay2Status.Location = new System.Drawing.Point(300, 226);
            this.buttonRelay2Status.Name = "buttonRelay2Status";
            this.buttonRelay2Status.Size = new System.Drawing.Size(56, 31);
            this.buttonRelay2Status.TabIndex = 25;
            this.buttonRelay2Status.Text = "OFF";
            this.buttonRelay2Status.UseVisualStyleBackColor = true;
            // 
            // buttonRelay3Status
            // 
            this.buttonRelay3Status.Enabled = false;
            this.buttonRelay3Status.Location = new System.Drawing.Point(300, 266);
            this.buttonRelay3Status.Name = "buttonRelay3Status";
            this.buttonRelay3Status.Size = new System.Drawing.Size(56, 31);
            this.buttonRelay3Status.TabIndex = 26;
            this.buttonRelay3Status.Text = "OFF";
            this.buttonRelay3Status.UseVisualStyleBackColor = true;
            // 
            // buttonRelay4Status
            // 
            this.buttonRelay4Status.Enabled = false;
            this.buttonRelay4Status.Location = new System.Drawing.Point(300, 306);
            this.buttonRelay4Status.Name = "buttonRelay4Status";
            this.buttonRelay4Status.Size = new System.Drawing.Size(56, 31);
            this.buttonRelay4Status.TabIndex = 27;
            this.buttonRelay4Status.Text = "OFF";
            this.buttonRelay4Status.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 361);
            this.Controls.Add(this.buttonRelay4Status);
            this.Controls.Add(this.buttonRelay3Status);
            this.Controls.Add(this.buttonRelay2Status);
            this.Controls.Add(this.buttonRelay1Status);
            this.Controls.Add(this.buttonRelay4Schedule);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.buttonRelay3Schedule);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.buttonRelay2Schedule);
            this.Controls.Add(this.checkBoxRelay2ForceOn);
            this.Controls.Add(this.buttonRelay1Schedule);
            this.Controls.Add(this.checkBoxRelay1ForceOn);
            this.Controls.Add(this.relayLabel4Name);
            this.Controls.Add(this.labelRelay3Name);
            this.Controls.Add(this.labelRelay2Name);
            this.Controls.Add(this.labelRelay1Name);
            this.Controls.Add(this.labelRelayOn);
            this.Controls.Add(this.labelForceOn);
            this.Controls.Add(this.buttonChangeDeviceAddress);
            this.Controls.Add(this.textBoxDeviceAddress);
            this.Controls.Add(this.labelDeviceAddress);
            this.Controls.Add(this.labelFormTitle);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "CTS Relay Scheduler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelFormTitle;
        private System.Windows.Forms.Label labelDeviceAddress;
        private System.Windows.Forms.TextBox textBoxDeviceAddress;
        private System.Windows.Forms.Button buttonChangeDeviceAddress;
        private System.Windows.Forms.Label labelForceOn;
        private System.Windows.Forms.Label labelRelayOn;
        private System.Windows.Forms.Label labelRelay1Name;
        private System.Windows.Forms.Label labelRelay2Name;
        private System.Windows.Forms.Label labelRelay3Name;
        private System.Windows.Forms.Label relayLabel4Name;
        private System.Windows.Forms.CheckBox checkBoxRelay1ForceOn;
        private System.Windows.Forms.Button buttonRelay1Schedule;
        private System.Windows.Forms.Button buttonRelay2Schedule;
        private System.Windows.Forms.CheckBox checkBoxRelay2ForceOn;
        private System.Windows.Forms.Button buttonRelay3Schedule;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button buttonRelay4Schedule;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemClose;
        private System.Windows.Forms.ToolStripMenuItem menuItemEdit;
        private System.Windows.Forms.Button buttonRelay1Status;
        private System.Windows.Forms.Button buttonRelay2Status;
        private System.Windows.Forms.Button buttonRelay3Status;
        private System.Windows.Forms.Button buttonRelay4Status;
    }
}

