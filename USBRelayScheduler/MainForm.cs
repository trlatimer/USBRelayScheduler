using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using USBRelayScheduler.Resources;

namespace USBRelayScheduler
{
    public partial class MainForm : Form
    {
        private TctecUSBDevice relayDevice;
        private System.Timers.Timer relayStatusTimer;

        public MainForm()
        {
            InitializeComponent();
            relayDevice = new TctecUSBDevice();
            ResetRelays();
            PopulateForm();
        }

        private void PopulateForm()
        {
            textBoxDeviceAddress.Text = relayDevice.GetSerialNumber();
        }

        private void ResetRelays()
        {
            if (relayDevice.GetSerialNumber() == null) return;
            for (int i = 0; i <= 3; i++)
            {
                relayDevice.SetRelay(i, false);
            }
        }

        private void ToggleRelayForce(int relay, bool forceOn)
        {
            if (forceOn)
            {
                Settings.Default.RelaySchedules[relay].enabled = false;
                Settings.Default.Save();
                if (!relayDevice.SetRelay(relay, true))
                {
                    ResetForceOn(relay);
                }
            }
            else
            {
                Settings.Default.RelaySchedules[relay].enabled = true;
                Settings.Default.Save();
                relayDevice.CheckRelaySchedules();
            }
        }

        private void ResetForceOn(int relay)
        {
            Settings.Default.RelaySchedules[relay].enabled = true;
            Settings.Default.Save();
            if (relay == 0) { checkBoxRelay1ForceOn.Checked = false; }
            else if (relay == 1) { checkBoxRelay2ForceOn.Checked = false; }
            else if (relay == 2) { checkBoxRelay3ForceOn.Checked = false; }
            else if (relay == 3) { checkBoxRelay4ForceOn.Checked = false; }
        }

        private void HandleRelayNamechange(int relayIndex)
        {
            if (relayIndex == 0) { Settings.Default.Relay1Name = menuTextBoxRelay1Name.Text; }
            else if (relayIndex == 1) { Settings.Default.Relay2Name = menuTextBoxRelay2Name.Text; }
            else if (relayIndex == 2) { Settings.Default.Relay3Name = menuTextBoxRelay3Name.Text; }
            else if (relayIndex == 3) { Settings.Default.Relay4Name = menuTextBoxRelay4Name.Text; }

            Settings.Default.Save();

            labelRelay1Name.Text = Settings.Default.Relay1Name;
            labelRelay2Name.Text = Settings.Default.Relay2Name;
            labelRelay3Name.Text = Settings.Default.Relay3Name;
            labelRelay4Name.Text = Settings.Default.Relay4Name;
        }

        private void CheckDeviceStatus(Object source, System.Timers.ElapsedEventArgs e)
        {
            if (relayDevice == null) { return; }
            relayStatusTimer.Elapsed -= CheckDeviceStatus;
            
            try
            {
                if (InvokeRequired && !this.IsDisposed && !this.Disposing)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        if (relayDevice.GetRelayState(0))
                        {
                            buttonRelay1Status.Text = "ON";
                            buttonRelay1Status.BackColor = Color.LimeGreen;
                        }
                        else
                        {
                            buttonRelay1Status.Text = "OFF";
                            buttonRelay1Status.BackColor = Color.Gray;
                        }

                        if (relayDevice.GetRelayState(1))
                        {
                            buttonRelay2Status.Text = "ON";
                            buttonRelay2Status.BackColor = Color.LimeGreen;
                        }
                        else
                        {
                            buttonRelay2Status.Text = "OFF";
                            buttonRelay2Status.BackColor = Color.Gray;
                        }

                        if (relayDevice.GetRelayState(2))
                        {
                            buttonRelay3Status.Text = "ON";
                            buttonRelay3Status.BackColor = Color.LimeGreen;
                        }
                        else
                        {
                            buttonRelay3Status.Text = "OFF";
                            buttonRelay3Status.BackColor = Color.Gray;
                        }

                        if (relayDevice.GetRelayState(3))
                        {
                            buttonRelay4Status.Text = "ON";
                            buttonRelay4Status.BackColor = Color.LimeGreen;
                        }
                        else
                        {
                            buttonRelay4Status.Text = "OFF";
                            buttonRelay4Status.BackColor = Color.Gray;
                        }
                    }));
                }
            }
            catch (ObjectDisposedException ex)
            {
                relayStatusTimer.Stop();
            }

            relayStatusTimer.Elapsed += CheckDeviceStatus;
        }

        private void RefreshDevice()
        {
            relayStatusTimer.Elapsed -= CheckDeviceStatus;
            relayDevice = null;
            relayDevice = new TctecUSBDevice();
            textBoxDeviceAddress.Text = relayDevice.GetSerialNumber();
            relayStatusTimer.Elapsed += CheckDeviceStatus;
        }

        private void buttonRefreshDeviceAddress_Click(object sender, EventArgs e)
        {
            RefreshDevice();
        }

        private void checkBoxRelay1ForceOn_CheckedChanged(object sender, EventArgs e)
        {
            ToggleRelayForce(0, checkBoxRelay1ForceOn.Checked);
        }

        private void checkBoxRelay2ForceOn_CheckedChanged(object sender, EventArgs e)
        {
            ToggleRelayForce(1, checkBoxRelay2ForceOn.Checked);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ToggleRelayForce(2, checkBoxRelay3ForceOn.Checked);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            ToggleRelayForce(3, checkBoxRelay4ForceOn.Checked);
        }

        private void MainForm_FormClosing(object sender, EventArgs e)
        {
            relayStatusTimer.Stop();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            relayStatusTimer = new System.Timers.Timer(10);
            relayStatusTimer.Elapsed += CheckDeviceStatus;
            relayStatusTimer.Start();

            labelRelay1Name.Text = Settings.Default.Relay1Name + ":";
            labelRelay2Name.Text = Settings.Default.Relay2Name + ":";
            labelRelay3Name.Text = Settings.Default.Relay3Name + ":";
            labelRelay4Name.Text = Settings.Default.Relay4Name + ":";

            menuTextBoxRelay1Name.Text = Settings.Default.Relay1Name;
            menuTextBoxRelay2Name.Text = Settings.Default.Relay2Name;
            menuTextBoxRelay3Name.Text = Settings.Default.Relay3Name;
            menuTextBoxRelay4Name.Text = Settings.Default.Relay4Name;

            menuTextBoxRelay1Name.LostFocus += MenuTextBoxRelay1Name_LostFocus;
            menuTextBoxRelay2Name.LostFocus += MenuTextBoxRelay2Name_LostFocus;
            menuTextBoxRelay3Name.LostFocus += MenuTextBoxRelay3Name_LostFocus;
            menuTextBoxRelay4Name.LostFocus += MenuTextBoxRelay4Name_LostFocus;

        }

        private void MenuTextBoxRelay1Name_LostFocus(object sender, EventArgs e)
        {
            HandleRelayNamechange(0);
        }

        private void MenuTextBoxRelay2Name_LostFocus(object sender, EventArgs e)
        {
            HandleRelayNamechange(1);
        }

        private void MenuTextBoxRelay3Name_LostFocus(object sender, EventArgs e)
        {
            HandleRelayNamechange(2);
        }

        private void MenuTextBoxRelay4Name_LostFocus(object sender, EventArgs e)
        {
            HandleRelayNamechange(3);
        }

        private void buttonRelay1Schedule_Click(object sender, EventArgs e)
        {
            RelaySetupForm relaySetupForm = new RelaySetupForm(0);
            relaySetupForm.Show();
        }

        private void buttonRelay2Schedule_Click(object sender, EventArgs e)
        {
            RelaySetupForm relaySetupForm = new RelaySetupForm(1);
            relaySetupForm.Show();
        }

        private void buttonRelay3Schedule_Click(object sender, EventArgs e)
        {
            RelaySetupForm relaySetupForm = new RelaySetupForm(2);
            relaySetupForm.Show();
        }

        private void buttonRelay4Schedule_Click(object sender, EventArgs e)
        {
            RelaySetupForm relaySetupForm = new RelaySetupForm(3);
            relaySetupForm.Show();
        }
    }
}
