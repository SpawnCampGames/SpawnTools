# SpawnTools
 A collection of Unity Tools

## Spawn Audio  v1
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
*The main script, and the one responsible for creating the GameObjects, AudioSources, and `SpawnDJ`*

**Game Audio**
- These are the default values and not edible after you Generate AudioSources.
	*Can be changed through `SpawnDJ` during runtime*

[ Channels ] This is the # of AudioSources that will be created to play AudioClips.
- The more sources the less likely you'll have to create an additional AudioSource.
	*Additional AudioSources can be created with `SpawnDJ` during runtime*

[Sfx and Background Volume] The default values for the AudioSources to be created.
	*Can be changed during runtime with `SpawnDJ` and reset to these defaults at anytime*

- Drag and drop background audio clips into the script.
- Assign how many audiosources you want available for the script to manage. [Channels]
- After sources are created an Instance of SpawnDJ is created.

### 📄 SpawnDJ.cs
---
*The singleton that's created by SpawnAudio.cs. Allows you to call basic functions to control the audiosources*
**This Component sits alongside the SpawnAudio Component but is Hidden in the Hierarchy**



Call a function from the SpawnDJ class from anywhere in your project with:

`SpawnDJ.Instance.Function();`

![logo](https://spawncampgames.github.io/img/maincolorized.png)



