using BattleTech;
using BattleTech.UI;
using Harmony;
using InControl;
using System;

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

        [HarmonyPatch(typeof(CombatSelectionHandler), "ProcessInput")]
        public static class CombatSelectionHandlerProcessInputPatch
        {
            public static void Prefix(CombatSelectionHandler __instance)
            {
                try
                {
                    if (SoundOnFocusAction == null || !SoundOnFocusAction.HasChanged || !SoundOnFocusAction.IsPressed)
                    {
                        return;
                    }

                    Logger.LogLine($"Toggling sound on / off without focus, from: {BTMLSoundOnFocusLost.ModSettings.EnableSoundOnLostFocus}");
                    BTMLSoundOnFocusLost.ModSettings.EnableSoundOnLostFocus = !BTMLSoundOnFocusLost.ModSettings.EnableSoundOnLostFocus;
                    Logger.LogLine($"It's now: {BTMLSoundOnFocusLost.ModSettings.EnableSoundOnLostFocus}");



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