using Harmony;

namespace BTMLSoundOnFocusLost
{
    [HarmonyPatch(typeof(WwiseManager), "OnApplicationFocus")]
    public static class WwiseManager_Patch
    {
        static bool Prefix(bool focus)
        {
            if(BTMLSoundOnFocusLost.ModSettings.EnableSoundOnLostFocus)
                return false;
            return true;
        }
    }
}