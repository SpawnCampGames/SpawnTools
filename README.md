# SpawnTools
 A collection of Unity Tools

## Spawn Audio v1
   Spawn Audio is a collection of (3) scripts that simplify the process of creating an audio system in your project.  
With one button click this tool will create all the GameObjects, AudioSources, and Scripts
needed to have a working system as soon as you Play ▶️

![logo](https://github.com/SpawnCampGames/SpawnTools/blob/main/Readme/SpawnAudio.png)

   It works by creating a singleton, `SpawnDJ`, that contains a list of Methods for manipulating
the AudioSources just created. To play audio you just pass in a clip.

   To call any of these functions or to play audio just call `SpawnDJ.Instance.SomeFunction();` 
from anywhere in your project.


### 📄 SpawnAudio.cs
---
*-Main script, and responsible for creating the GameObjects, AudioSources, and `SpawnDJ`-*

#### _Channels_

	The number of AudioSources that will be created to play AudioClips.
	The more sources the less likely you'll have to create an additional AudioSource.

#### _Sfx / Background Volume_

	The default values for the AudioSources to be created.

#### _Ambient Audio CLips_

	Drag in clips for your background audio.  
	They will automatically be assigned and loop during runtime.

Fill Out the inspector and Generate AudioSources  

![logo](https://github.com/SpawnCampGames/SpawnTools/blob/main/Readme/SpawnAudioHierarchy.png)

The Component will gray itself out after Generating.  
Any additional changes to the AudioSources can be made through the `SpawnDJ` at runtime.

### 📄 SpawnDJ.cs
---
*-Singleton that's created by `SpawnAudio`-*

*Allows you to call basic functions to control the AudioSources  
This Component sits alongside the SpawnAudio Component but is Hidden in the Hierarchy*

Contains (2) Lists of <AudioSources>.
- `audioSources` // list of your sound effect sources
- `backgroundSources` // list of your background loop sources

and possibly a third.
- `additionalSources` // any audiosource created during runtime

To gain access to these Lists use:

`SpawnDJ.audioSources;` or `SpawnDJ.backgroundSources;`

Call a function from the SpawnDJ class from anywhere in your project with:

`SpawnDJ.Instance.Function();`

To Play an Audio Clip use:

`SpawnDJ.Instance.PlayClip();` // and pass in an audioClip  
`SpawnDJ.Instance.PlayClip(yourAudioClip);`

`SpawnDJ` will search through all AudioSources and use the first one thats *not currently playing* to play the AudioClip.  
If all AudioSources are being used a new AudioSources will be created and added to the `additionalSources` list.   
As soon as the clip is finished the clip will be removed from the list and destroyed.

#### List of Functions Currently Available

Managing AudioSources
- `CreateNewAudioSource();`
- `RemoveExtraAudioSources();`
Muting
- `MuteAllAudio();`
- `MuteBackgroundAudio();`
- `MuteSfx();`
- `UnmuteAllAudio();`
- `UnmuteBackgroundAudio();`
- `UnmuteSfx();`
Pausing
- `PauseAllAudio();`
- `PauseBackgroundAudio();`
- `PauseSfx();`
- `UnPauseAllAudio();`
- `UnPauseBackgroundAudio();`
- `UnPauseSfx();`
Volume
- `SetMasterVolume(volume);`
- `RecoverMasterVolume();`
- `SetSfxVolume(volume);`
- `RecoverSfxVolume();`
- `SetBackgroundVolume(volume);`
- `RecoverBackgroundVolume();`