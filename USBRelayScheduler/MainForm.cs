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
            PopulateForm();
        }

        private void PopulateForm()
        {
            textBoxDeviceAddress.Text = relayDevice.GetSerialNumber();
        }

        private void ToggleRelay(int relay)
        {
            if (relayDevice.GetRelayState(relay))
            {
                relayDevice.SetRelayOff(relay);
            }
            else
            {
                relayDevice.SetRelayOn(relay);
            }
        }

        private void CheckRelayStatus(Object source, System.Timers.ElapsedEventArgs e)
        {
            // TODO Add multithreading and lock here
            relayStatusTimer.Elapsed -= CheckRelayStatus;

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
                Console.WriteLine("Tried to access disposed MainForm"); // TODO Find a better way to handle this than a Try/Catch
            }

            relayStatusTimer.Elapsed += CheckRelayStatus;
        }

        private void buttonChangeDeviceAddress_Click(object sender, EventArgs e)
        {
            // TODO add check for serial number
            // TODO dispose existing relayDevice and load new with serial number
            // TODO convert textbox to combobox?
        }

        private void checkBoxRelay1ForceOn_CheckedChanged(object sender, EventArgs e)
        {
            ToggleRelay(0);
        }

        private void checkBoxRelay2ForceOn_CheckedChanged(object sender, EventArgs e)
        {
            ToggleRelay(1);
        }

        private void MainForm_FormClosing(object sender, EventArgs e)
        {
            relayStatusTimer.Stop();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            ToggleRelay(2);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            ToggleRelay(3);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            relayStatusTimer = new System.Timers.Timer(10);
            relayStatusTimer.Elapsed += CheckRelayStatus;
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


        // TODO set relay names to be stored in settings and retrieved on load
        // TODO add edit feature for relay names
        // TODO add handling for each control
        // TODO create schedule class and variables
    }
}
