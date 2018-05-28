using BattleTech;
using BattleTech.UI;
using Harmony;
using InControl;
using System;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BattleTech.Data;
using BattleTech.UI.Tooltips;
using HBS;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BTMLSoundOnFocusLost
{
    public class KeyBinding
    {
        public class Adapter<T>
        {
            public readonly T instance;
            public readonly Traverse traverse;

            protected Adapter(T instance)
            {
                this.instance = instance;
                traverse = Traverse.Create(instance);
            }
        }

        public static PlayerAction SoundOnFocusAction;
        
        [HarmonyPatch(typeof(BattleTech.UI.UIManager), "Update")]
        public static class UIManager_Patch { 
            public static bool Prefix(UIManager __instance)
            {
                if ( SoundOnFocusAction.WasReleased)
                {
                    Logger.LogLine($"Toggling sound on / off without focus, from: {BTMLSoundOnFocusLost.ModSettings.EnableSoundOnLostFocus}");
                    BTMLSoundOnFocusLost.ModSettings.EnableSoundOnLostFocus = !BTMLSoundOnFocusLost.ModSettings.EnableSoundOnLostFocus;
                    Logger.LogLine($"It's now: {BTMLSoundOnFocusLost.ModSettings.EnableSoundOnLostFocus}");
                }
                return true;
            }
        }


        [HarmonyPatch(typeof(DynamicActions), "CreateWithDefaultBindings")]
        public static class DynamicActionsCreateWithDefaultBindingsPatch
        {


            public static void Postfix(DynamicActions __result)
            {
                try
                {
                    var adapter = new DynamicActionsAdapter(__result);
                    SoundOnFocusAction = adapter.CreatePlayerAction("Toggle Focus Sound");
                    SoundOnFocusAction.AddDefaultBinding(Key.O);
                    Logger.LogLine("Keybind added");
                }
                catch (Exception e)
                {
                    Logger.LogError(e);
                }
            }
        }

        internal class DynamicActionsAdapter : Adapter<DynamicActions>
        {
            internal DynamicActionsAdapter(DynamicActions instance) : base(instance)
            {
            }

            internal PlayerAction CreatePlayerAction(string name)
            {
                return traverse.Method("CreatePlayerAction", name).GetValue<PlayerAction>(name); ;
            }
        }
    }
}