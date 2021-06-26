# SpawnTools
 A collection of Unity Tools

## Spawn Audio

Spawn Audio is a collection of three scripts that simplify the process of creating a system to play and manage audio in your project.
With just a button click this script will create all the objects, audio sources, and scripts needed to have a system as soon as you play your game.

It works by creating a singleton with preset functions to manage the audio.
It includes basic functions like playing, muting, starting and stopping audio and tweaking the volumes.
This can be done to all sources, either background or sound effect sources, or to individual sources.

Before the script that holds these functions is created two lists are generated that hold either background or sound effect sources..
The background audio is assigned with the provided background clips (if available) and start automatically (for now)

The sound effect sources populate the other list and is managed by SpawnDJ.. When it receives the word to play a clip it does the work of,
looping through the sound effect sources available, finding the first source available (thats not currently being used), and playing the clip.
If no source is available then it creates a new source, plays the clip, then destroys that source. 

		*Generate AudioSources must be ran before any SpawnDJ function will work.*

### SpawnAudio.cs
*A script to create the audio manager, audiosources, and setup the hierarchy, all inside the editor.*

- Drag and drop background audio clips into the script.
- Assign how many audiosources you want available for the script to manage. [Channels]
- After sources are created an Instance of SpawnDJ is created.

### SpawnDJ.cs
*A singleton created by SpawnAudio.cs that allows you to call basic functions to control the audiosources*

- Call a function from the SpawnDJ class from anywhere in your project with:

		SpawnDJ.Instance.Function();



