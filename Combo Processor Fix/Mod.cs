using PulsarModLoader;

namespace Combo_Processor_Fix
{
    public class Mod : PulsarMod
    {
        public override string Version => "1.1.0";

        public override string Author => "Dragon";

        public override string Name => "Combo Processor Fix";


        public static bool Enabled = true;

        public override void Disable()
        {
            Enabled = false;
        }

        public override void Enable()
        {
            Enabled = true;
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
