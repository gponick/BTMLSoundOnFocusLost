﻿using System;
using System.Reflection;
using Harmony;
using Newtonsoft.Json;
using BattleTech;
using BattleTech.UI;
using InControl;


namespace BTMLSoundOnFocusLost
{
    public static class BTMLSoundOnFocusLost
    {
        internal static Settings ModSettings = new Settings();
        internal static string ModDirectory;

        public static void Init(string directory, string settingsJSON)
        {
            var harmony = HarmonyInstance.Create("com.gponick.BTMLSoundOnFoucsLost");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            ModDirectory = directory;
            try
            {
                ModSettings = JsonConvert.DeserializeObject<Settings>(settingsJSON);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                ModSettings = new Settings();
            }
        }
    }
}