using System;
using System.Collections.Generic;
using Sounds.Manager;
using Sounds.Util;
using UnityEngine;

namespace Sounds
{
    /// <summary>
    /// Uses two audio sources to allow fading between clip.
    /// To the outside it looks like a Audio Source.
    /// </summary>
    public class DoubleAudioSource : MonoBehaviour
    {
        private const float FadeDuration = 5f;
        private List<AudioSource> _audioSources;

        private int _index;
        
        public void Start()    
        {
            AudioSource firstSource = gameObject.AddComponent<AudioSource>();
            AudioSource secondSource = gameObject.AddComponent<AudioSource>();
            _audioSources = new List<AudioSource>(){firstSource, secondSource};
        }

        /// <summary>
        /// Boolean if this class is playing some clip.
        /// </summary>
        public bool IsPlaying => Current().isPlaying;
        /// <summary>
        /// The clip current launched in the audio source.
        /// </summary>
        public AudioClip Clip => Current().clip;

        /// <summary>
        /// Cross fades to a new clip.
        /// </summary>
        /// <param name="clip">The new clip to be played.</param>
        /// <param name="startTime">The time marker where to start the clip.</param>
        public void CrossFadeToNewClip(AudioClip clip, float startTime=0f)
        {
            AudioSource fadeFrom = Next();
            StartCoroutine(FadeAudioSource.StartFadeOut(fadeFrom, FadeDuration));
            AudioSource fadeTo = Next();
            StartCoroutine(FadeAudioSource.StartFadeIn(fadeTo, FadeDuration, clip, startTime:startTime));
        }

        /// <summary>
        /// Pauses this audio source.
        /// </summary>
        public void Pause()
        {
            _audioSources.ForEach(source => source.Pause());
        }

        /// <summary>
        /// UnPauses this audio source.
        /// </summary>
        public void UnPause()
        {
            _audioSources.ForEach(source => source.UnPause());
        }

        /// <summary>
        /// Stops this audio source.
        /// </summary>
        public void Stop()
        {
            Current().Stop();
        }

  
        /// <returns>The audio source object which is the currently active one.</returns>
        private AudioSource Current()
        {
            return _audioSources[_index];
        }
        
        /// <returns>Returns the next audio source object.</returns>
        private AudioSource Next()
        {
            _index++;
            
            if (_index >= _audioSources.Count)
            {
                _index = 0;
            }
            

            return _audioSources[_index];
        }
    }
}