using System;
using System.Collections.Generic;
using Sounds.Manager;
using UnityEngine;

namespace Sounds
{
    public class DoubleAudioSource : MonoBehaviour
    {
        private readonly List<AudioSource> _audioSources;

        private int _index;

        public DoubleAudioSource(AudioSource firstSource, AudioSource secondSource)
        {
            _audioSources = new List<AudioSource>(){firstSource, secondSource};
        }

        public void CrossFadeToNewClip(AudioClip clip)
        {
            AudioSource fadeFrom = Next();
            StartCoroutine(FadeAudioSource.StartFade(fadeFrom, 5f, 0f));
            AudioSource fadeTo = Next();
            fadeTo.clip = clip;
            StartCoroutine(FadeAudioSource.StartFade(fadeTo, 5f, 1f));
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