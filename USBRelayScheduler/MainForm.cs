using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using USBRelayScheduler.Resources;
using USBRelayScheduler.RelayDevices;

namespace USBRelayScheduler
{
    public partial class MainForm : Form
    {
        private RelayDeviceBase relayDevice;
        private System.Timers.Timer relayStatusTimer;

        public MainForm()
        {
            InitializeComponent();
            // Attempt to initialize a relay device0000
            if (InitializeRelayDevice())
            {
                // If we are successful, reset the relays and start checking the schedules
                ResetRelays();
                relayDevice.StartScheduleTimer();
            }
            
            PopulateForm();
        }

        /// <summary>
        /// Populates the fields and checkboxes on the form
        /// </summary>
        private void PopulateForm()
        {
            if (relayDevice == null)
                textBoxDeviceAddress.Text = "";
            else
                textBoxDeviceAddress.Text = relayDevice.GetSerialNumber();

            if (Settings.Default.RelayForcedStates == null) { return; }
            checkBoxRelay1ForceToggle.CheckState = Settings.Default.RelayForcedStates[0];
            checkBoxRelay2ForceToggle.CheckState = Settings.Default.RelayForcedStates[1];
            checkBoxRelay3ForceToggle.CheckState = Settings.Default.RelayForcedStates[2];
            checkBoxRelay4ForceToggle.CheckState = Settings.Default.RelayForcedStates[3];
        }

        /// <summary>
        /// Attempts to connect to a Tctec Device then to a FTDI device if unable to find a Tctec device
        /// </summary>
        /// <returns></returns>
        private bool InitializeRelayDevice()
        {
            // Attempt to connect to a Tctec Device
            relayDevice = InitializeTctecDevice();
            if (relayDevice == null)
            {
                // If unable to connect to Tctec, try connecting as FTDI device
                relayDevice = InitializeFTDIDevice();
                if (relayDevice == null)
                {
                    MessageBox.Show("Unable to locate a relay device. Please reconnect and try again.");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Attempts to connect to a Tctec device
        /// </summary>
        /// <returns></returns>
        private RelayDeviceBase InitializeTctecDevice()
        {
            try
            {
                // Attempt to get the serial number of the first relay, if no relay then it throws an ArgumentOutOfRangeException
                string serial = TctecUSB4.TctecUSB4.getSerialNumbers()[0].ToString();
                // If we did not throw an exception, a Tctec Device exists so we initialize it
                return new TctecUSBDevice();
            }
            catch (Exception ex)
            {
                if (ex is ArgumentOutOfRangeException || ex is DllNotFoundException)
                    return null;
                else
                {
                    MessageBox.Show("We encountered an exception: " + ex.Message);
                    return null;
                }      
            }
        }

        /// <summary>
        /// Attempts to connect to a FTDI device
        /// </summary>
        /// <returns></returns>
        private RelayDeviceBase InitializeFTDIDevice()
        {
            // Initialize a FTDI device
            FTDIRelayDevice tempDevice = new FTDIRelayDevice();

            // Check the connection status, return the new device if successful
            if (!tempDevice.CheckDeviceStatus())
            {
                return null;
            }
            return tempDevice;
        }

        /// <summary>
        /// Resets each relay to the state stored in settings
        /// </summary>
        private void ResetRelays()
        {
            if (relayDevice.GetSerialNumber() == null) return;

            // Iterate through each relay and set each according to the respective state in Settings
            for (int i = 0; i <= 3; i++)
            {
                if (Settings.Default.RelayForcedStates[i] == CheckState.Checked)
                {
                    if (!relayDevice.SetRelay(i, true)) break; // If unable to set relay, stop trying as we have no connection
                }
                else
                {
                    if (!relayDevice.SetRelay(i, false)) break;
                } 
            }
        }

        /// <summary>
        /// Forces the relay to ignore the schedule and adhere the current checkstate
        /// </summary>
        /// <param name="relay"></param>
        /// <param name="forceState"></param>
        private void ToggleRelayForce(int relay, CheckState forceState)
        {
            if (relayDevice == null) return;
            // Set the forced state of the relay
            if (forceState == CheckState.Checked)
            {
                Settings.Default.RelaySchedules[relay].enabled = false;
                Settings.Default.RelayForcedStates[relay] = CheckState.Checked;
                if (!relayDevice.SetRelay(relay, true))
                {
                    ResetForceState(relay);
                }
                Settings.Default.Save();
            }
            else if (forceState == CheckState.Indeterminate)
            {
                Settings.Default.RelaySchedules[relay].enabled = false;
                Settings.Default.RelayForcedStates[relay] = CheckState.Indeterminate;
                if (!relayDevice.SetRelay(relay, false))
                {
                    ResetForceState(relay);
                }
                Settings.Default.Save();
            }
            else
            {
                Settings.Default.RelaySchedules[relay].enabled = true;
                Settings.Default.RelayForcedStates[relay] = CheckState.Unchecked;
                relayDevice.CheckRelaySchedules();
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// Resets the UI to match the forced states
        /// </summary>
        /// <param name="relay"></param>
        private void ResetForceState(int relay)
        {
            // Force the UI to match the forced state
            Settings.Default.RelaySchedules[relay].enabled = true;
            Settings.Default.RelayForcedStates[relay] = CheckState.Unchecked;
            if (relay == 0) { checkBoxRelay1ForceToggle.Checked = false; }
            else if (relay == 1) { checkBoxRelay2ForceToggle.Checked = false; }
            else if (relay == 2) { checkBoxRelay3ForceToggle.Checked = false; }
            else if (relay == 3) { checkBoxRelay4ForceToggle.Checked = false; }
        }

        /// <summary>
        /// Updates the UI when a relay name is changed
        /// </summary>
        /// <param name="relayIndex"></param>
        private void HandleRelayNamechange(int relayIndex)
        {
            if (relayIndex == 0) { Settings.Default.Relay1Name = menuTextBoxRelay1Name.Text; }
            else if (relayIndex == 1) { Settings.Default.Relay2Name = menuTextBoxRelay2Name.Text; }
            else if (relayIndex == 2) { Settings.Default.Relay3Name = menuTextBoxRelay3Name.Text; }
            else if (relayIndex == 3) { Settings.Default.Relay4Name = menuTextBoxRelay4Name.Text; }

            Settings.Default.Save();

            labelRelay1Name.Text = Settings.Default.Relay1Name + ":";
            labelRelay2Name.Text = Settings.Default.Relay2Name + ":";
            labelRelay3Name.Text = Settings.Default.Relay3Name + ":";
            labelRelay4Name.Text = Settings.Default.Relay4Name + ":";
        }

        /// <summary>
        /// Checks the state of each relay and sets the UI relay indicators accordingly
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
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
                        if (relayDevice == null) return;
                        // Get each realy state and set the respective UI indicators
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

        /// <summary>
        /// Disconnects the current device and attempts to reconnect
        /// </summary>
        private void RefreshDevice()
        {   
            if (relayDevice != null)
            {
                // Stop checking for schedules to prevent attempts to set a relay while refreshing
                relayDevice.StopScheduleTimer();
                relayDevice.Close();
                relayDevice = null;
            }
            
            // Attempt to initialize the relays again
            if (InitializeRelayDevice())
            {
                textBoxDeviceAddress.Text = relayDevice.GetSerialNumber();
                relayDevice.StartScheduleTimer();
            }
        }

        /// <summary>
        /// Imports settings from an XML file
        /// </summary>
        private void ImportSettings()
        {
            // Initialize the OpenFileDialog settings
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Config files(*.config) | *.config; *.config*; config | Text files(*.txt) | *.txt | All files (*.*)|*.*";
            openFileDialog.Title = "Import Settings";
            openFileDialog.Multiselect = false;
            openFileDialog.DefaultExt = "config";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;

            // Display the OpenFileDialog
            DialogResult openResult = openFileDialog.ShowDialog(this);
            if (openResult == DialogResult.OK)
            {
                // Check if the file exists
                if (!File.Exists(openFileDialog.FileName))
                {
                    MessageBox.Show("Could not open selected file. Please try again.");
                    return;
                }

                var appSettings = Settings.Default;
                try
                {
                    // Grab the existing settings
                    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                    string appSettingsXmlName = Settings.Default.Context["GroupName"].ToString();

                    // Open settings file as XML
                    var import = XDocument.Load(openFileDialog.FileName);
                    // Get the whole XML inside the settings node
                    var settings = import.XPathSelectElements("//" + appSettingsXmlName);

                    // Set the current settings to the imported settings
                    config.GetSectionGroup("userSettings")
                        .Sections[appSettingsXmlName]
                        .SectionInformation
                        .SetRawXml(settings.Single().ToString());
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("userSettings");

                    appSettings.Reload();
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to load settings. Reloading previous settings.");
                    appSettings.Reload();
                }
            }
        }

        /// <summary>
        /// Saves the current settings in an importable format
        /// </summary>
        private void ExportSettings()
        {
            Settings.Default.Save();
            // Grab the existing settings
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            // Initialize the SaveFileDialog settings
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Settings";
            saveFileDialog.DefaultExt = ".config";
            saveFileDialog.Filter = "Config files(*.config) | *.config | Text files(*.txt) | *.txt";
            saveFileDialog.FileName = "userexport";

            // Display the SaveFileDialog
            DialogResult saveResult = saveFileDialog.ShowDialog();
            if (saveResult == DialogResult.OK)
            {
                if (saveFileDialog.CheckPathExists)
                {
                    bool addExtension = saveFileDialog.AddExtension;
                    string exportPath = saveFileDialog.FileName;
                    try
                    {
                        // Save the existing settings to the specified path
                        config.SaveAs(exportPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to export settings file. Please try again.");
                    }
                }
            }  
        }

        private void buttonRefreshDeviceAddress_Click(object sender, EventArgs e)
        {
            RefreshDevice();
        }

        private void MainForm_FormClosing(object sender, EventArgs e)
        {
            relayStatusTimer.Stop();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Start checking the relays
            relayStatusTimer = new System.Timers.Timer(10);
            relayStatusTimer.Elapsed += CheckDeviceStatus;
            relayStatusTimer.Start();

            // Initialize the UI to match settings
            labelRelay1Name.Text = Settings.Default.Relay1Name + ":";
            labelRelay2Name.Text = Settings.Default.Relay2Name + ":";
            labelRelay3Name.Text = Settings.Default.Relay3Name + ":";
            labelRelay4Name.Text = Settings.Default.Relay4Name + ":";

            menuTextBoxRelay1Name.Text = Settings.Default.Relay1Name;
            menuTextBoxRelay2Name.Text = Settings.Default.Relay2Name;
            menuTextBoxRelay3Name.Text = Settings.Default.Relay3Name;
            menuTextBoxRelay4Name.Text = Settings.Default.Relay4Name;
            
            // Subscribe events
            menuTextBoxRelay1Name.LostFocus += MenuTextBoxRelay1Name_LostFocus;
            menuTextBoxRelay2Name.LostFocus += MenuTextBoxRelay2Name_LostFocus;
            menuTextBoxRelay3Name.LostFocus += MenuTextBoxRelay3Name_LostFocus;
            menuTextBoxRelay4Name.LostFocus += MenuTextBoxRelay4Name_LostFocus;
            menuItemExport.Click += MenuItemExport_Click;
            menuItemImport.Click += MenuItemImport_Click;
            menuItemClose.Click += MenuItemClose_Click;
        }

        private void MenuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuItemImport_Click(object sender, EventArgs e)
        {
            ImportSettings();
        }

        private void MenuItemExport_Click(object sender, EventArgs e)
        {
            ExportSettings();
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

        private void checkBoxRelay1ForceOn_CheckedStateChanged(object sender, EventArgs e)
        {
            ToggleRelayForce(0, checkBoxRelay1ForceToggle.CheckState);
        }

        private void checkBoxRelay2ForceOn_CheckedStateChanged(object sender, EventArgs e)
        {
            ToggleRelayForce(1, checkBoxRelay2ForceToggle.CheckState);
        }

        private void checkBoxRelay3ForceOn_CheckedStateChanged(object sender, EventArgs e)
        {
            ToggleRelayForce(2, checkBoxRelay3ForceToggle.CheckState);
        }

        private void checkBoxRelay4ForceOn_CheckedStateChanged(object sender, EventArgs e)
        {
            ToggleRelayForce(3, checkBoxRelay4ForceToggle.CheckState);
        }
    }
}
