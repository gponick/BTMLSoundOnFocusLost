using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using fastJSON;
using HBS;
using HBS.Logging;
using UnityEngine;

// Token: 0x02000955 RID: 2389
public partial class WwiseManager : SceneSingletonBehavior<WwiseManager>
{
    // Token: 0x06004B17 RID: 19223 RVA: 0x0017663E File Offset: 0x0017483E
    private void OnApplicationFocus(bool focus)
    {
        WwiseManager.logger.LogDebug("OnApplicationFocus " + focus);
        if (focus)
        {
            this.WakeupSoundEngine();
        }
        else
        {
            this.SuspendSoundEngine(true);
        }
    }
}
