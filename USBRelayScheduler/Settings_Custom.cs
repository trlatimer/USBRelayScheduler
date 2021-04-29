using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Text;

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
        public List<bool> RelayForcedStates
        {
            get => ((List<bool>)(this["RelayForcedStates"]));
            set => this["RelayForcedStates"] = value;
        }
    }
}
