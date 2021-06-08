using System;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        #region Singleton

        private static AudioManager instance;
        private const string LOG = nameof(AudioManager);
        
        /// <summary>
        /// Singleton method
        /// </summary>
        public static AudioManager Instance
        {
            get
            {
                if (instance == null)
                {
                    // Find instance
                    instance = FindObjectOfType<AudioManager>();
                    
                    // If instance is not found, ...
                    if (instance == null)
                    {
                        // Give log error
                        Debug.LogError($"{LOG} not found");
                    }
                }

                return instance;
            }
        } 

        #endregion

        #region Don't Destroy On Load
        
        /// <summary>
        /// Use only 1 Audio Manager from HomeScene
        /// </summary>
        private void SetInstance()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        #endregion
        
        public Sound[] sounds;

        private void Awake()
        {
            SetInstance();
            
            foreach (Sound sound in sounds)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.playOnAwake = false;
                sound.source.clip = sound.clip;

                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;
                sound.source.loop = sound.loop;
            }
        }
        
        /// <summary>
        /// Play audio
        /// To call method in scripts
        /// </summary>
        /// <param name="listSound"></param>
        public void Play(ListSound listSound)
        {
            GetAudioSource(listSound).Play();
        }
        
        /// <summary>
        /// Get audio source for enum
        /// </summary>
        /// <param name="listSound">Type of sound that want to be played</param>
        /// <returns>Return listSound's audio source</returns>
        private AudioSource GetAudioSource(ListSound listSound)
        {
            Sound s = Array.Find(sounds, sound => sound.listSound == listSound);
            
            if (s == null)
            {
                Debug.LogError($"Sound: {listSound} not found!");
                return null;
            }
            
            return s.source;
        }
    }
}