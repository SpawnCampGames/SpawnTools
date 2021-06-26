using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnTools
{
    [ExecuteInEditMode]
    public class SpawnDJ : MonoBehaviour
    {
        [HideInInspector]
        public SpawnAudio spawnAudio;
        public static SpawnDJ Instance{get; private set;}
        
        [SerializeField]
        private List<AudioSource> audioSources;
        [SerializeField]
        private List<AudioSource> backgroundSources;
        
        //runtime vars
        private List<AudioSource> additionalSources = new List<AudioSource>();

        [HideInInspector]
        public AudioSource availableAudioSource;
        
        private float sfxStartingVol;
        private float bgStartingVol;
        
        private void Start() => CreateInstance();
        public void Initialize()
        {
            spawnAudio = GetComponent<SpawnAudio>();
            audioSources = spawnAudio.audioSources;
            backgroundSources = spawnAudio.backgroundAudioSources;
            CreateInstance();
        }

        void CreateInstance() => Instance = this;
        public void DestroyInstance() => Instance = null;

        #region Base Methods
        public void RemoveExtraAudioSources()
        {
            for (int i = 0; i < additionalSources.Count; i++)
            {
                GameObject toDel = additionalSources[i].gameObject;
                DestroyImmediate(toDel);
            }
            additionalSources.Clear();
            
            Debug.Log($"AudioSources Cleared\n");
        }

        public AudioSource CreateNewAudioSource()
        {
            GameObject toAdd = new GameObject($"Sfx{additionalSources.Count + audioSources.Count + 1}");
            toAdd.transform.parent = spawnAudio.sfx.transform;
            AudioSource sourceToAdd = toAdd.AddComponent<AudioSource>();
            sourceToAdd.volume = spawnAudio.sfxVolume;
            sourceToAdd.playOnAwake = false;
            sourceToAdd.loop = false;
            additionalSources.Add(sourceToAdd);
            
            Debug.Log($"New AudioSource Created\n");

            availableAudioSource = sourceToAdd;
            return sourceToAdd;
        }
        
        public AudioSource GetNextAvailableAudioSource()
        {
            availableAudioSource = null;
            
            for (int i = 0; i < audioSources.Count; i++)
            {
                if (!audioSources[i].isPlaying)
                {
                    Debug.Log($"Audio Source Found\n");
                    availableAudioSource = audioSources[i];
                    return availableAudioSource;
                }
            }
            
            for (int i = 0; i < additionalSources.Count; i++)
            {
                if (!additionalSources[i].isPlaying)
                {
                    Debug.Log($"Audio Source Found\n");
                    availableAudioSource = additionalSources[i];
                    return availableAudioSource;
                }
            }
            
            Debug.Log($"No Audio Sources Found\n" +
                      "<color=green>Creating New AudioSource</color>");
            
            return CreateNewAudioSource();
        }
        
        public void MuteAllAudio()
        {
            for (int i = 0; i < audioSources.Count; i++)
            {
                audioSources[i].mute = true;
            }
            
            for (int i = 0; i < additionalSources.Count; i++)
            {
                additionalSources[i].mute = true;
            }
            
            for (int i = 0; i < backgroundSources.Count; i++)
            {
                backgroundSources[i].mute = true;
            }
        }
        
        public void MuteBackground()
        {
            for (int i = 0; i < backgroundSources.Count; i++)
            {
                backgroundSources[i].mute = true;
            }
        }
        
        public void MuteSfx()
        {
            for (int i = 0; i < audioSources.Count; i++)
            {
                audioSources[i].mute = true;
            }
            
            for (int i = 0; i < additionalSources.Count; i++)
            {
                additionalSources[i].mute = true;
            }
        }
        
        public void UnmuteAllAudio()
        {
            for (int i = 0; i < audioSources.Count; i++)
            {
                audioSources[i].mute = false;
            }
            
            for (int i = 0; i < additionalSources.Count; i++)
            {
                additionalSources[i].mute = false;
            }
            
            for (int i = 0; i < backgroundSources.Count; i++)
            {
                backgroundSources[i].mute = false;
            }
        }
        
        public void UnmuteBackground()
        {
            for (int i = 0; i < backgroundSources.Count; i++)
            {
                backgroundSources[i].mute = false;
            }
        }
        
        public void UnmuteSfx()
        {
            for (int i = 0; i < audioSources.Count; i++)
            {
                audioSources[i].mute = false;
            }
            
            for (int i = 0; i < additionalSources.Count; i++)
            {
                additionalSources[i].mute = false;
            }
        }
        
        public void PauseAllAudio()
        {
            for (int i = 0; i < audioSources.Count; i++)
            {
                audioSources[i].Pause();
            }
            
            for (int i = 0; i < additionalSources.Count; i++)
            {
                additionalSources[i].Pause();
            }
            for (int i = 0; i < backgroundSources.Count; i++)
            {
                backgroundSources[i].Pause();
            }
        }
        
        public void PauseBackground()
        {
            for (int i = 0; i < backgroundSources.Count; i++)
            {
                backgroundSources[i].Pause();
            }
        }
        
        public void PauseSfx()
        {
            for (int i = 0; i < audioSources.Count; i++)
            {
                audioSources[i].Pause();
            }
            
            for (int i = 0; i < additionalSources.Count; i++)
            {
                additionalSources[i].Pause();
            }
        }
        
        public void UnpauseAllAudio()
        {
            for (int i = 0; i < audioSources.Count; i++)
            {
                audioSources[i].Play();
            }
            
            for (int i = 0; i < additionalSources.Count; i++)
            {
                additionalSources[i].Play();
            }
            
            for (int i = 0; i < backgroundSources.Count; i++)
            {
                backgroundSources[i].Play();
            }
        }
        
        public void UnpauseBackground()
        {
            for (int i = 0; i < backgroundSources.Count; i++)
            {
                backgroundSources[i].Play();
            }
        }
        
        public void UnpauseSfx()
        {
            for (int i = 0; i < audioSources.Count; i++)
            {
                audioSources[i].Play();
            }
            
            for (int i = 0; i < additionalSources.Count; i++)
            {
                additionalSources[i].Play();
            }
        }

        public void SetMasterVolume(float volume)
        {
            for (int i = 0; i < audioSources.Count; i++)
            {
                audioSources[i].volume = volume;
            }
            
            for (int i = 0; i < additionalSources.Count; i++)
            {
                additionalSources[i].volume = volume;
            }
            
            for (int i = 0; i < backgroundSources.Count; i++)
            {
                backgroundSources[i].volume = volume;
            }
        }

        public void RecoverMasterVolume()
        {
            for (int i = 0; i < audioSources.Count; i++)
            {
                audioSources[i].volume = spawnAudio.sfxVolume;
            }
            
            for (int i = 0; i < additionalSources.Count; i++)
            {
                additionalSources[i].volume = spawnAudio.sfxVolume;
            }
            
            for (int i = 0; i < backgroundSources.Count; i++)
            {
                backgroundSources[i].volume = spawnAudio.backgroundVolume;
            }
        }
        
        public void SetSoundFxVolume(float volume)
        {
            for (int i = 0; i < audioSources.Count; i++)
            {
                audioSources[i].volume = volume;
            }
            
            for (int i = 0; i < additionalSources.Count; i++)
            {
                additionalSources[i].volume = volume;
            }
        }

        public void RecoverSoundFxVolume()
        {
            for (int i = 0; i < audioSources.Count; i++)
            {
                audioSources[i].volume = spawnAudio.sfxVolume;
            }
            
            for (int i = 0; i < additionalSources.Count; i++)
            {
                additionalSources[i].volume = spawnAudio.sfxVolume;
            }
        }

        public void SetBackgroundVolume(float volume)
        {
            for (int i = 0; i < backgroundSources.Count; i++)
            {
                backgroundSources[i].volume = volume;
            }
        }

        public void RecoverBackgroundVolume()
        {
            for (int i = 0; i < backgroundSources.Count; i++)
            {
                backgroundSources[i].volume = spawnAudio.backgroundVolume;
            }
        }

        #endregion

        public void PlayClip(AudioClip clip)
        {
            AudioSource aToYeet = GetNextAvailableAudioSource();
            aToYeet.PlayOneShot(clip);
            if (additionalSources.Contains(aToYeet))
            {
                StartCoroutine(DestroyAfterUse(aToYeet, clip));
            }
        }

        private IEnumerator DestroyAfterUse(AudioSource a, AudioClip clip)
        {
            yield return new WaitForSeconds(clip.length + .01f);
            GameObject goToYeet = a.gameObject;
            additionalSources.Remove(a);
            Destroy(goToYeet);
        }
    }
}