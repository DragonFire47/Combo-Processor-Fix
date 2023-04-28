using HarmonyLib;
using PulsarModLoader;
using PulsarModLoader.MPModChecks;

namespace Combo_Processor_Fix
{
    internal class SyncModMessage : ModMessage
    {
        public static string Handle = "Combo_Processor_Fix.SyncModMessage";
        public override void HandleRPC(object[] arguments, PhotonMessageInfo sender)
        {
            if (sender.sender == PhotonNetwork.masterClient)
            {
                Mod.HostEnabled = (bool)arguments[0];
            }
        }

        public static void SendAllEnabledState()
        {
            if (PhotonNetwork.isMasterClient)
            {
                foreach (PhotonPlayer player in MPModCheckManager.Instance.NetworkedPeersWithMod(Mod.CachedHarmonyIdent))
                {
                    SendRPC(Mod.CachedHarmonyIdent, Handle, player, new object[] { Mod.Enabled });
                }
            }
        }
    }

    [HarmonyPatch(typeof(PLServer), "LoginMessage")]
    class PlayerConnectedPatch //used to sync the client with the host's settings
    {
        static void Postfix(ref PhotonPlayer newPhotonPlayer)
        {
            if (PhotonNetwork.isMasterClient && MPModCheckManager.Instance.NetworkedPeerHasMod(newPhotonPlayer, Mod.CachedHarmonyIdent))
            {
                ModMessage.SendRPC(Mod.CachedHarmonyIdent, SyncModMessage.Handle, newPhotonPlayer, new object[] { Mod.Enabled });
            }
        }
    }
}
