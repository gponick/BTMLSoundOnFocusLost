using UnityEngine;

namespace BTMLSoundOnFocusLost
{
    // the properties in in here are to be a deserializer step from JSON format
    // into the C# variables used by the mod.
    public class Settings
    {
        public bool EnableSoundOnLostFocus = true;

        public bool enableSoundOnLostFocus
        {
            set => EnableSoundOnLostFocus = value;
        }
    }
}