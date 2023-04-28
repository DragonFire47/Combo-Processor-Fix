using PulsarModLoader.CustomGUI;
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
                Label($"Host mod: {(Mod.HostEnabled ? "Enabled" : "Disabled")}");
            }
        }

        public override string Name()
        {
            return "Combo Processor Fix: " + (Mod.Enabled ? "Enabled" : "Disabled");
        }
    }
}
