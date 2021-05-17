
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelFormTitle = new System.Windows.Forms.Label();
            this.labelDeviceAddress = new System.Windows.Forms.Label();
            this.textBoxDeviceAddress = new System.Windows.Forms.TextBox();
            this.buttonRefreshDeviceAddress = new System.Windows.Forms.Button();
            this.labelForceOnOff = new System.Windows.Forms.Label();
            this.labelRelayOn = new System.Windows.Forms.Label();
            this.labelRelay1Name = new System.Windows.Forms.Label();
            this.labelRelay2Name = new System.Windows.Forms.Label();
            this.labelRelay3Name = new System.Windows.Forms.Label();
            this.labelRelay4Name = new System.Windows.Forms.Label();
            this.checkBoxRelay1ForceToggle = new System.Windows.Forms.CheckBox();
            this.buttonRelay1Schedule = new System.Windows.Forms.Button();
            this.buttonRelay2Schedule = new System.Windows.Forms.Button();
            this.checkBoxRelay2ForceToggle = new System.Windows.Forms.CheckBox();
            this.buttonRelay3Schedule = new System.Windows.Forms.Button();
            this.checkBoxRelay3ForceToggle = new System.Windows.Forms.CheckBox();
            this.buttonRelay4Schedule = new System.Windows.Forms.Button();
            this.checkBoxRelay4ForceToggle = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemImport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTextBoxRelay1Name = new System.Windows.Forms.ToolStripTextBox();
            this.menuTextBoxRelay2Name = new System.Windows.Forms.ToolStripTextBox();
            this.menuTextBoxRelay3Name = new System.Windows.Forms.ToolStripTextBox();
            this.menuTextBoxRelay4Name = new System.Windows.Forms.ToolStripTextBox();
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
            this.pictureBoxLogo.Location = new System.Drawing.Point(35, 30);
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
            this.labelFormTitle.Location = new System.Drawing.Point(290, 40);
            this.labelFormTitle.Name = "labelFormTitle";
            this.labelFormTitle.Size = new System.Drawing.Size(133, 37);
            this.labelFormTitle.TabIndex = 1;
            this.labelFormTitle.Text = "Scheduler";
            // 
            // labelDeviceAddress
            // 
            this.labelDeviceAddress.AutoSize = true;
            this.labelDeviceAddress.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDeviceAddress.Location = new System.Drawing.Point(39, 101);
            this.labelDeviceAddress.Name = "labelDeviceAddress";
            this.labelDeviceAddress.Size = new System.Drawing.Size(114, 20);
            this.labelDeviceAddress.TabIndex = 2;
            this.labelDeviceAddress.Text = "Device Address:";
            // 
            // textBoxDeviceAddress
            // 
            this.textBoxDeviceAddress.Location = new System.Drawing.Point(179, 98);
            this.textBoxDeviceAddress.Name = "textBoxDeviceAddress";
            this.textBoxDeviceAddress.Size = new System.Drawing.Size(176, 27);
            this.textBoxDeviceAddress.TabIndex = 3;
            // 
            // buttonRefreshDeviceAddress
            // 
            this.buttonRefreshDeviceAddress.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRefreshDeviceAddress.Location = new System.Drawing.Point(369, 98);
            this.buttonRefreshDeviceAddress.Name = "buttonRefreshDeviceAddress";
            this.buttonRefreshDeviceAddress.Size = new System.Drawing.Size(102, 31);
            this.buttonRefreshDeviceAddress.TabIndex = 4;
            this.buttonRefreshDeviceAddress.Text = "Refresh";
            this.buttonRefreshDeviceAddress.UseVisualStyleBackColor = true;
            this.buttonRefreshDeviceAddress.Click += new System.EventHandler(this.buttonRefreshDeviceAddress_Click);
            // 
            // labelForceOnOff
            // 
            this.labelForceOnOff.AutoSize = true;
            this.labelForceOnOff.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelForceOnOff.Location = new System.Drawing.Point(127, 141);
            this.labelForceOnOff.Name = "labelForceOnOff";
            this.labelForceOnOff.Size = new System.Drawing.Size(95, 20);
            this.labelForceOnOff.TabIndex = 5;
            this.labelForceOnOff.Text = "Force On/Off";
            // 
            // labelRelayOn
            // 
            this.labelRelayOn.AutoSize = true;
            this.labelRelayOn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRelayOn.Location = new System.Drawing.Point(263, 141);
            this.labelRelayOn.Name = "labelRelayOn";
            this.labelRelayOn.Size = new System.Drawing.Size(49, 20);
            this.labelRelayOn.TabIndex = 6;
            this.labelRelayOn.Text = "Status";
            // 
            // labelRelay1Name
            // 
            this.labelRelay1Name.AutoSize = true;
            this.labelRelay1Name.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRelay1Name.Location = new System.Drawing.Point(25, 174);
            this.labelRelay1Name.Name = "labelRelay1Name";
            this.labelRelay1Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelRelay1Name.Size = new System.Drawing.Size(56, 20);
            this.labelRelay1Name.TabIndex = 7;
            this.labelRelay1Name.Text = "Relay1:";
            this.labelRelay1Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRelay2Name
            // 
            this.labelRelay2Name.AutoSize = true;
            this.labelRelay2Name.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRelay2Name.Location = new System.Drawing.Point(25, 216);
            this.labelRelay2Name.Name = "labelRelay2Name";
            this.labelRelay2Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelRelay2Name.Size = new System.Drawing.Size(60, 20);
            this.labelRelay2Name.TabIndex = 8;
            this.labelRelay2Name.Text = "Relay 2:";
            this.labelRelay2Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRelay3Name
            // 
            this.labelRelay3Name.AutoSize = true;
            this.labelRelay3Name.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRelay3Name.Location = new System.Drawing.Point(25, 256);
            this.labelRelay3Name.Name = "labelRelay3Name";
            this.labelRelay3Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelRelay3Name.Size = new System.Drawing.Size(60, 20);
            this.labelRelay3Name.TabIndex = 9;
            this.labelRelay3Name.Text = "Relay 3:";
            this.labelRelay3Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRelay4Name
            // 
            this.labelRelay4Name.AutoSize = true;
            this.labelRelay4Name.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRelay4Name.Location = new System.Drawing.Point(25, 296);
            this.labelRelay4Name.Name = "labelRelay4Name";
            this.labelRelay4Name.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelRelay4Name.Size = new System.Drawing.Size(60, 20);
            this.labelRelay4Name.TabIndex = 10;
            this.labelRelay4Name.Text = "Relay 4:";
            this.labelRelay4Name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxRelay1ForceToggle
            // 
            this.checkBoxRelay1ForceToggle.AutoSize = true;
            this.checkBoxRelay1ForceToggle.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxRelay1ForceToggle.Location = new System.Drawing.Point(177, 179);
            this.checkBoxRelay1ForceToggle.Name = "checkBoxRelay1ForceToggle";
            this.checkBoxRelay1ForceToggle.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRelay1ForceToggle.TabIndex = 11;
            this.checkBoxRelay1ForceToggle.ThreeState = true;
            this.checkBoxRelay1ForceToggle.UseVisualStyleBackColor = true;
            this.checkBoxRelay1ForceToggle.CheckStateChanged += new System.EventHandler(this.checkBoxRelay1ForceOn_CheckedStateChanged);
            // 
            // buttonRelay1Schedule
            // 
            this.buttonRelay1Schedule.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRelay1Schedule.Location = new System.Drawing.Point(353, 171);
            this.buttonRelay1Schedule.Name = "buttonRelay1Schedule";
            this.buttonRelay1Schedule.Size = new System.Drawing.Size(121, 31);
            this.buttonRelay1Schedule.TabIndex = 13;
            this.buttonRelay1Schedule.Text = "Schedule...";
            this.buttonRelay1Schedule.UseVisualStyleBackColor = true;
            this.buttonRelay1Schedule.Click += new System.EventHandler(this.buttonRelay1Schedule_Click);
            // 
            // buttonRelay2Schedule
            // 
            this.buttonRelay2Schedule.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRelay2Schedule.Location = new System.Drawing.Point(353, 213);
            this.buttonRelay2Schedule.Name = "buttonRelay2Schedule";
            this.buttonRelay2Schedule.Size = new System.Drawing.Size(121, 31);
            this.buttonRelay2Schedule.TabIndex = 16;
            this.buttonRelay2Schedule.Text = "Schedule...";
            this.buttonRelay2Schedule.UseVisualStyleBackColor = true;
            this.buttonRelay2Schedule.Click += new System.EventHandler(this.buttonRelay2Schedule_Click);
            // 
            // checkBoxRelay2ForceToggle
            // 
            this.checkBoxRelay2ForceToggle.AutoSize = true;
            this.checkBoxRelay2ForceToggle.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxRelay2ForceToggle.Location = new System.Drawing.Point(177, 221);
            this.checkBoxRelay2ForceToggle.Name = "checkBoxRelay2ForceToggle";
            this.checkBoxRelay2ForceToggle.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRelay2ForceToggle.TabIndex = 14;
            this.checkBoxRelay2ForceToggle.ThreeState = true;
            this.checkBoxRelay2ForceToggle.UseVisualStyleBackColor = true;
            this.checkBoxRelay2ForceToggle.CheckStateChanged += new System.EventHandler(this.checkBoxRelay2ForceOn_CheckedStateChanged);
            // 
            // buttonRelay3Schedule
            // 
            this.buttonRelay3Schedule.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRelay3Schedule.Location = new System.Drawing.Point(353, 253);
            this.buttonRelay3Schedule.Name = "buttonRelay3Schedule";
            this.buttonRelay3Schedule.Size = new System.Drawing.Size(121, 31);
            this.buttonRelay3Schedule.TabIndex = 19;
            this.buttonRelay3Schedule.Text = "Schedule...";
            this.buttonRelay3Schedule.UseVisualStyleBackColor = true;
            this.buttonRelay3Schedule.Click += new System.EventHandler(this.buttonRelay3Schedule_Click);
            // 
            // checkBoxRelay3ForceToggle
            // 
            this.checkBoxRelay3ForceToggle.AutoSize = true;
            this.checkBoxRelay3ForceToggle.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxRelay3ForceToggle.Location = new System.Drawing.Point(177, 261);
            this.checkBoxRelay3ForceToggle.Name = "checkBoxRelay3ForceToggle";
            this.checkBoxRelay3ForceToggle.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRelay3ForceToggle.TabIndex = 17;
            this.checkBoxRelay3ForceToggle.ThreeState = true;
            this.checkBoxRelay3ForceToggle.UseVisualStyleBackColor = true;
            this.checkBoxRelay3ForceToggle.CheckStateChanged += new System.EventHandler(this.checkBoxRelay3ForceOn_CheckedStateChanged);
            // 
            // buttonRelay4Schedule
            // 
            this.buttonRelay4Schedule.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRelay4Schedule.Location = new System.Drawing.Point(353, 293);
            this.buttonRelay4Schedule.Name = "buttonRelay4Schedule";
            this.buttonRelay4Schedule.Size = new System.Drawing.Size(121, 31);
            this.buttonRelay4Schedule.TabIndex = 22;
            this.buttonRelay4Schedule.Text = "Schedule...";
            this.buttonRelay4Schedule.UseVisualStyleBackColor = true;
            this.buttonRelay4Schedule.Click += new System.EventHandler(this.buttonRelay4Schedule_Click);
            // 
            // checkBoxRelay4ForceToggle
            // 
            this.checkBoxRelay4ForceToggle.AutoSize = true;
            this.checkBoxRelay4ForceToggle.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxRelay4ForceToggle.Location = new System.Drawing.Point(177, 301);
            this.checkBoxRelay4ForceToggle.Name = "checkBoxRelay4ForceToggle";
            this.checkBoxRelay4ForceToggle.Size = new System.Drawing.Size(15, 14);
            this.checkBoxRelay4ForceToggle.TabIndex = 20;
            this.checkBoxRelay4ForceToggle.ThreeState = true;
            this.checkBoxRelay4ForceToggle.UseVisualStyleBackColor = true;
            this.checkBoxRelay4ForceToggle.CheckedChanged += new System.EventHandler(this.checkBoxRelay4ForceOn_CheckedStateChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemEdit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(508, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemImport,
            this.menuItemExport,
            this.menuItemClose});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(37, 20);
            this.menuItemFile.Text = "File";
            // 
            // menuItemImport
            // 
            this.menuItemImport.Name = "menuItemImport";
            this.menuItemImport.Size = new System.Drawing.Size(110, 22);
            this.menuItemImport.Text = "Import";
            // 
            // menuItemExport
            // 
            this.menuItemExport.Name = "menuItemExport";
            this.menuItemExport.Size = new System.Drawing.Size(110, 22);
            this.menuItemExport.Text = "Export";
            // 
            // menuItemClose
            // 
            this.menuItemClose.Name = "menuItemClose";
            this.menuItemClose.Size = new System.Drawing.Size(110, 22);
            this.menuItemClose.Text = "Close";
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTextBoxRelay1Name,
            this.menuTextBoxRelay2Name,
            this.menuTextBoxRelay3Name,
            this.menuTextBoxRelay4Name});
            this.menuItemEdit.Name = "menuItemEdit";
            this.menuItemEdit.Size = new System.Drawing.Size(39, 20);
            this.menuItemEdit.Text = "Edit";
            // 
            // menuTextBoxRelay1Name
            // 
            this.menuTextBoxRelay1Name.Name = "menuTextBoxRelay1Name";
            this.menuTextBoxRelay1Name.Size = new System.Drawing.Size(100, 23);
            this.menuTextBoxRelay1Name.Text = "Relay1";
            // 
            // menuTextBoxRelay2Name
            // 
            this.menuTextBoxRelay2Name.Name = "menuTextBoxRelay2Name";
            this.menuTextBoxRelay2Name.Size = new System.Drawing.Size(100, 23);
            this.menuTextBoxRelay2Name.Text = "Relay2";
            // 
            // menuTextBoxRelay3Name
            // 
            this.menuTextBoxRelay3Name.Name = "menuTextBoxRelay3Name";
            this.menuTextBoxRelay3Name.Size = new System.Drawing.Size(100, 23);
            this.menuTextBoxRelay3Name.Text = "Relay3";
            // 
            // menuTextBoxRelay4Name
            // 
            this.menuTextBoxRelay4Name.Name = "menuTextBoxRelay4Name";
            this.menuTextBoxRelay4Name.Size = new System.Drawing.Size(100, 23);
            this.menuTextBoxRelay4Name.Text = "Relay4";
            // 
            // buttonRelay1Status
            // 
            this.buttonRelay1Status.Enabled = false;
            this.buttonRelay1Status.Location = new System.Drawing.Point(261, 171);
            this.buttonRelay1Status.Name = "buttonRelay1Status";
            this.buttonRelay1Status.Size = new System.Drawing.Size(56, 31);
            this.buttonRelay1Status.TabIndex = 24;
            this.buttonRelay1Status.Text = "OFF";
            this.buttonRelay1Status.UseVisualStyleBackColor = true;
            // 
            // buttonRelay2Status
            // 
            this.buttonRelay2Status.Enabled = false;
            this.buttonRelay2Status.Location = new System.Drawing.Point(261, 213);
            this.buttonRelay2Status.Name = "buttonRelay2Status";
            this.buttonRelay2Status.Size = new System.Drawing.Size(56, 31);
            this.buttonRelay2Status.TabIndex = 25;
            this.buttonRelay2Status.Text = "OFF";
            this.buttonRelay2Status.UseVisualStyleBackColor = true;
            // 
            // buttonRelay3Status
            // 
            this.buttonRelay3Status.Enabled = false;
            this.buttonRelay3Status.Location = new System.Drawing.Point(261, 253);
            this.buttonRelay3Status.Name = "buttonRelay3Status";
            this.buttonRelay3Status.Size = new System.Drawing.Size(56, 31);
            this.buttonRelay3Status.TabIndex = 26;
            this.buttonRelay3Status.Text = "OFF";
            this.buttonRelay3Status.UseVisualStyleBackColor = true;
            // 
            // buttonRelay4Status
            // 
            this.buttonRelay4Status.Enabled = false;
            this.buttonRelay4Status.Location = new System.Drawing.Point(261, 293);
            this.buttonRelay4Status.Name = "buttonRelay4Status";
            this.buttonRelay4Status.Size = new System.Drawing.Size(56, 31);
            this.buttonRelay4Status.TabIndex = 27;
            this.buttonRelay4Status.Text = "OFF";
            this.buttonRelay4Status.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(508, 346);
            this.Controls.Add(this.buttonRelay4Status);
            this.Controls.Add(this.buttonRelay3Status);
            this.Controls.Add(this.buttonRelay2Status);
            this.Controls.Add(this.buttonRelay1Status);
            this.Controls.Add(this.buttonRelay4Schedule);
            this.Controls.Add(this.checkBoxRelay4ForceToggle);
            this.Controls.Add(this.buttonRelay3Schedule);
            this.Controls.Add(this.checkBoxRelay3ForceToggle);
            this.Controls.Add(this.buttonRelay2Schedule);
            this.Controls.Add(this.checkBoxRelay2ForceToggle);
            this.Controls.Add(this.buttonRelay1Schedule);
            this.Controls.Add(this.checkBoxRelay1ForceToggle);
            this.Controls.Add(this.labelRelay4Name);
            this.Controls.Add(this.labelRelay3Name);
            this.Controls.Add(this.labelRelay2Name);
            this.Controls.Add(this.labelRelay1Name);
            this.Controls.Add(this.labelRelayOn);
            this.Controls.Add(this.labelForceOnOff);
            this.Controls.Add(this.buttonRefreshDeviceAddress);
            this.Controls.Add(this.textBoxDeviceAddress);
            this.Controls.Add(this.labelDeviceAddress);
            this.Controls.Add(this.labelFormTitle);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Label labelForceOnOff;
        private System.Windows.Forms.Label labelRelayOn;
        private System.Windows.Forms.Label labelRelay1Name;
        private System.Windows.Forms.Label labelRelay2Name;
        private System.Windows.Forms.Label labelRelay3Name;
        private System.Windows.Forms.Label labelRelay4Name;
        private System.Windows.Forms.CheckBox checkBoxRelay1ForceToggle;
        private System.Windows.Forms.Button buttonRelay1Schedule;
        private System.Windows.Forms.Button buttonRelay2Schedule;
        private System.Windows.Forms.CheckBox checkBoxRelay2ForceToggle;
        private System.Windows.Forms.Button buttonRelay3Schedule;
        private System.Windows.Forms.CheckBox checkBoxRelay3ForceToggle;
        private System.Windows.Forms.Button buttonRelay4Schedule;
        private System.Windows.Forms.CheckBox checkBoxRelay4ForceToggle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemClose;
        private System.Windows.Forms.ToolStripMenuItem menuItemEdit;
        private System.Windows.Forms.Button buttonRelay1Status;
        private System.Windows.Forms.Button buttonRelay2Status;
        private System.Windows.Forms.Button buttonRelay3Status;
        private System.Windows.Forms.Button buttonRelay4Status;
        private System.Windows.Forms.ToolStripTextBox menuTextBoxRelay1Name;
        private System.Windows.Forms.ToolStripTextBox menuTextBoxRelay2Name;
        private System.Windows.Forms.ToolStripTextBox menuTextBoxRelay3Name;
        private System.Windows.Forms.ToolStripTextBox menuTextBoxRelay4Name;
        private System.Windows.Forms.Button buttonRefreshDeviceAddress;
        private System.Windows.Forms.ToolStripMenuItem menuItemImport;
        private System.Windows.Forms.ToolStripMenuItem menuItemExport;
    }
}

