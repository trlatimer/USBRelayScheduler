using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USBRelayScheduler
{
    public partial class MainForm : Form
    {
        private TctecUSBDevice relayDevice;

        public MainForm()
        {
            InitializeComponent();
            relayDevice = new TctecUSBDevice();
        }

        private void PopulateForm()
        {
            textBoxDeviceAddress.Text = relayDevice.GetSerialNumber();
        }

        // TODO set relay names to be stored in settings and retrieved on load
        // TODO add edit feature for relay names
        // TODO add handling for each control
        // TODO create schedule class and variables
    }
}
