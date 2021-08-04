# SpawnTools
 A collection of Unity Tools

![logo](https://github.com/SpawnCampGames/SpawnTools/blob/main/Readme/img/logo.png)

## Tools
- [SpawnAudio](https://github.com/SpawnCampGames/SpawnTools#-spawnaudio-v1)
- [SpawnScene](https://github.com/SpawnCampGames/SpawnTools#-spawnscene-v1)


## 🔊 SpawnAudio v1
Spawn Audio is a collection of (3) scripts that simplify the process of creating an audio system in your project.  
With one button click this tool will create all the GameObjects, AudioSources, and Scripts
needed to have an audio system ready when you hit Play ▶️

[SpawnAudio.unitypackage](https://github.com/SpawnCampGames/SpawnTools/blob/main/SpawnAudio.unitypackage)

![logo](https://github.com/SpawnCampGames/SpawnTools/blob/main/Readme/img/SpawnAudio.png)

It works by creating a singleton, `SpawnDJ`, that contains a list of Methods for manipulating
the AudioSources just created. To play audio you just pass in a clip.

To call any of these functions or to play audio just call `SpawnDJ.Instance.SomeFunction();` 
from anywhere in your project.


## 📄 SpawnAudio.cs
#### *- Main script, and Responsible for creating the GameObjects, AudioSources, and `SpawnDJ` -*

#### _Channels_

	The number of AudioSources that will be created to play AudioClips.
	The more sources the less likely you'll have to create an additional AudioSource.

#### _Sfx / Background Volume_

	The default values for the AudioSources to be created.

#### _Ambient Audio CLips_

	Drag in clips for your background audio.  
	They will automatically be assigned and loop during runtime.

Fill Out the inspector and Generate AudioSources  

![logo](https://github.com/SpawnCampGames/SpawnTools/blob/main/Readme/img/SpawnAudioHierarchy.png)

The Component will gray itself out after Generating.  
Any additional changes to the AudioSources can be made through the `SpawnDJ` at runtime.

## 📄 SpawnDJ.cs
#### *- Singleton that's created by `SpawnAudio` -*

*Allows you to call basic functions to control the AudioSources  
This Component sits alongside the SpawnAudio Component but is Hidden in the Hierarchy*

Contains (2) Lists of `<AudioSources>`
- `audioSources` // list of your sound effect sources
- `backgroundSources` // list of your background loop sources

and possibly a third.
- `additionalSources` // any audiosource created during runtime

### To gain access to these Lists use:

`SpawnDJ.audioSources;` or `SpawnDJ.backgroundSources;`

### Call a function from the SpawnDJ class from anywhere in your project with:

`SpawnDJ.Instance.Function();`

### To Play an Audio Clip use:

`SpawnDJ.Instance.PlayClip();` // and pass in an audioClip  
`SpawnDJ.Instance.PlayClip(yourAudioClip);`

`SpawnDJ` will search through all AudioSources and use the first one thats *not currently playing* to play the AudioClip.  
If all AudioSources are being used a new AudioSources will be created and added to the `additionalSources` list.   
As soon as the clip is finished the clip will be removed from the list and destroyed.

### List of Functions Currently Available

#### Managing AudioSources
- `CreateNewAudioSource();` //creates a new source to play sound effects
- `RemoveExtraAudioSources();`  //removes it

#### Muting
- `MuteAllAudio();`
- `MuteBackgroundAudio();`
- `MuteSfx();`
- `UnmuteAllAudio();`
- `UnmuteBackgroundAudio();`
- `UnmuteSfx();`  

#### Pausing
- `PauseAllAudio();`
- `PauseBackgroundAudio();`
- `PauseSfx();`
- `UnPauseAllAudio();`
- `UnPauseBackgroundAudio();`
- `UnPauseSfx();`  

#### Volume
- `SetMasterVolume(volume);` //sets volume to a float
- `RecoverMasterVolume();` //sets volume to values used to generate audiosources
- `SetSfxVolume(volume);`
- `RecoverSfxVolume();`
- `SetBackgroundVolume(volume);`
- `RecoverBackgroundVolume();`  

#### Playing Audio
- `PlayClip(clip);` // play an audio clip





## 🏠 SpawnScene v1
Spawn Scene is a collection of (2) scripts that simplify the process of creating a starting scene in your project.  
With one button click this tool will create a starting scene with a ground plane, a default cube, and your lighting.
You'll be set up and ready to prototype.

[SpawnScene.unitypackage](https://github.com/SpawnCampGames/SpawnTools/blob/main/SpawnScene.unitypackage)

## 📄 SpawnScene.cs
#### *- Main script, and Responsible for creating the starting scene.-*

To setup just create an `Empty Gameobject` in your scene. I usually call mine `SpawnScene`.
Don't worry about the position as the script will reset it to *Zero* when you generate the scene.

Then you simply add the `SpawnScene.cs` as a component.

![logo](https://github.com/SpawnCampGames/SpawnTools/blob/main/Readme/img/SpawnSceneAdd.png)


Fill out the Inspector by chosing how many lights you want in your scene, the color, and the size of the ground plane.

![logo](https://github.com/SpawnCampGames/SpawnTools/blob/main/Readme/img/SpawnSceneGenerate.png)

Finally, just click `Generate`.

![logo](https://github.com/SpawnCampGames/SpawnTools/blob/main/Readme/img/SpawnSceneSetup.png)


The gameobject will be setup and an Empty with all your lights will be created, along with a default cube (for scale), and the ground plane.
Then the component will remove itself from the GameObject, as it is no longer needed.

## Currently You can only add (3) lights, as I figured thats enough for any starting scene but to add more open SpawnScene.cs and edit the Range[()] Attribute
```     
[Header("Lights")]
[Range(0,3)] // <-- Edit
public int numberOfLights = 0;
```

