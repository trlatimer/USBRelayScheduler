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
            if (Settings.Default.RelayForcedStates == null) { return; }
            checkBoxRelay1ForceToggle.CheckState = Settings.Default.RelayForcedStates[0];
            checkBoxRelay2ForceToggle.CheckState = Settings.Default.RelayForcedStates[1];
            checkBoxRelay3ForceToggle.CheckState = Settings.Default.RelayForcedStates[2];
            checkBoxRelay4ForceToggle.CheckState = Settings.Default.RelayForcedStates[3];
        }

        private void ResetRelays()
        {
            if (relayDevice.GetSerialNumber() == null) return;
            for (int i = 0; i <= 3; i++)
            {
                if (Settings.Default.RelayForcedStates[i] == CheckState.Checked)
                {
                    relayDevice.SetRelay(i, true);
                }
                else
                {
                    relayDevice.SetRelay(i, false);
                } 
            }
        }

        private void ToggleRelayForce(int relay, CheckState forceState)
        {
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

        private void ResetForceState(int relay)
        {
            Settings.Default.RelaySchedules[relay].enabled = true;
            Settings.Default.RelayForcedStates[relay] = CheckState.Unchecked;
            if (relay == 0) { checkBoxRelay1ForceToggle.Checked = false; }
            else if (relay == 1) { checkBoxRelay2ForceToggle.Checked = false; }
            else if (relay == 2) { checkBoxRelay3ForceToggle.Checked = false; }
            else if (relay == 3) { checkBoxRelay4ForceToggle.Checked = false; }
        }

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

        private void ImportSettings()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Config files(*.config) | *.config; *.config*; config | Text files(*.txt) | *.txt | All files (*.*)|*.*";
            openFileDialog.Title = "Import Settings";
            openFileDialog.Multiselect = false;
            openFileDialog.DefaultExt = "config";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            DialogResult openResult = openFileDialog.ShowDialog(this);
            if (openResult == DialogResult.OK)
            {
                if (!File.Exists(openFileDialog.FileName))
                {
                    MessageBox.Show("Could not open selected file. Please try again.");
                    return;
                }

                var appSettings = Settings.Default;
                try
                {
                    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                    string appSettingsXmlName = Settings.Default.Context["GroupName"].ToString();

                    // Open settings file as XML
                    var import = XDocument.Load(openFileDialog.FileName);
                    // Get the whole XML inside the settings node
                    var settings = import.XPathSelectElements("//" + appSettingsXmlName);

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

        private void ExportSettings()
        {
            Settings.Default.Save();
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Settings";
            saveFileDialog.DefaultExt = ".config";
            saveFileDialog.Filter = "Config files(*.config) | *.config | Text files(*.txt) | *.txt";
            saveFileDialog.FileName = "userexport";
            DialogResult saveResult = saveFileDialog.ShowDialog();
            if (saveResult == DialogResult.OK)
            {
                if (saveFileDialog.CheckPathExists)
                {
                    bool addExtension = saveFileDialog.AddExtension;
                    string exportPath = saveFileDialog.FileName;
                    try
                    {
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
