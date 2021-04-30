using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace USBRelayScheduler.Resources
{
    internal sealed partial class Settings
    {
        [UserScopedSetting]
        [DebuggerNonUserCode]
        public List<RelaySchedule> RelaySchedules
        {
            get => ((List<RelaySchedule>)(this["RelaySchedules"]));
            set => this["RelaySchedules"] = value;
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        public List<CheckState> RelayForcedStates
        {
            get => ((List<CheckState>)(this["RelayForcedStates"]));
            set => this["RelayForcedStates"] = value;
        }
    }
}
