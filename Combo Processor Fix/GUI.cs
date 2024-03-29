﻿using PulsarModLoader.CustomGUI;
using static UnityEngine.GUILayout;

namespace Combo_Processor_Fix
{
    class GUI : ModSettingsMenu
    {
        public override void Draw()
        {
            if (Button("Combo Processor Fix " + (Mod.Enabled ? "Enabled" : "Disabled")))
            {
                Mod.Enabled = !Mod.Enabled;
                SyncModMessage.SendAllEnabledState();
            }
            if (!PhotonNetwork.isMasterClient)
            {
                Label($"Local mod: {(Mod.Enabled ? "Enabled" : "Disabled")}, Host mod: {(Mod.HostEnabled ? "Enabled" : "Disabled")}, Mod is effectively {((Mod.HostEnabled && Mod.Enabled) ? "Enabled" : "Disabled")}");
            }
        }

        public override string Name()
        {
            if (!PhotonNetwork.isMasterClient)
            {
                return "Combo Processor Fix: " + ((Mod.HostEnabled && Mod.Enabled) ? "Enabled" : "Disabled");
            }
            return "Combo Processor Fix: " + (Mod.Enabled ? "Enabled" : "Disabled");
        }
    }
}
