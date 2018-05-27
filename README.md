# BTMLSoundOnFocusLost
BattleTech Mod (using [BTML](https://github.com/Mpstark/BattleTechModLoader) and [ModTek](https://github.com/Mpstark/ModTek)) that keeps the sound going in the background when you tab out. I got super annoyed at not hearing the masterpiece that is [Jon Everist](http://everistsound.com/)'s works while chatting or modding. Seriously, go listen! [NOW!](https://open.spotify.com/artist/4DqJvNq10EAyXLdTIFoMK2).

Also I guess you can hear your mechs get stomped into the ground while alt-tabbed. There's that too.

## Download
Downloads can be found on [Github](https://github.com/gponick/BTMLSoundOnFocusLost/releases) 

## Install
- [Install BTML and Modtek](https://github.com/Mpstark/ModTek/wiki/The-Drop-Dead-Simple-Guide-to-Installing-BTML-&-ModTek-&-ModTek-mods).
- Put the `BTMLSoundOnFocusLost.dll` and `mod.json` files into `\BATTLETECH\Mods\BTMLSoundOnFocusLost` folder.
- If you want to change the settings do so in the mod.json.
- Start the game.

## Settings


Setting | Type | Default | Description
--- | --- | --- | ---
`enableSoundOnLostFocus` | `bool` | `true` | should sound be enabled when focus is lost

## Special Thanks

HBS, @Mpstark, @Morphyum, @janxous


## Maintainer Notes: New HBS Patch Instructions

* pop open VS
* grab the latest version of the assembly
* copy the new version of the methods in `original_src` over the existing ones
* see if anything important changed via git
