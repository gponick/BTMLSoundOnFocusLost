using System.Collections.Generic;
using BattleTech;
using BattleTech.UI;
using Harmony;
using UnityEngine;
using static BTMLSoundOnFocusLost.BTMLSoundOnFocusLost;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using fastJSON;
using HBS;
using HBS.Logging;
using UnityEngine;

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