using System.Collections.Generic;
using UnityEngine;

namespace SpawnTools
{
    [HelpURL("https://spawncampgames.github.io")]
    [ExecuteInEditMode]
    public class SpawnAudio : MonoBehaviour
    {
        [Header("Game Audio")]
        [Tooltip("Number of AudioSources dedicated to playing sound effects.")]
        [Range(1,5)]
        public int channels;
        [Tooltip("All sound effect AudioSources will start at this volume.")]
        [Range(0,1)]
        public float sfxVolume;
        [Tooltip("All background AudioSources will start at this volume.")]
        [Range(0,1)]
        public float backgroundVolume;
        
        [Header("Ambient Audio")]
        
        public List<AudioClip> audioClips = new List<AudioClip>();
        
        [HideInInspector]
        public bool hasGeneratedSources;
        [HideInInspector]
        public GameObject bg;
        [HideInInspector]
        public GameObject sfx;
        [HideInInspector]
        public SpawnDJ dj;
        [HideInInspector]
        public List<AudioSource> audioSources = new List<AudioSource>();
        [HideInInspector]
        public List<AudioSource> backgroundAudioSources = new List<AudioSource>();

        //Defaults
        float bgVolDef = 0.1f;
        float sfxVolDef = 0.1f;
        int chanDef = 3;
        
        public void GenerateAudioSources()
        {
            if (hasGeneratedSources)
                return;
            
            bg = new GameObject("Background");
            sfx = new GameObject("Sound Effects");

            bg.transform.parent = transform;
            sfx.transform.parent = transform;

            for (int i = 0; i < channels; i++)
            {
                GameObject SFX = new GameObject($"Sound Effects{i+1}");
                SFX.transform.parent = sfx.transform;
                var a = SFX.AddComponent<AudioSource>() as AudioSource;
                a.playOnAwake = false;
                a.volume = sfxVolume;
                a.loop = false;
                audioSources.Add(a);
            }

            for (int i = 0; i < audioClips.Count; i++)
            {
                GameObject BG = new GameObject($"Background Audio{i+1}");
                BG.transform.parent = bg.transform;
                var a = BG.AddComponent<AudioSource>() as AudioSource;
                a.clip = audioClips[i];
                a.playOnAwake = true;
                a.volume = backgroundVolume;
                a.loop = true;
                backgroundAudioSources.Add(a);
            }
            
            SpawnDJ dj_ = GetComponent<SpawnDJ>();
            
            if (dj_ != null)
            {
                dj_.DestroyInstance();
                DestroyImmediate(dj_);
            }
            
            dj = gameObject.AddComponent<SpawnDJ>();
            dj.Initialize();
            dj.hideFlags = HideFlags.HideInInspector;
            
            Debug.Log($"{dj} has been created.\n" +
                      "use SpawnDJ.Instance. to call Audio Functions");
            hasGeneratedSources = true;
        }
        
        public void Reset()
        {
            audioSources.Clear();
            backgroundAudioSources.Clear();
            audioClips.Clear();
            
            for (int i = transform.childCount - 1; i >= 0; i--) {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }

            if (dj != null)
            {
                dj.DestroyInstance();
                DestroyImmediate(dj);
            }
            
            ResetDefaults();
            hasGeneratedSources = false;
        }

        private void ResetDefaults()
        {
            backgroundVolume = bgVolDef;
            sfxVolume = sfxVolDef;
            channels = chanDef;
        }
    }
}
