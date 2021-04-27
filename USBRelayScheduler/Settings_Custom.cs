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
        public RelaySchedule Relay1Schedule
        {
            get => ((RelaySchedule)(this["Relay1Schedule"]));
            set => this["Relay1Schedule"] = value;
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        public RelaySchedule Relay2Schedule
        {
            get => ((RelaySchedule)(this["Relay2Schedule"]));
            set => this["Relay2Schedule"] = value;
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        public RelaySchedule Relay3Schedule
        {
            get => ((RelaySchedule)(this["Relay3Schedule"]));
            set => this["Relay3Schedule"] = value;
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        public RelaySchedule Relay4Schedule
        {
            get => ((RelaySchedule)(this["Relay4Schedule"]));
            set => this["Relay4Schedule"] = value;
        }
    }
}
