using PulsarModLoader;

namespace Combo_Processor_Fix
{
    public class Mod : PulsarMod
    {
        public Mod()
        {
            CachedHarmonyIdent = HarmonyIdentifier();
        }

        public static string CachedHarmonyIdent;

        public override string Version => "1.2.1";

        public override string Author => "Dragon";

        public override string Name => "Combo Processor Fix";


        public static bool Enabled = true;
        public static bool HostEnabled = false;

        public override void Disable()
        {
            Enabled = false;
            SyncModMessage.SendAllEnabledState();
        }

        public override void Enable()
        {
            Enabled = true;
            SyncModMessage.SendAllEnabledState();
        }

        public override bool IsEnabled()
        {
            return Enabled;
        }

        public override string HarmonyIdentifier()
        {
            return $"{Author}.{Name}";
        }
    }
}
