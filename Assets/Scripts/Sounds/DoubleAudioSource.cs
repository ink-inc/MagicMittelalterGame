using System;
using System.Collections.Generic;
using Sounds.Manager;
using UnityEngine;

namespace Sounds
{
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

        public bool IsPlaying => Current().isPlaying;
        public AudioClip Clip => Current().clip;

        public void CrossFadeToNewClip(AudioClip clip)
        {
            AudioSource fadeFrom = Next();
            StartCoroutine(FadeAudioSource.StartFade(fadeFrom, FadeDuration, 0f));
            AudioSource fadeTo = Next();
            fadeTo.clip = clip;
            fadeTo.volume = 0f;
            fadeTo.Play();
            StartCoroutine(FadeAudioSource.StartFade(fadeTo, FadeDuration, 1f));
        }

        public void Pause()
        {
            _audioSources.ForEach(source => source.Pause());
        }

        public void UnPause()
        {
            _audioSources.ForEach(source => source.UnPause());
        }

        public void Stop()
        {
            Current().Stop();
        }

        private AudioSource Current()
        {
            return _audioSources[_index];
        }
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