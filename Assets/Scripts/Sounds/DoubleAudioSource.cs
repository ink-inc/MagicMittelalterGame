using System;
using System.Collections.Generic;
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
        private List<AudioSource> _audioSources = new List<AudioSource>();

        private int _index;
        
        public void Start()    
        {
            AudioSource firstSource = gameObject.AddComponent<AudioSource>();
            AudioSource secondSource = gameObject.AddComponent<AudioSource>();
            _audioSources = new List<AudioSource> {firstSource, secondSource};
        }

        /// <summary>
        /// Boolean if this class is playing some clip.
        /// </summary>
        public bool IsPlaying => Current().isPlaying;
        
        /// <summary>
        /// Boolean if source is playing in a loop.
        /// </summary>
        public bool IsLoop { get; set; }
        /// <summary>
        /// The clip current launched in the audio source.
        /// </summary>
        public AudioClip Clip => Current().clip;

        /// <summary>
        /// Cross fades to a new clip.
        /// </summary>
        /// <param name="clip">The new clip to be played.</param>
        /// <param name="delay"></param>
        /// <param name="targetVolume"></param>
        /// <param name="startTime">The time marker where to start the clip.</param>
        /// <param name="fadeDuration">The time it take to get to target volume.</param>
        public void CrossFadeToNewClip(AudioClip clip, int delay = 0, float targetVolume = 1f, float startTime=0f,
            float fadeDuration=5f)
        {
            AudioSource fadeFrom = Next();
            StartCoroutine(FadeAudioSource.StartFadeOut(fadeFrom, fadeDuration));
            AudioSource fadeTo = Next();
            fadeTo.loop = IsLoop;
            StartCoroutine(FadeAudioSource.StartFadeIn(fadeTo, fadeDuration, clip, targetVolume, startTime, delay));
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
            if (_audioSources.Count > 0)
            {
                Current().Stop();
            }
        }

        /// <summary>
        /// Like stop but smoother
        /// </summary>
        /// <param name="duration"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void FadeOut(float duration = 5f)
        {
            StartCoroutine(FadeAudioSource.StartFadeOut(Current(), duration));
            Next();
            
        }

        /// <summary>
        /// Fades in the new clip.
        /// </summary>
        public void FadeIn(AudioClip clip, float delay = 0f, float duration = 5f, float targetVolume = 1f, float startTime = 0f)
        {
            Current().loop = IsLoop;
            StartCoroutine(FadeAudioSource.StartFadeIn(Current(), duration, clip, targetVolume, startTime, delay));
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